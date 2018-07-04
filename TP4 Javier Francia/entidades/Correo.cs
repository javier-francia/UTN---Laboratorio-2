using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                //Impl.
            }

        }

        public void FinEntregas()
        {
            foreach(Thread hilo in mockPaquetes)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> lista = (List<Paquete>)((Correo)elementos).Paquetes;

            string aux;
            StringBuilder sBuilder = new StringBuilder();

            foreach(Paquete p in lista)
            {
                aux = string.Format("{0} para {1} ({2})",p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
                sBuilder.AppendLine(aux);
            }

            return sBuilder.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete unPaquete in c.paquetes)
            {
                if (unPaquete == p)
                {
                    throw new TrackingIdRepetidoException("Este paquete ya se ingresó.");
                }
            }
            c.paquetes.Add(p);

            Thread t = new Thread(p.MockCicloDeVida);
            t.Start();
            c.mockPaquetes.Add(t);


            return c;
        }
    }
}
