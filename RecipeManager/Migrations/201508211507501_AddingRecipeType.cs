namespace RecipeManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRecipeType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "RecipeType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "RecipeType");
        }
    }
}
