using ImporterDomain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterData
{
    public class ImporterDbContext : DbContext
    {
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
    }
}
