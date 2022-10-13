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
    public interface IDebtorRespository : IGenericRepository<DebtorModel>
    {
        Task<DebtorModel> GetByIdAsync(int friendId);
    }

    public class DebtorRespository : GenericRepository<DebtorModel, ImporterDbContext>, IDebtorRespository
    {
        public DebtorRespository(ImporterDbContext context) : base(context)
        {

        }

        public override async Task<DebtorModel> GetByIdAsync(int accountNumber)
        {
            return await Context.Debtors
              .SingleAsync(f => f.AccountNumber == accountNumber);
        }


    }
}
