using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBaseQuery<T>
{
    Task<IEnumerable<T>> Get<Filter>(Filter? filter);
    Task<bool> Update(T model);
    //Task<bool> Delete(T model, string? sql);
    Task<bool> Create(T model);
}