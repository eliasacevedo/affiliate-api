using Data.BaseQueries;
using Data.Config;
using Data.Models.Affiliate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Queries.Affiliates
{
    public class AffiliateQuery : BaseQuery<Affiliate>, IAffiliateQuery
    {
        public AffiliateQuery(ConnectionStringManager manager) : base(manager)
        {
        }

        public async Task<bool> AddAmount(AffiliateConsumedAmount consumedAmount)
        {
            string sql = "exec AddAffiliateConsumedAmount";
            return await BaseSqlExecute(ConnectionStringNames.Default, sql, consumedAmount);
        }


        public async Task<IEnumerable<Affiliate>> Get(Domain.Affiliate filter)
        {
            string sql = $"select * from affiliate where IdentificationId like %@IdentificationId% and Firstname like %@Firstname% and Lastname like %@Lastname%";
            return await BaseSqlQuery(ConnectionStringNames.Default, sql, filter);
        }

    }
}
