using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.EntidadesDeNegocio;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System;
using System.Data;
using Syncrosoft.Framework.Utils.Logs;
using System.IO;
using OpenXmlPowerTools;
using DocumentFormat.OpenXml.Packaging;
using System.Drawing.Imaging;
using System.Xml.Linq;
using System.Text;

namespace SSO.SGP.Web.Areas.Expedientes.Controllers
{
    public class ModelosEscritoADMController : Controller 
    {
        private ModelosEscritoadmRN oModelosEscritoADMRN = new ModelosEscritoadmRN();
        private OrganismosRefRN oOrganismosRefRN = new OrganismosRefRN();
        private TiposModelosEscritoadmRefRN oTipos = new TiposModelosEscritoadmRefRN();
        private TiposActuacionadmRefRN oTiposActuacionADMRefRN = new TiposActuacionadmRefRN();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public DataTablesResult<ModelosEscritoadmView> getModelosEscritoADMGrilla(DataTablesParam dataTableParam)
        {
            var x = SessionHelper.OficinaActual.Value;
            return DataTablesResult.Create(this.oModelosEscritoADMRN.ObtenerParaGrilla(SessionHelper.OficinaActual.Value), dataTableParam, a => new ModelosEscritoadmView()
            {
                Id = a.Id,
                Oficina = a.Oficina,
                Titulo = a.Titulo,
                FechaAlta = a.FechaAlta,
                Tipo = a.Tipo
            });
        }

        public ActionResult Crear()
        {
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.TiposActuacionADMRef = new SelectList(oTiposActuacionADMRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Tipo = new SelectList(this.oTipos.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ModelosEscritoadm modelosescritoadm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (modelosescritoadm.CargoAutomatico == 0)
                        modelosescritoadm.CargoAutomatico = null;

                    modelosescritoadm.Usuario = SessionHelper.IdUsuario.Value;
                    modelosescritoadm.FechaAlta = DateTime.Now;
                    modelosescritoadm.FechaModifica = DateTime.Now;
                    modelosescritoadm.UsuarioModifica = SessionHelper.IdUsuario.Value;
                    oModelosEscritoADMRN.Guardar(modelosescritoadm);
                    return Json(new object[] { true, String.Format("Se guardo el modelo " + modelosescritoadm.Titulo + " satisfactoriamente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar el modelo " + modelosescritoadm.Titulo });
                }
            }
            else
            {
                return Json(new object[] { false, "Ha ocurrido un error al guardar el modelo" });
            }
        }


        [HttpPost]
        public ActionResult Editar(ModelosEscritoadm modelosescritoadm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (modelosescritoadm.CargoAutomatico == 0)
                        modelosescritoadm.CargoAutomatico = null;

                    modelosescritoadm.FechaModifica = DateTime.Now;
                    modelosescritoadm.UsuarioModifica = SessionHelper.IdUsuario.Value;

                    oModelosEscritoADMRN.Actualizar(modelosescritoadm);
                    return Json(new object[] { true, String.Format("Se actualizó el modelo " + modelosescritoadm.Titulo + " satisfactoriamente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo actualizarse el modelo " + modelosescritoadm.Titulo });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse ModelosEscritoADM" });
            }

        }

        public static void ConvertToHtml(string file, string outputDirectory)
        {
            var fi = new FileInfo(file);
            Console.WriteLine(fi.Name);
            byte[] byteArray = System.IO.File.ReadAllBytes(fi.FullName);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wDoc = WordprocessingDocument.Open(memoryStream, true))
                {

                    var destFileName = new FileInfo(fi.Name.Replace(".docx", ".html"));
                    var destFileNamecss = new FileInfo(fi.Name.Replace(".docx", ".css"));
                    if (outputDirectory != null && outputDirectory != string.Empty)
                    {
                        DirectoryInfo di = new DirectoryInfo(outputDirectory);
                        if (!di.Exists)
                        {
                            throw new OpenXmlPowerToolsException("Output directory does not exist");
                        }
                        destFileName = new FileInfo(Path.Combine(di.FullName, destFileName.Name));
                        destFileNamecss = new FileInfo(Path.Combine(di.FullName, destFileNamecss.Name));
                    }
                    var imageDirectoryName = destFileName.FullName.Substring(0, destFileName.FullName.Length - 5) + "_files";
                    int imageCounter = 0;

                    var pageTitle = fi.FullName;
                    var part = wDoc.CoreFilePropertiesPart;
                    if (part != null)
                    {
                        pageTitle = (string)part.GetXDocument().Descendants(DC.title).FirstOrDefault() ?? fi.FullName;
                    }

                    // TODO: Determine max-width from size of content area.
                    WmlToHtmlConverterSettings settings = new WmlToHtmlConverterSettings()
                    {
                        //AdditionalCss = "body { margin: 1cm auto; max-width: 20cm; padding: 0; }",
                        PageTitle = pageTitle,
                        FabricateCssClasses = true,
                        CssClassPrefix = "pt-",
                        RestrictToSupportedLanguages = false,
                        RestrictToSupportedNumberingFormats = false,

                        ImageHandler = imageInfo =>
                        {
                            DirectoryInfo localDirInfo = new DirectoryInfo(imageDirectoryName);
                            if (!localDirInfo.Exists)
                                localDirInfo.Create();
                            ++imageCounter;
                            string extension = imageInfo.ContentType.Split('/')[1].ToLower();
                            ImageFormat imageFormat = null;
                            if (extension == "png")
                                imageFormat = ImageFormat.Png;
                            else if (extension == "gif")
                                imageFormat = ImageFormat.Gif;
                            else if (extension == "bmp")
                                imageFormat = ImageFormat.Bmp;
                            else if (extension == "jpeg")
                                imageFormat = ImageFormat.Jpeg;
                            else if (extension == "tiff")
                            {
                                // Convert tiff to gif.
                                extension = "gif";
                                imageFormat = ImageFormat.Gif;
                            }
                            else if (extension == "x-wmf")
                            {
                                extension = "wmf";
                                imageFormat = ImageFormat.Wmf;
                            }

                            // If the image format isn't one that we expect, ignore it,
                            // and don't return markup for the link.
                            if (imageFormat == null)
                                return null;

                            string imageFileName = imageDirectoryName + "/image" +
                                imageCounter.ToString() + "." + extension;
                            try
                            {
                                imageInfo.Bitmap.Save(imageFileName, imageFormat);
                            }
                            catch (System.Runtime.InteropServices.ExternalException)
                            {
                                return null;
                            }
                            string imageSource = "/files/documentos/" + localDirInfo.Name + "/image" +
                                imageCounter.ToString() + "." + extension;

                            XElement img = new XElement(Xhtml.img,
                                new XAttribute(NoNamespace.src, imageSource),
                                imageInfo.ImgStyleAttribute,
                                imageInfo.AltText != null ?
                                    new XAttribute(NoNamespace.alt, imageInfo.AltText) : null);
                            return img;
                        }
                    };
                    XElement htmlElement = WmlToHtmlConverter.ConvertToHtml(wDoc, settings);

                    // Produce HTML document with <!DOCTYPE html > declaration to tell the browser
                    // we are using HTML5.
                    var html = new XDocument(
                        new XDocumentType("html", null, null, null),
                        htmlElement);

                    var css = html.Descendants().SingleOrDefault(p => p.Name.LocalName == "style");


                    // Note: the xhtml returned by ConvertToHtmlTransform contains objects of type
                    // XEntity.  PtOpenXmlUtil.cs define the XEntity class.  See
                    // http://blogs.msdn.com/ericwhite/archive/2010/01/21/writing-entity-references-using-linq-to-xml.aspx
                    // for detailed explanation.
                    //
                    // If you further transform the XML tree returned by ConvertToHtmlTransform, you
                    // must do it correctly, or entities will not be serialized properly.

                    var htmlString = html.ToString(SaveOptions.DisableFormatting);
                    System.IO.File.WriteAllText(destFileName.FullName, htmlString, Encoding.UTF8);
                    var cssString = css.ToString(SaveOptions.DisableFormatting);
                    System.IO.File.WriteAllText(destFileNamecss.FullName, cssString, Encoding.UTF8);
                }
            }
        }

