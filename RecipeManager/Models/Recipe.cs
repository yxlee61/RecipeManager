using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager.Models
{

  public enum RecipeType
  {
    Meal,Snack,Wrap,Salad
  }

  public class Recipe
  {
    public int RecipeId { get; set; }
    public string Name { get; set; }

    [Display(Name = "Type")]
    public RecipeType RecipeType { get; set; }

    [DataType(DataType.MultilineText)]
    public string Ingredients { get; set; }

    [DataType(DataType.MultilineText)]
    public string Instruction { get; set; }

    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [Display(Name = "Gluten-Free")]
    public bool GlutenFree { get; set; }

    [Display(Name = "Lactose-Free")]
    public bool LactoseFree { get; set; }

    [Display(Name = "Soy-Free")]
    public bool SoyFree { get; set; }

    public bool Vegetarian { get; set; }
    public bool Vegan { get; set; }

    public virtual ICollection<Size> Sizes { get; set; }

  }
}