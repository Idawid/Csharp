Plugins interface format:

namespace EffectPlugin
{
	public interface IEffect {

	}
}



1.
Program checks the interfaces of the dll's in the current directory.
All plugins must implement interface "EffectPlugin.IEffect", otherwise won't be added.


2.
Effects in the project don't compile to dll's by default. Need to add the references to their projects and then compile.