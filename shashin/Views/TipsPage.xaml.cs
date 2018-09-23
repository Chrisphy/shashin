using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace shashin.Views
{
    public partial class TipsPage : ContentPage
    {
        public TipsPage()
        {

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
                    webView
                }
            };
        }


    }
}
