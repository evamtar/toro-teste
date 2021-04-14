using PatrimonioPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatrimonioPortal.CrossCutting.Interface
{
    public interface ILoginService
    {
        Task<LoginModel> AutenticarAsync(LoginModel entity);
    }
}
