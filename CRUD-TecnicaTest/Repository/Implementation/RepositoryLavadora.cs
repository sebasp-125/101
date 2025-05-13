using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_TecnicaTest.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TecnicaTest.Repository.Implementation
{
    public class RepositoryLavadora : IRepositoryLavadora
    {
        private readonly PruebaTecnicaContext _context;
        public RepositoryLavadora(PruebaTecnicaContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsnyc(Lavadora t)
        {
            try{
                await _context.Lavadoras.AddAsync(t);
                await _context.SaveChangesAsync();
                return true; 
            }catch{
                return false;
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            try{
                var response = await _context.Lavadoras.FindAsync(id);
                    _context.Lavadoras.Remove(response);
                    await _context.SaveChangesAsync();
                return true;
            }catch{
                return false;
            }
        }

        public async Task<List<Lavadora>> GeAlll()
        {
            try{
                return await _context.Lavadoras
                .Include(x => x.Category)
                .ToListAsync();
            }catch{
                return new List<Lavadora>();
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try{
                return await _context.Categories.ToListAsync();
            }catch{
                return new List<Category>();
            }
        }
    }
}