using System;
using System.Web;
using System.IO;
using System.Web.Mvc;
using SSO.SGP.AccesoADatos;

namespace SSO.SGP.Web.Helpers
{
    public static class HelperManagerFile
    {
        public static string UploadFile(int agente, HttpPostedFileBase hpf,int categoria)
        {

            try
            {
                //Directorio del adjunto
                var directorioguardar = "/SGP/RRHH/" + agente + "/" + categoria + "/";
                var directorio = System.Web.Hosting.HostingEnvironment.MapPath("~" + System.Configuration.ConfigurationManager.AppSettings["RutaArchivosLocal.path"] + directorioguardar);

                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                var ext = Path.GetExtension(hpf.FileName);
                var nombreArchivo = hpf.FileName.GetHashCode() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ext;
                var pathArchivo = directorio + nombreArchivo;

                // Si el largo del path completo excede los 259 caracteres acorta el nombre para que se ajuste al tamaño permitido
                if (pathArchivo.Length > 259)
                {
                    var excedente = pathArchivo.Length - 259;
                    nombreArchivo = nombreArchivo.Substring(0, nombreArchivo.Length - ext.Length - excedente) + ext;
                    pathArchivo = directorio + nombreArchivo;
                }
                hpf.SaveAs(pathArchivo);

                return directorioguardar + nombreArchivo;
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        public static FileStream DownloadFile(int id)
        {
            ImagenesrrhhAD oImagenesrrhh = new ImagenesrrhhAD();
            var file=oImagenesrrhh.ObtenerPorId(id);

            /*FileStream fs = File.OpenWrite(file.Imagen);*/

            return System.IO.File.Open(file.Imagen, FileMode.Open, FileAccess.Read);
        }
        public static int CheckPermissions(int idFile,int idAgente)
        {

            AgentesAD oAgente = new AgentesAD();
            var agente=oAgente.ObtenerPorId(idAgente);
            ImagenesrrhhAD oImagenesrrhh = new ImagenesrrhhAD();
            var file = oImagenesrrhh.ObtenerPorId(idFile);

            if(!File.Exists(file.Imagen))
            {
                return 0; //El archivo no existe
            }

            if (file.Categoria == 6) //Categoria 6=Certificados Médicos
            {
                if (file.Agente == agente.Id || agente.Profesion.Contains("MEDICO"))
                {
                    return 1; //Ok
                }
                else
                    return -1; //No tiene permisos 
            }
            else
                return 1; //Ok

        }

    }
}