using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BaseQueries;

public class BaseQuery: IBaseQuery<IBaseModel>
{
    public bool Create(IBaseModel model)
    {
        throw new NotImplementedException();
    }

    public bool Delete(IBaseModel model)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IBaseModel> Get(IBaseModel? filter)
    {
        throw new NotImplementedException();
    }

    public bool Update(IBaseModel model)
    {
        throw new NotImplementedException();
    }
}