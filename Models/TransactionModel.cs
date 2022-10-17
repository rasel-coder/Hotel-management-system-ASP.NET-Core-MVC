using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Models
{
    public class TransactionModel
    {
        [Key]
        public int TransactionID { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage = "Account Number is Required")]
        [DisplayName("Account Number")]
        [Column(TypeName = "nvarchar(12)")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Beneficiary Name is Required")]
        [DisplayName("Beneficiary Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string BeneficiaryName { get; set; }

        [Required(ErrorMessage = "Bank Name is Required")]
        [DisplayName("Bank Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string BankName { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "SWIFT Code is Required")]
        [DisplayName("SWIFT Code")]
        [Column(TypeName = "nvarchar(11)")]
        public string SWIFTCode { get; set; }

        [Required(ErrorMessage = "Amount is Required")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
