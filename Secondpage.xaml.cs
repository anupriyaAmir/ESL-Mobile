using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamNative
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Secondpage : ContentPage
    {
        public Secondpage()
        {
            InitializeComponent();
        }

		private async void Review_me(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new HumanPage()); //review page
		}
		private async void ESL(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new eslupload()); //upload to esl
		}
	}
}
