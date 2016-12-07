using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Recipe_Book
{
    public class RecipeList                                                         //Class called RecipeList (contains a list of all recipes).
    {
        public static List<Recipe> Recipes;                                             //List of recipes called RecipeList.

        public static List<string> RecipeNameList()                                     //Creates and returns a list of all recipe names in Recipes:
        {
            List<string> RecipeNames = new List<string>();                                  //New list of recipe names.
            foreach (Recipe Recipe in Recipes) RecipeNames.Add(Recipe.Name);                //Add each recipe name to the list.
            return RecipeNames;                                                             //Return the list of recipe names.
        }
    }

    public class Recipe                                                             //Class called Recipe (one recipe).
    {
        public string Name;                                                             //Create recipe name.
        public double Servings;                                                         //Create servings number.
        public List<RecipeDetail> RecipeDetails;                                        //Variable to contain a list of recipe details (ingredients).

        public Recipe() { RecipeDetails = new List<RecipeDetail>(); }                   //When a recipe is created, create an empty list of recipe details.

        public string AddItem(string Ingredient, string Amount, string Unit)            //To add an ingredient to a recipe:
        {
            RecipeDetail ThisItem = new RecipeDetail();                                     //New RecipeDetail called ThisItem.
            ThisItem.Ingredient = Ingredient;                                               //Save ingredient to ThisItem.
            ThisItem.Amount = Convert.ToDouble(Amount);                                     //Save amount to ThisItem.
            ThisItem.Unit = Unit;                                                           //Save unit to ThisItem.
            RecipeDetails.Add(ThisItem);                                                    //Save ThisItem to RecipeDetail.
            return Amount + Unit + " " + Ingredient + Environment.NewLine;                  //Return a string representation of the ingredient added.
        }

        public string GetIngredientsList(double Multiplier)                             //To get the list of ingredients to display based on a multiplier to give amounts for the new number of people to serve:
        {
            string Ingredients = "";                                                        //Clear the list of ingredients.
            foreach (RecipeDetail RD in RecipeDetails)                                      //For each RecipeDetail (ingredient) in the recipe's RecipeDetails list:
            {
                Ingredients += string.Format((RD.Amount * Multiplier).ToString("0.##") +        //Append the list of ingredients with the new amount (calculated using the multiplier) to a maximum of 2 decimal places,
                                   RD.Unit + " " + RD.Ingredient + Environment.NewLine);        //followed by the unit, a space, the ingredient and then a new line.
            }
            return Ingredients;                                                             //Return the list of formatted ingredients for display.
        }
    }

    public class RecipeDetail                                                       //Class called RecipeDetail to contain the details of one ingredient.
    {
        public string Ingredient;                                                       //Create an ingredient.
        public double Amount;                                                           //Create an amount.
        public string Unit;                                                             //Create a unit.
    }
}