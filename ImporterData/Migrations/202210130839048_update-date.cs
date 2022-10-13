namespace ImporterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PaymentModels", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PaymentModels", "Amount", c => c.Double());
        }
    }
}
