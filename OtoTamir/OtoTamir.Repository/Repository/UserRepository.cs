using OtoTamir.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTamir.Repository.Repository
{
    public class UserRepository : IUserRepository,IDisposable
    {
        private OtoTamirDBEntities db;
        public UserRepository(OtoTamirDBEntities db)
        {
            this.db = db;
        }
        public void Delete(int id)
        {
            db.Users.Remove(db.Users.Find(id));
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetDetailByID(int id)
        {
            return db.Users.Find(id);
        }

        public void Insert(User obj)
        {
            db.Users.Add(obj);
        }

        public User IsHave(string email,string password)
        {
            User obj = db.Users.Where(x => x.Email == email && x.Sifre == password).FirstOrDefault();
            if (obj != null) return obj;
            else return null;
        }

        public void RemoveAll(IEnumerable<User> users)
        {
            db.Users.RemoveRange(users);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
