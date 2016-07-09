using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchListXam.Controls
{
    public class SearchListExtented : StackLayout
    {
        public int _height = 50;
        public int _width = 200;

        public StackLayout MainView;
        public Entry mainEntry;
        public ListView ListViewSearch;

        public IList newListSource;
        public IList ListSource;

        public SearchListExtented()
        {
            MainView = new StackLayout()
            {
                BackgroundColor = Color.White,
                WidthRequest = _width,
                Spacing = 0,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            mainEntry = new Entry()
            {
                FontSize = 25,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                WidthRequest = _width,
            };

            ListViewSearch = new ListView()
            {
                BackgroundColor = Color.White,
                RowHeight = _height,
                HeightRequest = (_height * 4),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                ListViewSearch.BackgroundColor = Color.Blue;
            }
        }

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IList), typeof(SearchListExtented), null,
                BindingMode.TwoWay, null, ItemsSourcePropertyChanged);

        private static void ItemsSourcePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var sourceStack = bindable as SearchListExtented;
            //sourceStack?.SetItemsSource(newvalue as IList);
            if (sourceStack != null)
            {
                sourceStack.SetItemsSource(newvalue as IList);

                if (newvalue is INotifyCollectionChanged)
                {
                    var coll = newvalue as INotifyCollectionChanged;

                    coll.CollectionChanged += sourceStack.Coll_CollectionChanged;
                }
            }
        }

        private void Coll_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        IList itemsToAdd = e.NewItems;
                        this.Children.Add(GetItemView(itemsToAdd));
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    {

                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        IList itemsToRemove = e.OldItems;

                        foreach (var item in itemsToRemove)
                        {
                            var removedChild = this.Children.FirstOrDefault(x => x.BindingContext == item);
                            if (removedChild != null)
                            {
                                this.Children.Remove(removedChild);
                            }
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    {

                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    {

                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetItemsSource(IList newvalue)
        {
            this.Children.Clear();
            if (ItemsSource == null)
                return;

            this.Children.Add(GetItemView(newvalue));
        }

        public virtual View GetItemView(IList items)
        {
            ListSource = items;
            ListViewSearch.ItemSelected += ListViewSearch_ItemSelected;

            mainEntry.TextChanged += (sender, args) =>
            {
                SearchText(args.NewTextValue);
            };

            ListViewSearch.ItemsSource = ListSource;

            MainView.Children.Add(mainEntry);
            MainView.Children.Add(ListViewSearch);

            return MainView;
        }

        public virtual void ListViewSearch_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string sel = e.SelectedItem as String;
            mainEntry.Text = sel;
        }

        public virtual bool IsFindText(string newTextValue)
        {
            bool IsFind = false;
            foreach (var str in ListSource)
            {
                var s = str as String;
                if (s != null && s.Contains(newTextValue))
                {
                    IsFind = true;
                    newListSource.Add(s);
                }
            }
            return IsFind;
        }
        private void SearchText(string newTextValue)
        {
            newListSource = new List<object>();
            bool IsFind = IsFindText(newTextValue);

            if (IsFind && !String.IsNullOrWhiteSpace(newTextValue))
            {
                ListViewSearch.ItemsSource = newListSource;
            }
            else if (!String.IsNullOrWhiteSpace(newTextValue))
            {
                newListSource.Clear();
                ListViewSearch.ItemsSource = newListSource;
            }
            else
            {
                ListViewSearch.ItemsSource = ListSource;
            }
        }
    }
}
