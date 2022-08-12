using Domain;

namespace DTOs;

public class SearchFilterAffiliatePage
{
    public string? Firstname { get; set; }
    public string? IdentificationId { get; set; }
    public string? Lastname { get; set; }

    public Affiliate ToDomain() {
        return new Affiliate()
        {
            Firstname = Firstname,
            Lastname = Lastname,
            IdentificationId = IdentificationId
        };
    }

}
