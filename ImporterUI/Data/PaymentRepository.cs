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

    }

    public class PaymentRespository : GenericRepository<PaymentModel, ImporterDbContext>, IPaymentRespository
    {
        public PaymentRespository(ImporterDbContext context) : base(context)
        {

        }
    }
}
