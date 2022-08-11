namespace Data.Models.Affiliate;

public class Affiliate: IBaseModel {
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


}