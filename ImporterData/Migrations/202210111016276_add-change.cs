namespace ImporterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DebtorModels", "DebtType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DebtorModels", "DebtType", c => c.String());
        }
    }
}
