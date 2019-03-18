using System.Linq;
using DBRepository.Interfaces;
using CommonModels.Entity;

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

	    public bool Registration(string userName, string password)
	    {
	        using (var context = ContextFactory.CreateDbContext(ConnectionString))
	        {
	            context.Users.Add(new User
	            {
	                Login = userName,
	                Password = password,
	            });
	            context.SaveChanges();
                return true;
	        }
	    }

	    public User GetUserById(long userId)
	    {
	        using (var context = ContextFactory.CreateDbContext(ConnectionString))
	        {
	            return context.Users.FirstOrDefault(u => u.Id == userId);
	        }
        }
	    public User GetUserByToken(string token)
	    {
	        using (var context = ContextFactory.CreateDbContext(ConnectionString))
	        {
	            return context.Users.FirstOrDefault(u => u.Token == token);
	        }
	    }
	}
}
