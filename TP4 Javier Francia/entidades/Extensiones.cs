using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Entidades
{
    public static class Extensiones
    {
        public static void GuardaString(this String stringObject, string fileName)
        {
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string pathComplete = pathDesktop + "\\" + fileName + ".txt";
            StreamWriter sWriter = null;
            try
            {
                sWriter = new StreamWriter(pathComplete);
                sWriter.WriteLine(stringObject, true);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                sWriter.Close();
            }
        }
    }
}
