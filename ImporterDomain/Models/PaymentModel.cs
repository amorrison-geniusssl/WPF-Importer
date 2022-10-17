using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterDomain.Models
{
    public class PaymentModel
    {
        public PaymentModel() { }

        public PaymentModel(string adeptRef, double? amount, string effectiveDate, string source, string method, string comment, int accountNumber)
        {
            AdeptRef = adeptRef;
            Amount = amount;
            EffectiveDate = effectiveDate;
            Source = source;
            Method = method;
            Comment = comment;
            AccountNumber = accountNumber;
        }

        [Key]
        [Required]
        [MinLength(7), MaxLength(7)]
        public string AdeptRef { get; set; }

        [Required]
        public double? Amount { get; set; }

        [Required]
        public string EffectiveDate { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string Method { get; set; }

        public string Comment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int AccountNumber { get; set; }



    }
}
