using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace shashin.Views
{
    public partial class TipsPage : ContentPage
    {
        public TipsPage()
        {
            Label header = new Label
            {
                Text = "Tips & Tricks",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            WebView webView = new WebView
            {
                Source = new UrlWebViewSource
                {
                    Url = "https://www.canon.com.au/explore/blink",
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    webView
                }
            };
        }


    }
}
