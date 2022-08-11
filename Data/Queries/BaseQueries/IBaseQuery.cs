using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBaseQuery<T>
{
    IEnumerable<T> Get(T? filter);
    bool Update(T model);
    bool Delete(T model);
    bool Create(T model);
}