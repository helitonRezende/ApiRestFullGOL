using System.Collections.Generic;

namespace GOL.Repositorio.SQL
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T Add(T obj);
        T GetById(int id);
        List<T> GetAll();
        T Update(T obj);
    }
}