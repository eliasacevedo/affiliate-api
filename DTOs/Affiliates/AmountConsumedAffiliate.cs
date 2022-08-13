using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Affiliates;

public class AmountConsumedAffiliate
{
    public string? UserId { get; set; }
    public double ConsumedAmount { get; set; }

    public Data.Models.Affiliates.AffiliateConsumedAmount ToData()
    {
        int.TryParse(UserId, out int id);
        return new Data.Models.Affiliates.AffiliateConsumedAmount()
        {
            UserId = id,
            Amount = ConsumedAmount,
        };
    }
}

