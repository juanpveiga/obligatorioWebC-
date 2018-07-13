using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public class Embarcacion
    {
        #region atributos
        private int idEmb;
        private static int ultIdEmb = 1;
        private string nombre;
        private DateTime fechaConst;
        private TipoMotor tipoMotor;
        private List<Reparacion> reparaciones = new List<Reparacion>();

        #endregion

        #region Propiedades
        public int IdEmb
        {
            get { return this.idEmb; }
        }

        public string Nombre
        {
            get { return this.nombre; }
        }

        #endregion

        #region constructor

        public Embarcacion(string nombre, DateTime fechaConst, TipoMotor tipoMotor)
        {
            this.idEmb = Embarcacion.ultIdEmb;
            Embarcacion.ultIdEmb++;
            this.nombre = nombre;
            this.fechaConst = fechaConst;
            this.tipoMotor = tipoMotor;
        }
        #endregion

        #region Metodos Embarcacion
        public override string ToString()
        {
            return "El id es: " + this.idEmb + " El nombre de la embarcacion es: " + this.nombre + "\n";
        }
        #endregion

        #region Metodos de Reparacion
        public bool agregarReparacion(DateTime fechaIng, DateTime fechaPromEnt)
        {
            bool agregado = false;
            int cantRep = reparaciones.Count;
            Reparacion r = new Reparacion(fechaIng, fechaPromEnt);
            reparaciones.Add(r);

            if (reparaciones.Count > cantRep)
            {
                agregado = true;
            }

            return agregado;
        }

      

      

       

       

        public Reparacion buscarRepNoFin()
        {
            int i = 0;
            Reparacion r = null;
            DateTime mifecha = new DateTime();
            DateTime.TryParse("01 / 01 / 0001", out mifecha);

            while (i < reparaciones.Count && r == null)
            {
                

                if (reparaciones[i].FechaRealEnt == mifecha)
                {
                    r = reparaciones[i];
                }
                i++;
            }
            return r;
        }

        public bool verifDipsMec(Mecanico mec)
        {
            bool disponible = true;

            Reparacion r = buscarRepNoFin();
            if (r != null)
            {
                
                if (r.estaMecanico(mec))
                {
                   
                    disponible = false;
                }
            }
                return disponible;
            }
        

        public string agregarMat(Material material, double cantidad)
        {
            string salida = "El material no se pudo agregar";
            Reparacion r = buscarRepNoFin();

            if (r != null)
            {

                if (r.agregarMatAlista(cantidad, material))
                {
                    salida = "El material se agrego correctamente.";
                }
            }
            else
            {
                salida = "No se encontro la reparacion";
            }

            return salida;
        }

        public string agregarMec(Mecanico mec)
        {
            string salida = "Error al agregar mecanico";
            Reparacion r = buscarRepNoFin();

            if (r != null)
            {
                if (r.agregarMecAlista(mec))
                {
                    salida = "El mecanico se agrego correctamente.";
                }
            }
            else
            {
                salida = "No se encontro la reparacion";
            }

            return salida;
        }

       

      

        public string entregaRep(DateTime fechaEntrega)//finaliza la reparacion de la embarcacion
        {
            string salida = "Ingreso de forma erronea la fecha de ingreso de la reparacion a entregar.";
            Reparacion r = buscarRepNoFin();

            salida = r.entrega(fechaEntrega);

            return salida;
        }
    }
    #endregion

}



