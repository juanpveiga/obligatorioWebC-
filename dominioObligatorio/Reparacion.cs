using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioObligatorio
{
    public class Reparacion
    {
        #region Atributos
       
        private DateTime fechaIng;
        private DateTime fechaPromEnt;
        private DateTime fechaRealEnt;
        private List<Mecanico> mecAsignados = new List<Mecanico>();
        private List<MatUtilizado> matUtilizados = new List<MatUtilizado>();
        private bool pendiente;
        #endregion

        #region Propiedades

        public bool Pendiente
        {
            get { return pendiente; }
            set { pendiente = value; }
        }

        public DateTime FechaIng
        {
            get { return fechaIng; }
        }

        public DateTime FechaPromEnt
        {
            get { return this.fechaPromEnt; }
        }

        public DateTime FechaRealEnt
        {
            get { return fechaRealEnt; }
            set { this.fechaRealEnt = value; }
        }

        /*public int IdRep
        {
            get { return idRep; }
        }*/

        public List<Mecanico> MecAsignados
        {
            get { return this.mecAsignados; }
        }

        public List<MatUtilizado> MatUtilizados
        {
            get { return this.matUtilizados; }
        }
        #endregion

        #region Constructor
        public Reparacion(DateTime fechaIng, DateTime fechaPromEnt)
        {
            /*this.idRep = Reparacion.ultIdRep;
            Reparacion.ultIdRep++;*/
            this.fechaIng = fechaIng;
            this.fechaPromEnt = fechaPromEnt;
            this.fechaRealEnt = new DateTime();
            this.pendiente = false;
            DateTime.TryParse("01 / 01 / 0001", out fechaRealEnt);
        }


        #endregion

        #region Metodos

        public bool valorarPendiente()
        {
            bool esta = false;
            if(mecAsignados.Count != 0 && matUtilizados.Count != 0)
            {
                esta = true;
            }
            return esta;
        }
        public bool agregarMatAlista(double cantidad, Material m)
        {
            bool agregado = false;
            int cantMat = matUtilizados.Count;

            MatUtilizado mu = new MatUtilizado(cantidad, m);
            matUtilizados.Add(mu);

            if (matUtilizados.Count > cantMat)
            {
                agregado = true;
                Pendiente = valorarPendiente(); // Actualiza el estado pendiente de la reparacion si es true ya tiene 1 mec y un mat asignados
            }
            return agregado;
        }

        public bool agregarMecAlista(Mecanico m)
        {
            bool agregado = false;
            int cantMec = mecAsignados.Count;
      
        
            mecAsignados.Add(m);
            if (mecAsignados.Count > cantMec)
            {
                agregado = true;
                Pendiente = valorarPendiente();// Actualiza el estado pendiente de la reparacion si es true ya tiene 1 mec y un mat asignados
            }
            return agregado;
        }

        

        public bool estaMecanico(Mecanico mec)//confirma si el mecanico esta en la lista de mecanicos asignados de la reparacion no finalizada
        {
            bool esta = false;

            if (mecAsignados.Contains(mec))
            {
                esta = true;
            }

            return esta;
        }

        public string entrega(DateTime fechaEnt)//finaliza la reparacion, asigna una fecha de entrega real
        {
            string salida = "La fecha de entrega se ingreso de forma erronea.\n No puede ser menor que la fecha ingreso.";

            if (fechaEnt.CompareTo(this.fechaIng) == 1)
            {
                this.FechaRealEnt = fechaEnt;
                salida = "Se a entregado la reparacion con fecha " + this.FechaRealEnt + ".";
            }
            return salida;
        }
        public double calcularCostoReparacion()
        {
            double costoRep = 0;
            int diasJornal = this.fechaIng.Subtract(this.fechaRealEnt).Days;

            foreach (MatUtilizado mU in matUtilizados)
            {
                costoRep += mU.calcularCostoMatUtil();
            }

            foreach (Mecanico m in mecAsignados)
            {
                costoRep += diasJornal * m.ValorJornal;
            }

            return costoRep;
        }

       


        public override string ToString()
        {
            return /*"IdRep: " + this.idRep + */" Fecha de ingreso: " + this.fechaIng;
        }



        #endregion
    }
}
