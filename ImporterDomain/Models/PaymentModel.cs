using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterDomain.Models
{
    public class PaymentModel
    {
        [Key]
        public string AdeptRef { get; set; }

        public double Amount { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string Source { get; set; }

        public string Method { get; set; }

        public string Comment { get; set; }

        public int AccountNumber { get; set; }
    }
}
