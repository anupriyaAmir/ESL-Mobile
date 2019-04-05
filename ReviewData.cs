using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL
{
	public class ReviewData : INotifyPropertyChanged
	{
		private int reviewID;
		private string product;
		private decimal newprice;
		private decimal oldprice;
		private string barcode;


		public int ReviewID
		{
			get { return reviewID; }
			set
			{
				this.reviewID = value;
				RaisePropertyChanged("ReviewID");
			}
		}

		public string Product
		{
			get { return product; }
			set
			{
				this.product = value;
				RaisePropertyChanged("Product");
			}
		}


		public decimal Newprice
		{
			get { return newprice; }
			set
			{
				this.newprice = value;
				RaisePropertyChanged("Newprice");
			}
		}

			
		public decimal Oldprice
		{
			get { return oldprice; }
			set
			{
				this.oldprice = value;
				RaisePropertyChanged("Oldprice");
			}
		}


		public string Barcode
		{
			get { return barcode; }
			set
			{
				this.barcode = value;
				RaisePropertyChanged("Barcode");
			}
		}


		public ReviewData(int reviewID, string product, decimal newprice, decimal oldprice, string barcode)
		{
			this.ReviewID = reviewID;
			this.Product = product;
			this.Newprice = newprice;
			this.Oldprice = oldprice;
			this.Barcode = barcode;

		}

		

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{

			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));

		}


	}
}
 