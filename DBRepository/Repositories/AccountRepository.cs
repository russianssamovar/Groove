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
                return Enumerable.Empty<Account>();
                //return context.Accounts.Where(u => u.OwnerId == userId).ToArray();
            }
        }

        public Account GetAccount(long userId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return null;
            }
        }

        public async Task<bool> Add(Account account)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                await context.AddAsync(account);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}