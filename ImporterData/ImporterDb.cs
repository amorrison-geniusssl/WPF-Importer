using ImporterDomain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterData
{
    public class ImporterDb : DbContext
    {
        public DbSet<DebtorModel> Debtors { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }

    }
}
