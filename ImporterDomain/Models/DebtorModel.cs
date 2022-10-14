 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImporterDomain.Models
{
    public class DebtorModel
    {
        public DebtorModel() { }

        public DebtorModel(string? debtType, int accountNumber, string? accountName, string? birthDate, double? balance, string? email, long? phoneNumber, string? firstAddress, string? secondAddress, string? thirdAddress, string? postCode)
        {
            DebtType = debtType;
            AccountNumber = accountNumber;
            AccountName = accountName;
            BirthDate = birthDate;
            Balance = balance;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstAddress = firstAddress;
            SecondAddress = secondAddress;
            ThirdAddress = thirdAddress;
            PostCode = postCode;
        }

        [Required]
        [StringLength(30)]
        public string? DebtType { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string? AccountName { get; set; }

        [Required]
        [StringLength(10)]
        public string? BirthDate { get; set; }

        [Required]
        public double? Balance { get; set; }

        [Required]
        [StringLength(30)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public long? PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string? FirstAddress { get; set; }

        [StringLength(30)]
        public string? SecondAddress { get; set; }

        [Required]
        [StringLength(30)]
        public string? ThirdAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string? PostCode { get; set; }

        public ICollection<PaymentModel>? PaymentList { get; set; }

    }

}
