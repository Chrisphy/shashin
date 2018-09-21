using System;
using System.Collections.Generic;
using System.IO;
//using Android.Graphics;
using Xamarin.Forms;
using Plugin.Media;
using shashin.Models;
using shashin.Views;
using shashin.ViewModels;
using shashin.Services;
using Plugin.Permissions.Abstractions;
using Plugin.Permissions;

namespace shashin.Views
{
    public partial class unsplashPhotoDetails : ContentPage
    {
        public unsplashPhotoDetails()
        {
            InitializeComponent();
        }

        async void saveImage(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);


            if (storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                storageStatus = results[Permission.Storage];
            }


            else if (storageStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                SaveToAlbum = true
                });

                //Get the public album path
                string aPpath = file.AlbumPath;



                //Get private path
                var path = file.Path;

                await DisplayAlert("File Location", file.Path, "OK");

            
            }

            else
            {
                await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });


                await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();
            }



        }




    }
}
