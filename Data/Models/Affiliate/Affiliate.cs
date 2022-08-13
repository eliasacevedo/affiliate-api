namespace Data.Models.Affiliates;

public class Affiliate: IBaseModel {

    public Affiliate()
    {

    }

    public Affiliate(Domain.Affiliate affiliate)
    {
        int id;
        int.TryParse(affiliate.Id, out id);
        Id = id;

        Firstname = affiliate.Firstname;
        Lastname = affiliate.Lastname;
        BirthDate = affiliate.BirthDate;
        Sex = affiliate.Sex;
        IdentificationId = affiliate.IdentificationId;
        PhoneNumber = affiliate.PhoneNumber;
        SocialSecurity = affiliate.SocialSecurity;
        RegistryDate = affiliate.RegistryDate;
        ConsumedAmount = affiliate.ConsumedAmount;

        int plan;
        int.TryParse(affiliate.PlanId, out plan);
        PlanId = plan;

        int statusId;
        int.TryParse(affiliate.StatusId, out statusId);
        StatusId = statusId;

    }
    public int Id {get; set;}
    public string? Firstname {get; set;}
    public string? Lastname {get; set;}
    public DateTime BirthDate {get; set;}
    public bool Sex {get; set;}
    public string? IdentificationId {get; set;}
    public string? PhoneNumber {get; set;}
    public string? SocialSecurity {get; set;}
    public DateTime RegistryDate {get; set;}
    public double ConsumedAmount {get; set;}
    public int PlanId {get; set;}
    public int StatusId {get; set;}

    public Domain.Affiliate ToDomain() { 
        return new Domain.Affiliate
        {
            Id = Id.ToString(),
            Firstname = Firstname,
            Lastname = Lastname,
            BirthDate = BirthDate,
            Sex = Sex,
            IdentificationId = IdentificationId,
            PhoneNumber = PhoneNumber,
            SocialSecurity = SocialSecurity,
            RegistryDate = RegistryDate,
            ConsumedAmount = ConsumedAmount,
            PlanId = PlanId.ToString(),
            StatusId = StatusId.ToString(),

        };
    }


}