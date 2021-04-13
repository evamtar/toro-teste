using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace toroinvestimentos.patromonio.domain.Entities.Model.Base
{
    public class BaseEntity
    {
        public virtual string Id { get; internal set; }

        public virtual string GeneratedID()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
