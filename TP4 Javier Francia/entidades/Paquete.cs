using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Campos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoException(object sender, string detalleException);
        public event DelegadoEstado InformaEstado;
        public event DelegadoException InformaException;


        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        public void MockCicloDeVida()
        {
            PaqueteDAO paq = new PaqueteDAO();
            
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(2000);
                switch (this.Estado)
                {
                    case EEstado.Ingresado:
                        this.Estado = EEstado.EnViaje;
                        break;
                    case EEstado.EnViaje:
                        this.Estado = EEstado.Entregado;
                        break;
                    default:
                        break;
                }
                InformaEstado.Invoke(this, EventArgs.Empty);
            }
            try
            {
                paq.Insertar(this);
            }
            catch (Exception e)
            {
                InformaException.Invoke(this, e.Message);
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool output = false;
            if (p1.trackingID == p2.trackingID)
                output = true;
            return output;
	    }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return MostrarDatos((IMostrar<Paquete>)this);
        }
        
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
    }
}
