namespace ImporterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePaymentModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PaymentModels");
            AlterColumn("dbo.PaymentModels", "AdeptRef", c => c.String(nullable: false, maxLength: 7));
            AlterColumn("dbo.PaymentModels", "EffectiveDate", c => c.String(nullable: false));
            AlterColumn("dbo.PaymentModels", "Source", c => c.String(nullable: false));
            AlterColumn("dbo.PaymentModels", "Method", c => c.String(nullable: false));
            AddPrimaryKey("dbo.PaymentModels", "AdeptRef");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PaymentModels");
            AlterColumn("dbo.PaymentModels", "Method", c => c.String());
            AlterColumn("dbo.PaymentModels", "Source", c => c.String());
            AlterColumn("dbo.PaymentModels", "EffectiveDate", c => c.String());
            AlterColumn("dbo.PaymentModels", "AdeptRef", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PaymentModels", "AdeptRef");
        }
    }
}
