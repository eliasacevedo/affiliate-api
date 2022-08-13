using Data.Models;
using Data.Models.Affiliates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries.Affiliates
{
    public interface IAffiliateQuery: IBaseQuery<Affiliate>
    {
        Task<IEnumerable<Affiliate>> Get(Affiliate filter);
        Task<bool> Update(Affiliate model);
        Task<bool> Create(Affiliate model);
        Task<bool> AddAmount(AffiliateConsumedAmount consumedAmount);
    }
}
