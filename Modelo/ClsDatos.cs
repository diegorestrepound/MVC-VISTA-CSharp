using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class ClsDatos
    {
        #region Declaracion de variables
        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter daAdaptador = null;
        DataTable Dtt = null;
        String strCadenaConexion = string.Empty;
        #endregion

        #region Constructor
        public ClsDatos()
        {
            strCadenaConexion = @"Data Source=SALA403-20\SQLEXPRESS;Initial Catalog=Contacto;Integrated Security=True";
        }
        #endregion

        #region Metodos a ejecutar
        public void EjecutarSP(SqlParameter[] parParametros,string pasSPName)
        {

        }
        public DataTable RetornaTabla(SqlParameter[] parParametros, string parTSQL)
        {
            Dtt = null;
            try
            {
                Dtt = new DataTable();
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parTSQL;
                cmdComando.Parameters.AddRange(parParametros);

                daAdaptador = new SqlDataAdapter(cmdComando);
                daAdaptador.Fill(Dtt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                daAdaptador.Dispose();
            }
            return Dtt;
        }
        #endregion 
    }
}
