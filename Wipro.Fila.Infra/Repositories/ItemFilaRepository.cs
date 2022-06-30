using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wipro.Fila.Domain.Entities;
using Wipro.Fila.Domain.Repository;
using Wipro.Fila.Infra.Contexts;

namespace Wipro.Fila.Infra.Repositories
{
    public class ItemFilaRepository : IItemFileRpository
    {
        private readonly DataContext _context;

        public ItemFilaRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(ItemFila item)
        {
            _context.ItemFilas.Add(item);
            _context.SaveChanges();
        }

        public IEnumerable<ItemFila> GetAll()
        {
            return _context.ItemFilas.ToList();
               
        }

        
    }
}
