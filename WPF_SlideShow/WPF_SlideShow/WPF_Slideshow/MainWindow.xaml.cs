using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using WinForms = System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;
using System.Windows.Forms;
using System.Reflection;

namespace WPF_Slideshow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object dummyNode = null;
        public string SelectedImagePath { get; set; }
        public List<ImageClass> images { get; set; }

        public List<EffectPlugin.IEffect> plugins = new List<EffectPlugin.IEffect>();
        public MainWindow()
        {
            images = new List<ImageClass>();
            InitializeComponent();
        }

        //link:
        //https://www.codeproject.com/Articles/21248/A-Simple-WPF-Explorer-Tree
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = s;
                item.Tag = s;
                item.FontWeight = FontWeights.Normal;
                item.Items.Add(dummyNode);
                item.Expanded += new RoutedEventHandler(folder_Expanded);
                foldersItem.Items.Add(item);
            }


            //Load effect dll's from the exe folder (bin in our case)
            var files = Directory.GetFiles(Environment.CurrentDirectory, "*.dll");

            foreach (var file in files)
            {
                Type[] types;
                try
                {
                    types = Assembly.LoadFrom(file).GetTypes();
                    foreach(var type in types)
                    {
                        if (type.GetInterface("IEffect") == typeof(EffectPlugin.IEffect))
                        {
                            var effect = (EffectPlugin.IEffect)Activator.CreateInstance(type);
                            plugins.Add(effect);

                            //add to menu
                            MenuItem item = new MenuItem();
                            item.Header = effect.Name;
                            item.Click += MenuSlideshow_Click;
                            item.Tag = (plugins.Count - 1).ToString();
                            MenuStartSlideshow.Items.Add(item);
                        }
                    }
                }
                catch
                {
                    continue;  // Can't load as .NET assembly, so ignore
                }
            }
            MenuStartSlideshow.UpdateLayout();
            options.DataContext = plugins;
        }
        void folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Items.Add(dummyNode);
                        subitem.Expanded += new RoutedEventHandler(folder_Expanded);
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }

        private void foldersItem_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
			System.Windows.Controls.TreeView tree = (System.Windows.Controls.TreeView)sender;
            TreeViewItem temp = ((TreeViewItem)tree.SelectedItem);

            if (temp == null)
                return;
            SelectedImagePath = "";
            string temp1 = "";
            string temp2 = "";
            while (true)
            {
                temp1 = temp.Header.ToString();
                if (temp1.Contains(@"\"))
                {
                    temp2 = "";
                }
                SelectedImagePath = temp1 + temp2 + SelectedImagePath;
                if (temp.Parent.GetType().Equals(typeof(System.Windows.Controls.TreeView)))
                {
                    break;
                }
                temp = ((TreeViewItem)temp.Parent);
                temp2 = @"\";
            }
            images = new List<ImageClass> { };
            try
            {
                foreach (string filename in Directory.GetFiles(SelectedImagePath))
                {
                    string ex = System.IO.Path.GetExtension(filename);
                    if (ex == ".png" || ex == ".bmp" || ex == ".jpg" || ex == ".jpeg")
                    {
                        string title = filename.Replace(SelectedImagePath, "");
                        images.Add(new ImageClass(title, GetImageFromResourceString(filename), filename));
                    }
                }
            } catch (Exception ex) { }
            DataContext = images;
            if (nofile.Visibility != Visibility.Visible)
            {
                nofile.Visibility = Visibility.Visible;
                imgdetails.Visibility = Visibility.Collapsed;
            }
        }

        //this one was from microsoft's website but I'm not really sure
        public BitmapImage GetImageFromResourceString(string imageName)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(imageName);
                image.EndInit();
                return image;
            }
            catch (Exception ex) { }
            return null;
        }

        public void About_Click(object sender, RoutedEventArgs e)
        {
			System.Windows.MessageBox.Show("This is a sample image slideshow application", "About");
        }
        public void StartSlideshow(object sender, RoutedEventArgs e)
        {
            if (images == null || images.Count == 0)
            {
                System.Windows.MessageBox.Show("The selected folder does not contain any image to start a slideshow!",
                "An error occured", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Yes);
                return;
            }
            var option = options.SelectedIndex;
            EffectPlugin.IEffect effect = null;
            try
            {
                effect = plugins.ElementAt(options.SelectedIndex);
            } catch (Exception ex) {}
            if (effect == null) return;

            var slideshowWindow = new Window1(effect);
            slideshowWindow.Show();
        }

        //link:
        //https://www.c-sharpcorner.com/UploadFile/mahesh/folderbrowserdialog-in-C-Sharp/
        private void FolderMenu_Click(object sender, RoutedEventArgs e)
		{
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            //dialog.ShowNewFolderButton = true;
            if (result == (DialogResult)1)
            {
                SelectedImagePath = dialog.SelectedPath;
                images = new List<ImageClass> { };
                foreach (string filename in Directory.GetFiles(SelectedImagePath))
                {
                    string ex = System.IO.Path.GetExtension(filename);
                    if (ex == ".png" || ex == ".bmp" || ex == ".jpg" || ex == ".jpeg")
                    {
                        string title = filename.Replace(SelectedImagePath, "");
                        //images.Add(String.Format("{0}\\{1}", SelectedImagePath, System.IO.Path.GetFileName(s)));
                        images.Add(new ImageClass(title, GetImageFromResourceString(filename), filename));
                    }
                }
                DataContext = images;
                if (nofile.Visibility != Visibility.Visible)
                {
                    nofile.Visibility = Visibility.Visible;
                    imgdetails.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

		private void ImageSelected(object sender, SelectionChangedEventArgs e)
		{
            ImageClass item = (ImageClass)(sender as System.Windows.Controls.ListView).SelectedItem;

            if (item == null) return;
            filenameval.Text = item.Title.Replace(".jpg", "").Replace(".png", "").Replace(".bmp", "").Replace(".jpeg", "").Substring(0, 9);
            widthval.Text = ((int)item.Image.Width).ToString() + " px";
            heightval.Text = ((int)item.Image.Height).ToString() + " px";
			sizeval.Text = (Math.Round((float)new System.IO.FileInfo(item.Path).Length / 1024, 2)).ToString() + " KB";

            if (nofile.Visibility == Visibility.Visible)
            {
                nofile.Visibility = Visibility.Collapsed;
                imgdetails.Visibility = Visibility.Visible;
                infoExpander.IsExpanded = true;
            }
		}
        public void MenuSlideshow_Click(object sender, RoutedEventArgs e)
        {
            if (images == null || images.Count == 0)
            {
                System.Windows.MessageBox.Show("The selected folder does not contain any image to start a slideshow!",
                "An error occured", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.Yes);
                return;
            }

            MenuItem item = e.OriginalSource as MenuItem;
            EffectPlugin.IEffect effect = null;
            try
            {
                effect = plugins.ElementAt(Int32.Parse(item.Tag.ToString()));
            }
            catch (Exception ex) { }
            if (effect == null) return;

            var slideshowWindow = new Window1(effect);
            slideshowWindow.Show();
        }
    }
}
