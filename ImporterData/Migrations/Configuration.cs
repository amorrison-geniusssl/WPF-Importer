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
                  AccountName = "John Huber",
                  BirthDate = Convert.ToDateTime("13/11/81"),
                  Balance = 111.11,
                  Email = "huber@gmail.com",
                  PhoneNumber = 1231211,
                  FirstAddress = "21 Street Lane",
                  SecondAddress = "Florence",
                  ThirdAddress = "United States",
                  PostCode = "EH2 9ED",
              });

            context.Debtors.AddOrUpdate(
              f => f.AccountNumber,
              new DebtorModel
              {
                  DebtType = "Business",
                  AccountNumber = 2222222,
                  AccountName = "Alan Morrison",
                  BirthDate = Convert.ToDateTime("11/11/11"),
                  Balance = 444.44,
                  Email = "example@gmail.com",
                  PhoneNumber = 12345679,
                  FirstAddress = "53 Birch Lane",
                  SecondAddress = "",
                  ThirdAddress = "England",
                  PostCode = "LN3 3EA",
              });

            context.Debtors.AddOrUpdate(
              f => f.AccountNumber,
              new DebtorModel
              {
                  DebtType = "Business",
                  AccountNumber = 3333333,
                  AccountName = "Jon Snow",
                  BirthDate = Convert.ToDateTime("12/02/01"),
                  Balance = 32,
                  Email = "amorrison@gmail.com",
                  PhoneNumber = 123145124,
                  FirstAddress = "2 Oak Road",
                  SecondAddress = "Okay",
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