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

        public string? DebtType { get; set; }

        [Key]
        public int AccountNumber { get; set; }

        public string? AccountName { get; set; }

        public string? BirthDate { get; set; }

        public double? Balance { get; set; }

        public string? Email { get; set; }

        public long? PhoneNumber { get; set; }

        public string? FirstAddress { get; set; }

        public string? SecondAddress { get; set; }

        public string? ThirdAddress { get; set; }

        public string? PostCode { get; set; }

        public ICollection<PaymentModel>? PaymentList { get; set; }

    }

}
