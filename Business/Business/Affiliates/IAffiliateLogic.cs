using Domain;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Affiliates
{
    public interface IAffiliateLogic
    {
        Task<IEnumerable<Affiliate>> GetAffiliates(SearchFilterAffiliatePage? filter);
    }
}
