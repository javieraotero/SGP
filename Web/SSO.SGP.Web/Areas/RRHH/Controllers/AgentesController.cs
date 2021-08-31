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
using SSO.SGP.EntidadesDeNegocio.Results;
using SSO.SGP.Web.BasicConsumer;
using SSO.SGP.AccesoADatos;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using Manatee.Trello.ManateeJson;
using Manatee.Trello;
using Manatee.Trello.WebApi;
using SSO.SGP.Web.Controllers;
using System.Net;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Globalization;
using DocumentFormat.OpenXml;

namespace SSO.SGP.Web.Areas.RRHH.Controllers
{
    public class AgentesController : Controller
    {
        private AgentesRN oAgentesRN = new AgentesRN();
        private CargosRefRN oCargosRefRN = new CargosRefRN();
        private LocalidadesRefRN oLocalidadesRN = new LocalidadesRefRN();
        private OrganismosRefRN oOrganismosRN = new OrganismosRefRN();
        private ParametrosadmRN oParametrosRN = new ParametrosadmRN();
        private PersonasRN oPersonasRN = new PersonasRN();
        private AgentesAD oAgentes = new AgentesAD();
        private CesidaParametrosDeMovimientosAD oParametrosDeMovimiento = new CesidaParametrosDeMovimientosAD();
        private AgentesBonificacionesAD oBonificaciones = new AgentesBonificacionesAD();
        private CesidaCategoriasAD oCesidaCategorias = new CesidaCategoriasAD();
        private CesidaMovimientoAgentesAD oCesidaMovimientosAgente = new CesidaMovimientoAgentesAD();
        private TurnosWebAD oTurnos = new TurnosWebAD();

        private BDEntities db = new BDEntities();

        #region Results

        public JsonResult login(string device_id, int legajo)
        {
            return this.Json(oAgentesRN.validarApp(device_id, legajo), JsonRequestBehavior.AllowGet);
        }

        //public JsonResult testMovimiento() {

        //   Service.post<>


        //}

        public JsonResult deviceEnabled(string device_id)
        {

            var res = new Result();

            if (this.oAgentesRN.deviceEnabled(device_id))
            {
                res.state = true;
                res.message = "Dispositivo habilitado";
                res.exception = "";
            }
            else
            {
                res.state = false;
                res.message = "Dispositivo deshabilitado";
                res.exception = "El dispositivo " + device_id + " no está habilitado";
            }

            return this.Json(res, JsonRequestBehavior.AllowGet);

        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexSueldos()
        {
            return View();
        }

        public ActionResult IndexBonificaciones()
        {
            return View();
        }

        public ActionResult Bonificaciones()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult CrearCertificado()
        {
            return View();
        }

        public ActionResult TurnosWeb()
        {
            return View();
        }

        public ActionResult ArchivosAdjuntos(int id)
        {
            ViewBag.Id = id;
            return View(id);
        }

        public ActionResult Proveedores()
        {
            return View();
        }

        public ActionResult TurnosWebDetalle(int id)
        {
            var turno = oTurnos.ObtenerPorId(id);

            return View(turno);
        }

        public ActionResult ProveedoresDetalle(int id)
        {
            var oProveedores = new ECO_ProveedoresAD();
            var proveedor = oProveedores.ObtenerPorId(id);

            return View(proveedor);
        }
        public ActionResult HistorialAdjuntos(int id)
        {
            var oProveedorAdjuntos= new ECO_ProveedoresAdjuntosAD();
            var adjuntos = oProveedorAdjuntos.ObtenerHistorialAdjuntos(id);
            return View(adjuntos);
        }


        public ActionResult MinisterioPublico()
        {
            return View();
        }

        public ActionResult Resumen(int agente)
        {
            Agentes a = oAgentesRN.ObtenerPorId(agente);
            var dias = oAgentesRN.DiasDeLicenciaDisponiblesSustitutos(agente, DateTime.Now);
            ViewBag.DiasSustituto = dias;

            //ViewBag.DiasDeLicenciasDisponibles = oAgentesRN.DiasDeLicenciasDisponibles(agente, DateTime.Now.Year);
            return View(a);
        }

        public ActionResult MisDatos()
        {
            var ag = oAgentes.GetByUser(SessionHelper.NombrePersona);

            Agentes a = oAgentesRN.ObtenerPorId(ag.Id);
            ViewBag.Suplente = a.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Grupo;
            var dias = oAgentesRN.DiasDeLicenciaDisponiblesSustitutos(ag.Id, DateTime.Now);
            ViewBag.DiasSustituto = dias;

            //ViewBag.DiasDeLicenciasDisponibles = oAgentesRN.DiasDeLicenciasDisponibles(agente, DateTime.Now.Year);
            return View(a);
        }

        public ActionResult CrearMovimientoCesida(int agente)
        {
            Agentes a = oAgentesRN.ObtenerPorId(agente);

            return View(a);
        }

        private DocumentFormat.OpenXml.Wordprocessing.TableCell createTcHeader(string texto) {
            // Create a cell.
            DocumentFormat.OpenXml.Wordprocessing.TableCell tc1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();


            var paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
            var run = new DocumentFormat.OpenXml.Wordprocessing.Run();
            var text = new DocumentFormat.OpenXml.Wordprocessing.Text(texto);
            // your old code for reference:  tc.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data[i, j]))));

            RunProperties runProperties1 = new RunProperties();
            DocumentFormat.OpenXml.Wordprocessing.FontSize fontSize1 = new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "24" };
            Bold bold1 = new Bold();
            runProperties1.Append(fontSize1);
            runProperties1.Append(bold1);

            run.Append(runProperties1);
            run.Append(text);

            paragraph.Append(run);
           
            // Specify the width property of the table cell.
            tc1.Append(new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));


            tc1.Append(paragraph);
            // Specify the table cell content.
            //tc1.Append(new Paragraph(new Run(new Text(text))));

            return tc1;
        }

        private DocumentFormat.OpenXml.Wordprocessing.TableCell createTcData(string texto)
        {
            // Create a cell.
            DocumentFormat.OpenXml.Wordprocessing.TableCell tc1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();

            // Specify the width property of the table cell.
            tc1.Append(new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));


