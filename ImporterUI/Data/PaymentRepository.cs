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
        bool ItemExists(string id);
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

        public bool ItemExists(string id)
        {
                PaymentModel payment = Context.Payments.Find(id);
                if (payment == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }

    }
}
