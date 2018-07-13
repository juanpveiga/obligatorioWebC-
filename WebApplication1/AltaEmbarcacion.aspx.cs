using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioObligatorio;

namespace WebApplication1
{
    public partial class altaEmbarcacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarEmb_Click(object sender, EventArgs e)
        {
            string nombre = lblNombre.Text;
            DateTime fecha = DateTime.Now;
            DateTime.TryParse(lblFecha.Text, out fecha);
            int tipoMotor = 0;
            int.TryParse(txtTipoMotor.Text, out tipoMotor);
            if (nombre != "")
            {
                if (fecha != DateTime.Now)
                {
                    if (tipoMotor != 0)
                    {

                        lblMensaje.Text = EmpNaviera.Instancia.agregarEmbarcacion(nombre, fecha, tipoMotor);

                    }
                    else { lblMensaje.Text = "Debe seleccionar un tipo de motor "; }

                }else { lblMensaje.Text = "Debe ingresar una fecha"; }
            }else { lblMensaje.Text = "Debe Ingresar Nombre de la Embarcacion "; }
        }

        protected void rbnIntegrado_CheckedChanged(object sender, EventArgs e)
        {
            string tipoMotor = "";
            if (rbnIntegrado.Checked)
            {
                tipoMotor ="1";
            }
            txtTipoMotor.Text = tipoMotor;
        }

        protected void rbnFueraDeBorda_CheckedChanged(object sender, EventArgs e)
        {
            string tipoMotor = "";
            if (rbnFueraDeBorda.Checked)
            {
                tipoMotor = "2";
            }
            txtTipoMotor.Text = tipoMotor;
        }

        protected void rbnOtros_CheckedChanged(object sender, EventArgs e)
        {
            string tipoMotor = "";
            if (rbnOtros.Checked)
            {
                tipoMotor = "3";

            }
            txtTipoMotor.Text = tipoMotor;
        }
    }
}