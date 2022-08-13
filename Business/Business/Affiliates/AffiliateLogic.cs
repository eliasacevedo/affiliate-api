using Data.Queries.Affiliates;
using Domain;
using DTOs;
using DTOs.Affiliates;
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

    public async Task AddConsumedAmount(AmountConsumedAffiliate affiliate)
    {
        await affiliateQuery.AddAmount(affiliate.ToData());
    }

    public async Task CreateAffiliate(Affiliate affiliate)
    {
        await affiliateQuery.Create(new Data.Models.Affiliates.Affiliate(affiliate));
    }

    public async Task<IEnumerable<Affiliate>> GetAffiliates(SearchFilterAffiliatePage? filter)
    {
        if (filter == null)
        {
            filter = new SearchFilterAffiliatePage();
        }
        
        var affiliates = await affiliateQuery.Get(filter.ToData());
        return affiliates.Select(x => x.ToDomain());
    }

    public async Task UpdateAffiliate(Affiliate affiliate)
    {
        await affiliateQuery.Update(new Data.Models.Affiliates.Affiliate(affiliate));
    }
}