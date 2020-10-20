using Abp.Data;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using MDR_Angular.EntityFrameworkCore;
using MDR_Angular.EntityFrameworkCore.Repositories;
using MDR_Angular.OrderMate.Reports.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.Reports.Repository
{
    public class ReportRepository1 : MDR_AngularRepositoryBase<TotalSalesByDayOfWeekReport, int>, IReportRepository1
    {

        private readonly IActiveTransactionProvider _transactionProvider;

        public ReportRepository1(IDbContextProvider<MDR_AngularDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        public int Count(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TotalSalesByMenuItemReport FirstOrDefault(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TotalSalesByMenuItemReport> FirstOrDefaultAsync(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TotalSalesByMenuItemReport> GetAllIncluding(params Expression<Func<TotalSalesByMenuItemReport, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<TotalSalesByMenuItemReport> GetAllList(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TotalSalesByMenuItemReport>> GetAllListAsync(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TotalSalesByMenuItemReportDto>> GetTotSBMI(int miId, DateTime dateFrom, DateTime dateTo)
        {
            await EnsureConnectionOpenAsync();

            var dbCommand = CreateCommand("SP_SalesByMenuItem", CommandType.StoredProcedure);

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@menuItemId", SqlDbType.Int){Value=miId },
                new SqlParameter("@dateFrom", SqlDbType.DateTime){Value=dateFrom },
                new SqlParameter("@dateTo", SqlDbType.DateTime){Value=dateTo}
            };

            dbCommand.Parameters.AddRange(sqlParameters);

            var lst = new List<TotalSalesByMenuItemReportDto>();

            using (var reader = dbCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var row = new TotalSalesByMenuItemReportDto();
                    row.MenuIteMane = reader.GetString(0);
                    row.MenuItemPrice1 = reader.GetDouble(1);
                    row.TotalSalesAmount = reader.GetDouble(2);


                    lst.Add(row);
                }
                return lst;
            }
        }

        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = Context.Database.GetDbConnection().CreateCommand();

            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        private async Task EnsureConnectionOpenAsync()
        {
            var connection = Context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }
        }

        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
    {
        {"ContextType", typeof(MDR_AngularDbContext) },
        {"MultiTenancySide", MultiTenancySide }
    });
        }

        public TotalSalesByMenuItemReport Insert(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public int InsertAndGetId(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAndGetIdAsync(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public Task<TotalSalesByMenuItemReport> InsertAsync(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public TotalSalesByMenuItemReport InsertOrUpdate(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdateAndGetId(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertOrUpdateAndGetIdAsync(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public Task<TotalSalesByMenuItemReport> InsertOrUpdateAsync(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<TotalSalesByMenuItemReport>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public TotalSalesByMenuItemReport Single(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TotalSalesByMenuItemReport> SingleAsync(Expression<Func<TotalSalesByMenuItemReport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TotalSalesByMenuItemReport Update(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public TotalSalesByMenuItemReport Update(int id, Action<TotalSalesByMenuItemReport> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<TotalSalesByMenuItemReport> UpdateAsync(TotalSalesByMenuItemReport entity)
        {
            throw new NotImplementedException();
        }

        public Task<TotalSalesByMenuItemReport> UpdateAsync(int id, Func<TotalSalesByMenuItemReport, Task> updateAction)
        {
            throw new NotImplementedException();
        }

        TotalSalesByMenuItemReport IRepository<TotalSalesByMenuItemReport, int>.FirstOrDefault(int id)
        {
            throw new NotImplementedException();
        }

        Task<TotalSalesByMenuItemReport> IRepository<TotalSalesByMenuItemReport, int>.FirstOrDefaultAsync(int id)
        {
            throw new NotImplementedException();
        }

        TotalSalesByMenuItemReport IRepository<TotalSalesByMenuItemReport, int>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<TotalSalesByMenuItemReport> IRepository<TotalSalesByMenuItemReport, int>.GetAll()
        {
            throw new NotImplementedException();
        }

        List<TotalSalesByMenuItemReport> IRepository<TotalSalesByMenuItemReport, int>.GetAllList()
        {
            throw new NotImplementedException();
        }

        Task<List<TotalSalesByMenuItemReport>> IRepository<TotalSalesByMenuItemReport, int>.GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        Task<TotalSalesByMenuItemReport> IRepository<TotalSalesByMenuItemReport, int>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        TotalSalesByMenuItemReport IRepository<TotalSalesByMenuItemReport, int>.Load(int id)
        {
            throw new NotImplementedException();
        }
    }
}
