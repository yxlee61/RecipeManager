using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipeManager.Models
{
  public class RecipeInitializer : System.Data.Entity.DropCreateDatabaseAlways<RecipeDbContext>
  {
    protected override void Seed(RecipeDbContext context)
    {
      var recipes = new List<Recipe>
      {
        new Recipe{RecipeId=1,Name="All American Steak",Type="Meal",
                    Ingredients="Flank Steak, Sweet Potato, Green Bean, Unsweetened Almond Milk, Shallot, Organic Agave, Pineapple Juice, White Wine Vinegar, Salt, Cornstarch, Pepper, Seasonings \nCONTAINS: tree nuts",
                    Instruction="Heating Instructions: Loosen lid, remove portion cups (if included), reheat until internal temperature of 165° is reached, approximately 1-2 minutes in microwave. After heating, let stand 2 more minutes before removing from microwave. CAUTION container and contents will be HOT! Keep refrigerated until use. Do NOT consume past use by date.",
                    Description="Grilled flank steak topped with a sweet shallot sauce, steamed green beans and mashed sweet potatoes. ",
                    GlutenFree=true,LactoseFree=true,SoyFree=true,Vegetarian=false,Vegan=false
                  },
        new Recipe{RecipeId=2,Name="Taco Salad",Type="Meal",
                    Ingredients="Lean ground turkey, Salsa [CRUSHED TOMATOES (WATER, CRUSHED TOMATO CONCENTRATE), FRESH JALAPENO PEPPERS, DICED TOMATOES IN TOMATO JUICE, FRESH ONIONS, DEHYDRATED ONIONS, SALT, DISTILLED VINEGAR, CILANTRO, GARLIC, NATURAL FLAVORING.], Chips [Stone Ground Non-GMO Corn, Sunflower and/or Safflower Oil, Sprouted Seed and Grain Blend (Sprouted Flax Seed, Sprouted Quinoa, Sprouted Broccoli Seed, Sprouted Daikon Radish Seed), Pure Sea Salt], onion, garlic, cumin, pepper, salt], Spring mix salad greens, Black Beans, Tomato.",
                    Instruction="Important: Keep refrigerated until use. Do NOT consume past Use by date. Consuming raw or undercooked meats, poultry, seafood, shellfish or eggs may increase your risk of food-borne illness.",
                    Description="Mexican style lean ground turkey, black beans, salsa and crispy tortilla strips.",
                    GlutenFree=true,LactoseFree=true,SoyFree=true,Vegetarian=false,Vegan=false      
                  },
        new Recipe{RecipeId=3,Name="Picnic Box",Type="Snack",
                    Ingredients="Apple, Seedless red grapes, Light string cheese, Chips [Stone Ground Non-GMO Corn, Sunflower and/ or Safflower Oil, Sprouted Seed and Grain Blend (Sprouted Flax Seed, Sprouted Quinoa, Sprouted Broccoli Seed, Sprouted Daikon Radish Seed), Pure Sea Salt], almonds, sweetened dried cranberries. CONTAINS: cheese, nuts",
                    Instruction="Important: Keep refrigerated until use. Do NOT consume past Use by date. Consuming raw or undercooked meats, poultry, seafood, shellfish or eggs may increase your risk of food-borne illness.",
                    Description="Crisp apple slices, raw almonds, dried cranberries, fresh grapes, gluten free almond nut crackers and light mozzarella cheese.",
                    GlutenFree=true,LactoseFree=false,SoyFree=true,Vegetarian=true,Vegan=false
                  },
        new Recipe{RecipeId=4,Name="Edamame Pad Thai",Type="Meal",
                    Ingredients="Rice noodles, edamame (soybeans), mushroom, bean sprout, carrot, broccoli, garlic, low sodium soy sauce, lime juice, organic agave, green onion, ginger, cornstarch, canola/olive oil blend, peanut, cilantro, lime, pepper, salt \nCONTAINS: soy, peanuts",
                    Instruction="Heating Instructions: Loosen lid, remove portion cups (if included), reheat until internal temperature of 165° is reached, approximately 1-2 minutes in microwave. After heating, let stand 2 more minutes before removing from microwave. CAUTION container and contents will be HOT! Keep refrigerated until use. Do NOT consume past use by date.",
                    Description="Classic rice noodle dish with edamame, carrots, broccoli, mushrooms, bean sprouts and seasoned with lime, a spicy Pad Thai sauce, fresh cilantro and a side of roasted peanuts.",
                    GlutenFree=true,LactoseFree=true,SoyFree=false,Vegetarian=false,Vegan=true
                  }, 
        new Recipe{RecipeId=5,Name="Daybreak Scramble",Type="Meal",
                    Ingredients=" All Natural Chicken Breast, Egg whites, spinach, Whole eggs, Chevre cheese, sun dried tomatoes, pepper, salt, seasonings. \nCONTAINS: eggs, milk",
                    Instruction="Heating Instructions: Loosen lid, remove portion cups (if included), reheat until internal temperature of 165° is reached, approximately 1-2 minutes in microwave. After heating, let stand 2 more minutes before removing from microwave. CAUTION container and contents will be HOT! Keep refrigerated until use. Do NOT consume past use by date.",
                    Description="Tender slices of all natural chicken breast served on fresh spinach, 4-1 eggs, creamy goat cheese and sweet sun-dried tomatoes.",
                    GlutenFree=true,LactoseFree=false,SoyFree=true,Vegetarian=false,Vegan=false
                  }
        };

      recipes.ForEach(r => context.Recipes.Add(r));
      context.SaveChanges();

      var sizes = new List<Size>
      {
        new Size{SizeId=1,RecipeId=1,SizeName=SizeName.Regular,Template=Template.Red,Price=12M,Calories=482.5M,CaloriesFromFat=121.8M,TotalFat=13.5M,SaturatedFat=5.5M,TransFat=0M,Cholesterol=64.5M,Sodium=296.2M,TotalCarbs=44.9M,Fiber=9.3M,Sugars=13.7M,Protein=43.3M},
        new Size{SizeId=2,RecipeId=1,SizeName=SizeName.Small,Template=Template.Yellow,Price=9.75M,Calories=293M,CaloriesFromFat=74.9M,TotalFat=8.3M,SaturatedFat=3.4M,TransFat=0M,Cholesterol=39.7M,Sodium=176.1M,TotalCarbs=26.7M,Fiber=5.6M,Sugars=8.2M,Protein=26.6M},
        new Size{SizeId=3,RecipeId=2,SizeName=SizeName.OneSize,Template=Template.Red,Price=7.25M,Calories=342.7M,CaloriesFromFat=125.4M,TotalFat=13M,SaturatedFat=2.1M,TransFat=0M,Cholesterol=83.3M,Sodium=715.5M,TotalCarbs=37.9M,Fiber=9.3M,Sugars=6.1M,Protein=18.9M},
        new Size{SizeId=4,RecipeId=3,SizeName=SizeName.OneSize,Template=Template.Purple,Price=4.75M,Calories=275.8M,CaloriesFromFat=126.5M,TotalFat=13.6M,SaturatedFat=2.3M,TransFat=0M,Cholesterol=10.1M,Sodium=285.1M,TotalCarbs=27.2M,Fiber=4.8M,Sugars=12.8M,Protein=11.4M},
        new Size{SizeId=5,RecipeId=4,SizeName=SizeName.Regular,Template=Template.Red,Price=8.25M,Calories=517.6M,CaloriesFromFat=111.2M,TotalFat=13M,SaturatedFat=1.4M,TransFat=0M,Cholesterol=0M,Sodium=951M,TotalCarbs=85.6M,Fiber=8.4M,Sugars=12.1M,Protein=19.3M},
        new Size{SizeId=6,RecipeId=4,SizeName=SizeName.Small,Template=Template.Yellow,Price=6.75M,Calories=408.6M,CaloriesFromFat=102.8M,TotalFat=11.3M,SaturatedFat=1.3M,TransFat=0M,Cholesterol=0M,Sodium=687.9M,TotalCarbs=64.8M,Fiber=6.2M,Sugars=8.8M,Protein=14.6M},
       
      };

      sizes.ForEach(s => context.Sizes.Add(s));
      context.SaveChanges();


    }

  }
}