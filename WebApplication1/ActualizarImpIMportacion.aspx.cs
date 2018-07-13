using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class ActualizarImpIMportacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnActualizarIMp_Click(object sender, EventArgs e)
        {
            double imp = 0;
            double.TryParse(txtNuevoValor.Text, out imp);
            if (imp != 0)
            {
                lblMensaje.Text = EmpNaviera.Instancia.modificarImp(imp);
            }


        }
    }
}