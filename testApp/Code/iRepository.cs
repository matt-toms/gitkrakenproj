using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using LinqToDB;
using LinqToDB.Data;
using static LinqToDB.DataProvider.SqlServer.SqlServerProviderAdapter;

namespace testApp.Code
{


    public partial class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {


        MattContext _db;
        private Microsoft.EntityFrameworkCore.DbSet<TEntity> table = null;


        public EntityRepository(MattContext mattContext)
        {
            _db = mattContext;
            table = _db.Set<TEntity>();

        }



        public TEntity GetTable(object id)
        {
            return table.Find(id);

        }


        public int getID()
        {
            return 123;
        }


    }


    public partial interface IRepository<TEntity>
    {

        public TEntity GetTable(object id);


    }
}
