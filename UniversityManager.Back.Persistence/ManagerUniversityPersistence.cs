using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Persistence.Contexts;
using UniversityManager.Back.Persistence.Interfaces;

namespace UniversityManager.Back.Persistence
{
    public class ManagerUniversityPersistence : IManagerUniversityPersistence
    {
        public readonly UniversityManagerContext _context;

        public ManagerUniversityPersistence(UniversityManagerContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
