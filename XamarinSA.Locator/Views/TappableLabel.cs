using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace XamarinSA.Locator.Views
{
	public class TappableLabel : Label
	{
		public static readonly BindableProperty CommandProperty =
			BindableProperty.Create<TappableLabel, ICommand>(
				lbl => lbl.Command,
				null,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					((TappableLabel)bindable).Command = newValue;
				}
			);

		public static readonly BindableProperty CommandParameterProperty =
			BindableProperty.Create<TappableLabel, object>(
				lbl => lbl.CommandParameter,
				null,
				defaultBindingMode: BindingMode.TwoWay,
				propertyChanging: (bindable, oldValue, newValue) => {
					((TappableLabel)bindable).CommandParameter = newValue;
				}
			);


		private TapGestureRecognizer labelTapped;

		public object CommandParameter {
			get{ return GetValue (CommandParameterProperty); }
			set { 
				SetValue (CommandParameterProperty, value);
				labelTapped.CommandParameter = value;
			}
		}

		public ICommand Command {
			get{ return (ICommand)GetValue (CommandProperty); }
			set { 
				SetValue (CommandProperty, value);
				labelTapped.Command = value;
			}
		}

		public TappableLabel ()
		{
			//create default label tap handler
			labelTapped = new TapGestureRecognizer ();
		}
	}
}

