using System;
using System.Collections.Generic;
using System.Text;
using TDList.Abstractions;
using TDList.Data;
using TDList.Models;
using System.Linq;

namespace TDList.BL
{
    public class AccountService : IAccount
    {
        private readonly ApplicationContext _applicationContext;
        public AccountService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public AccountInfoModel GetAccountInfo(AccountModel accountModel)
        {
            var user = _applicationContext.Users.FirstOrDefault(x => x.Login == accountModel.Login);
            if (user == null) return null;
            return new AccountInfoModel
            {
                Id = user.Id,
                Role = user.Role
            };
        }

        public bool IsAuthorized(AccountModel accountModel)
        {
            var user = _applicationContext.Users.FirstOrDefault(x => x.Login == accountModel.Login);
            if (user == null) return false;
            string salt = user.Salt;
            string hash = HashingMethods.GenerateSha256Hash(accountModel.Password, salt);
            return hash == user.PasswordHash;

        }

        public AccountModel Registration(AccountModel accountModel)
        {
            var salt = HashingMethods.CreateSalt();
            var hash = HashingMethods.GenerateSha256Hash(accountModel.Password, salt);
            User newUser = new User
            {
                Login = accountModel.Login,
                PasswordHash = hash,
                Salt = salt,
                Role = "user"
            };
            _applicationContext.Users.Add(newUser);
            _applicationContext.SaveChanges();
            return accountModel;
        }
    }
}
