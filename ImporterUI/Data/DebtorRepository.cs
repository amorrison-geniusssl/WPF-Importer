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
        Task<bool> ItemExistsAsync(int accountNumber);
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

        public async Task<bool> ItemExistsAsync(int accountNumber)
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

    }
}
