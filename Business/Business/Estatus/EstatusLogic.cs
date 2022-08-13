using Data.Models.Estatus;
using Data.Queries.Affiliates;
using DTOs.Estatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Estatus
{
    public class EstatusLogic : IEstatusLogic
    {
        private readonly IEstatusQuery estatusQuery;
        public EstatusLogic(IEstatusQuery estatusQuery)
        {
            this.estatusQuery = estatusQuery;
        }
        public async Task<IEnumerable<Domain.Estatus>> GetEstatus(SearchEstatusFilter? filter)
        {

            if (filter == null)
            {
                filter = new SearchEstatusFilter();
            }

            var result = await estatusQuery.Get(filter.ToData());
            return result.Select(x => x.ToDomain());
        }

    }
}
