using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchListXam.Models;

namespace SearchListXam.ViewModels
{
    public class MainVM
    {
        public ObservableCollection<string> Items { get; set; }

        public ObservableCollection<Item> Items2 { get; set; }

        public MainVM()
        {
            Items = new ObservableCollection<string>();
            for (int i = 1; i < 100; i++)
            {
                Items.Add("item " + i);
            }

            Items2 = new ObservableCollection<Item>();
            for (int i = 1; i < 100; i++)
            {
                Items2.Add(new Item() { Title = ("item " + i) });
            }
        }
    }
}
