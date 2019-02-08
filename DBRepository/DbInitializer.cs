using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CommonModels;

namespace DBRepository
{
	public static class DbInitializer
	{
		public static async Task Initialize(RepositoryContext context)
		{
			await context.Database.MigrateAsync();

			var userCount = await context.Users.CountAsync().ConfigureAwait(false);
			if (userCount == 0)
			{
				context.Users.Add(new User()
				{
					Login = "admin",
					Password = "745414",
				});

				await context.SaveChangesAsync().ConfigureAwait(false);
			}
		}
	}
}
