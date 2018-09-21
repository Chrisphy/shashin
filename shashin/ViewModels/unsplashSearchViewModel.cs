using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using shashin.Data;
using Unsplasharp.Models;

namespace shashin.ViewModels
{
    public class unsplashSearchViewModel: INotifyPropertyChanged
    {
        public static string searchString = null;

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


        public async Task SearchDataAsync()
        {
            List<Photo> tmpList = null;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                tmpList = await PhotoManager.client.SearchPhotos(searchString, page: 1, perPage: 5);
            }
            ListPhoto = new ObservableCollection<Photo>(tmpList);
        }


        public event PropertyChangedEventHandler PropertyChanged;
    

        public unsplashSearchViewModel()
        {
            SearchDataAsync();
        }
    }
}
