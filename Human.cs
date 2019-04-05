using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamNative.Models
{
   
    public class Human
	{
        public string bu_id { get; set; }
        public string name { get; set; }
        public int retail_modified_item_id { get; set; }
        public double old_price { get; set; }
        public double new_price { get; set; }
    }
}