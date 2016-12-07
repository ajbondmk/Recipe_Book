using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.IO;

namespace Recipe_Book
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)                        //When the add recipe button is clicked:
        {
            NavigationService.Navigate(new Uri("/AddRecipePage.xaml", UriKind.Relative));               //Go to the add recipe page.
        }

        private void BrowseRecipesButton_Click(object sender, RoutedEventArgs e)                    //When the browse recipes button is clicked:
        {
            NavigationService.Navigate(new Uri("/BrowseRecipesPage.xaml", UriKind.Relative));           //Go to the browse recipes page.
        }
    }
}