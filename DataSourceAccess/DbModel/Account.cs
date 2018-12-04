using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSourceAccess
{
    public class Account
    {
        [Key] public int AccountId { get; set; }
        [Required] public string Login { get; set; }
        public string Password { get; set; }
        [Required, Range(1,2)]public int AccountTypeValue { get; set; }
        [Range(1, 4), NotMapped]
        public AccountType AccountType
        {
            get => (AccountType) AccountTypeValue;
            set => AccountTypeValue = (int) value;
        }
    }
}