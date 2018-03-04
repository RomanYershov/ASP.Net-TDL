using System;
using System.Collections.Generic;
using System.Text;
using TDList.Models;

namespace TDList.Abstractions
{
    public interface IAccount
    {
        bool IsAuthorized(AccountModel accountModel);
        AccountInfoModel GetAccountInfo(AccountModel accountModel);
        AccountModel Registration(AccountModel accountModel);
    }
}
