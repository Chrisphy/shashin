using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using shashin.Data;
using Unsplasharp;
using Unsplasharp.Models;
using System.Collections.Generic;
using static Unsplasharp.UnsplasharpClient;

namespace shashin.ViewModels
{
    public class unsplashViewModel : INotifyPropertyChanged
    {

        ObservableCollection<Photo> _listPhoto;

        public ObservableCollection<Photo> ListPhoto
        {
            get { return _listPhoto; }
            set
            {
                _listPhoto = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ListPhoto"));
                }
            }
        }
        public unsplashViewModel()
        {
            FetchDataAsync();
        }

        public async Task FetchDataAsync()
        {
            int randomNumber;
            randomNumber = new Random().Next(1,3);
            _listPhoto = null;
            List<Photo> tmpList = null;
            switch(randomNumber){
                case 1:
                    tmpList = await PhotoManager.client.ListPhotos(page: 1, perPage: 5, orderBy: OrderBy.Popular);
                    break;
                case 2:
                    tmpList = await PhotoManager.client.ListPhotos(page: 1, perPage: 5, orderBy: OrderBy.Latest);
                    break;
                case 3:
                    tmpList = await PhotoManager.client.ListPhotos(page: 1, perPage: 5, orderBy: OrderBy.Oldest);
                    break;

            }
            ListPhoto = new ObservableCollection<Photo>(tmpList);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
