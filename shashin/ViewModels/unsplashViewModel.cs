using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using shashin.Data;
using Unsplasharp;
using Unsplasharp.Models;

namespace shashin.ViewModels
{
    public class unsplashViewModel : INotifyPropertyChanged
    {

        UnsplasharpClient client = new UnsplasharpClient("93123f0db401f8367e061a60e9b0976b9bc9c3cafe5133f344bba4010c97a4de",
                                                         "ec8401ec0727226a41f9fea4ef184c10f7efef4b009ee910dbf3ca386a");
        Photo _randomPhoto;
        public Photo randomPhoto
        {
            get { return _randomPhoto; }
            set
            {
                _randomPhoto = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("randomPhoto"));
                }
            }
        }
        public unsplashViewModel()
        {
            FetchDataAsync();
        }

        public async Task FetchDataAsync()
        {
            randomPhoto = await client.GetRandomPhoto();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
