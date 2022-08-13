using DTOs;
using DTOs.Estatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.Estatus
{
    public interface IEstatusLogic
    {
        Task<IEnumerable<Domain.Estatus>> GetEstatus(SearchEstatusFilter? filter);
    }
}
