using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace GOL.AcessoBD.Repositorio
{
    public class Contexto
    {
        #region Objetos Estáticos
        private static SqlConnection sqlconnection = new SqlConnection();
        private static SqlCommand comando = new SqlCommand();
        public string rodaSQL = "";
        #endregion

        #region Obter SqlConnection
        private static SqlConnection Connection()
        {
            try
            {
                //string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
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
        #endregion

        #region Executa uma instrução SQL: INSERT, UPDATE e DELETE
        public void ExecutaAtualizacao()
        {
            try
            {
                comando.Connection = Connection();
                comando.CommandText = rodaSQL;
                comando.ExecuteNonQuery();
                sqlconnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Executar Consulta SQL
        public List<T> ExecutaConsulta<T>()
        {
            try
            {
                comando.Connection = Connection();
                comando.CommandText = rodaSQL;
                comando.ExecuteScalar();

                IDataReader dtreader = comando.ExecuteReader();
                DataTable dtresult = new DataTable();
                dtresult.Load(dtreader);

                sqlconnection.Close();

                List<T> data = new List<T>();
                foreach (DataRow row in dtresult.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (System.Reflection.PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
