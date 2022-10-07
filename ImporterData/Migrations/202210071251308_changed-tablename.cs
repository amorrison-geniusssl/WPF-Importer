namespace ImporterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedtablename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserModels", newName: "DebtorModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DebtorModels", newName: "UserModels");
        }
    }
}
