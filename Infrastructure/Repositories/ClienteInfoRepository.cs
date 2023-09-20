using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Repositories
{
    public class ClienteInfoRepository
    {
        private  string _filepath;
        private readonly List <ClienteInfo> _usuarios;

        public ClienteInfoRepository(IConfiguration configuration)
        {
            _filepath = configuration.GetValue<string>("usersjson") ?? string.Empty;
            _usuarios = LoadData();
        }
         private string? GetCurrentFilePath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentFilePath = Path.Combine(currentDirectory, _filepath);

            return currentFilePath;
        }

        private List<ClienteInfo> LoadData()
        {
           var usuarios = GetCurrentFilePath();
            if (File.Exists(usuarios))
            {
                var json = File.ReadAllText(usuarios);
                return JsonSerializer.Deserialize<List<ClienteInfo>>(json) ?? new List<ClienteInfo>();
            }

            return new List<ClienteInfo>();
        }

        public ClienteInfo GetById(int id)
        {
            return _usuarios.FirstOrDefault(x => x.Identificador == id)!;
        }

        public IEnumerable<ClienteInfo> GetAll()
        {
            return _usuarios;
        }

       
    }
}