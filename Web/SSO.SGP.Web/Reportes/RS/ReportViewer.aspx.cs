using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.EntidadesDeNegocio;
using System.Security.Principal;
using System.Net;

namespace SSO.SGP.Web.Reportes.RS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var requestID = Request.QueryString["r"];

                SSO.SGP.EntidadesDeNegocio.Reportes request;

                request = new ReportesRN().ObtenerPorId(int.Parse(requestID));

                mainReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["rs.url"]);
                mainReportViewer.ServerReport.ReportPath = string.Format(ConfigurationManager.AppSettings["rs.folder"]+"/"+request.NombreDeArchivo);
                IReportServerCredentials irsc = new ReportViewerCredentials(ConfigurationManager.AppSettings["rs.user"], ConfigurationManager.AppSettings["rs.password"]);
                mainReportViewer.ServerReport.ReportServerCredentials = irsc;

                mainReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                mainReportViewer.ShowParameterPrompts = false;
                mainReportViewer.ShowRefreshButton = false;
                mainReportViewer.ShowWaitControlCancelLink = false;
                mainReportViewer.ShowBackButton = false;
                mainReportViewer.ShowCredentialPrompts = false;

                var parametersCollection = new List<ReportParameter>();
                foreach (var parameter in request.ReportesParametros)
                {
                    var parameterName = parameter.Nombre;
                    if (parameterName.StartsWith("@"))
                    {
                        parameterName = parameterName.Substring(1);
                    }
                    parametersCollection.Add(new ReportParameter(parameterName, Request[parameterName], false));
                }
                mainReportViewer.ServerReport.SetParameters(parametersCollection);
                mainReportViewer.ServerReport.Refresh();
            }
        }
    }

    public class ReportViewerCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
    {

        // variables locales para credenciales de autenticacion de red.
        private string _UserName;
        private string _PassWord;

        public Uri ReportServerUrl;

        public ReportViewerCredentials(string UserName, string PassWord)
        {
            _UserName = UserName;
            _PassWord = PassWord;
        }
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                return null;  // no usar ImpersonationUser
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {
                // activando credenciales de red
                return new NetworkCredential(_UserName, _PassWord);
            }
        }
        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {

            // not use FormsCredentials unless you have implements a custom autentication.
            authCookie = null;
            user = password = authority = null;
            return false;
        }

    }

}