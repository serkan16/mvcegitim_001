using OtoTamir.Data;
using OtoTamir.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTamir.Repository.Infrastructure
{
    public interface IUserRepository : IOtoTamir<User>,IDisposable
    {
        void RemoveAll(IEnumerable<User> users);
        User IsHave(string email,string password);
    }
}
