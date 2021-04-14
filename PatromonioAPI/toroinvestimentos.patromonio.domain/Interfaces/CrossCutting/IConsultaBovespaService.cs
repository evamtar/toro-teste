using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using toroinvestimentos.patromonio.domain.Entities.Model;

namespace toroinvestimentos.patromonio.domain.Interfaces.CrossCutting
{
    public interface IConsultaBovespaService
    {
        Task<BovespaExternal> ConsultaValor(BovespaExternal entity);
    }
}
