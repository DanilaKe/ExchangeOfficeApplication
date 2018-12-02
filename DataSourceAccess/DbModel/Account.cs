using System.ComponentModel.DataAnnotations;

namespace DataSourceAccess
{
    public class Account
    {
        [Key] public int AccountId { get; set; }
        [Required] public string Login { get; set; }
        public string Password { get; set; }
        [Required, Range(1,2)]public AccountType AccountType { get; set; }
    }
}