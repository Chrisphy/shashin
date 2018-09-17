using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace shashin.ViewModels
{
    public class unsplashDetailsViewModel : INotifyPropertyChanged
    {
        public string RegularUrls { get; set; }
        public string UserName { get; set; }
        public string PhotoDescription { get; set; }

        public unsplashDetailsViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

