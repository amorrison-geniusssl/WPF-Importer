using ImporterData;
using ImporterDomain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterUI.Data
{
    public interface IPaymentRespository : IGenericRepository<PaymentModel>
    {
        Task<PaymentModel> GetByIdAsync(int accountNumber);
        Task<bool> ForeignKeyExists(int accountNumber);
    }

    public class PaymentRespository : GenericRepository<PaymentModel, ImporterDbContext>, IPaymentRespository
    {
        public PaymentRespository(ImporterDbContext context) : base(context)
        {

        }

        public override async Task<PaymentModel> GetByIdAsync(int accountNumber)
        {
            return await Context.Payments
              .SingleAsync(f => f.AccountNumber == accountNumber);
        }

        public async Task<bool> ForeignKeyExists(int accountNumber)
        {
            try
            {
                DebtorModel debtor = await Context.Debtors.FindAsync(accountNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
