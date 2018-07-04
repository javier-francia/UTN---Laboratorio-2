using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP4_JavierFrancia
{
    public partial class MainCorreo : Form
    {
        Correo correo;
        public MainCorreo()
        {
            InitializeComponent();
            correo = new Correo();
            ActualizarEstados();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDireccion.Text == string.Empty || mtxtTrackingID.Text.Length < 12)
            {
                MessageBox.Show("Datos incompletos.", "Error en la carga");
            }
            else
            {
                Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                nuevoPaquete.InformaEstado += paq_InformaEstado;
                nuevoPaquete.InformaException += paq_InformaException;
                try
                {
                    correo += nuevoPaquete;
                }
                catch(TrackingIdRepetidoException exception)
                {
                    MessageBox.Show(exception.Message);
                }
                
                ActualizarEstados();
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        public void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.ReferenceEquals(elemento, null))
            {
                if (elemento is Paquete)
                {
                    rtbMostrar.Text = ((Paquete)elemento).ToString();
                }
                else if (elemento is Correo)
                {
                    rtbMostrar.Text = ((Correo)elemento).MostrarDatos(((IMostrar<List<Paquete>>)elemento));
                }
                rtbMostrar.Text.GuardaString("salida");
            }
        }
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado); this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void paq_InformaException(object sender, string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete p in correo.Paquetes)
            {
                switch(p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                    default:
                        break;
                }
            }
        }

        private void MainCorreo_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
    }
}
