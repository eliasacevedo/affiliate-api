using Data.BaseQueries;
using Data.Config;
using Data.Models.Affiliates;
using Data.Models.Estatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries.Affiliates
{
    public class EstatusQuery : BaseQuery<GeneralEstatus>, IEstatusQuery
    {
        public EstatusQuery(ConnectionStringManager manager) : base(manager)
        {
        }

        public async Task<IEnumerable<GeneralEstatus>> Get(GeneralEstatus filter)
        {
            var statusParam = "";
            if (filter.Estatus != null && filter.Estatus.Length > 0)
            {
                filter.Estatus = $"%{filter.Estatus}%";
                statusParam = "and estatus like @Estatus";
            }
            string sql = $"select * from generalstatus where 1=1 {(filter.Id > 0 ? "and id = @Id ": "")} {statusParam}";
            var r = await BaseSqlQuery(ConnectionStringNames.Default, sql, filter);
            return r;
        }

    }
}
