using System.IO;

namespace SSO.SGP.EntidadesDeNegocio.Results
{
    public class ImagenResult
    {
        public int status { get; set; } // 1 OK -1 NO PERMITDO // 0 NO EXISTE
        public FileStream imagen { get; set; }
    }
}
