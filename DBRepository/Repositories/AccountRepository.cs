using System.Threading.Tasks;
using CommonModels;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBRepository.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(string connectionString, IRepositoryContextFactory contextFactory)
            : base(connectionString, contextFactory)
        {
        }

        public async Task<Account> GetAccounts(long accountId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Accounts.FirstOrDefaultAsync(ac => ac.Id == accountId);
            }
        }
    }
}