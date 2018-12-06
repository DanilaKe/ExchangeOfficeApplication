using System;
using System.Linq;
using DataSourceAccess;
using Microsoft.Data.Sqlite;
using Ninject;

namespace ExchangeOffice.Service
{
    internal class LoginService : Service
    {
        private IKernel _kernel;
        public string Login { get; set; }
        public string Password { get; set; }
        public bool AdminFlag { get; set; }

        public LoginService(IKernel kernel,string login, string password,bool adminFlag)
        {
            _kernel = kernel;
            Login = login;
            Password = password;
            AdminFlag = adminFlag;
        }

        internal override ServiceEventArgs Invoke()
        {
            ServiceEventArgs e;
            if (Check())
            {
                if (AdminFlag)
                {
                    new Administrator();
                }
                else
                {
                    new Cashier();
                }
                e = new ServiceEventArgs(true,"Successful login");
            }
            else
            {
                e = new ServiceEventArgs(false,"Incorrect username / password.");
            }

            return e;
        }

        private bool Check()
        {
            var Status = AdminFlag ? 1 : 2;
            return _kernel.Get<IRepository<DataSourceAccess.Account>>().GetList().Select(x => x)
                .Any(x => x.Login == Login &&
                          x.Password == Password &&
                          x.AccountTypeValue == Status);
        }
    }
}