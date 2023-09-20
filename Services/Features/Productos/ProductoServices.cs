using MyProject.Domain.Entities;
using MyProject.Infrastructure.Repositories;

namespace MyProject.Services.Features.Productos
{
    public class ProductoServices
    {
        // esto puede estar mal, por que estoy instancias la lista dos veces
        private readonly ProductRepository _productoRepository;

        public ProductoServices(ProductRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public IEnumerable<Producto> GetAll()
        {
            return _productoRepository.GetAll();
        }
        public Producto GetById(int Codigo)
        {
            // lanzar una exepcion o algo para mostrar que no existe tal producto
           return _productoRepository.GetById(Codigo);
        }
        public void Add(Producto producto)
        {
            // a ca podemos hacer otra clase donde llamemos a nuestro carrito de compras, y agregamos el producto ahi
            _productoRepository.Add(producto);
        }
        public void Update(Producto productoToUpdate)
        {
           var producto = GetById(productoToUpdate.Codigo);
           if(producto.Codigo >0)
           {
            _productoRepository.Update(productoToUpdate);

           }
        }
        public void Delete(int Codigo){
            var producto = GetById(Codigo);
            if(producto.Codigo > 0){
                _productoRepository.Delete(Codigo);
            }
        }

    }
}


