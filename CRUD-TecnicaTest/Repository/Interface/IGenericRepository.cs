using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_TecnicaTest.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GeAlll();
        Task<bool> AddAsnyc(T t);
        Task<bool> DeleteById(int id);
    }
}