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
using System.IO;
using System.IO.IsolatedStorage;

namespace Recipe_Book
{
    public partial class AddRecipePage : PhoneApplicationPage
    {
        public AddRecipePage()
        {
            InitializeComponent();
        }

        Recipe ThisRecipe = new Recipe();                                                                                   //Make a new Recipe called ThisRecipe in which to store the recipe being added.

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)                                            //When the add ingredient button is clicked:
        {
            if (!AddIngredient()) ErrorBlock.Text = "Please fill in the ingredient and amount fields and try again.";           //Call AddIngredient to add the ingredient. If it returns False, display error message.
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)                                               //When the save recipe button is clicked:
        {
            if (RecipeNameBox.Text != "" && NumberServingBox.Text != "")                                                        //If the recipe name box and the number of people to serve box contain something:
            {
                AddIngredient();                                                                                                    //Call AddIngredient to add an ingredient that has been entered but not added (if nothing has been entered, this will do nothing).
                ThisRecipe.Name = RecipeNameBox.Text;                                                                               //Save the recipe name into ThisRecipe.
                ThisRecipe.Servings = Convert.ToDouble(NumberServingBox.Text);                                                      //Save the serving number into ThisRecipe.
                RecipeList.Recipes.Add(ThisRecipe);                                                                                 //Save the list of ingredients into ThisRecipe.
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));                                            //Go to the main page.
            }
            else ErrorBlock.Text = "Please fill in 'recipe name' and 'number of people to serve' and try again.";               //Else display error message.
        }

        private bool AddIngredient()                                                                                        //To add an ingredient:
        {
            if (IngredientBox.Text != "" && AmountBox.Text != "")                                                               //If there is something in the ingredient box and the amount box:
            {
                IngredientsListBlock.Text += ThisRecipe.AddItem(IngredientBox.Text, AmountBox.Text, UnitBox.Text);                  //Adds the ingredient to RecipeDetails and to the list of ingredients displayed on the page.
                AmountBox.Text = "";                                                                                                //Clear the amount box.
                UnitBox.Text = "";                                                                                                  //Clear the unit box.
                IngredientBox.Text = "";                                                                                            //Clear the ingredient box.
                ErrorBlock.Text = "";                                                                                               //Clear the error message box.
                return true;                                                                                                        //Return True (an ingredient has been added).
            }
            else return false;                                                                                                  //Else return False (an ingredient has not been added).
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)                                                     //When the back button is clicked:
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));                                            //Go to the main page.
        }
    }
}