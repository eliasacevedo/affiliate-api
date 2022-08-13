using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Estatus
{
    public class SearchEstatusFilter
    {
        public string? Id { get; set; }
        public string? Description { get; set; }

        public Data.Models.Estatus.GeneralEstatus ToData()
        {
            int.TryParse(Id, out var id);

            return new Data.Models.Estatus.GeneralEstatus()
            {
                Estatus = Description,
                Id = id
            };
        }
    }
}
