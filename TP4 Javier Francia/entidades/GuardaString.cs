using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this String texto, string archivo)
        {
            string pathEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathCompleto = pathEscritorio + "\\" + archivo + ".txt";
            StreamWriter sWriter = new StreamWriter(pathCompleto);
            try
            {
                sWriter.Write(archivo, true);
            }
            catch (Exception)
            {
                if (sWriter != null)
                    sWriter.Close();
                return false;
            }
            finally
            {
                if (sWriter != null)
                    sWriter.Close();
            }
            return true;
        }
    }
}
