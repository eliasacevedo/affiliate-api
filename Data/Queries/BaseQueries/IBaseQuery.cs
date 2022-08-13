using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBaseQuery<T>
{
    Task<bool> BaseSqlExecute(string connectionStringName, string sql, object? sqlParams = null);
    Task<IEnumerable<T>> BaseSqlQuery(string connectionStringName, string sql, object? sqlParams = null);
}