﻿using ImporterData;
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
    }

    public class DebtorRespository : GenericRepository<DebtorModel, ImporterDbContext>, IDebtorRespository
    {
        public DebtorRespository(ImporterDbContext context) : base(context)
        {

        }
    }
}
