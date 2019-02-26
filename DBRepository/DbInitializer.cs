using System.Linq;
using Microsoft.EntityFrameworkCore;
using CommonModels.Entity;

namespace DBRepository
{
    public static class DbInitializer
	{
		public static void Initialize(RepositoryContext context)
		{
            context.Database.Migrate();

		    var userCount = context.Users.Count();
		    if (userCount != 0) return;
		    context.Users.Add(new User()
		    {
		        Login = "admin",
		        Password = "745414",
		    });
		    context.SaveChanges();
		}
	}
}
