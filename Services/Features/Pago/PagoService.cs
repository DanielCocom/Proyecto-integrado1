using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class PagosService
    {
        private readonly List<Pagos> _pagos;

        public PagosService()
        {
            _pagos = new();
        }
        private readonly List<Pagos> _pago = new();

        public IEnumerable<Pagos> GetAll()
        {
            return _pago;
        }
    
    }
}