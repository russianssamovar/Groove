using System;
using System.Collections.Generic;
using System.Linq;
using CommonModels.Entity;
using DBRepository.Interfaces;

namespace DBRepository.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(string connectionString, IRepositoryContextFactory contextFactory)
            : base(connectionString, contextFactory)
        {
        }

        public IEnumerable<Account> GetAccounts(long userId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return context.Accounts.Where(u => u.Owner.Id == userId).ToArray();
            }
        }

        public Account GetAccount(long accountId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return context.Accounts.FirstOrDefault(a => a.Id == accountId);
            }
        }

        public IEnumerable<Account> UpdateAccounts(long userId, IEnumerable<Account> accounts)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var existAccounts = context.Accounts.Where(u => u.Owner.Id == userId).ToArray();
                foreach (var acc in accounts)
                {
                    var existAccount = existAccounts.FirstOrDefault(a => a.SocialUserId == acc.SocialUserId && a.Type == acc.Type);
                    if (existAccount != null && existAccount.Owner.Id == userId)
                    {
                        UpdateAccount(acc, existAccount);
                    }
                }
                context.SaveChanges();
                return existAccounts;
            }
        }

        public Account GetAccount(long userId, string socialId, AccountType type)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return null;
            }
        }

        public bool Add(long userId, Account account)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);

                var existAccount = context.Accounts.FirstOrDefault(a => a.SocialUserId == account.SocialUserId && a.Type == account.Type);

                if (existAccount != null && existAccount.Owner.Id != user.Id)
                {
                   throw new UnauthorizedAccessException("You don't own this account");
                }

                if (existAccount != null && existAccount.Owner.Id == user.Id)
                {
                    UpdateAccount(account, existAccount);
                    return true;
                }

                account.Owner = user;
                context.Accounts.Add(account);
                context.SaveChanges();
                return true;
            }
        }

        private void UpdateAccount(Account account, Account existAccount)
        {
            existAccount.AccessToken = account.AccessToken;
            existAccount.AvatarUrl = account.AvatarUrl;
            existAccount.FirstName = account.FirstName;
            existAccount.LastName = account.LastName;
        }
    }
}