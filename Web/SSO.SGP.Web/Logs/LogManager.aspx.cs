using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSO.SGP.Web.Logs
{
    public partial class LogManager : System.Web.UI.Page
    {
        private string[] files;
        private FileInfo archivoInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtFechaDesde.Text = DateTime.Today.AddDays(-30).ToString("dd/MM/yyyy");
                this.txtFechaHasta.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            files = Directory.GetFiles(this.pathDestino);
            List<string> listaFiles = new List<string>();

            if (this.txtFechaDesde.Text != "" || this.txtFechaHasta.Text != "")
            {
                foreach (string file in files)
                {
                    archivoInfo = new FileInfo(file);
                    if (archivoInfo.Extension == ".txt")
                    {
                        if (this.txtFechaDesde.Text != "" && this.txtFechaHasta.Text != "")
                        {
                            if (archivoInfo.CreationTime.Date >= DateTime.Parse(this.txtFechaDesde.Text) && archivoInfo.CreationTime.Date <= DateTime.Parse(this.txtFechaHasta.Text))
                            {
                                listaFiles.Add(file);
                            }
                        }
                        if (this.txtFechaDesde.Text != "" && this.txtFechaHasta.Text == "")
                        {
                            if (archivoInfo.CreationTime.Date >= DateTime.Parse(this.txtFechaDesde.Text))
                            {
                                listaFiles.Add(file);
                            }
                        }
                        if (this.txtFechaDesde.Text == "" && this.txtFechaHasta.Text != "")
                        {
                            if (archivoInfo.CreationTime.Date <= DateTime.Parse(this.txtFechaHasta.Text))
                            {
                                listaFiles.Add(file);
                            }
                        }
                    }
                    dtlArchivosLog.DataSource = listaFiles;
                }
            }
            else
            {
                dtlArchivosLog.DataSource = files;
            }

            dtlArchivosLog.DataBind();
        }

        protected void dtlArchivosLog_OnItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                archivoInfo = new FileInfo(e.Item.DataItem.ToString());

                Label nombreDoc = (Label)e.Item.FindControl("lblArchivo");
                nombreDoc.Text = archivoInfo.Name;

                HyperLink linkDoc = (HyperLink)e.Item.FindControl("lnkArchivo");
                linkDoc.NavigateUrl = this.pathDestinoRelativo + "/" + nombreDoc.Text;

                Label pesoDoc = (Label)e.Item.FindControl("lblPesoArchivo");
                pesoDoc.Text = archivoInfo.Length.ToString() + " bytes";
            }
        }

        public string pathDestino
        {
            get
            {
                return Server.MapPath("~" + ConfigurationManager.AppSettings["LogFilePath"]);
            }
        }

        public string pathDestinoRelativo
        {
            get
            {
                return ConfigurationManager.AppSettings["LogFilePath"];
            }
        }

    }
}