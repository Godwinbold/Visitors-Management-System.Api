using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Visitors_Management_System.Domain.Entities;

namespace Visitors_Management_System.API.Extensions
{
	public class DbRegistration
	{
		public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
					optionsBuilder =>
					{
						optionsBuilder.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
						// optionsBuilder.UseNetTopologySuite();
					}));

			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
		}
	}
}
