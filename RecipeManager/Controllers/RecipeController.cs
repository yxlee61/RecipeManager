using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeManager.Models;
using RecipeManager.Helpers;

namespace RecipeManager.Controllers
{
  public class RecipeController : Controller
  {
    private RecipeDbContext db = new RecipeDbContext();

    // GET: Recipe
    public ActionResult Index(int? id)
    {
      return View(id.HasValue ? db.Recipes.Where(r => r.RecipeId == id) : Enumerable.Empty<Recipe>());      
    }

    // GET: Recipe/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Recipe recipe = db.Recipes.Find(id);
      if (recipe == null)
      {
        return HttpNotFound();
      }
      return View(recipe);
    }

    // GET: Recipe/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Recipe/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "RecipeId,Name,Type,Ingredients,Instruction,Description,GlutenFree,LactoseFree,SoyFree,Vegetarian,Vegan")] Recipe recipe)
    {
      if (ModelState.IsValid)
      {
        db.Recipes.Add(recipe);
        db.SaveChanges();
        return RedirectToAction("Index", new { id = recipe.RecipeId });
      }

      return View(recipe);
    }

    // GET: Recipe/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Recipe recipe = db.Recipes.Find(id);
      if (recipe == null)
      {
        return HttpNotFound();
      }
      return View(recipe);
    }

    // POST: Recipe/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "RecipeId,Name,Type,Ingredients,Instruction,Description,GlutenFree,LactoseFree,SoyFree,Vegetarian,Vegan")] Recipe recipe)
    {
      if (ModelState.IsValid)
      {
        db.Entry(recipe).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index", new { id = recipe.RecipeId });
      }
      return View(recipe);
    }

    // GET: Recipe/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Recipe recipe = db.Recipes.Find(id);
      if (recipe == null)
      {
        return HttpNotFound();
      }
      return View(recipe);
    }

    // POST: Recipe/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Recipe recipe = db.Recipes.Find(id);
      db.Recipes.Remove(recipe);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    public ActionResult RecipeSearch(string q)
    {
      var recipes = GetRecipes(q);

      return PartialView(recipes);
    }

    public ActionResult QuickSearch(string term)
    {
      var recipes = GetRecipes(term).Select(r => new { value = r.Name });
      return Json(recipes, JsonRequestBehavior.AllowGet);
    }

    private List<Recipe> GetRecipes(string searchString)
    {
      var query = db.Recipes.Where(r => r.Name.Contains(searchString));
      query = query.OrderBy(r => r.Name);
      return query.ToList();
    }

    private List<Size> GetSizes(string searchString)
    {
      var result = db.Sizes.Where(s => s.Recipe.Name.Contains(searchString));

      return result.ToList();
    }

    public ActionResult SizeSearch(string q)
    {
      var sizes = GetSizes(q);

      return PartialView(new SearchModel() { sizes = sizes });
    }

    public ActionResult Print()
    {
      return View(db.Recipes.ToList());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Display(int sizeId)
    {
      var size = db.Sizes.Where(s => s.SizeId == sizeId).First();
      return View(size);
    }

    public ActionResult PdfStuff()
    {
      string file = "C:\\Users\\Yan Xin\\documents\\visual studio 2013\\Projects\\RecipeManager\\RecipeManager\\Test\\label1.pdf";
      string outfile = "C:\\Users\\Yan Xin\\documents\\visual studio 2013\\Projects\\RecipeManager\\RecipeManager\\Test\\label1-empty.pdf";

      //Helpers.PdfHelper.ResetBackgroundColor(file, outfile, "white");
      double[] dimensions = Helpers.EmptyLabelGenerator.CreateEmptyLabel(file, outfile);

      string output = Helpers.PdfHelper.FontExtraction(file);

      string text = Helpers.PdfHelper.ExtractText(file);
      PdfModel pdfModel = new PdfModel();
      pdfModel.text = text;
      pdfModel.layers = output;
      pdfModel.dimensions = dimensions;

      return View(pdfModel);
    }

    public ActionResult PdfTest(){
      return View();
    }

  }

  public class PdfModel{
    public string text { get; set; }
    public string layers { get; set; }
    public double[] dimensions { get; set; }
  }


  public class SearchModel
  {
    public IEnumerable<Size> sizes { get; set; }
  }
}
