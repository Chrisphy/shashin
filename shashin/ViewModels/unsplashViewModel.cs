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
        PhotoManager photoManager = new PhotoManager();

        Photo _randomPhoto;

        public Photo RandomPhoto
        {
            get { return _randomPhoto; }
            set
            {
                _randomPhoto = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("RandomPhoto"));
                }
            }
        }

        public unsplashViewModel()
        {
            FetchDataAsync();
        }

        public async Task FetchDataAsync()
        {
            Photo photo = await photoManager.RandomPhoto();
            RandomPhoto = photo;
            //Log.Debug.WriteLine(RandomPhoto.Urls.Small);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
