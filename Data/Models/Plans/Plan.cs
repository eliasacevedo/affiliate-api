namespace Data.Models.Plans;
public class Plan: IBaseModel
{
    public Plan()
    {

    }

    public int Id {get;set;}
	public string Names {get;set;}
	public double CoverageAmount {get;set;}
	public DateTime RegistryDate {get;set;}
	public int StatusId {get;set;}
}
