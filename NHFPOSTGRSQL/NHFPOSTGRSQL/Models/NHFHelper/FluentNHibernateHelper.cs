using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHFPOSTGRSQL.Models.EntityModel;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHFPOSTGRSQL.Models.NHFHelper
{
    public class FluentNHibernateHelper
    {
        public static ISession OpenSession()
        {
            string connectionString = "Host=localhost;Database=test11;User Id=postgres;Password=123456;Port=5432";

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<personprofil>())
                //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersonProfilVM>())
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true,true))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
