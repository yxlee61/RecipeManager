namespace RecipeManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Ingredients = c.String(),
                        Instruction = c.String(),
                        Description = c.String(),
                        GlutenFree = c.Boolean(nullable: false),
                        LactoseFree = c.Boolean(nullable: false),
                        SoyFree = c.Boolean(nullable: false),
                        Vegetarian = c.Boolean(nullable: false),
                        Vegan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        SizeId = c.Int(nullable: false, identity: true),
                        RecipeId = c.Int(nullable: false),
                        SizeName = c.Int(nullable: false),
                        Template = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Calories = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CaloriesFromFat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalFat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SaturatedFat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransFat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cholesterol = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sodium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCarbs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fiber = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sugars = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Protein = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VitaminA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VitaminC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Calcium = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iron = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SizeId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sizes", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Sizes", new[] { "RecipeId" });
            DropTable("dbo.Sizes");
            DropTable("dbo.Recipes");
        }
    }
}
