using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GOL.AcessoDados.Repositorio
{
    public class Contexto
    {
        public SqlConnection sqlconnection = new SqlConnection();
        public SqlCommand comando = new SqlCommand();

        public Contexto() : base() { }

        public SqlConnection Connection()
        {
            try
            {
                string dadosConexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;";
                sqlconnection = new SqlConnection(dadosConexao);
                if (sqlconnection.State == ConnectionState.Closed)
                {
                    sqlconnection.Open();
                }
                return sqlconnection;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
