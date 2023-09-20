using MyProject.Infrastructure.Repositories.c;
using MyProject.Domain.Entities;
using MyProject.Infrastructure.Repositories;

namespace MyProject.Services.Features.CaSer
{
    public class CarritoServices
    {
        private readonly CarritoRepositorie _carritoRepository;
        private readonly ProductRepository _productoRepository;

        public CarritoServices(CarritoRepositorie carritoRepository, ProductRepository productoRepository)
        {
            _carritoRepository = carritoRepository;
            _productoRepository = productoRepository;
        }

        public Carrito GetCarritoById(int id)
        {
            return _carritoRepository.GetById(id);
        }

        public void AddCarrito(Carrito carrito)
        {
            _carritoRepository.Add(carrito);
        }

        public void DeleteCarrito(int id)
        {
            _carritoRepository.Delete(id);
        }

        public void AgregarProductoACarrito(int carritoId, Producto producto)
        {
            var carrito = _carritoRepository.GetById(carritoId);
            if (carrito != null)
            {
                carrito.Productos.Add(producto);
                _carritoRepository.SaveChanges();
            }
        }

        public void EliminarProductoDeCarrito(int carritoId, int productoId)
        {
            var carrito = _carritoRepository.GetById(carritoId);
            if (carrito != null)
            {
                var producto = carrito.Productos.Find(p => p.Codigo == productoId);
                if (producto != null)
                {
                    carrito.Productos.Remove(producto);
                    _carritoRepository.SaveChanges();
                }
            }
        }
    }

}
