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
using Microsoft.Phone.Shell;

namespace Recipe_Book
{
    public partial class ViewRecipePage : PhoneApplicationPage
    {
        Recipe ThisRecipe;                                                                                              //Create a variable called ThisRecipe to hold a recipe.
        int RecipeIndex;                                                                                                //Create a variable called RecipeIndex to hold the recipe index of the recipe to be viewed.

        public ViewRecipePage()                                                                                         //When the page is opened:
        {
            InitializeComponent();
            RecipeIndex = (int)PhoneApplicationService.Current.State["RecipeIndex"];                                        //Retrieve the recipe index of the recipe to be viewed and store in RecipeIndex.
            ThisRecipe = RecipeList.Recipes.ElementAt(RecipeIndex);                                                         //Set ThisRecipe to reference the recipe stored at the recipe index.
            PageTitle.Text = ThisRecipe.Name;                                                                               //Set the page title to be the recipe name.
            ServingNumberBox.Text = ThisRecipe.Servings.ToString();                                                         //Put the servings number into the servings number box.
            IngredientsListBlock.Text = ThisRecipe.GetIngredientsList(Multiplier: 1);                                       //Display the list of the recipe's ingredients (original quantities).
        }

        private void GoButton_Click(object sender, RoutedEventArgs e)                                                   //When the button is clicked to change the number of people served:
        {
            double Multiplier = Convert.ToDouble(ServingNumberBox.Text) / Convert.ToDouble(ThisRecipe.Servings);            //Multiplier (used to find new ingredient amounts) = new number to serve / original number to serve
            IngredientsListBlock.Text = ThisRecipe.GetIngredientsList(Multiplier);                                          //Call GetIngredientsList and display the new ingredients list it returns based on the multiplier provided.
        }

        private void DeleteRecipeButton_Click(object sender, RoutedEventArgs e)                                         //When the delete recipe button is clicked:
        {
            RecipeList.Recipes.RemoveAt(RecipeIndex);                                                                       //Delete the recipe at the recipe index.
            NavigationService.Navigate(new Uri("/BrowseRecipesPage.xaml", UriKind.Relative));                               //Go to the browse recipes page.
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)                                                 //When the back button is clicked:
        {
            NavigationService.Navigate(new Uri("/BrowseRecipesPage.xaml", UriKind.Relative));                               //Go to the main page.
        }
    }
} 