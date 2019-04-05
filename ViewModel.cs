using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL
{

	

	public class ViewModel
	{

		public ObservableCollection<ReviewData> ReviewsData { get; set; }
		

		public ViewModel()
		{
			this.ReviewsData = new ObservableCollection<ReviewData>();
			generateReview();
		}
			
		private void generateReview()
		{
			ReviewsData.Add(new ReviewData(1001, "Milk", 23, 24, "18236391"));
			ReviewsData.Add(new ReviewData(1002, "Curd", 33, 45, "98234864"));
			ReviewsData.Add(new ReviewData(1003, "Ice", 3, 4, "274824782"));
			ReviewsData.Add(new ReviewData(1004, "Chicken", 21, 14, "019363"));
		}
			


	}
}
