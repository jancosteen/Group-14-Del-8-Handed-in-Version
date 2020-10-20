using Abp.Application.Services.Dto;
using Abp.Data;
using Abp.EntityFrameworkCore;
using AutoMapper;
using MDR_Angular.EntityFrameworkCore;
using MDR_Angular.EntityFrameworkCore.Repositories;
using MDR_Angular.OrderMate.Reports.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.Reports.Repository
{
    public class ReportRepository: MDR_AngularRepositoryBase<TotalSalesByDayOfWeekReport,int>, IReportRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        public ReportRepository(IDbContextProvider<MDR_AngularDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
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

        public async Task<List<TotalSalesByDayOfWeekReportDto>> GetTotSDOW(int resId, DateTime dateFrom, DateTime dateTo)
        {
            await EnsureConnectionOpenAsync();

            

            var dbCommand = CreateCommand("SP_TotalSalesByDayOfWeek", CommandType.StoredProcedure);

            SqlParameter[] sqlParams =
            {
                new SqlParameter("@restaurantId", SqlDbType.Int){Value=resId },
                new SqlParameter("@dateFrom", SqlDbType.DateTime){Value=dateFrom },
                new SqlParameter("@dateTo", SqlDbType.DateTime){Value=dateTo}

            };

            dbCommand.Parameters.AddRange(sqlParams);

            var lst = new List<TotalSalesByDayOfWeekReportDto>();

            using (var reader = dbCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var row = new TotalSalesByDayOfWeekReportDto();
                    row.Sunday = reader.GetInt32(0);
                    row.Monday = reader.GetInt32(1);
                    row.Tuesday = reader.GetInt32(2);
                    row.Wednesday = reader.GetInt32(3);
                    row.Thursday = reader.GetInt32(4);
                    row.Friday = reader.GetInt32(5);
                    row.Saturday = reader.GetInt32(6);
                    row.TotalSales = reader.GetInt32(7);
                    row.TotalAmount = reader.GetDouble(8);

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

        
    }
}
