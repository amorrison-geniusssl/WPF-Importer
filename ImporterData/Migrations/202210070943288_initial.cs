namespace ImporterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PaymentModels");
            AlterColumn("dbo.PaymentModels", "AdeptRef", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PaymentModels", "Source", c => c.String());
            AlterColumn("dbo.PaymentModels", "Method", c => c.String());
            AlterColumn("dbo.PaymentModels", "Comment", c => c.String());
            AlterColumn("dbo.PersonModels", "DebtType", c => c.String());
            AlterColumn("dbo.PersonModels", "AccountName", c => c.String());
            AlterColumn("dbo.PersonModels", "FirstAddress", c => c.String());
            AlterColumn("dbo.PersonModels", "SecondAddress", c => c.String());
            AlterColumn("dbo.PersonModels", "ThirdAddress", c => c.String());
            AlterColumn("dbo.PersonModels", "PostCode", c => c.String());
            AddPrimaryKey("dbo.PaymentModels", "AdeptRef");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PaymentModels");
            AlterColumn("dbo.PersonModels", "PostCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.PersonModels", "ThirdAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.PersonModels", "SecondAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.PersonModels", "FirstAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.PersonModels", "AccountName", c => c.String(maxLength: 50));
            AlterColumn("dbo.PersonModels", "DebtType", c => c.String(maxLength: 20));
            AlterColumn("dbo.PaymentModels", "Comment", c => c.String(maxLength: 50));
            AlterColumn("dbo.PaymentModels", "Method", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PaymentModels", "Source", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PaymentModels", "AdeptRef", c => c.String(nullable: false, maxLength: 7));
            AddPrimaryKey("dbo.PaymentModels", "AdeptRef");
        }
    }
}
