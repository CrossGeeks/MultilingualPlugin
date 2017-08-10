using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.Multilingual;
using Xamarin.Forms;

namespace MultilingualSample.Views
{
    public partial class ChangeLanguagePage : ContentPage
    {
        public ChangeLanguagePage()
        {
            InitializeComponent();


            picker.Items.Add("English");
            picker.Items.Add("Spanish");
            picker.Items.Add("Portuguese");
            picker.Items.Add("French");

            picker.SelectedItem = CrossMultilingual.Current.CurrentCultureInfo.DisplayName;
        }

         void OnUpdateLangugeClicked(object sender, System.EventArgs e)
        {
            CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.DisplayName.Contains(picker.SelectedItem.ToString()));
			AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;

            App.Current.MainPage =new NavigationPage(new HomePage());

        }
    }
}
