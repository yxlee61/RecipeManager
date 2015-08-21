using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager.Models
{

  public enum Template
  {
    Red,Yellow,Purple
  }

  public enum SizeName
  {
    Regular, Small, OneSize
  }

  public class Size
  {
    public int SizeId { get; set; }

    [Display(Name = "Recipe Name")]
    public int RecipeId { get; set; }

    [Display(Name = "Size Name")]
    public SizeName SizeName { get; set; }
    public Template Template { get; set; }
    public decimal Price { get; set; }
    public decimal Calories { get; set; }

    [Display(Name = "Calories From Fat")]
    public decimal CaloriesFromFat { get; set; }

    [Display(Name = "Total Fat (g)")]
    public decimal TotalFat { get; set; }

    [Display(Name = "Saturated Fat (g)")]
    public decimal SaturatedFat { get; set; }

    [Display(Name = "Trans Fat (g)")]
    public decimal TransFat { get; set; }

    [Display(Name = "Cholesterol (mg)")]
    public decimal Cholesterol { get; set; }

    [Display(Name = "Sodium (mg)")]
    public decimal Sodium { get; set; }

    [Display(Name = "Total Carbs (g)")]
    public decimal TotalCarbs { get; set; }

    [Display(Name = "Dietary Fiber (g)")]
    public decimal Fiber { get; set; }

    [Display(Name = "Sugars (g)")]
    public decimal Sugars { get; set; }

    [Display(Name = "Protein (g)")]
    public decimal Protein { get; set; }

    [Display(Name = "Vitamin A (%)")]
    public decimal VitaminA { get; set; }

    [Display(Name = "Vitamin C (%)")]
    public decimal VitaminC { get; set; }

    [Display(Name = "Calcium (%)")]
    public decimal Calcium { get; set; }

    [Display(Name = "Iron (%)")]
    public decimal Iron { get; set; }

    public virtual Recipe Recipe { get; set; }
  }

}