using Domain.BaseEntities;
namespace Domain;

public class Estatus: IBaseEntity {

    public Estatus()
    {

    }
    public string Id {get;set;}
    public string Description {get;set;}
}
