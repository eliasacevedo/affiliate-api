using Data.Models;
using Data.Models.Affiliates;
using Data.Models.Estatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries.Affiliates
{
    public interface IEstatusQuery: IBaseQuery<GeneralEstatus>
    {
        Task<IEnumerable<GeneralEstatus>> Get(GeneralEstatus filter);
    }
}
