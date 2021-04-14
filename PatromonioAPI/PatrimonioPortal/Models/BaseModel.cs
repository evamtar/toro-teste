using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatrimonioPortal.Models
{
    public class BaseModel
    {
        public bool HasErrors { get; set; }

        public string ErrorTitle { get; set; }

        public string ErrorMessage { get; set; }
    }
}