            var paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
            var run = new DocumentFormat.OpenXml.Wordprocessing.Run();
            var text = new DocumentFormat.OpenXml.Wordprocessing.Text(texto);
            // your old code for reference:  tc.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data[i, j]))));

            RunProperties runProperties1 = new RunProperties();
            DocumentFormat.OpenXml.Wordprocessing.FontSize fontSize1 = new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "24" };
            
            runProperties1.Append(fontSize1);

            run.Append(runProperties1);
            run.Append(text);

            paragraph.Append(run);

            // Specify the width property of the table cell.
            tc1.Append(new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));


            tc1.Append(paragraph);

            // Specify the table cell content.
            //tc1.Append(new Paragraph(new Run(new Text(text))));

            return tc1;
        }

        private DocumentFormat.OpenXml.Wordprocessing.Table createTableMovimientos(Nombramientos n)
        {
            // Create an empty table.
            DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();

            // Create a TableProperties object and specify its border information.
            TableProperties tblProp = new TableProperties(
                new TableBorders(
                    new TopBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new BottomBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new LeftBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new RightBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new InsideHorizontalBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new InsideVerticalBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    }
                )
            );

            // Append the TableProperties object to the empty table.
            table.AppendChild<TableProperties>(tblProp);

            // Create a row.
            DocumentFormat.OpenXml.Wordprocessing.TableRow trmovimiento = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

            DocumentFormat.OpenXml.Wordprocessing.TableCell tc1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();            


            var paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
            var run = new DocumentFormat.OpenXml.Wordprocessing.Run();
            var text = new DocumentFormat.OpenXml.Wordprocessing.Text("Movimientos");
            // your old code for reference:  tc.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data[i, j]))));

            RunProperties runProperties1 = new RunProperties();
            DocumentFormat.OpenXml.Wordprocessing.FontSize fontSize1 = new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "24" };
            Bold bold1 = new Bold();
            runProperties1.Append(fontSize1);
            runProperties1.Append(bold1);

            run.Append(runProperties1);
            run.Append(text);

            paragraph.Append(run);

            TableCellProperties tableCellProperties = new TableCellProperties();
            HorizontalMerge verticalMerge = new HorizontalMerge()
            {
                Val = MergedCellValues.Restart
            };
            tableCellProperties.Append(verticalMerge);


            TableCellProperties tableCellProperties1 = new TableCellProperties();
            HorizontalMerge verticalMerge1 = new HorizontalMerge()
            {
                Val = MergedCellValues.Continue
            };
            tableCellProperties1.Append(verticalMerge1);

            // Specify the width property of the table cell.
            tc1.Append(new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));

            tc1.Append(paragraph);

            DocumentFormat.OpenXml.Wordprocessing.TableRow tr = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

            trmovimiento.Append(tc1);
            // Create a cell.
            //DocumentFormat.OpenXml.Wordprocessing.TableCell tc1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();

            tr.Append(createTcHeader("Fecha Desde"));
            tr.Append(createTcHeader("Fecha Hasta"));
            tr.Append(createTcHeader("Organismo"));
            tr.Append(createTcHeader("Cargo"));
            tr.Append(createTcHeader("Situación Revista"));
            //tr.Append(createTcHeader("Observaciones"));
            //table.Append(trmovimiento);
            table.Append(tr);
            foreach (var m in n.NombramientosMovimientos.OrderBy(x=>x.Desde).ToList())
            {

                DocumentFormat.OpenXml.Wordprocessing.TableRow trdata = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                trdata.Append(createTcData(m.Desde.ToShortDateString()));
                trdata.Append(createTcData(m.Hasta.HasValue ? m.Hasta.Value.ToShortDateString() : ""));
                trdata.Append(createTcData(m.Organismos.Descripcion));
                trdata.Append(createTcData(m.Cargos.Descripcion));
                //trdata.Append(createTcData(!string.IsNullOrEmpty(m..Motivo) ? n.Motivo : ""));
                trdata.Append(createTcData(m.SituacionRevista));

                // Append the table row to the table.

                table.Append(trdata);
            }

            return table;
        }

        private DocumentFormat.OpenXml.Wordprocessing.Table createTableNombramiento(Nombramientos n) {
            // Create an empty table.
            DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();

            // Create a TableProperties object and specify its border information.
            TableProperties tblProp = new TableProperties(
                new TableJustification() { Val = TableRowAlignmentValues.Right },
                new TableBorders(
                    new TopBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new BottomBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new LeftBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new RightBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new InsideHorizontalBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    },
                    new InsideVerticalBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Thick),
                        Size = 10
                    }
                )
            );

            // Append the TableProperties object to the empty table.
            table.AppendChild<TableProperties>(tblProp);

            // Create a row.
            DocumentFormat.OpenXml.Wordprocessing.TableRow tr = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

            // Create a cell.
            DocumentFormat.OpenXml.Wordprocessing.TableCell tc1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();


            DocumentFormat.OpenXml.Wordprocessing.TableRow trmovimiento = new DocumentFormat.OpenXml.Wordprocessing.TableRow();


            var paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
            var run = new DocumentFormat.OpenXml.Wordprocessing.Run();
            var text = new DocumentFormat.OpenXml.Wordprocessing.Text("NOMBRAMIENTO");
            // your old code for reference:  tc.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data[i, j]))));

            RunProperties runProperties1 = new RunProperties();
            DocumentFormat.OpenXml.Wordprocessing.FontSize fontSize1 = new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "24" };
            Bold bold1 = new Bold();
            runProperties1.Append(fontSize1);
            runProperties1.Append(bold1);

            run.Append(runProperties1);
            run.Append(text);

            paragraph.Append(run);

            TableCellProperties tableCellProperties = new TableCellProperties();
            HorizontalMerge verticalMerge = new HorizontalMerge()
            {
                Val = MergedCellValues.Restart
            };
            tableCellProperties.Append(verticalMerge);


            TableCellProperties tableCellProperties1 = new TableCellProperties();
            HorizontalMerge verticalMerge1 = new HorizontalMerge()
            {
                Val = MergedCellValues.Continue
            };
            tableCellProperties1.Append(verticalMerge1);

            //// Specify the width property of the table cell.
            tc1.Append(new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = "100" }));

            tc1.Append(paragraph);

            trmovimiento.Append(tc1);

            //var tc2 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
            ////tc2.Append(new Paragraph(new Run(new Text("Test"))));
            ////tc2.Append(new TableCellProperties(
            ////    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "700" }));
            //tc2.Append(tableCellProperties1);
            //tc2.Append(new Paragraph(new Run(new Text(""))));
            //trmovimiento.Append(tc2);



            //var tc3 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
            ////tc2.Append(new Paragraph(new Run(new Text("Test"))));
            //tc3.Append(new TableCellProperties(
            //    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            //tc3.Append(tableCellProperties1);
            //tc3.Append(new Paragraph(new Run(new Text(""))));
            //trmovimiento.Append(tc3);

            //var tc4 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
            //tc4.Append(new Paragraph(new Run(new Text(""))));
            //tc4.Append(new TableCellProperties(
            //   new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            //tc4.Append(tableCellProperties1);
            //trmovimiento.Append(tc4);
            //var tc5 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
            //tc5.Append(new TableCellProperties(
            //   new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            //tc5.Append(new Paragraph(new Run(new Text(""))));
            //tc5.Append(tableCellProperties1);
            //trmovimiento.Append(tc5);
            //var tc6 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
            //tc6.Append(new Paragraph(new Run(new Text(""))));
            //tc6.Append(new TableCellProperties(
            //   new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            //tc6.Append(tableCellProperties1);
            //trmovimiento.Append(tc6);
            //var tc7 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
            //tc7.Append(new Paragraph(new Run(new Text(""))));
            //tc7.Append(new TableCellProperties(
            //   new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));
            //tc7.Append(tableCellProperties1);
            //trmovimiento.Append(tc7);


            tr.Append(createTcHeader("Fecha Desde"));
            tr.Append(createTcHeader("Fecha Hasta"));
            tr.Append(createTcHeader("Organismo"));
            tr.Append(createTcHeader("Cargo"));
            tr.Append(createTcHeader("Resolución / Acuerdo"));
            tr.Append(createTcHeader("Último Ascenso"));
            tr.Append(createTcHeader("Situación Revista"));

            DocumentFormat.OpenXml.Wordprocessing.TableRow trdata = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

            trdata.Append(createTcData(n.FechaDeAlta.ToShortDateString()));
            trdata.Append(createTcData(n.FechaDeBaja.HasValue ? n.FechaDeBaja.Value.ToShortDateString() : ""));
            trdata.Append(createTcData(n.Organismos.Descripcion));
            trdata.Append(createTcData(n.Cargos.Descripcion + " " + (n.SituacionRevista == "S" ? "(Sustituto)" : n.FechaFinSustitucion.HasValue ? "(Sustituto)" : "")));
            trdata.Append(createTcData(!string.IsNullOrEmpty(n.Motivo) ? n.Motivo : ""));
            trdata.Append(createTcData(n.FechaUltimoAscenso.HasValue ? n.FechaUltimoAscenso.Value.ToShortDateString() : ""));
            trdata.Append(createTcData(n.SituacionRevista));

            // Append the table row to the table.
            table.Append(trmovimiento);
            table.Append(tr);
            table.Append(trdata);

            return table;
        }

        private static void AddNewStyle(StyleDefinitionsPart styleDefinitionsPart,
       string styleid, string stylename)
        {
            // Get access to the root element of the styles part.
            Styles styles = styleDefinitionsPart.Styles;

            // Create a new paragraph style and specify some of the properties.
            DocumentFormat.OpenXml.Wordprocessing.Style style = new DocumentFormat.OpenXml.Wordprocessing.Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = styleid,
                CustomStyle = true
            };
            StyleName styleName1 = new StyleName() { Val = stylename };
            BasedOn basedOn1 = new BasedOn() { Val = "Normal" };
            NextParagraphStyle nextParagraphStyle1 = new NextParagraphStyle() { Val = "Normal" };
            style.Append(styleName1);
            style.Append(basedOn1);
            style.Append(nextParagraphStyle1);

            // Create the StyleRunProperties object and specify some of the run properties.
            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            Bold bold1 = new Bold();
            //Color color1 = new Color() { ThemeColor = ThemeColorValues.Accent2 };
            RunFonts font1 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman" };
            Italic italic1 = new Italic();
            SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };
            // Specify a 12 point size.
            DocumentFormat.OpenXml.Wordprocessing.FontSize fontSize1 = new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "25" };
            //styleRunProperties1.Append(bold1);
            //styleRunProperties1.Append(color1);
            styleRunProperties1.Append(font1);
            styleRunProperties1.Append(fontSize1);
            styleRunProperties1.Append(spacingBetweenLines1);
            //styleRunProperties1.Append(italic1);

            // Add the run properties to the style.
            style.Append(styleRunProperties1);

            // Add the style to the styles part.
            styles.Append(style);
        }

        public static void ApplyStyleToParagraph(WordprocessingDocument doc,
        string styleid, string stylename, Paragraph p)
        {
            // If the paragraph has no ParagraphProperties object, create one.
            if (p.Elements<ParagraphProperties>().Count() == 0)
            {
                p.PrependChild<ParagraphProperties>(new ParagraphProperties());
            }

            // Get the paragraph properties element of the paragraph.
            ParagraphProperties pPr = p.Elements<ParagraphProperties>().First();

            // Get the Styles part for this document.
            StyleDefinitionsPart part =
                doc.MainDocumentPart.StyleDefinitionsPart;

            // If the Styles part does not exist, add it and then add the style.
            if (part == null)
            {
                part = AddStylesPartToPackage(doc);
                AddNewStyle(part, styleid, stylename);
            }
            else
            {
                // If the style is not in the document, add it.
                if (IsStyleIdInDocument(doc, styleid) != true)
                {
                    // No match on styleid, so let's try style name.
                    string styleidFromName = GetStyleIdFromStyleName(doc, stylename);
                    if (styleidFromName == null)
                    {
                        AddNewStyle(part, styleid, stylename);
                    }
                    else
                        styleid = styleidFromName;
                }
            }

            // Set the style of the paragraph.
            pPr.ParagraphStyleId = new ParagraphStyleId() { Val = styleid };
        }

        public static string GetStyleIdFromStyleName(WordprocessingDocument doc, string styleName)
        {
            StyleDefinitionsPart stylePart = doc.MainDocumentPart.StyleDefinitionsPart;
            string styleId = stylePart.Styles.Descendants<StyleName>()
                .Where(s => s.Val.Value.Equals(styleName) &&
                    (((DocumentFormat.OpenXml.Wordprocessing.Style)s.Parent).Type == StyleValues.Paragraph))
                .Select(n => ((DocumentFormat.OpenXml.Wordprocessing.Style)n.Parent).StyleId).FirstOrDefault();
            return styleId;
        }

        public static bool IsStyleIdInDocument(WordprocessingDocument doc,   string styleid)
        {
            // Get access to the Styles element for this document.
            Styles s = doc.MainDocumentPart.StyleDefinitionsPart.Styles;

            // Check that there are styles and how many.
            int n = s.Elements<DocumentFormat.OpenXml.Wordprocessing.Style>().Count();
            if (n == 0)
                return false;

            // Look for a match on styleid.
            DocumentFormat.OpenXml.Wordprocessing.Style style = s.Elements<DocumentFormat.OpenXml.Wordprocessing.Style>()
                .Where(st => (st.StyleId == styleid) && (st.Type == StyleValues.Paragraph))
                .FirstOrDefault();
            if (style == null)
                return false;

            return true;
        }

        public static StyleDefinitionsPart AddStylesPartToPackage(WordprocessingDocument doc)
        {
            StyleDefinitionsPart part;
            part = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            Styles root = new Styles();
            root.Save(part);
            return part;
        }

        public ActionResult CrearCertificacion(int id)
        {
            var a = oAgentes.ObtenerPorId(id);

            var pMedidas = "Que de acuerdo a los registros obrantes en el Legajo personal interno de esta Secretaría, {medidas} (MEDIDAS DISCIPLINARIAS) existen constancias de sanciones disciplinarias aplicadas al solicitante.--------------------------------------";
            var pFinal = "Para ser presentado ante las autoridades que lo requieran, se extiende el presente, en la ciudad de Santa Rosa capital de la Provincia de La Pampa, a los {hoy_letras}.-------------------------------------------";

            System.IO.File.Copy(Server.MapPath("~/Files/Templates/Certificacion_servicios.docx"), Server.MapPath($"~/Files/Certificaciones/Certificacion_servicios_{a.Legajo.ToString()}.docx"), true);

            using (WordprocessingDocument doc =
                    WordprocessingDocument.Open(Server.MapPath($"~/Files/Certificaciones/Certificacion_servicios_{a.Legajo.ToString()}.docx"), true))
            {
                var body = doc.MainDocumentPart.Document.Body;
                var paras = body.Elements<Paragraph>();

                //var run = new Run();

                foreach (var para in paras)
                {
                    foreach (var run in para.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            if (text.Text.Contains("{dni}"))
                            {
                                text.Text = text.Text.Replace("{dni}", a.Personas.NroDocumento.ToString());
                            }

                            if (text.Text.Contains("{nombres}"))
                            {
                                text.Text = text.Text.Replace("{nombres}", a.Personas.Apellidos.Trim() + " " + a.Personas.Nombres.Trim());
                            }

                            if (text.Text.Contains("{fecha_letras}"))
                            {
                                var n = a.Nombramientos.OrderBy(x => x.FechaDeAlta).FirstOrDefault();
                                text.Text = text.Text.Replace("{fecha_letras}",n.FechaDeAlta.ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
                            }

                            if (text.Text.Contains("{hoy_letras}"))
                            {
                                text.Text = text.Text.Replace("{fecha_letras}", DateTime.Now.ToString("D", CultureInfo.CreateSpecificCulture("es-ES")));
                            }

                        }
                    }
                }

                foreach (var n in a.Nombramientos.Where(x => !x.FechaEliminacion.HasValue).OrderBy(x => x.FechaDeAlta).ToList()) {
                    var table = createTableNombramiento(n);
                    doc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(table)));
                    if (n.NombramientosMovimientos.Count() > 0) {
                        doc.MainDocumentPart.Document.Body.Append(new Break());
                        var table_movimientos = createTableMovimientos(n);
                        doc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(table_movimientos)));
                        //run.AppendChild(table_movimientos);
                    }
                    doc.MainDocumentPart.Document.Body.Append(new Break());
                }

                var run2 = new Run();

                var medidas = a.MedidasDisciplinarias.Count() > 0;

                var runProp = new RunProperties();

                var runFont = new RunFonts { Ascii = "Arial" };

                // 48 half-point font size
                var size = new DocumentFormat.OpenXml.Wordprocessing.FontSize { Val = new StringValue("18") };

                runProp.Append(runFont);
                runProp.Append(size);

                Paragraph p = new Paragraph(new Run(new Text(pMedidas.Replace("{medidas}", medidas ? "SI" : "NO"))));           

                Paragraph p2 = new Paragraph(new Run(new Text(pFinal.Replace("{hoy_letras}", DateTime.Now.ToString("D", CultureInfo.CreateSpecificCulture("es-ES"))))));
                //p2.PrependChild(runProp);
                ////doc.MainDocumentPart.Document.Body.PrependChild(runProp);
                doc.MainDocumentPart.Document.Body.Append(p);
                doc.MainDocumentPart.Document.Body.Append(new Break());
                doc.MainDocumentPart.Document.Body.Append(p2);
                List<Paragraph> paragraphs = body.OfType<Paragraph>().Where(x => x.InnerText != "")
                        .ToList();
                Paragraph beforeLast = paragraphs[paragraphs.Count - 1];
                //Run run3 = beforeLast.AppendChild(new Run());
                //run.AppendChild(new Break()); //Line Break
                //run.AppendChild(new Text(epMedidas.Replace("{medidas}", medidas ? "SI" : "NO")));
                //run.AppendChild(new Break());
                //run3.PrependChild(runProp);

                if (p.Elements<ParagraphProperties>().Count() == 0)
                {
                    p.PrependChild<ParagraphProperties>(new ParagraphProperties());
                }

                ApplyStyleToParagraph(doc, "", "", p);
                ApplyStyleToParagraph(doc, "", "", p2);

                doc.Save();

                

                //doc.Save();

                doc.Close();
            }

            return Json(new object[] { true, String.Format("Se ha eliminado el turno") });
        }

        public ActionResult test_trello()
        {
            var serializer = new ManateeSerializer();
            TrelloConfiguration.Serializer = serializer;
            TrelloConfiguration.Deserializer = serializer;
            TrelloConfiguration.JsonFactory = new ManateeFactory();
            TrelloConfiguration.RestClientProvider = new WebApiClientProvider();
            TrelloAuthorization.Default.AppKey = "acf026e9a41e049b3c1a80fb0b4e4c97";
            TrelloAuthorization.Default.UserToken = "b6357356ab06bac7fdfd8e6eb966f621f1682ee7f6bd0a2e213ab43fd0b14757";

            var board = new Board("gYqEZ4ZY");

            var l = board.Lists.First();
            //board.Labels.Add()

            //string listId = "Reportado por Usuarios";
            //var list = new List(listId);
            var member = l.Board.Members.First();
            var card = l.Cards.Add("new card");
            card.Members.Add(member);
            card.Name = "A New Hope";
            card.Description = "The original Star Wars film is still considered by many to be the best of the entire series.";
            card.DueDate = DateTime.Now;

            return View();
        }

        public ActionResult ResumenMM(int agente)
        {
            Agentes a = oAgentesRN.ObtenerPorId(agente);
            var dias = oAgentesRN.DiasDeLicenciaDisponiblesSustitutos(agente, DateTime.Now);
            ViewBag.DiasSustituto = dias;
            //ViewBag.DiasDeLicenciasDisponibles = oAgentesRN.DiasDeLicenciasDisponibles(agente, DateTime.Now.Year);
            return View(a);
        }

        [HttpPost]
        public ActionResult GenerarCertificado(List<int> agentes, int tipo, string desde, string hasta, string lugar, string horario)
        {

            try
            {
                foreach (var a in agentes)
                {
                    var agente = oAgentes.ObtenerPorId(a);
                    agente.TokenGCM = lugar;
                    if (tipo == 1)
                    {
                        agente.CertificadoFechaDesde = DateTime.Now;
                    }
                    else
                    {
                        var fdesde = DateTime.Parse(desde);
                        var fhasta = DateTime.Parse(hasta);

                        agente.CertificadoFechaDesde = fdesde;
                        agente.CertificadoFechaHasta = fhasta;
                    }
                    agente.CertificadoHorario = horario;
                    agente.CertificadoValidez = DateTime.Now.Date.ToLongDateString();

                    oAgentes.Actualizar(agente);
                }
                return Json(new object[] { true, String.Format("Se generaron los certificados") });
            }
            catch (Exception e)
            {
                return Json(new object[] { false, String.Format("Hay un problema al generar los certificados") });
            }


        }



        [HttpPost]
        public ActionResult actualizarestadoturno(int turno, int estado)
        {
            var t = oTurnos.ObtenerPorId(turno);
            t.Estado = estado;

            oTurnos.Actualizar(t);

            return Json(new object[] { true, String.Format("Se actualizaron todas las bonificaciones") });
        }


        [HttpPost]
        public ActionResult QuitarTurno(int id)
        {
            var t = oTurnos.ObtenerPorId(id);
            t.Estado = (int)eEstadosTurnos.Eliminado;

            oTurnos.Actualizar(t);

            return Json(new object[] { true, String.Format("Se ha eliminado el turno") });
        }

        [HttpPost]
        public ActionResult GuardarPlanillaDeBonificaciones(List<AgentesBonificaciones> bonificaciones)
        {

            List<string> errores = new List<string>();

            foreach (var b in bonificaciones)
            {
                try
                {
                    b.FechaAlta = DateTime.Now;

                    if (b.Id > 0)
                    {
                        oBonificaciones.Actualizar(b);
                    }
                    else
                    {
                        oBonificaciones.Guardar(b);
                    }

                    var a = oAgentes.ObtenerPorId(b.Agente);
                    a.Bonificacion = b.Porcentaje;
                    a.TieneBonificacion = b.Aplica;

                    oAgentes.Actualizar(a);

                }
                catch (Exception e)
                {
                    var a = oAgentes.ObtenerPorId(b.Agente);
                    errores.Add(a.Legajo.ToString() + " - No ha podido actualizarse.");
                }

            }



            return Json(new object[] { true, String.Format("Se actualizaron todas las bonificaciones") });
        }

        [HttpPost]
        public ActionResult SubirFoto(HttpPostedFileBase file)
        {


            if (file == null) return View();

            Object stragente = Request.Params["agente"];
            Object stremail = Request.Params["email"];

            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + stragente + "-" + file.FileName).ToLower();

            var agente = oAgentes.ObtenerPorId(int.Parse(stragente.ToString()));
            agente.TokenGCM = archivo;
            agente.Email = stremail.ToString();
            agente.CertificadoFechaDesde = DateTime.Now;
            agente.CertificadoValidez = "GENERADO";
            oAgentes.Actualizar(agente);


            file.SaveAs(Server.MapPath("~/Files/Perfiles/" + archivo));

            return RedirectToAction("MiCertificado", "Home", new { dni = agente.Personas.NroDocumento });
        }

        [HttpGet]
        public ActionResult ValidarAgente(long dni, string codigo)
        {
            var agente = new AgentesView { Id = -1 };
            string json;

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://concursos.justicialapampa.gob.ar/home/validar_dni/?dni=" + dni.ToString() + "&codigo=" + codigo);
            }


            if (json.Contains("true"))
            {

                var agente2 = oAgentes.ObtenerPorDni(dni);
                if (agente2 != null)
                {
                    agente = new AgentesView { Id = agente2.Id, Nombre = agente2.Personas.Apellidos + " " + agente2.Personas.Nombres };
                }

            }

            return this.Json(agente, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult ActualizarNombre(int pk, string value, string name)
        {
            try
            {
                Personas p = oPersonasRN.ObtenerPorId(pk);

                if (name.Contains("nombre"))
                    p.Nombres = value;
                else
                    p.Apellidos = value;

                oPersonasRN.Actualizar(p);
                return Json(new object[] { true, String.Format("Se actualizó el nombre del agente") });
            }
            catch (Exception e)
            {
                return Json(new object[] { false, String.Format("No se ha podido actualizar el nombre") });
            }
        }

        [HttpPost]
        public ActionResult ActualizarAgente(int pk, string value, string name)
        {
            try
            {
                Agentes a = oAgentesRN.ObtenerPorId(pk);

                if (name.Contains("telefono"))
                    a.Telefono = value;

                if (name.Contains("domicilio"))
                {
                    a.Domicilio = value;
                }

                if (name.Contains("profesion"))
                {
                    a.Profesion = value;
                }

                if (name.Contains("email"))
                {
                    a.Email = value;
                }


                oAgentesRN.Actualizar(a);
                return Json(new object[] { true, String.Format("Se actualizó el " + name + " del agente") });
            }
            catch (Exception e)
            {
                return Json(new object[] { false, String.Format("No se ha podido actualizar el " + name) });
            }
        }

        [HttpPost]
        public ActionResult GuardarMovimientoDeSueldo(int id_agente, int id_designacion, int id_movimiento, int id_nombramiento, List<CesidaValoresDeParametros> parametros)
        {
            CesidaMovimientoAgentes movimientoagente = new CesidaMovimientoAgentes();

            var agente = oAgentes.ObtenerPorId(id_agente);
            var nombramiento = agente.Nombramientos.Where(n => n.Designacion_Cesida == id_designacion).FirstOrDefault();

            movimientoagente.Agente = id_agente;
            movimientoagente.Autorizado = false;
            movimientoagente.Movimiento = id_movimiento;
            movimientoagente.Persona = nombramiento.Persona_Cesida;
            movimientoagente.Nombramiento = id_nombramiento;
            movimientoagente.UsuarioAlta = SessionHelper.IdUsuario.Value;
            movimientoagente.FechaAlta = DateTime.Now;

            oCesidaMovimientosAgente.Guardar(movimientoagente);

            foreach (var p in parametros)
            {

                p.Movimiento = movimientoagente.Id;

            }


            return Json(new object[] { true, String.Format("Se registró el movimiento") });


        }

        public DataTablesResult<AgentesView> getAgentesGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oAgentes.ObtenerParaGrilla(), dataTableParam, a => new AgentesView()
            {
                Id = a.Id,
                Legajo = a.Legajo,
                Telefono = a.Telefono,
                Organismo = a.Organismo,
                //FechaDeCasamiento=a.FechaDeCasamiento,	
                Cargo = a.Cargo,
                Nombre = a.Nombre
            });
        }

        public DataTablesResult<TurnosWebView> getTurnosWeb(DataTablesParam dataTableParam, int? organismo, string desde, string hasta, int estado)
        {
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

            return DataTablesResult.Create(this.oTurnos.ObtenerParaGrilla(organismo, fdesde, fhasta, SessionHelper.IdUsuario.Value, estado), dataTableParam, x => x);
        }

        public DataTablesResult<AgentesBonificacionesView> getBonficacionesGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oBonificaciones.ObtenerParaGrilla(), dataTableParam, a => a);
        }

        public DataTablesResult<ECO_ProveedoresEconomiaView> getProveedoresGrillaFilter(DataTablesParam dataTableParam, eEstadosProveedores? estado, string razonSocial, string cuit)
        {

            var oProveedores = new ECO_ProveedoresAD();
            return DataTablesResult.Create(oProveedores.ObtenerParaGrilla(estado, razonSocial, 0,cuit), dataTableParam, a => a);
        }

        public DataTablesResult<ECO_ProveedoresEconomiaView> getProveedoresGrill(DataTablesParam dataTableParam)
        {
            var oProveedores = new ECO_ProveedoresAD();
            return DataTablesResult.Create(oProveedores.ObtenerParaGrilla(null, "", 0, ""), dataTableParam, a => a);
        }

        public DataTablesResult<AgentesView> getAgentesGrillaMM(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oAgentesRN.ObtenerParaGrillaMM(), dataTableParam, a => new AgentesView()
            {
                Id = a.Id,
                Legajo = a.Legajo,
                Telefono = a.Telefono,
                Organismo = a.Organismo,
                //FechaDeCasamiento=a.FechaDeCasamiento,	
                Cargo = a.Cargo,
                Nombre = a.Nombre
            });
        }

        public ActionResult Detalle(int id = 0)
        {
            Agentes agentes = oAgentesRN.ObtenerPorId(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }


        public ActionResult Crear()
        {

            //ViewBag.Legajo = oParametrosRN.ObtenerPorId(1).UltimoLegajo.Value;
            Agentes a = new Agentes()
            {
                Legajo = oParametrosRN.ObtenerPorId(1).UltimoLegajo.Value,
            };
            ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Descripcion = "Hola";
            return View(a);
        }


        [HttpPost]
        public ActionResult AsignarTurno(int turno, DateTime fecha, string hora)
        {

            try
            {
                var t = oTurnos.ObtenerPorId(turno);
                t.Fecha = fecha.Date;
                t.Hora = TimeSpan.Parse(hora);
                t.Contactar = false;
                oTurnos.Actualizar(t);

                new MailController().ConfirmarTurno(t).Deliver();

                return Json(new object[] { true, String.Format("El actualizó el turno") });
            }
            catch (Exception e)
            {
                return Json(new object[] { false, String.Format("El actualizó el turno") });
            }
        }

        [HttpPost]
        public ActionResult CrearAdjunto(string descripcion, int agente, string archivo)
        {
            var oImagenes = new ImagenesrrhhAD();

            var i = new Imagenesrrhh()
            {
                Agente = agente,
                FechaDeCarga = DateTime.Now,
                FechaUltimaActualizacion = DateTime.Now,
                Nombre = archivo,
                Descripcion = descripcion,
                Imagen = archivo,
                Categoria = 3,
                Usuario = SessionHelper.IdUsuario.Value
            };

            oImagenes.Guardar(i);

            return Json(new object[] { true, String.Format("Se guardó el adjunto correctamente") });

        }

        [HttpPost]
        public ActionResult EliminarAdjunto(int id)
        {
            var oImagenes = new ImagenesrrhhAD();

            oImagenes.Eliminar(id);

            return Json(new object[] { true, String.Format("Se eliminó el adjunto correctamente") });

        }

        [HttpPost]
        public ActionResult ConfirmarProveedor(int id)
        {
            var oProveedores = new ECO_ProveedoresAD();

            try
            {
                var proveedor = oProveedores.ObtenerPorId(id);
                proveedor.Estado = eEstadosProveedores.Confirmado;
                proveedor.FechaCambioEstado = DateTime.Now;
                oProveedores.Actualizar(proveedor);

                new MailController().NotificacionProveedor(proveedor).Deliver();

                return Json(new object[] { true, String.Format("El proveedor se confirmó satisfactoriamente") });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido confirmar el proveedor" });
            }

        }

        [HttpPost]
        public ActionResult RechazarProveedor(int id, string observaciones)
        {
            var oProveedores = new ECO_ProveedoresAD();

            try
            {
                var proveedor = oProveedores.ObtenerPorId(id);
                proveedor.Estado = eEstadosProveedores.Rechazado;
                proveedor.FechaCambioEstado = DateTime.Now;
                proveedor.ObservacionesEconomia += $"\n [{DateTime.Now.ToShortDateString()}] {observaciones}";
                oProveedores.Actualizar(proveedor);

                new MailController().RechazoProveedor(proveedor, observaciones).Deliver();

                return Json(new object[] { true, String.Format("El proveedor se rechazó satisfactoriamente") });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No se ha podido rechazar el proveedor" });
            }

        }

        [HttpPost]
        public ActionResult Crear(Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    agentes.FechaAlta = DateTime.Now;
                    agentes.Activo = true;
                    oAgentesRN.Guardar(agentes);

                    Parametrosadm p = oParametrosRN.ObtenerPorId(1);
                    p.UltimoLegajo = agentes.Legajo + 1;
                    oParametrosRN.Actualizar(p);

                    return Json(new object[] { true, String.Format("El agente se guardó satisfactoriamente") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No se ha podido guardar el agente" });
                }
            }
            else
            {
                return Json(new object[] { false, "No se ha podido guardar Agentes" });
            }
        }


        [HttpPost]
        public ActionResult Editar(Agentes agentes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    agentes.Activo = true;
                    oAgentesRN.Actualizar(agentes);
                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente Agentes") });
                }
                catch (Exception ex)
                {
                    Logger.GrabarExcepcion(ex, false);
                    return Json(new object[] { false, "No pudo guardarse Agentes" });
                }
            }
            else
            {
                return Json(new object[] { false, "No pudo guardarse Agentes" });
            }

        }

        public ActionResult Editar(int id = 0)
        {

            ViewBag.CargosRef = new SelectList(oCargosRefRN.ObtenerTodo().ToList(), "Id", "Descripcion");

            Agentes agentes = oAgentesRN.ObtenerPorId(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }


        [HttpPost, ActionName("Eliminar")]
        public ActionResult EliminarConfirmado(int id)
        {
            try
            {
                oAgentesRN.Eliminar(id);
                return Json(new object[] { true, "La operación se realizó con éxito" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el agente" });
            }
        }

        [HttpPost, ActionName("EliminarProveedor")]
        public ActionResult EliminarProveedor(int id)
        {

            try
            {
                
                return Json(new object[] { true, "La operación se realizó satisfactoriamente" });
            }
            catch (Exception ex)
            {
                Logger.GrabarExcepcion(ex, false);
                return Json(new object[] { false, "No pudo eliminarse el agente" });
            }
        }

        public DataTablesResult<ImagenesrrhhView> getAdjuntosAgenteGrid(DataTablesParam dataTableParam, int? id)
        {
            var oImagenes = new ImagenesrrhhAD();
            return DataTablesResult.Create(oImagenes.ObtenerParaGrilla(id.Value), dataTableParam, x => x);
        }

        public JsonResult JsonT(string term)
        {
            var res = from x in this.oAgentesRN.JsonT(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonPorOrganismo(int id)
        {
            var oOrganismos = new SSO.SGP.AccesoADatos.OrganismosRefAD();
            var res = oOrganismos.AgentesDelOrganismo(id).OrderBy(x => x.Nombre).ToList();

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonPorOrganismoTrazabilidad(int id)
        {
            var oOrganismos = new SSO.SGP.AccesoADatos.OrganismosRefAD();
            var res = oOrganismos.AgentesDelOrganismoTrazabilidad(id).OrderBy(x => x.Nombre).ToList();

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPorLegajo(int legajo)
        {
            var res = this.oAgentesRN.ObtenerPorLegajo(legajo);
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult JsonOptions(string term)
        {
            var res = from x in this.oAgentesRN.ObtenerOptions(term)
                      select new { id = x.value, label = x.text };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult CesidaCategoriasJson(string term)
        {
            var res = from x in this.oCesidaCategorias.ObtenerOptions(term)
                      select new { id = x.value, label = x.text };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult GetJson(string term)
        {
            var res = from x in this.oAgentesRN.GetJson(term)
                      select new
                      {
                          id = x.Id,
                          label = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(),
                          legajo = x.Legajo,
                          documento = x.Personas.NroDocumento,
                          expediente = x.AnioExpediente,
                          cargo = (x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).Count() > 0 ? x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).FirstOrDefault().Cargos : null),
                          afiliado = x.AfiliadoISS
                      };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJsonOrganismo(string term)
        {
            var organismo = SessionHelper.OficinaActual.Value;
            var res = from x in this.oAgentesRN.GetJsonOrganismo(term, organismo)
                      select new
                      {
                          id = x.Id,
                          label = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(),
                          legajo = x.Legajo,
                          documento = x.Personas.NroDocumento,
                          expediente = x.AnioExpediente,
                          cargo = (x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).Count() > 0 ? x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).FirstOrDefault().Cargos : null),
                          afiliado = x.AfiliadoISS
                      };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJsonFuncionarios(string term)
        {
            var res = from x in this.oAgentes.GetJsonFuncionarios(term)
                      select new
                      {
                          id = x.Id,
                          label = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(),
                          legajo = x.Legajo,
                          documento = x.Personas.NroDocumento,
                          expediente = x.AnioExpediente,
                          cargo = (x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).Count() > 0 ? x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).OrderByDescending(f => f.FechaDeAlta).FirstOrDefault().Cargos : null),
                          afiliado = x.AfiliadoISS
                      };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJson2(string term)
        {
            var res = from x in this.oAgentesRN.GetJson(term)
                      select new
                      {
                          id = x.Id,
                          label = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(),
                          legajo = x.Legajo,
                          documento = x.Personas.NroDocumento,
                          expediente = x.AnioExpediente,
                          cargo = (x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).Count() > 0 ? x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).OrderByDescending(f => f.FechaDeAlta).FirstOrDefault().Cargos : null),
                          organismo = (x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).Count() > 0 ? x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).OrderByDescending(f => f.FechaDeAlta).FirstOrDefault().Organismos.Descripcion : null),
                          afiliado = x.AfiliadoISS
                      };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        //--- Utilizar esta acción para Autocomplete
        public JsonResult GetParametrosDeMovimiento(int movimiento)
        {
            var res = oParametrosDeMovimiento.ObtenerPorMovmiento(movimiento);
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgentesConBonificaciones(string desde, string hasta, int mes, int anio)
        {
            var d = DateTime.Parse(desde);
            var h = DateTime.Parse(hasta);

            var res = oAgentes.AgentesConBonificacion(d, h, mes, anio);

            return this.Json(res, JsonRequestBehavior.AllowGet);
        }


        public JsonResult LocalidadesJson(string term)
        {
            var res = from x in this.oLocalidadesRN.ObtenerOptions(term)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OrganismosJson(string term)
        {
            var res = from x in this.oOrganismosRN.ObtenerOptions(term)
                      select new { id = x.value, label = x.text };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFuncionariosJson(string term)
        {
            var res = from x in this.oAgentesRN.GetFuncionariosJson(term)
                      select new
                      {
                          id = x.Id,
                          label = x.Personas.Apellidos.Trim() + ", " + x.Personas.Nombres.Trim(),
                          legajo = x.Legajo,
                          documento = x.Personas.NroDocumento,
                          expediente = x.AnioExpediente,
                          email = x.Email,
                          cargo = (x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).Count() > 0 ? x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).FirstOrDefault().Cargos : null),
                          afiliado = x.AfiliadoISS,
                          organismo = (x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).Count() > 0 ? x.Nombramientos.Where(n => !n.FechaDeBaja.HasValue).FirstOrDefault().Organismos.Descripcion : null),
                      };
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Eliminar(int id = 0)
        {
            Agentes agentes = oAgentesRN.ObtenerPorId(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        public JsonResult DiasDisponiblesJsonT(int agente)
        {
            var a = oAgentes.ObtenerPorId(agente);

            var res = from x in oAgentesRN.DiasDeLicenciasDisponibles(agente, DateTime.Now.Year)
                      where (!a.Ordinaria3710 && !x.Licencia.Contains("3710") || a.Ordinaria3710)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DiasDisponiblesJsonT2(int agente)
        {
            var res = from x in oAgentesRN.DiasDeLicenciasDisponibles(agente, DateTime.Now.Year)
                      select x;
            return this.Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData(int agente)
        {
            var res = oAgentes.ObtenerPorId(agente);

            var a = new
            {
                nombre = res.Personas.Apellidos.Trim() + ", " + res.Personas.Nombres.Trim(),
                legajo = res.Legajo,
                organismo = res.Nombramientos.Where(n => n.FechaDeBaja == null && n.FechaEliminacion == null).FirstOrDefault().Organismos.Descripcion,
                cargo_actual = res.Nombramientos.Where(n => n.FechaDeBaja == null && n.FechaEliminacion == null).FirstOrDefault().Cargos.Descripcion
            };

            return this.Json(a, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerarExcelBonificaciones(string desde, string hasta, int mes, int anio)
        {

            var d = DateTime.Parse(desde);
            var h = DateTime.Parse(hasta);

            var res = oAgentes.AgentesConBonificacionExcel(d, h, mes, anio, false);

            var res2 = (from x in res

                        select new AgentesConBonificacionExcelView
                        {
                            Cargo = x.Cargo,
                            Dias = x.Dias,
                            Legajo = x.Legajo,
                            Liquidar = 30 - x.Dias,
                            Nombre = x.Nombre,
                            Organismo = x.Organismo,
                            Porcentaje = x.Porcentaje
                        }).ToList();

            var gv = new GridView();
            gv.DataSource = res2;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Bonificaciones.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            //return View("Index");
            return RedirectToAction("GenerarExcelBonificacionesMP", new { desde = desde, hasta = hasta, mes = mes, anio = anio });

        }

        public ActionResult GenerarExcelBonificacionesMP(string desde, string hasta, int mes, int anio)
        {

            var d = DateTime.Parse(desde);
            var h = DateTime.Parse(hasta);

            var res = oAgentes.AgentesConBonificacionExcel(d, h, mes, anio, true);

            var res2 = (from x in res

                        select new AgentesConBonificacionExcelView
                        {
                            Cargo = x.Cargo,
                            Dias = x.Dias,
                            Legajo = x.Legajo,
                            Liquidar = 30 - x.Dias,
                            Nombre = x.Nombre,
                            Organismo = x.Organismo,
                            Porcentaje = x.Porcentaje
                        }).ToList();

            var gv = new GridView();
            gv.DataSource = res2;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=BonificacionesMinisterioPublico.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");

        }

        protected override void Dispose(bool disposing)
        {
            oAgentesRN.Dispose();

            oCargosRefRN.Dispose();

            oPersonasRN.Dispose();

            base.Dispose(disposing);
        }

    } //fin de clase
}
