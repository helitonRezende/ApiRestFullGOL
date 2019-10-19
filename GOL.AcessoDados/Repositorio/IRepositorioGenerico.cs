using System.Collections.Generic;

namespace GOL.AcessoDados.Repositorio
{
    public interface IRepositorioGenerico<T> where T : class
    {
        void ExecutaAtualizacao(string sql);
        List<T> ExecutaConsulta(string sql);
    }
}
