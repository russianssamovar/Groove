using System.Linq;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CommonModels;

namespace DBRepository.Repositories
{
    public class IdentityRepository : BaseRepository, IIdentityRepository
	{
		public IdentityRepository(string connectionString, IRepositoryContextFactory contextFactory)
		    : base(connectionString, contextFactory) { }

	    public User GetUser(string userName)
	    {
	        using (var context = ContextFactory.CreateDbContext(ConnectionString))
	        {
	            return context.Users.FirstOrDefault(u => u.Login == userName);
	        }
        }

	    public bool Reistration(string userName, string password)
	    {
	        using (var context = ContextFactory.CreateDbContext(ConnectionString))
	        {
	            context.Users.Add(new User()
	            {
	                Login = userName,
	                Password = password,
	            });
	            context.SaveChanges();
                return true;
	        }
	    }
    }
}
