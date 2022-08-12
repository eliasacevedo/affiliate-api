using Data.Models;
using Data.Models.Affiliate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries.Affiliates
{
    public interface IAffiliateQuery: IBaseQuery<Affiliate>
    {
        Task<IEnumerable<Affiliate>> Get(Domain.Affiliate filter);
        Task<bool> AddAmount(AffiliateConsumedAmount consumedAmount);
    }
}
