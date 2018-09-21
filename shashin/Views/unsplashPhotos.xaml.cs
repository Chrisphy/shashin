using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Unsplasharp.Models;
using shashin.ViewModels;

namespace shashin.Views
{
    public partial class unsplashPhotos : ContentPage
    {
        public unsplashPhotos()
        {
            InitializeComponent();
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

        void Handle_SearchButtonPressed(object sender, System.EventArgs e)
        {
            string tmpString = searchPhoto.Text.Trim();
            if (!string.IsNullOrEmpty(tmpString))
            {
                unsplashSearchViewModel.searchString = tmpString;
                //DisplayAlert("Searching", unsplashSearchViewModel.searchString, "OK");

                var SearchPhotoView = new unsplashSearchViewModel();
                //myPhotoList.ItemsSource = null;
                //this.BindingContext = PhotoViewModel;

                var SearchPhotoPage = new unsplashSearchPhotos();
                SearchPhotoPage.BindingContext = SearchPhotoView;
                Navigation.PushAsync(SearchPhotoPage);
            }
        }
    }
}
