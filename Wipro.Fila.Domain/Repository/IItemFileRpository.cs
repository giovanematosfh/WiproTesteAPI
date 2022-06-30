using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wipro.Fila.Domain.Entities;

namespace Wipro.Fila.Domain.Repository
{


    public interface IItemFileRpository
    {
        void Create(ItemFila item);
        //void Update(TodoItem todo);
        //TodoItem GetById(Guid id, string user);
        IEnumerable<ItemFila> GetAll();
        //IEnumerable<TodoItem> GetAllDone(string user);
        //IEnumerable<TodoItem> GetAllUndone(string user);
        //IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
    }

}
