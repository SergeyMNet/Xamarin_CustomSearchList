using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchListXam.Models;
using Xamarin.Forms;

namespace SearchListXam.Controls
{
    public class SearchListExtentedChild : SearchListExtented
    {
        public SearchListExtentedChild()
        {

        }

        public override View GetItemView(IList items)
        {
            ListViewSearch.ItemTemplate = new DataTemplate(typeof(CustomCell));
            return base.GetItemView(items);
        }

        public override void ListViewSearch_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var sel = e.SelectedItem as Item;
            mainEntry.Text = sel.Title;
        }

        public override bool IsFindText(string newTextValue)
        {
            bool IsFind = false;
            foreach (var str in ListSource)
            {
                var s = str as Item;
                if (s != null && s.Title.Contains(newTextValue))
                {
                    IsFind = true;
                    newListSource.Add(s);
                }
            }
            return IsFind;
        }
    }
}
