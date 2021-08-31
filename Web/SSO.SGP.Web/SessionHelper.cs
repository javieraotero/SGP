using System;
using System.Web;
using System.Collections.Generic;

namespace SSO.SGP.Web
{
    public class SessionHelper
    {
        public static int? IdUsuario
        {
            get
            {
                if (HttpContext.Current.Session["IdUsuario"] != null)
                    return (int)HttpContext.Current.Session["IdUsuario"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["IdUsuario"] = value;
            }
        }

        public static bool CambiarClave
        {
            get
            {
                if (HttpContext.Current.Session["CambiarClave"] != null)
                    return (bool)HttpContext.Current.Session["CambiarClave"];
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["CambiarClave"] = value;
            }
        }

        public static string NombrePersona
        {
            get
            {
                if (HttpContext.Current.Session["NombrePersona"] != null)
                    return HttpContext.Current.Session["NombrePersona"].ToString();
                else
                    return  "";
            }
            set
            {
                HttpContext.Current.Session["NombrePersona"] = value;
            }
        }

        public static List<string> Roles
        {
            get
            {
                if (HttpContext.Current.Session["Roles"] != null)
                    return (List<string>)HttpContext.Current.Session["Roles"];
                else
                    return new List<string>();
            }
            set
            {
                HttpContext.Current.Session["Roles"] = value;
            }
        }

        public static string EmailAgente
        {
            get
            {
                if (HttpContext.Current.Session["EmailAgente"] != null)
                    return HttpContext.Current.Session["EmailAgente"].ToString();
                else
                    return "";
            }
            set
            {
                HttpContext.Current.Session["EmailAgente"] = value;
            }
        }


        public static string MenuDefault
        {
            get
            {
                if (HttpContext.Current.Session["MenuDefault"] != null)
                    return (string)HttpContext.Current.Session["MenuDefault"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["MenuDefault"] = value;
            }
        }

        public static int? OficinaActual
        {
            get
            {
                if (HttpContext.Current.Session["OficinaActual"] != null)
                    return (int)HttpContext.Current.Session["OficinaActual"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["OficinaActual"] = value;
            }
        }

        public static string OficinaActualDescripcion
        {
            get
            {
                if (HttpContext.Current.Session["OficinaActualDescripcion"] != null)
                    return HttpContext.Current.Session["OficinaActualDescripcion"].ToString();
                else
                    return "";
            }
            set
            {
                HttpContext.Current.Session["OficinaActualDescripcion"] = value;
            }
        }

        public static int? AmbitoActual
        {
            get
            {
                if (HttpContext.Current.Session["AmbitoActual"] != null)
                    return (int)HttpContext.Current.Session["AmbitoActual"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["AmbitoActual"] = value;
            }
        }

        public static bool UsuarioMinisterioPublico {
            get
            {
                if (HttpContext.Current.Session["UsuarioMinisterioPublico"] != null)
                    return (bool)HttpContext.Current.Session["UsuarioMinisterioPublico"];
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["UsuarioMinisterioPublico"] = value;
            }
        }

        public static int? FueroActual
        {
            get
            {
                if (HttpContext.Current.Session["FueroActual"] != null)
                    return (int)HttpContext.Current.Session["FueroActual"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["FueroActual"] = value;
            }
        }

        public static int? UnidadDeOrganizacion
        {
            get
            {
                if (HttpContext.Current.Session["UnidadDeOrganizacion"] != null)
                    return (int)HttpContext.Current.Session["UnidadDeOrganizacion"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["UnidadDeOrganizacion"] = value;
            }
        }

        public static bool AppExterna
        {
            get
            {
                if (HttpContext.Current.Session["AppExterna"] != null)
                    return (bool)HttpContext.Current.Session["AppExterna"];
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["AppExterna"] = value;
            }
        }

        public static int? IdUsuarioAppExterna
        {
            get
            {
                if (HttpContext.Current.Session["IdUsuarioAppExterna"] != null)
                    return (int)HttpContext.Current.Session["IdUsuarioAppExterna"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["IdUsuarioAppExterna"] = value;
            }
        }

        public static bool Es_Funcionario
        {
            get
            {
                if (HttpContext.Current.Session["Es_Funcionario"] != null)
                    return (bool)HttpContext.Current.Session["Es_Funcionario"];
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["Es_Funcionario"] = value;
            }
        }

        public static bool es_MP
        {
            get
            {
                if (HttpContext.Current.Session["es_MP"] != null)
                    return (bool)HttpContext.Current.Session["es_MP"];
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["es_MP"] = value;
            }
        }

        public static bool habilita_aprobar_licencia
        {
            get
            {
                if (HttpContext.Current.Session["habilita_aprobar_licencia"] != null)
                    return (bool)HttpContext.Current.Session["habilita_aprobar_licencia"];
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["habilita_aprobar_licencia"] = value;
            }
        }


        public static int Operacion_Default
        {
            get
            {
                if (HttpContext.Current.Session["Operacion_Default"] != null)
                    return (int)HttpContext.Current.Session["Operacion_Default"];
                else
                    return 0;
            }
            set
            {
                HttpContext.Current.Session["Operacion_Default"] = value;
            }
        }

        public static List<int> roles
        {
            get
            {
                if (HttpContext.Current.Session["Roles"] != null)
                    return (List<int>)HttpContext.Current.Session["Roles"];
                else
                {
                    return new List<int>();
                }
            }
            set
            {
                HttpContext.Current.Session["Roles"] = value;
            }
        }

    }
}