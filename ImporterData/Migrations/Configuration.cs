using ImporterDomain.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;

namespace ImporterData.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ImporterData.ImporterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ImporterData.ImporterDbContext context)
        {
            context.Debtors.AddOrUpdate(
              f => f.AccountNumber,
              new DebtorModel
              {
                  DebtType = "Residential",
                  AccountNumber = 1111111,
                  AccountName = "Huber",
                  BirthDate = Convert.ToDateTime("11/11/11"),
                  Balance = 111.11,
                  Email = "amorrison@gmail.com",
                  PhoneNumber = 1231211,
                  FirstAddress = "2 Oak Road",
                  SecondAddress = "Wowee",
                  ThirdAddress = "Scotland",
                  PostCode = "FK1 2AD",
              });

            context.Debtors.AddOrUpdate(
              f => f.AccountNumber,
              new DebtorModel
              {
                  DebtType = "Residential",
                  AccountNumber = 1111111,
                  AccountName = "Huber",
                  BirthDate = Convert.ToDateTime("11/11/11"),
                  Balance = 111.11,
                  Email = "amorrison@gmail.com",
                  PhoneNumber = 1231211,
                  FirstAddress = "2 Oak Road",
                  SecondAddress = "Wowee",
                  ThirdAddress = "Scotland",
                  PostCode = "FK1 2AD",
              });

            context.Debtors.AddOrUpdate(
              f => f.AccountNumber,
              new DebtorModel
              {
                  DebtType = "Residential",
                  AccountNumber = 1111111,
                  AccountName = "Huber",
                  BirthDate = Convert.ToDateTime("11/11/11"),
                  Balance = 111.11,
                  Email = "amorrison@gmail.com",
                  PhoneNumber = 1231211,
                  FirstAddress = "2 Oak Road",
                  SecondAddress = "Wowee",
                  ThirdAddress = "Scotland",
                  PostCode = "FK1 2AD",
              });
        }



            public string? DebtType { get; set; }

        [Key]
        public int AccountNumber { get; set; }

        public string? AccountName { get; set; }

        public DateTime? BirthDate { get; set; }

        public double? Balance { get; set; }

        public string? Email { get; set; }

        public long? PhoneNumber { get; set; }

        public string? FirstAddress { get; set; }

        public string? SecondAddress { get; set; }

        public string? ThirdAddress { get; set; }

        public string? PostCode { get; set; }

        public ICollection<PaymentModel> Payments { get; set; }
    }
}