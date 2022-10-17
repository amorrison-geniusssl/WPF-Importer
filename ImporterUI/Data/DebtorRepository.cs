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
        bool ItemExists(int accountNumber);
    }

    public class DebtorRespository : GenericRepository<DebtorModel, ImporterDb>, IDebtorRespository
    {
        public DebtorRespository(ImporterDb context) : base(context)
        {

        }

        public override async Task<DebtorModel> GetByIdAsync(int accountNumber)
        {
            return await Context.Debtors
              .SingleAsync(f => f.AccountNumber == accountNumber);
        }

        public bool ItemExists(int accountNumber)
        {

                DebtorModel debtor = Context.Debtors.Find(accountNumber);
                if (debtor == null)
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
