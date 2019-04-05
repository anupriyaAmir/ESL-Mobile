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
	public partial class HumanPage : ContentPage
	{
        ObservableCollection<Human> allItems = new ObservableCollection<Human>();
        List<int> selected = new List<int>();
        dynamic output = new List<dynamic>();
       // dynamic foo = new ExpandoObject();
        

        public HumanPage()
		{
           
            try
            {
                InitializeComponent();
                ProductsListView.ItemsSource = allItems;
                Getproducts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var switch1 = (Switch)sender;
            var human = (Human)switch1.BindingContext;
            var id = human.retail_modified_item_id;
            var name = human.name;
            var old_price = human.old_price;
            var new_price = human.new_price;
            Debug.WriteLine(id);

            if (switch1.IsToggled)
            {
                if (!selected.Contains(id))
                {
                    selected.Add(id);
                    dynamic foo = new ExpandoObject();
                    foo.id = id;
                    foo.name = name;
                    foo.old_price=old_price;
                    foo.new_price=new_price;
                    output.Add(foo);
                   
                }
            }
            else
            {
                if (selected.Contains(id)) selected.Remove(id);
            }

        }
        private async void Getproducts()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri=new Uri("https://esowfmrdev.jdadelivers.com/ReviewItemPrices?bu_id=1000829");
                var response = await client.GetStringAsync(uri);
                var product = JsonConvert.DeserializeObject<List<Human>>(response);
                ProductsListView.ItemsSource = product;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         private void accept(object sender, EventArgs args)
		{
            Debug.WriteLine("selected value");
            foreach (var item in selected)
            {
                Debug.WriteLine(item);
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(output);
            Debug.WriteLine("json");
            Debug.WriteLine(json);
            approve(); 
            DisplayAlert("Success", "Request Accepted and Updated", "OK");
		}

        private async void approve()//List<TodoItem> item, bool isNewItem = false)
        {
            try
            {

                HttpClient client = new HttpClient();
                var url = new Uri("https://esowfmrdev.jdadelivers.com/UpdateRetailApproveAll?bu_id=1000829");
                var post = new Human { bu_id = "1000826" ,
                    name= "Onion Rings, Medium",
                    new_price=9.45,
                    old_price =1.29,retail_modified_item_id= 1000630,
                   };
                var content = JsonConvert.SerializeObject(post);
                await client.PostAsync(url, new StringContent(content));
                Debug.WriteLine("Successfully Approved");            
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error in approve");
                throw ex;
            }
        }

        private void reject(object sender, EventArgs args)
		{
            rejectAll();
            DisplayAlert("Rejected","Request Rejected!!", "OK");
		}

        private async void rejectAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                var url = new Uri("https://esowfmrdev.jdadelivers.com/ReviewItemPrices?bu_id=1000829");
                var post = new Human { bu_id = "1000825", name = "Onion Rings, Medium",
                    new_price = 9.45,
                    old_price = 1.29,
                    retail_modified_item_id = 1000630,
                };
                var content = JsonConvert.SerializeObject(post);
                await client.PostAsync(url, new StringContent(content));
                Debug.WriteLine("Successfully Rejected");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error in Reject");
                throw ex;
            }
        }
    }
}