using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using borsvarlden.Db;
using borsvarlden.Helpers;
using borsvarlden.Models;
using borsvarlden.Services.Finwire;
using Microsoft.EntityFrameworkCore;

namespace borsvarlden.Services.Entities
{

    public interface IFinwireXmlNewsService
    {
        Task<string> GetFileContentAsync(string fileName);
    }

    public class FinwireXmlNewsService : IFinwireXmlNewsService
    {
        private ApplicationContext _dbContext;

        public FinwireXmlNewsService(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task<string> GetFileContentAsync(string fileName)
        {
            return (await _dbContext
                    .FinwireXmlNews
                    .Where(x => x.FileName == fileName)
                    ?.FirstOrDefaultAsync())
                .FileContent;
        }
    }
}