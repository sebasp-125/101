using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_TecnicaTest.Repository.Implementation;
using CRUD_TecnicaTest.Repository.Interface;
using CRUD_TecnicaTest.UnitOfWork.Interface;

namespace CRUD_TecnicaTest.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        //This is a Context of DataBase
        private readonly PruebaTecnicaContext _context;

        //This is a Differents repositorys about this project.
        private IRepositoryLavadora _LavadoraRepository;
        public UnitOfWork(PruebaTecnicaContext context)
        {
            _context = context;
        }
        public IRepositoryLavadora _UnitOfWork_Lavadora => _LavadoraRepository ??= new RepositoryLavadora(_context);
    }
}