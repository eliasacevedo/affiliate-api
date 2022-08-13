using Domain.BaseEntities;
using System;
namespace Domain;
public class Plan: IBaseEntity
{
    public Plan()
    {

    }

    public string Id {get;set;}
	public string Names {get;set;}
	public double CoverageAmount {get;set;}
	public DateTime RegistryDate {get;set;}
	public string StatusId {get;set;}
}
