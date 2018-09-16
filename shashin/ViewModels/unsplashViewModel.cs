using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using shashin.Data;
using Unsplasharp;
using Unsplasharp.Models;
using System.Collections.Generic;

namespace shashin.ViewModels
{
    public class unsplashViewModel : INotifyPropertyChanged
    {
        UnsplasharpClient client = new UnsplasharpClient("93123f0db401f8367e061a60e9b0976b9bc9c3cafe5133f344bba4010c97a4de",
                                                         "ec8401ec0727226a41f9fea4ef184c10f7efef4b009ee910dbf3ca386a");

        List<Photo> _listPhoto;

        public List<Photo> ListPhoto
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
            //ListPhoto = await client.SearchPhotos("mountains", page: 1, perPage: 20);
            //List<Photo> tmpList = await client.GetRandomPhoto(5);//page: pageNumber, perPage: 5, orderBy: OrderBy.Popular);
            //ListPhoto = new ObservableCollection<Photo>(tmpList);
            ListPhoto = await client.ListPhotos(page: 1, perPage: 5);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
