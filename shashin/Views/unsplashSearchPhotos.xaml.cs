using System;
using System.Collections.Generic;
using shashin.ViewModels;
using Unsplasharp.Models;
using Xamarin.Forms;

namespace shashin.Views
{
    public partial class unsplashSearchPhotos : ContentPage
    {
        public unsplashSearchPhotos()
        {
            InitializeComponent();
            mySearchList.BeginRefresh();
            mySearchList.EndRefresh();
        }
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                var PhotoDetailsView = new unsplashDetailsViewModel();
                Photo tmpPhoto = (Photo)e.SelectedItem;

                PhotoDetailsView.RegularUrls = tmpPhoto.Urls.Regular;
                PhotoDetailsView.UserName = tmpPhoto.User.Name;
                PhotoDetailsView.PhotoDescription = tmpPhoto.Description;

                var PhotoDetailsPage = new unsplashPhotoDetails();
                PhotoDetailsPage.BindingContext = PhotoDetailsView;
                Navigation.PushAsync(PhotoDetailsPage);

            }
        }
    }
}
