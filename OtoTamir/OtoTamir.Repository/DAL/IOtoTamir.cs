using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTamir.Repository.DAL
{
    public interface IOtoTamir<T> : IDisposable
    {
        IEnumerable<T> GetAll();

        T GetDetailByID(int id);

        void Insert(T obj);

        void Delete(int id);

        
        void Update(T obj);

        void Save();
    }
}
