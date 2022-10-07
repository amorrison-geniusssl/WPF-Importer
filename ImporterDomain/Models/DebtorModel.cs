 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterDomain.Models
{
    public class DebtorModel
    {
        private DebtorModel customer;

        public DebtorModel()
        {

        }

        public string? DebtType { get; set; }

        [Key]
        public int AccountNumber { get; set; }

        public string? AccountName { get; set; }

        public DateTime? BirthDate { get; set; }

        public double? Balance { get; set; }

        public string? Email { get; set; }

        public long? PhoneNumber { get; set; }

        public string? FirstAddress { get; set; }

        public string? SecondAddress { get; set; }

        public string? ThirdAddress { get; set; }

        public string? PostCode { get; set; }

        public ICollection<PaymentModel> Payments { get; set; }

    }

}
