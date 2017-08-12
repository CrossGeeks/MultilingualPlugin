using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Multilingual;
using Xamarin.Forms;

namespace MultilingualSample.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ChangeLanguagePage());
        }
    }
}
