using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using XamNative.Models;
using System.Diagnostics;
using System.Dynamic;

namespace XamNative
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class eslupload : ContentPage
	{
		public eslupload ()
		{
			InitializeComponent ();
            Getproducts1();
        }

        private async void Getproducts1()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = new Uri("https://esowfmrdev.jdadelivers.com/ESLReviewShelfLabel?bu_id=1000829");
                var response = await client.GetStringAsync(uri);
                var product = JsonConvert.DeserializeObject<List<UploadHuman>>(response);
                ProductsListView1.ItemsSource = product;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void upload(object sender, EventArgs args)
		{
            HttpClient client = new HttpClient();
            var uri = new Uri("https://esowfmrdev.jdadelivers.com/ESLReviewShelfLabel?bu_id=1000829");
            var response = await client.GetStringAsync(uri);
            var product = JsonConvert.DeserializeObject<List<UploadHuman>>(response);
            foreach (var i in product)
            {
                Debug.WriteLine(i.item_name);
                var prodid = i.retail_modified_item_id.Substring(0,7);
                


                var url = new Uri(" https://esowfmrdev.jdadelivers.com/ESLUpdateShelfLabel?bu_id=1000829&product_id="+prodid+"&flag=N");
                Debug.WriteLine(url);
                var post = new UploadHuman
                {
                    bu_id = "1000829",
                    item_name = "Onion Rings, Medium",
                    price = 9.45,
                    barcode_id= 486587978904,
                    updated="N" ,
                    retail_modified_item_id = "1000630",
                };
                var content = JsonConvert.SerializeObject(post);
                await client.PostAsync(url, new StringContent(content));

            }

            DisplayAlert("Success", "Data Successfully Uploaded to ESL", "OK");
		}
	}
}