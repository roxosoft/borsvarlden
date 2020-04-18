using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using borsvarlden.Db;

namespace borsvarlden.Tests.UnitTests.Config
{
    public static class SetUp
    {
        //TODO from file borsvarlden config file
        public static string ConnectionString => "Server=localhost;Database=borsvarlden;Trusted_Connection=True;";

        private static readonly Lazy<ApplicationContext> ApplicationContextInstance =
            new Lazy<ApplicationContext>(() =>
                new ApplicationContext(((new DbContextOptionsBuilder<ApplicationContext>()).UseSqlServer(ConnectionString))
                    .Options));

        //todo normal
        public static ApplicationContext ApplicationContext => ApplicationContextInstance.Value;

    }
}
