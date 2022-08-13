using Data.BaseQueries;
using Data.Config;
using Data.Models.Affiliates;
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
            string sql = "exec AddAffiliateConsumedAmount @UserId, @Amount";
            return await BaseSqlExecute(ConnectionStringNames.Default, sql, consumedAmount);
        }


        public async Task<IEnumerable<Affiliate>> Get(Affiliate filter)
        {
            string identificationIdParam = filter.IdentificationId != null && filter.IdentificationId.Length > 0 ? "and IdentificationId like '%@IdentificationId%'" : "";
            string firstnameParam = filter.Firstname != null && filter.Firstname.Length > 0 ? "and Firstname like '%@Firstname%'" : "";
            string lastnameParam = filter.Lastname != null && filter.Lastname.Length > 0 ? "and Lastname like '%@Lastname%'" : "";
            string conditional = $"where 1=1 {identificationIdParam} {firstnameParam} {lastnameParam}";
            string sql = $"select * from affiliate {conditional}";
            var r = await BaseSqlQuery(ConnectionStringNames.Default, sql, filter);
            return r;
        }

        public virtual async Task<bool> Update(Affiliate model)
        {
            var sql = $"exec AffiliateUpdate @Id, @Firstname, @Lastname, @BirthDate, @Sex, @IdentificationId, @PhoneNumber, @SocialSecurity, @ConsumedAmount, @PlanId, @StatusId";
            return await BaseSqlExecute(ConnectionStringNames.Default, sql, model);
        }

        public virtual async Task<bool> Create(Affiliate model)
        {
            var sql = $"exec AffiliateInsert @Firstname, @Lastname, @BirthDate, @Sex, @IdentificationId, @PhoneNumber, @SocialSecurity, @ConsumedAmount, @PlanId, @StatusId";
            return await BaseSqlExecute(ConnectionStringNames.Default, sql, model);
        }

    }
}
