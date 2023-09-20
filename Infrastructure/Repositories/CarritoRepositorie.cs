using MyProject.Domain.Entities;
using System.Text.Json;

namespace MyProject.Infrastructure.Repositories.c{
    public class CarritoRepositorie{
        private List<Carrito> _carrito = new List<Carrito>();
        private string _filePath;

        public CarritoRepositorie(IConfiguration configuration){
            _filePath = configuration.GetValue<string>("carritosjson") ?? string.Empty;
            _carrito = LoadData();
        }
         private string GetCurrentFilePath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentFilePath = Path.Combine(currentDirectory, _filePath);

            return currentFilePath;
        }
        private List<Carrito> LoadData()
        {
            var carritosFilePath = GetCurrentFilePath();
            if (File.Exists(carritosFilePath))
            {
                var json = File.ReadAllText(carritosFilePath);
                return JsonSerializer.Deserialize<List<Carrito>>(json) ?? new List<Carrito>();
            }

            return new List<Carrito>();
        }
        public Carrito GetById(int id)
        {
            return _carrito.FirstOrDefault(x => x.Codigo == id)!;
        }
        
        public void Add(Carrito carrito)
        {
            carrito.Codigo = GenerateNewCarritoId(); // Asigna un nuevo ID al carrito
            _carrito.Add(carrito);
            SaveChanges();
        }
          public void Delete(int id)
        {
            _carrito.RemoveAll(x => x.Codigo == id);
            SaveChanges();
        }
        private int GenerateNewCarritoId()
        {
            // Implementa lógica para generar un nuevo ID único
            // Esto podría ser una secuencia numérica única o cualquier otro enfoque que prefieras.
            // Por simplicidad, aquí se usa el valor máximo existente + 1.
            return _carrito.Count > 0 ? _carrito.Max(c => c.Codigo) + 1 : 1;
        }
         public void SaveChanges()
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(_carrito));
        }

    }
}