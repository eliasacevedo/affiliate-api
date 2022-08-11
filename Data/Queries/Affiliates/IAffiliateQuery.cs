using Data.Models;
using Data.Models.Affiliate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries.Affiliates
{
    public interface IAffiliateQuery
    {
        bool AddAmount(AffiliateConsumedAmount consumedAmount);
    }
}
