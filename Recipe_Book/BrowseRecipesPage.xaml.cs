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
using Microsoft.Phone.Shell;

namespace Recipe_Book
{
    public partial class BrowseRecipesPage : PhoneApplicationPage
    {
        public BrowseRecipesPage()                                                                  //When the page is opened:
        {
            InitializeComponent();
            ListOfRecipesBox.ItemsSource = RecipeList.RecipeNameList();                                 //Display a list of all the recipe names.
        }

        private void ListOfRecipesBox_Tap(object sender, SelectionChangedEventArgs e)               //When a recipe is clicked:
        {
            int RecipeIndex = ListOfRecipesBox.SelectedIndex;                                           //Find the index of the recipe selected.
            PhoneApplicationService.Current.State["RecipeIndex"] = RecipeIndex;                         //Save the recipe index for access from the view recipe page.
            NavigationService.Navigate(new Uri("/ViewRecipePage.xaml", UriKind.Relative));              //Go to the view recipe page.
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)                             //When the back button is clicked:
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));                    //Go to the main page.
        }
    }
}