using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamNative
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
			image.Source = "icon.png";
		}
		private async void Click_Me(object sender, EventArgs args)
		{
			
			await Navigation.PushAsync(new Secondpage());
		}
	}
}
