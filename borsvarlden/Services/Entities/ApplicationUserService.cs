﻿using System.Threading.Tasks;
using borsvarlden.Db;
using borsvarlden.Extensions;
using borsvarlden.Models;
using Microsoft.EntityFrameworkCore;

namespace borsvarlden.Services.Entities
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> GetUser(string userName, string password);
    }

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationContext _dbContext;

        public ApplicationUserService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<ApplicationUser> GetUser(string userName, string password)
        {
            var passwordHash = password.ToMd5Hash();
            var user = await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName == userName && u.PasswordHash == passwordHash);

            return user;
        }
    }
}
