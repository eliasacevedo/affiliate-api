using Data.Queries.Affiliates;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Affiliates;
public class AffiliateLogic: IAffiliateLogic
{
    private readonly IAffiliateQuery affiliateQuery;
    public AffiliateLogic(IAffiliateQuery affiliateQuery)
    {
        this.affiliateQuery = affiliateQuery;
    }

    public async Task<IEnumerable<Domain.Affiliate>> GetAffiliates(SearchFilterAffiliatePage? filter)
    {
        if (filter == null)
        {
            filter = new SearchFilterAffiliatePage();
        }
        
        var affiliates = await affiliateQuery.Get(filter.ToDomain());
        return affiliates.Select(x => x.Domain);
    }

}