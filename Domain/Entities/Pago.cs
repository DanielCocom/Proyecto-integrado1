using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class Pagos
    {
        public int id{ get; set;}
        public required string nombre{ get; set;}

        public required string Cantidad{ get; set;}
    }
}