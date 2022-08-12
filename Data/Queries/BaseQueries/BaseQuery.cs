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

public class BaseQuery<T>: IBaseQuery<T>
{
    private readonly ConnectionStringManager manager;
    public BaseQuery(ConnectionStringManager manager)
    {
        this.manager = manager;
    }
    public virtual async Task<bool> Create(T model)
    {
        if (model == null)
        {
            throw new ArgumentNullException("model param is missing");
        }

        var modelName = nameof(model);
        var sql = $"exec {modelName}Insert";
        return await BaseSqlExecute(ConnectionStringNames.Default, sql, model);
    }


    public virtual async Task<IEnumerable<T>> Get(object? filter)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<bool> Update(T model)
    {
        if (model == null)
        {
            throw new ArgumentNullException("model param is missing");
        }

        var modelName = model.GetType().Name;
        var sql = $"exec {modelName}Update";
        return await BaseSqlExecute(ConnectionStringNames.Default, sql, model);
    }

    public async Task<bool> BaseSqlExecute(string connectionStringName, string sql, object? sqlParams = null)
    {
        var conn = manager.GetSqlConnection(connectionStringName);
        try
        {
            await conn.ExecuteAsync(sql, sqlParams);
            return true;
        }
        catch
        {
            // add log
            return false;
        }
    }
    public async Task<IEnumerable<T>> BaseSqlQuery(string connectionStringName, string sql, object? sqlParams = null)
    {
        var conn = manager.GetSqlConnection(connectionStringName);
        try
        {
            return await conn.QueryAsync<T>(sql, sqlParams);
        }
        catch
        {
            // add log
            return new List<T>();
        }
    }

    public Task<IEnumerable<T>> Get<Filter>(Filter? filter)
    {
        throw new NotImplementedException();
    }
}