using MyProject.Domain.Entities;

namespace MyProject.Services.Features.Productos
{
    public class ProductoServices
    {
        // esto puede estar mal, por que estoy instancias la lista dos veces
        private readonly List<Producto> _producto = new();

        public ProductoServices()
        {
            _producto = new();
        }
        public IEnumerable<Producto> GetAll()
        {
            return _producto;
        }
        public Producto GetProductoByID(int Codigo)
        {
            // lanzar una exepcion o algo para mostrar que no existe tal producto
            return _producto.FirstOrDefault(Producto => Producto.Codigo == Codigo)!;
        }
        public void Add(Producto producto)
        {
            // a ca podemos hacer otra clase donde llamemos a nuestro carrito de compras, y agregamos el producto ahi
            _producto.Add(producto);
        }
        public void Update(Producto producto)
        {
            var productoExiste= GetProductoByID(producto.Codigo);
            if(productoExiste != null){
                _producto.Remove(productoExiste);
                _producto.Add(producto);
            }
        }
        public void Delete(int Codigo){
            var producto = GetProductoByID(Codigo);
            if(producto != null){
                _producto.Remove(producto);
            }
        }

    }
}


