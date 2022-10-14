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
        Task<bool> ItemExistsAsync(string id);
        Task<bool> ForeignKeyExistsAsync(int accountNumber);
    }

    public class PaymentRespository : GenericRepository<PaymentModel, ImporterDb>, IPaymentRespository
    {
        public PaymentRespository(ImporterDb context) : base(context)
        {

        }

        public override async Task<PaymentModel> GetByIdAsync(int accountNumber)
        {
            return await Context.Payments
              .SingleAsync(f => f.AccountNumber == accountNumber);
        }

        public async Task<bool> ForeignKeyExistsAsync(int accountNumber)
        {
            try
            {
                DebtorModel debtor = await Context.Debtors.FindAsync(accountNumber);
                if (debtor == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ItemExistsAsync(string id)
        {
            try
            {
                PaymentModel payment = await Context.Payments.FindAsync(id);
                if (payment == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
