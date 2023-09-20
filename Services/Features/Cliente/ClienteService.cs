using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Domain.Entities;
using MyProject.Infrastructure.Repositories;

namespace MyProject.Services.Features.Cliente
{
    public class ClienteService
    {
        private readonly ClienteInfoRepository _repository;

        public ClienteService(ClienteInfoRepository repository)
        {
            _repository = repository;
        }

        public ClienteInfo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<ClienteInfo> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
