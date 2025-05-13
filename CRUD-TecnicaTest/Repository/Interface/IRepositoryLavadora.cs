using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_TecnicaTest.Repository.Interface
{
    public interface IRepositoryLavadora : IGenericRepository<Lavadora>
    {
        Task<List<Category>> GetAllCategories();
    }
}