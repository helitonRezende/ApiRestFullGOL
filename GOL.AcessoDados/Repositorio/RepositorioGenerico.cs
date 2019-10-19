using System;
using System.Collections.Generic;
using System.Data;

namespace GOL.AcessoDados.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {

        private readonly Contexto db;

        public RepositorioGenerico()
        {
            db = new Contexto();
        }

        public void ExecutaAtualizacao(string sql)
        {
            try
            {
                db.comando.Connection = db.Connection();
                db.comando.CommandText = sql;
                db.comando.ExecuteNonQuery();
                db.sqlconnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> ExecutaConsulta(string sql)
        {
            try
            {
                db.comando.Connection = db.Connection();
                db.comando.CommandText = sql;
                db.comando.ExecuteScalar();

                IDataReader dtreader = db.comando.ExecuteReader();
                DataTable dtresult = new DataTable();
                dtresult.Load(dtreader);

                db.sqlconnection.Close();

                List<T> data = new List<T>();
                foreach (DataRow row in dtresult.Rows)
                {
                    T item = GetItem(row);
                    data.Add(item);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static T GetItem(DataRow dr)
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