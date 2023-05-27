using System;
using System.Text;

namespace Lab1
{
    public static class ParcelsManipulator
    {
        public static IParcel ChangeParcelWeight(IParcel parcel, float weight)
        {
            IParcel result = new WeightTranslator(parcel, weight);
            return result;
        }

        public static IParcel ChangeParcelCubature(IParcel parcel, float cubature)
        {
            IParcel result = new CubatureTranslator(parcel, cubature);
            return result;
        }
    
        public static IParcel MakeParcelFragile(IParcel parcel, FragilityType fr)
        {
            IParcel result = new FragileTranslator(parcel, fr);
            return result;
        }

        public static IParcel MakeParcelExpress(IParcel parcel, int daysDecrease)
        {
            IParcel result = new ExpressTranslator(parcel, daysDecrease);
            return result;
        }
    
        public static IParcel SetParcelAsForgotten(IParcel parcel)
        {
            IParcel result = new ForgottenTranslator(parcel);
            return result;
        }

        public static IParcel MakeDescriptionUnreadable(IParcel parcel)
        {
            IParcel result = new UnreadableTranslator(parcel);
            return result;
        }

        public static IParcel TranslateDescription(IParcel parcel)
        {
            IParcel result = new TranslateTranslator(parcel);
            return result;
        }

    }

    public class ParcelDecorator : IParcel
    {
        private IParcel _iparcel;

        public ParcelDecorator(IParcel parcel)
        {
            _iparcel = parcel;
        }
        virtual public string Name => _iparcel.Name;

        virtual public DateTime DeliveryDate => _iparcel.DeliveryDate;

        virtual public float Weight => _iparcel.Weight;

        virtual public string GetDescription()
        {
            return _iparcel.GetDescription();
        }

        virtual public float GetCubature()
        {
            return _iparcel.GetCubature();
        }
    }

    public class WeightTranslator : ParcelDecorator
    {
        private float _weight;
        public WeightTranslator(IParcel parcel, float weight) : base(parcel)
        {
            _weight = weight;
        }

        public override float Weight => _weight;
    }

    public class CubatureTranslator : ParcelDecorator
    {
        private float _cubature;
        private float _OldCubature;
        public CubatureTranslator(IParcel parcel, float cubature) : base(parcel)
        {
            _cubature = cubature;
            _OldCubature = parcel.GetCubature();
        }

        public override DateTime DeliveryDate => base.DeliveryDate.AddDays(2 * (_OldCubature - GetCubature()));

        public override float GetCubature()
        {
            return _cubature;
        }
    }

    public class FragileTranslator : ParcelDecorator
    {
        private FragilityType _fr;
        public FragileTranslator(IParcel parcel, FragilityType fr) : base(parcel)
        {
            _fr = fr;
        }

        public override float Weight => base.Weight * 2;

        public override string GetDescription()
        {
            return base.GetDescription() + $" Fragility: {_fr}\n";
        }
    }

    public class ExpressTranslator : ParcelDecorator
    {
        int _days;
        public ExpressTranslator(IParcel parcel, int daysDecrease) : base(parcel)
        {
            _days = daysDecrease;
        }

        public override DateTime DeliveryDate => base.DeliveryDate.AddDays(-_days);

        public override float GetCubature()
        {
            return base.GetCubature() / 2;
        }
    }
    public class ForgottenTranslator : ParcelDecorator
    {
        private float _weight = (float)((new Random(0).NextDouble() * 3) + 0.5);
        private DateTime _date = DateTime.MaxValue;
        public ForgottenTranslator(IParcel parcel) : base(parcel)
        {

        }

        public override DateTime DeliveryDate => _date;

        public override float Weight => _weight;
    }

    public class UnreadableTranslator : ParcelDecorator
    {
        private string _OldDescription;
        public UnreadableTranslator(IParcel parcel) : base(parcel)
        {
            _OldDescription = parcel.GetDescription();
        }

        public override string Name => base.Name;

        public override string GetDescription()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _OldDescription.Length; i ++)
            {
                if (i % 2 == 1) result.Append('_');
                else result.Append(_OldDescription[i]);
            }
            return result.ToString();
        }
    }

    public class TranslateTranslator : ParcelDecorator
    {
        public TranslateTranslator(IParcel parcel) : base(parcel)
        {

        }

        public override string GetDescription()
        {
            return "Following description is in french:\n" + base.GetDescription();
        }
    }
}