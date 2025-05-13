using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_TecnicaTest.Repository.Interface;

namespace CRUD_TecnicaTest.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepositoryLavadora _UnitOfWork_Lavadora {get;}
    }
}