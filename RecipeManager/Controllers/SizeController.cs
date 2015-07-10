using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeManager.Models;

namespace RecipeManager.Controllers
{
  public class SizeController : Controller
  {
    private RecipeDbContext db = new RecipeDbContext();

    // GET: Size
    public ActionResult Index()
    {
      var sizes = db.Sizes.Include(s => s.Recipe);
      return View(sizes.ToList());
    }

    // GET: Size/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Size size = db.Sizes.Find(id);
      if (size == null)
      {
        return HttpNotFound();
      }
      return View(size);
    }

    // GET: Sizes/Create
    public ActionResult Create([Bind(Prefix = "id")] int RecipeID)
    {
      var recipes = db.Recipes.ToList();
      var sel = new SelectList(recipes, "RecipeId", "Name", RecipeID);
      ViewBag.RecipeId = sel;
      return View();
    }

    // POST: Sizes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "SizeId,RecipeId,SizeName,Template,Price,Calories,CaloriesFromFat,TotalFat,SaturatedFat,TransFat,Cholesterol,Sodium,TotalCarbs,Fiber,Sugars,Protein,VitaminA,VitaminC,Calcium,Iron")] Size size)
    {
      if (ModelState.IsValid)
      {
        db.Sizes.Add(size);
        db.SaveChanges();
        return RedirectToAction("Index", "Recipe");
      }

      ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Name", size.RecipeId);
      return View(size);
    }

    // GET: Size/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Size size = db.Sizes.Find(id);
      if (size == null)
      {
        return HttpNotFound();
      }
      ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Name", size.RecipeId);
      return View(size);
    }

    // POST: Size/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "SizeId,RecipeId,SizeName,Template,Price,Calories,CaloriesFromFat,TotalFat,SaturatedFat,TransFat,Cholesterol,Sodium,TotalCarbs,Fiber,Sugars,Protein,VitaminA,VitaminC,Calcium,Iron")] Size size)
    {
      if (ModelState.IsValid)
      {
        db.Entry(size).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index", "Recipe");
      }
      ViewBag.RecipeId = new SelectList(db.Recipes, "RecipeId", "Name", size.RecipeId);
      return View(size);
    }

    // GET: Size/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Size size = db.Sizes.Find(id);
      if (size == null)
      {
        return HttpNotFound();
      }
      return View(size);
    }

    // POST: Size/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Size size = db.Sizes.Find(id);
      db.Sizes.Remove(size);
      db.SaveChanges();
      return RedirectToAction("Index", "Recipe");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
