using System.Collections.Generic;
using System.Linq;
using DataSourceAccess;
using Ninject;

namespace ExchangeOffice.Service
{
    internal class LoginService : ILoginService
    {
        private IKernel _kernel;
        public string Login { get; set; }
        public string Password { get; set; }
        public bool AdminFlag { get; set; }

        public LoginService(IKernel kernel)
        {
            _kernel = kernel;
        }

        public ServiceEventArgs<DataSourceAccess.Account> Invoke()
        {
            ServiceEventArgs<DataSourceAccess.Account> e;
            var account = GetAccount();
            if (account != null)
            {
                if (AdminFlag)
                {
                    new Administrator();
                }
                else
                {
                    new Cashier();
                }
                e = new ServiceEventArgs<DataSourceAccess.Account>(){Status = true,Result = new List<DataSourceAccess.Account>() {account},Message = "Successful"};
            }
            else
            {
                e = new ServiceEventArgs<DataSourceAccess.Account>(){Status = false, Result = new List<DataSourceAccess.Account>(),
                    Message = "Invalid login/password."};
            }

            return e;
        }

        private DataSourceAccess.Account GetAccount()
        {
            var db = _kernel.Get<UnitOfWork>().Accounts;
            var status = AdminFlag ? 1 : 2;
            return db.GetList().FirstOrDefault(x => x.Login == Login &&
                          x.Password == Password &&
                          x.AccountTypeValue == status);
        }
    }
}