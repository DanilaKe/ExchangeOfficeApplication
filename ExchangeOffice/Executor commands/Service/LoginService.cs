using System;
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
        public IRepository<DataSourceAccess.Account> db;

        public LoginService(IKernel kernel,string login, string password,bool adminFlag)
        {
            _kernel = kernel;
            Login = login;
            Password = password;
            AdminFlag = adminFlag;
            db = _kernel.Get<IRepository<DataSourceAccess.Account>>();
        }

        public IServiceEventArgs Invoke()
        {
            IServiceEventArgs e;
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
                e = new LoginServiceEventArgs(){Status = true,Account = account,Message = "Successful"};
            }
            else
            {
                e = new LoginServiceEventArgs(){Status = false, Account = new DataSourceAccess.Account(),
                    Message = "Invalid login/password."};
            }

            return e;
        }

        private DataSourceAccess.Account GetAccount()
        {
            var status = AdminFlag ? 1 : 2;
            return db.GetList().FirstOrDefault(x => x.Login == Login &&
                          x.Password == Password &&
                          x.AccountTypeValue == status);
        }
    }
}