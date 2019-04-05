using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using XamNative.Models;
using XamNative.MyDataSource;

namespace XamNative.ViewModels
{

	public class HumanViewModels
	{
		private ObservableCollection<Human> humans;
		public ObservableCollection<Human> Humans
		{
			get { return humans; }
			set
			{
				humans = value;
			}
		}

		public HumanViewModels()
		{

			Humans = new ObservableCollection<Human>();

			MyData1 _context = new MyData1();

			foreach (var human in _context.Humans)
			{
				Humans.Add(human);
			}
		}

	}


}