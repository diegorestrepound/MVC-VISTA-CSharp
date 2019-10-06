using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
    public class ClsContactoMgr
    {
        ClsDatos cnGeneral = null;
        ClsContacto objContacto = null;
        DataTable tblDatos = null;

        public ClsContactoMgr(ClsContacto parObjContacto)
        {
            objContacto = parObjContacto;
        }
        public DataTable Listar()
        {
            tblDatos = new DataTable();
            try
            {
                cnGeneral = new ClsDatos();
                SqlParameter[] parParameter = new SqlParameter[1];
                parParameter[0] = new SqlParameter();
                parParameter[0].ParameterName = "@opc";
                parParameter[0].SqlDbType = SqlDbType.Int;
                parParameter[0].SqlValue = objContacto.opc;
                tblDatos = cnGeneral.RetornaTabla(parParameter, "SPContacto");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return tblDatos;
        }
        

        }
    }

