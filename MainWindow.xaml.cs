using ShopApp.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICollectionView _toysCV;
        public ICollectionView ToysCV {
            get { return _toysCV; }
            set { _toysCV = value; }
        }
        
        public MainWindow()
        {
            InitializeComponent();

            App.db.Toys.Load();

            _toysCV = CollectionViewSource.GetDefaultView(App.db.Toys.Local);

            // because dep. prop. doesn't work
            ToyList.ItemsSource = _toysCV;

            SearchBox.TextChanged += (s, e) => _toysCV.Refresh();

            _toysCV.Filter += (obj) =>
            {
                var toy = obj as Toy;

                var searchText = SearchBox.Text;

                if (toy.Name.Contains(searchText)
                    || toy.Description.Contains(searchText))
                    return true;
                return false;
            };

            SortBox.SelectionChanged += (s, e) =>
            {
                var tag = (SortBox.SelectedItem as ComboBoxItem).Tag;

                switch (tag)
                {
                    case "Any":
                        _toysCV.SortDescriptions.Clear();
                        break;
                    case "CostAscending":
                        _toysCV.SortDescriptions.Clear();
                        _toysCV.SortDescriptions.Add(new SortDescription()
                        {
                            PropertyName = "Cost",
                            Direction = ListSortDirection.Ascending
                        });
                        break;
                    case "CostDescending":
                        _toysCV.SortDescriptions.Clear();
                        _toysCV.SortDescriptions.Add(new SortDescription()
                        {
                            PropertyName = "Cost",
                            Direction = ListSortDirection.Descending
                        });
                        break;
                }
            };

            
        }

        private void Button_ChangeUserMode_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
