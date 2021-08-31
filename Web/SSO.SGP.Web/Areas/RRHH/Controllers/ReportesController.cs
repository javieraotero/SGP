using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.EntidadesDeNegocio;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using OfficeOpenXml;
using SSO.SGP.AccesoADatos;
using iTextSharp.text;
using Syncrosoft.Framework.Controles.MvcRazorToPdf;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
    public class ReportesController : Controller
    {
        private CargosRefRN oCargosRef = new CargosRefRN();
        private NombramientosRN oNombramientos = new NombramientosRN();
        private OrganismosRefRN oOrganismos = new OrganismosRefRN();
        private UsuariosAD oUsuariosRN = new UsuariosAD();

        public ActionResult ExportToExcel()
        {
            var x = oCargosRef.PlantaDePersonal();

            var products = new System.Data.DataTable("teste");
            products.Columns.Add("Codigo", typeof(int));
            products.Columns.Add("Cargo", typeof(string));
            products.Columns.Add("Presupuesto", typeof(int));
            products.Columns.Add("Cargos", typeof(int));
            products.Columns.Add("Vacantes", typeof(int));
            products.Columns.Add("Contratados", typeof(int));
            products.Columns.Add("Saldo", typeof(int));
            products.Columns.Add("Sustitutos", typeof(int));


            foreach (var i in x)
            {
                products.Rows.Add(i.Id, i.Descripcion, i.Presupuesto, i.PlantaPermanente, i.Vacantes, i.Contratados, i.Saldo, i.Sustitutos);
            }

            //products.Rows.Add(1, "product 1");

            var grid = new GridView();
            grid.DataSource = products;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return View();
        }

        public ActionResult Nombramientos()
        {
            return View();
        }

        public ActionResult TurnosPDF(int? organismo, string desde, string hasta)
        {
            var oTurnos = new SSO.SGP.AccesoADatos.TurnosWebAD();

            DateTime? fdesde = null;
            DateTime? fhasta = null;

            if (!string.IsNullOrEmpty(desde))
            {
                fdesde = DateTime.Parse(desde).Date.Add(new TimeSpan(0, 0, 0));
            }

            if (!string.IsNullOrEmpty(hasta))
            {
                fhasta = DateTime.Parse(hasta).Date.Add(new TimeSpan(23, 59, 59));
            }

            var res = oTurnos.ObtenerParaGrilla(organismo, fdesde, fhasta, SessionHelper.IdUsuario.Value,-1).Where(x => x.Contactar == "NO").OrderBy(x => x.Id).ToList();


            //pdf.ViewBag.PendienteFianza = r.Where(p => p.FianzaADevolver.HasValue && !p.FechaDevolucionFianza.HasValue).Sum(p => p.FianzaADevolver);
            //pdf.ViewBag.PendientePropietario = r.Where(p => (!p.FechaPagoPropietario.HasValue)).Sum(p => p.PagarPropietarioPorEstancia);
            ViewBag.Title = "Turnos";
            //ViewBag.UnidadNegocio = UnidadNegocio;
            //ViewBag.LogoEncabezado = System.Configuration.ConfigurationManager.AppSettings["PathLogoEncabezadoPDF"] + UnidadNegocio.LogoEncabezadoPDF;
            // return pdf;

            return new PdfActionResult(res, (writer, document) =>
            {
                document.SetMargins(50, 36, 36, 36);
                document.SetPageSize(PageSize.A4);
                document.NewPage();
            });
        }

        public ActionResult TurnosContactarPDF(int? organismo)
        {
            var oTurnos = new SSO.SGP.AccesoADatos.TurnosWebAD();

            DateTime? fdesde = null;
            DateTime? fhasta = null;


            var res = oTurnos.ObtenerParaGrilla(organismo, fdesde, fhasta, SessionHelper.IdUsuario.Value,-1).Where(x => x.Contactar == "SI").OrderBy(x => x.Id).ToList();


            //pdf.ViewBag.PendienteFianza = r.Where(p => p.FianzaADevolver.HasValue && !p.FechaDevolucionFianza.HasValue).Sum(p => p.FianzaADevolver);
            //pdf.ViewBag.PendientePropietario = r.Where(p => (!p.FechaPagoPropietario.HasValue)).Sum(p => p.PagarPropietarioPorEstancia);
            ViewBag.Title = "Turnos";
            //ViewBag.UnidadNegocio = UnidadNegocio;
            //ViewBag.LogoEncabezado = System.Configuration.ConfigurationManager.AppSettings["PathLogoEncabezadoPDF"] + UnidadNegocio.LogoEncabezadoPDF;
            // return pdf;

            return new PdfActionResult(res, (writer, document) =>
            {
                document.SetMargins(50, 36, 36, 36);
                document.SetPageSize(PageSize.A4);
                document.NewPage();
            });
        }

        public ActionResult ActividadDocente()
        {
            return View();
        }

        public ActionResult Licencias()
        {
            return View();
        }

        public ActionResult LicenciasPorOrganismo()
        {
            return View();
        }

        public ActionResult PlantaPersonal()
        {
            return View();
        }

        public ActionResult FuncionariosConLicencia()
        {
            return View();
        }

        public ActionResult RenunciaCondicionada()
        {
            return View();
        }

        public ActionResult PersonalDadoDeBaja()
        {
            return View();
        }

        public ActionResult AscensosPorCategoria()
        {
            ViewBag.Categoria = new SelectList(oCargosRef.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        public ActionResult PersonalAscendido()
        {
            ViewBag.Categoria = new SelectList(oCargosRef.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        public ActionResult PersonalAPlanta()
        {
            ViewBag.Categoria = new SelectList(oCargosRef.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        public ActionResult PersonalContratado()
        {
            ViewBag.Categoria = new SelectList(oCargosRef.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        public ActionResult PersonalSustituto()
        {
            ViewBag.Categoria = new SelectList(oCargosRef.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        public ActionResult PersonalRenuncia()
        {
            //ViewBag.Categoria = new SelectList(oCargosRef.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        public ActionResult PersonalPorOrganismo()
        {
            ViewBag.Organismos = new SelectList(this.oOrganismos.ObtenerRRHH().ToList(), "Id", "Descripcion");
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Dashboard()
        {

            var v = new CustomDashboard()
            {
                TotalContratados = this.oNombramientos.TotalContratado(),
                TotalPlantaPermanente = this.oNombramientos.TotalPlantaPermanente(),
                TotalEnLicencia = this.oNombramientos.TotalEnLicencia(),
                TotalSustitutos = this.oNombramientos.TotalSustitutos()
            };

            return View(v);
        }

        public ActionResult Excel(string query, string filename)
        {
            string[] blackList = { ";", "delete", "update", "create", "drop", "exec", "xp_cmdshell" };
            bool isValid = !blackList.Any(s => query.Contains(s));

            if (!isValid)
                return this.Json(new { resultado = false, mensaje = "Instrucción no permitida" }, JsonRequestBehavior.AllowGet);

            string titulo = filename.ToUpper() + " - " + DateTime.Now.ToShortDateString();

            var res = this.oUsuariosRN.ObtenerConsulta(query);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Hoja1");

            workSheet.Cells[1, 1].Style.Font.Bold = true;
            workSheet.Cells[1, 1].Style.Font.Size = 14;
            workSheet.Cells[1, 1].Value = titulo;

            using (ExcelRange rng = workSheet.Cells["A1:A" + res.columnas.Count()])
            {
                bool merge = rng.Merge;
            }

            for (int col = 1; col <= res.columnas.Count(); col++)
            {
                workSheet.Cells[3, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[3, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                workSheet.Cells[3, col].Style.Font.Bold = true;
                workSheet.Cells[3, col].Value = res.columnas[col - 1];

                for (int row = 4; row <= res.resultado.Count() + 3; row++)
                {
                    if (res.columnas[col - 1].ToLower().Contains("fecha"))
                    {
                        workSheet.Cells[row, col].Style.Numberformat.Format = "dd/MM/yyyy";
                    }

                    workSheet.Cells[row, col].Value = res.resultado[row - 4][col - 1];
                }
                workSheet.Cells[1, col].AutoFitColumns();
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + filename + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

            return this.Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExcelSinTitulo(string query, string filename)
        {
            string[] blackList = { ";", "delete", "update", "create", "drop", "exec", "xp_cmdshell" };
            bool isValid = !blackList.Any(s => query.Contains(s));

            if (!isValid)
                return this.Json(new { resultado = false, mensaje = "Instrucción no permitida" }, JsonRequestBehavior.AllowGet);

            string titulo = filename.ToUpper() + " - " + DateTime.Now.ToShortDateString();

            var res = this.oUsuariosRN.ObtenerConsulta(query);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Hoja1");

            //workSheet.Cells[1, 1].Style.Font.Bold = true;
            //workSheet.Cells[1, 1].Style.Font.Size = 14;
            //workSheet.Cells[1, 1].Value = titulo;

            using (ExcelRange rng = workSheet.Cells["A1:A" + res.columnas.Count()])
            {
                bool merge = rng.Merge;
            }

            for (int col = 1; col <= res.columnas.Count(); col++)
            {
                workSheet.Cells[1, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[1, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                workSheet.Cells[1, col].Style.Font.Bold = true;
                workSheet.Cells[1, col].Value = res.columnas[col - 1];

                for (int row = 2; row <= res.resultado.Count() + 1; row++)
                {
                    if (res.columnas[col - 1].ToLower().Contains("fecha"))
                    {
                        workSheet.Cells[row, col].Style.Numberformat.Format = "dd/MM/yyyy";
                    }

                    workSheet.Cells[row, col].Value = res.resultado[row - 2][col - 1];
                }
                workSheet.Cells[1, col].AutoFitColumns();
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + filename + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

            return this.Json(true, JsonRequestBehavior.AllowGet);
        }

        public FileResult toText(string query, string filename)
        {
            string[] blackList = { ";", "delete", "update", "create", "drop", "exec", "xp_cmdshell" };
            bool isValid = !blackList.Any(s => query.Contains(s));

            //if (!isValid)
            //    return this.Json(new { resultado = false, mensaje = "Instrucción no permitida" }, JsonRequestBehavior.AllowGet);

            string titulo = filename.ToUpper() + " - " + DateTime.Now.ToShortDateString();

            var res = this.oUsuariosRN.ObtenerConsulta(query);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Hoja1");

            //workSheet.Cells[1, 1].Style.Font.Bold = true;
            //workSheet.Cells[1, 1].Style.Font.Size = 14;
            //workSheet.Cells[1, 1].Value = titulo;

            var nombre = Server.MapPath(@"/Files/test.txt");

            using (TextWriter tw = new StreamWriter(Server.MapPath(@"/Files/test.txt")))
            {
                for (int row = 2; row <= res.resultado.Count() + 1; row++)
                {
                    string s = "";
                    for (int col = 1; col <= res.columnas.Count(); col++)
                    {
                        s += res.resultado[row - 2][col - 1] + ";";
                    }
                    tw.WriteLine(s.Substring(0, s.Length-1));
                }                                 
            }

            return File(nombre, "text/plain");

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlPathEncode(fileName));
            //Response.Charset = "";
            //Response.ContentType = fileType;
            //Response.Output.Write(tw.);
            //Response.Flush();
            //Response.End();

            //using (var memoryStream = new MemoryStream())
            //{
            //    Response.ContentType = "text/html; charset=utf-8";
            //    Response.AddHeader("content-disposition", "attachment;  filename=" + filename + ".txt");
            //    //excel.SaveAs(memoryStream);
            //    memoryStream.WriteTo(Response.OutputStream);
            //    Response.Flush();
            //    Response.End();
            //}

            //return this.Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExcelConTitulo(string query, string filename, string titulo)
        {
            string[] blackList = { ";", "delete", "update", "create", "drop", "exec", "xp_cmdshell" };
            bool isValid = !blackList.Any(s => query.Contains(s));

            if (!isValid)
                return this.Json(new { resultado = false, mensaje = "Instrucción no permitida" }, JsonRequestBehavior.AllowGet);

            // string titulo = filename.ToUpper() + " - " + DateTime.Now.ToShortDateString();

            titulo += " - " + DateTime.Now.ToShortDateString();

            var res = this.oUsuariosRN.ObtenerConsulta(query);

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Hoja1");

            workSheet.Cells[1, 1].Style.Font.Bold = true;
            workSheet.Cells[1, 1].Style.Font.Size = 14;
            workSheet.Cells[1, 1].Value = titulo;

            using (ExcelRange rng = workSheet.Cells["A1:A" + res.columnas.Count()])
            {
                bool merge = rng.Merge;
            }

            for (int col = 1; col <= res.columnas.Count(); col++)
            {
                workSheet.Cells[3, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[3, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                workSheet.Cells[3, col].Style.Font.Bold = true;
                workSheet.Cells[3, col].Value = res.columnas[col - 1];

                for (int row = 4; row <= res.resultado.Count() + 3; row++)
                {
                    if (res.columnas[col - 1].ToLower().Contains("fecha"))
                    {
                        workSheet.Cells[row, col].Style.Numberformat.Format = "dd/MM/yyyy";
                    }

                    workSheet.Cells[row, col].Value = res.resultado[row - 4][col - 1];
                }
                workSheet.Cells[1, col].AutoFitColumns();
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + filename + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

            return this.Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Excel2(string query, int organismo, string filename)
        {
            string[] blackList = { ";", "delete", "update", "create", "drop", "exec", "xp_cmdshell" };
            bool isValid = !blackList.Any(s => query.Contains(s));

            if (!isValid)
                return this.Json(new { resultado = false, mensaje = "Instrucción no permitida" }, JsonRequestBehavior.AllowGet);

            string titulo = filename.ToUpper() + " - " + DateTime.Now.ToShortDateString();

            ExcelPackage excel = new ExcelPackage();

            var agentes = oOrganismos.ObtenerAgentes(organismo).ToList();

            foreach (var a in agentes)
            {
                var workSheet = excel.Workbook.Worksheets.Add(a.Personas.Apellidos.Trim() + ", " + a.Personas.Nombres.Trim());

                var res = this.oUsuariosRN.ObtenerConsulta(query + " and idagente = " + a.Id.ToString());

                workSheet.Cells[1, 1].Style.Font.Bold = true;
                workSheet.Cells[1, 1].Style.Font.Size = 14;
                workSheet.Cells[1, 1].Value = titulo;

                using (ExcelRange rng = workSheet.Cells["A1:A" + res.columnas.Count()])
                {
                    bool merge = rng.Merge;
                }

                for (int col = 1; col <= res.columnas.Count(); col++)
                {
                    workSheet.Cells[3, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    workSheet.Cells[3, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                    workSheet.Cells[3, col].Style.Font.Bold = true;
                    workSheet.Cells[3, col].Value = res.columnas[col - 1];

                    for (int row = 4; row <= res.resultado.Count() + 3; row++)
                    {
                        if (res.columnas[col - 1].ToLower().Contains("fecha"))
                        {
                            workSheet.Cells[row, col].Style.Numberformat.Format = "dd/MM/yyyy";
                        }

                        workSheet.Cells[row, col].Value = res.resultado[row - 4][col - 1];
                    }
                    workSheet.Cells[1, col].AutoFitColumns();
                }
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=" + filename + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

            return this.Json(true, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            oCargosRef.Dispose();
            base.Dispose(disposing);
        }

    }
}
