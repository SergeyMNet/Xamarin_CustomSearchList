using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchListXam.ViewModels;
using Xamarin.Forms;

namespace SearchListXam.Pages
{
    public partial class TestPage1 : ContentPage
    {
        public TestPage1()
        {
            InitializeComponent();
            this.BindingContext = new MainVM();
        }
    }
}
