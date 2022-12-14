using Dapper;
using Data.Config;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BaseQueries;

public class BaseQuery<T> : IBaseQuery<T>
{
    private readonly ConnectionStringManager manager;
    public BaseQuery(ConnectionStringManager manager)
    {
        this.manager = manager;
    }

    public async Task<bool> BaseSqlExecute(string connectionStringName, string sql, object? sqlParams = null)
    {
        var conn = manager.GetSqlConnection(connectionStringName);
        await conn.ExecuteAsync(sql, sqlParams);
        return true;
    }
    public async Task<IEnumerable<T>> BaseSqlQuery(string connectionStringName, string sql, object? sqlParams = null)
    {
        var conn = manager.GetSqlConnection(connectionStringName);
        return await conn.QueryAsync<T>(sql, sqlParams);
    }


}