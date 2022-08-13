namespace Data.Models.Estatus;

public class GeneralEstatus: IBaseModel {
    public GeneralEstatus()
    {

    }
    public GeneralEstatus(Domain.Estatus estatus)
    {
        if (estatus == null)
        {
            return;
        }

        int.TryParse(estatus.Id, out var id);
        Id = id;
        Estatus = estatus.Description;
    }

    public Domain.Estatus ToDomain()
    {
        return new Domain.Estatus()
        {
            Description = Estatus,
            Id = Id.ToString()
        };
    }
    public int Id {get;set;}
    public string Estatus {get;set;}
}
