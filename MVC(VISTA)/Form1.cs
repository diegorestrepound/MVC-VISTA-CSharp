using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;


namespace MVC_VISTA_
{
    public partial class Form1 : Form
    {
        ClsContacto objContacto = null;
        ClsContactoMgr objContactoMgr = null;
        DataTable Dtt;

        public Form1()
        {
            InitializeComponent();
        }
        private void Listar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 1;
            objContactoMgr = new ClsContactoMgr(objContacto);

            Dtt = new DataTable();
            Dtt = objContactoMgr.Listar();
            if (Dtt.Rows.Count > 0)
            {
                dtregistros.DataSource = Dtt;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