        //public void GetHtml()
        //{
        //    var encoding = new System.Text.UTF8Encoding();
        //    var htm = System.IO.File.ReadAllText(Server.MapPath("~/Files/Documents/test-01.html"), encoding);
        //    byte[] data = encoding.GetBytes(htm);
        //    Response.OutputStream.Write(data, 0, data.Length);
        //    Response.OutputStream.Flush();
        //}

        [HttpGet]
        public FileResult GetHtml(string doc)
        {
            string archivo = Server.MapPath("/Files/Documentos/" + doc);
            string directorio = Server.MapPath("/") + "Files\\Documentos";
            ConvertToHtml(archivo, directorio);
            //string html = System.IO.File.ReadAllText(HttpContext.Server.MapPath("~/Files/Documentos/test-01.html"));
            return File(Server.MapPath("~/Files/Documentos/" + doc.Replace("docx", "html")), "text/html");
        }

        public ActionResult Files()
        {
            DirectoryInfo salesFTPDirectory = null;
            FileInfo[] files = null;

            try
            {
                string salesFTPPath = Server.MapPath("/") + "Files\\Documentos";
                salesFTPDirectory = new DirectoryInfo(salesFTPPath);
                files = salesFTPDirectory.GetFiles();
            }
            catch (DirectoryNotFoundException exp)
            {
                throw new DirectoryNotFoundException("Could not open the ftp directory", exp);
            }
            catch (IOException exp)
            {
                throw new DirectoryNotFoundException("Failed to access directory", exp);
            }

            var r = files.Where(f => f.Extension == ".docx" || f.Extension == ".doc")
              .OrderBy(f => f.Name)
              .Select(f => f.Name)
              .ToList();
            return View(r);
        }


        public ActionResult Editar(int id = 0)
        {
            ViewBag.OrganismosRef = new SelectList(oOrganismosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.TiposActuacionADMRef = new SelectList(oTiposActuacionADMRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Tipo = new SelectList(this.oTipos.ObtenerTodo().ToList(), "Id", "Descripcion");

            ModelosEscritoadm modelosescritoadm = oModelosEscritoADMRN.ObtenerPorId(id);
            if (modelosescritoadm == null)
            {
                return HttpNotFound();
            }
            return View(modelosescritoadm);
        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oModelosEscritoADMRN.Eliminar(id);
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el modelosescritoadm" });
            }
        }

        public JsonResult JsonT(string term)
        {
            var res = from x in this.oModelosEscritoADMRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getText(int id)
        {
            var res = oModelosEscritoADMRN.ObtenerPorId(id);
            var html = res.Contenido;
            return this.Json(html, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oModelosEscritoADMRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            oModelosEscritoADMRN.Dispose();

            oOrganismosRefRN.Dispose();

            oTiposActuacionADMRefRN.Dispose();

            base.Dispose(disposing);
        }

    } //fin de clase
}
