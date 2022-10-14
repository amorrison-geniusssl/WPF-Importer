namespace ImporterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DebtorModels",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false),
                        DebtType = c.String(nullable: false, maxLength: 30),
                        AccountName = c.String(nullable: false, maxLength: 30),
                        BirthDate = c.String(nullable: false, maxLength: 10),
                        Balance = c.Double(nullable: false),
                        Email = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.Long(nullable: false),
                        FirstAddress = c.String(nullable: false, maxLength: 30),
                        SecondAddress = c.String(maxLength: 30),
                        ThirdAddress = c.String(nullable: false, maxLength: 30),
                        PostCode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.PaymentModels",
                c => new
                    {
                        AdeptRef = c.String(nullable: false, maxLength: 128),
                        Amount = c.Double(nullable: false),
                        EffectiveDate = c.String(),
                        Source = c.String(),
                        Method = c.String(),
                        Comment = c.String(),
                        AccountNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdeptRef)
                .ForeignKey("dbo.DebtorModels", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentModels", "AccountNumber", "dbo.DebtorModels");
            DropIndex("dbo.PaymentModels", new[] { "AccountNumber" });
            DropTable("dbo.PaymentModels");
            DropTable("dbo.DebtorModels");
        }
    }
}
