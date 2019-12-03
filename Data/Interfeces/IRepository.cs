using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Models
{
    public interface IRepository<T>
    {
        // Retrives one item from table.
        T Get(int id);
        T Create(T item);
        T Delete(int id);
        T Update(T itemChanges);

        // Retrives list of items in existing table.
        IEnumerable<T> GetList();
    }
}
