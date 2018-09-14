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
<<<<<<< HEAD
        UnsplasharpClient client = new UnsplasharpClient("93123f0db401f8367e061a60e9b0976b9bc9c3cafe5133f344bba4010c97a4de",
                                                         "ec8401ec0727226a41f9fea4ef184c10f7efef4b009ee910dbf3ca386a");
        Photo _randomPhoto;
        public Photo randomPhoto
=======

        UnsplasharpClient client = new UnsplasharpClient("b18240d07f00d99b6cb5e5c0041758c4008ba295c9bd6bed2c3a670abc28fcab",
                                                                "228d690471d58d510538caccbd863c74dcd9495b03985b6ff36ac8b3cd2ec525");
        List<Photo> _listPhoto;

        public List<Photo> ListPhoto
>>>>>>> fb13a28aa772c5c31d9021f102f8e1a94efa98e1
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
