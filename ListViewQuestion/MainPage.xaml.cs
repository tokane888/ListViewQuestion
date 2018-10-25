using ListViewQuestion.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ListViewQuestion
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            GenerateSampleData();
        }

        private void GenerateSampleData()
        {
            for (int i = 0; i < 1000; i++)
            {
                People.Add(new Person
                {
                    Countries = new List<string> { "China", "India", "USA" },
                });
            }
            People[999].Country = "India";
        }

        private void CountryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StringBuilder sb = new StringBuilder("Added:");
            foreach (var added in e.AddedItems)
            {
                if (added is string country)
                {
                    sb.Append($" {country,-5}");
                }
            }

            sb.Append(", Removed:");
            foreach (var removed in e.RemovedItems)
            {
                if (removed is string country)
                {
                    sb.Append($" {country,-5}");
                }
            }
            Debug.WriteLine(sb);
        }
    }

    public class Person : BindableBase
    {
        public List<string> Countries { get; set; }

        private string _country;
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }
    }
}