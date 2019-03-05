﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Account GetAccount(long userId)
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

                var existAccount = context.Accounts.FirstOrDefault(a => a.SocialUserId == account.SocialUserId);
                if (existAccount != null && existAccount.Owner.Id != user.Id)
                {
                   throw new UnauthorizedAccessException("You don't own this account");
                }

                if (existAccount != null && existAccount.Owner.Id == user.Id)
                {
                    existAccount.AccessToken = account.AccessToken;
                    existAccount.AvatarUrl = account.AvatarUrl;
                    existAccount.FirstName = account.FirstName;

                }
                account.Owner = user;
                context.Accounts.Add(account);
                context.SaveChanges();
                return true;
            }
        }
    }
}