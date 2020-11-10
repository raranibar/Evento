using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Estado { get; set; }
    }
}
