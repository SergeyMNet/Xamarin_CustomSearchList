using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchListXam.Controls
{
    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            var titleLabel = new Label
            {
                FontSize = 16,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
            };
            titleLabel.SetBinding(Label.TextProperty, "Title");

            var ItemStack = new StackLayout();

            ItemStack.Children.Add(titleLabel);
            View = ItemStack;
        }
    }
}
