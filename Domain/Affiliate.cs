using Domain.BaseEntities;
namespace Domain;

public class Affiliate: IBaseEntity {
    public Affiliate()
    {

    }

    public string Id {get; set;}
    public string Firstname {get; set;}
    public string Lastname {get; set;}
    public DateTime BirthDate {get; set;}
    public bool Sex {get; set;}
    public string IdentificationId {get; set;}
    public string PhoneNumber {get; set;}
    public string SocialSecurity {get; set;}
    public DateTime RegistryDate {get; set;}
    public double ConsumedAmount {get; set;}
    public string PlanId {get; set;}
    public string StatusId {get; set;}
}