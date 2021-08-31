using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using System.Linq.Expressions;

namespace Syncrosoft.Framework.Controles.MVC.Script
{
    public static class JQuery
    {

        private static string startScriptReady()
        {
            return @"<script type=""text/javascript"">
                        $(document).ready(function() {
            ";
        }

        private static string startScript()
        {
            return @"<script type=""text/javascript"">";
        }

        private static string endScript()
        {
            return @"});
            </script>";
        }

        /// <summary>
        /// Genera script con document.ready, validación y AJAX POST y mensajes de alertas
        /// </summary>
        /// <param name="element">Nombre del elemento HTML que llamará al script (input, form, img, etc)</param>
        /// <param name="Event">Evento con el que se invocará (click, blur, submit, etc)</param>
        /// <param name="form">Nombre del formulario HTML que se va a procesar</param>
        /// <param name="afterSuccess">Script o nombre de funcion javascript para complementar luego de que se procesa satisfactoriamente el AJAX</param>
        /// <param name="afterError">Script (sentencias;) o nombre de funcion (funcion();) para complementar si ocurrió un error al procesar AJAX</param>
        /// <param name="afterComplete">Script (sentencias;) o nombre de funcion (funcion();) para complementar al completarse el AJAX</param>
        /// <param name="table">Nombre de datatable si hay que refrescar contenido</param>
        public static MvcHtmlString ajaxPost(string element, string Event, string form, string afterSuccess, string afterError, string afterComplete, string table)
        {

            var script = startScriptReady();

            script += string.Format(@"$(""#{0}"").on(""{1}"", function(event) {{
                    var form = $(""#{2}"");
                    form.validate();
                    if (form.valid()) {{
                        $(""#ProgressDialog"").dialog(""open"");
                        $.ajax({{
                            type: ""POST"",
                            url: form.attr(""action""),
                            data: form.serialize(),
                            success: function(data) {{
                                {3}
                                if (data[0]) {{
                                    $.jGrowl(data[1], {{ theme: ""success"" }});
                                }} else {{
                                    $.jGrowl(data[1], {{ theme: ""error"" }});
                                }}
                            }},
                            error: function(jqXhr, textStatus, errorThrown) {{
                                {4}
                                alert(""Error al procesar formulario ajax"");
                            }},
                            complete: function() {{
                                $(""#ProgressDialog"").dialog(""close"");
                                {5}
                                {6}
                            }}
                        }}); //end ajax
                    }} //endif
                }});
                ", element, Event, form, afterSuccess, afterError, afterComplete, (table.Length > 0) ? @"" + table + ".fnDraw();" : "");

            script += endScript();

            return MvcHtmlString.Create(script);

        }

        /// <summary>
        /// Genera script con document.ready, validación y AJAX POST y mensajes de alertas
        /// </summary>
        /// <param name="form">Nombre del formulario HTML que se va a procesar</param>
        /// <param name="afterComplete">Script (sentencias;) o nombre de funcion (funcion();) para complementar al completarse el AJAX</param>
        /// <param name="table">Nombre de instancia javascript datatable si hay que refrescar contenido</param>
        public static MvcHtmlString ajaxPost(string form, string table, string afterComplete)
        {

            var script = startScriptReady();

            script += string.Format(@"$(""#{0}"").submit(function(event) {{
                    var form = $(this);
                    event.preventDefault();
                    form.validate();
                    var success=false;
                    if (form.valid()) {{
                        $(""#ProgressDialog"").dialog(""open"");
                        $.ajax({{
                            type: ""POST"",
                            url: form.attr(""action""),
                            data: form.serialize(),
                            success: function(data) {{
                                success=data[0];
                                if (data[0]) {{
                                    $.jGrowl(data[1], {{ theme: ""success"" }});
                                }} else {{
                                    error=1;
                                    $.jGrowl(data[1], {{ theme: ""error"" }});
                                }}
                            }},
                            error: function(jqXhr, textStatus, errorThrown) {{
                                alert(""Error al procesar formulario ajax"");
                            }},
                            complete: function() {{
                                $(""#ProgressDialog"").dialog(""close"");
                                {1}
                                {2}
                            }}
                        }}); //end ajax
                    }} //endif
                }});", form, afterComplete, (table.Length > 0) ? @"" + table + ".fnDraw();" : "");

            script += endScript();

            return MvcHtmlString.Create(script);

        }


        /// <summary>
        /// Genera script con document.ready, validación y AJAX POST y mensajes de alertas
        /// </summary>
        /// <param name="form">Nombre del formulario HTML que se va a procesar</param>
        /// <param name="table">Nombre de datatable si hay que refrescar contenido</param>
        public static MvcHtmlString ajaxPost(string form, string table)
        {

            var script = startScriptReady();

            script += string.Format(@"$(""#{0}"").submit(function(event) {{
                    var form = $(this);
                    event.preventDefault();
                    form.validate();
                    var error=0;
                    if (form.valid()) {{
                        $(""#ProgressDialog"").dialog(""open"");
                        $.ajax({{
                            type: ""POST"",
                            url: form.attr(""action""),
                            data: form.serialize(),
                            success: function(data) {{
                                if (data[0]) {{
                                    $.jGrowl(data[1], {{ theme: ""success"" }});
                                }} else {{
                                    error=1;
                                    $.jGrowl(data[1], {{ theme: ""error"" }});
                                }}
                            }},
                            error: function(jqXhr, textStatus, errorThrown) {{
                                alert(""Error al procesar formulario ajax"");
                            }},
                            complete: function() {{
                                $(""#ProgressDialog"").dialog(""close"");
                               {1}
                            }}
                        }}); //end ajax
                    }} //endif
                }});", form, (table.Length > 0) ? @"" + table + ".fnDraw();" : "");

            script += endScript();

            return MvcHtmlString.Create(script);
        }

        /// <summary>
        /// Genera el elemento HTML y SCRIPT para generar autocomplete
        /// </summary>
        /// <param name="form">Id del elemento a crear</param>
        /// <param name="table">Url que devuelve Json POST con los datos (ej: /Home/getData/) </param>
        public static MvcHtmlString autocomplete(string element, string url)
        {
            var html = String.Format(@"<div id=""cont{0}"" class=""demo"">
                <div class=""ui-widget"">
                    <input id=""{0}"" size=""50"" />
                </div>
            </div>", element);

            var script = startScriptReady();

            script += String.Format(@"

        function split(val) {{
            return val.split(/,\s*/);
        }}
        function extractLast(term) {{
            return split(term).pop();
        }}

        $(""#{0}"").bind(""keydown"", function (event) {{
			    if (event.keyCode === $.ui.keyCode.TAB &&
						$(this).data(""autocomplete"").menu.active) {{
			        event.preventDefault();
			    }}
			}})
			.autocomplete({{
			    appendTo: ""#cont{0}"",
			    source: function (request, response) {{

			        $.ajax({{
			            url: '{1}' + extractLast(request.term), type: ""POST"", dataType: ""json"",
			            data: {{ term: extractLast(request.term) }},
			            success: function (data) {{
			                response($.map(data, function (item) {{
			                    return {{ label: item.Tag, value: item.Tag }};
			                }}))
			            }}
			        }})

			    }},
			    search: function () {{
			        var term = extractLast(this.value);
			        if (term.length < 2) {{
			            return false;
			        }}
			    }},
			    focus: function () {{
			        return false;
			    }},
			    select: function (event, ui) {{
			        var terms = split(this.value);
			        // remove the current input
			        terms.pop();
			        // add the selected item
			        terms.push(ui.item.value);
			        // add placeholder to get the comma-and-space at the end
			        terms.push("");
			        this.value = terms.join("", "");
			        return false;
			    }}
			}});
            ", element, url);

            script += endScript();

            return MvcHtmlString.Create(html.ToString() + script.ToString());
        }


        /// <summary>
        /// Genera HTML de los dialog para AJAX load
        /// </summary>
        public static MvcHtmlString createAjaxLoad(this HtmlHelper helper)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Content("~/Content/ajax-loader.gif");

            return MvcHtmlString.Create(String.Format(@"<div id=""ProgressDialog"" style=""text-align: center; padding: 50px;"">
                                <img src=""{0}"" width=""128"" height=""15"" alt=""Cargando..."" />
                                </div>
                                <div id=""SuccessDialog"" style=""text-align: center; padding: 50px;"">
                                    <div id=""SuccessContainer"">
                               </div></div>", url));
        }

        /// <summary>
        /// EN DESARROLLO! Genera HTML y constructor Jquery de Jquery-UI Tab
        /// </summary>
        /// <param name="id">Id del elemento Tab a crear</param>
        /// <param name="tags">Array de tabs a generar</param>
        public static MvcHtmlString createTab<TController, TResult>(this HtmlHelper helper, string id, Tabs[] tabs, Expression<Func<TController, DataTablesResult<TResult>>> exp)
        {

            var Html = String.Format(@"<div id=""{0}"">
                        <ul>", id);

            var script = startScript();

            for (int i = 0; i < tabs.Length; i++)
            {

                switch (tabs[i].type)
                {
                    case TagType.Datatable:
                        Html += String.Format(@"<li><a href=""tabs-{0}"">{1}</a></li>", i, tabs[i].name);
                        break;
                    case TagType.AjaxContent:
                        var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                        var url = urlHelper.Content(tabs[i].URL);
                        Html += String.Format(@"<li><a href=""{0}""><span id=""spedit{1}"">{2}</span></a></li>", url, i, tabs[i].name);
                        break;
                }
            }

            Html += @"</ul>";

            for (int i = 0; i < tabs.Length; i++)
            {

                if (tabs[i].type == TagType.Datatable)
                {

                    Html += String.Format(@"<div id=""tabs-{0}"">", i);

                    var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                    System.Web.Mvc.Html.PartialExtensions.Partial(helper, "DataTable", tabs[i].dt);

                    Html += @"</div>";
                }

            }

            return MvcHtmlString.Create("");
        }
    }

    public class Tabs
    {

        public string name { get; set; }
        public TagType type { get; set; }
        public string URL { get; set; }
        public string HTML { get; set; }
        public bool closeButton { get; set; }
        public string datatableId { get; set; }
        public ColumnCommand[] operators { get; set; }
        //public DataTablesResult dataTableResult { get; set; }
        //  public Expression<Func<TController, DataTablesResult<TResult>>> x;
        public DataTableVm dt;


        public Tabs(string name, string URL, TagType type, bool closeButton, string datatableId, ColumnCommand[] operators)
        {
            this.name = name;
            this.type = type;
            this.URL = URL;
            this.closeButton = closeButton;
            this.datatableId = datatableId;
            this.operators = operators;
        }
    }

    public static class Aux
    {
        static DataTableVm setDataTableTab<TController, TResult>(this HtmlHelper html, string name, Expression<Func<TController, DataTablesResult<TResult>>> exp)
        {
            var columns = typeof(TResult).GetProperties().Where(p => p.GetGetMethod() != null).Select(p => Tuple.Create(p.Name, p.PropertyType)).ToArray();

            var mi = exp.MethodInfo();
            var controllerName = typeof(TController).Name;
            controllerName = controllerName.Substring(0, controllerName.LastIndexOf("Controller"));
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var ajaxUrl = urlHelper.Action(mi.Name, controllerName);
            return  new DataTableVm(name, ajaxUrl, columns);
        }
    }

    public enum TagType
    {
        AjaxContent = 1,
        Html = 2,
        Datatable = 3
    }
}
