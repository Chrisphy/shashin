using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shashin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PasscodePage : ContentPage
	{
		public PasscodePage ()
		{
			InitializeComponent ();
            
		}
        private void EntryPasscode_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }
        private void EntryPasscode_Completed(object sender, EventArgs e)
        {
            if (EntryPasscode.Text == "1234")
            {
                App.Current.MainPage = new MainPage();
            }
            else
            {
                EntryPasscode.Text = "Incorrect Passcode";
            }
        }
        private void EntryPasscode_Focused(object sender, FocusEventArgs e)
        {
            EntryPasscode.Text = "";
        }
    }
}