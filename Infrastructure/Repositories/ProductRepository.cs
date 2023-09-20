using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private List<Producto> _products;
        private string _filePath;

        public ProductRepository(IConfiguration configuration)
        {
            _filePath = configuration.GetValue<string>("productosjson") ?? string.Empty;
            _products = LoadData();
        }

        private string GetCurrentFilePath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentFilePath = Path.Combine(currentDirectory, _filePath);

            return currentFilePath;
        }

        private List<Producto> LoadData()
        {
            var products = new List<Producto>();
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                products = JsonSerializer.Deserialize<List<Producto>>(json);
            }

            return new List<Producto>();
        }

        public IEnumerable<Producto> GetAll()
        {
            return _products;
        }

        public Producto GetById(int id)
        {
            return _products.FirstOrDefault(x => x.Codigo == id)
            ?? new Producto{
                Codigo = 0,
                Nombre = "No existe",
                Precio = 0
            };
        }

        public void Add(Producto product)
        {
            var currentFilePath = GetCurrentFilePath();
            if(!File.Exists(currentFilePath))
            return;

            _products.Add(product);
            File.WriteAllText(_filePath,JsonSerializer.Serialize(_products));
        }

        public void Update(Producto updateproducto)
        {
            var currentFilePath = GetCurrentFilePath();
            if(!File.Exists(currentFilePath))
            {
                return;
            }
            var index = _products.FindIndex(x => x.Codigo == updateproducto.Codigo);

            if(index != -1)
            {
                _products[index] = updateproducto;
                File.WriteAllText(_filePath, JsonSerializer.Serialize(_products));

            }

        }

        public void Delete(int id){
            var currentFilePath = GetCurrentFilePath();
            if(!File.Exists(currentFilePath))
            {
                return;
            }
           _products.RemoveAll(x => x.Codigo == id);
           File.WriteAllText(_filePath, JsonSerializer.Serialize(_products));
        }
    }
}