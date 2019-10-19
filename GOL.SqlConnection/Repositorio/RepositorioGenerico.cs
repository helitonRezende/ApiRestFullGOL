using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL.SqlConnection.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {

        public T Add(T obj)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
