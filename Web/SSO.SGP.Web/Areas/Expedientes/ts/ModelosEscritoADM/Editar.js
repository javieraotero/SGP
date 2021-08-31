/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ModelosEscritoADM;
(function (ModelosEscritoADM) {
    var ts;
    (function (ts) {
        var Editar = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Editar(hash) {
                var _self = this;
                this.form = $("#" + hash);
                this.datatables = [];
                this.Id = $("#Id" + hash);
                this.Oficina = $("#Oficina" + hash);
                this.Titulo = $("#Titulo" + hash);
                this.TipoActuacion = $("#TipoActuacion" + hash);
                this.Contenido = $("#Contenido" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                //this.RemoveTinymce();
                //tinymce.remove();
                if (typeof window.tinymce != 'undefined' && $(window.tinymce.editors).length > 0) {
                    $(window.tinymce.editors).each(function (idx) {
                        try {
                            tinymce.remove(idx);
                        }
                        catch (e) { }
                    });
                }
                tinymce.init({
                    mode: "exact",
                    height: 600,
                    theme: 'modern',
                    language: "es",
                    //selector: "textarea",
                    selector: "#Contenido" + hash,
                    valid_elements: '*[*]',
                    valid_children: "+body[style], +style[type]",
                    //elements: "Contenido" + hash,                
                    plugins: [
                        'advlist autolink lists link image charmap print preview hr anchor pagebreak',
                        'searchreplace wordcount visualblocks visualchars code fullscreen',
                        'insertdatetime media nonbreaking save table contextmenu directionality',
                        'emoticons template paste textcolor colorpicker textpattern imagetools',
                        "responsivefilemanager customtemplate propiedades"
                    ],
                    content_css: [
                        //'//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
                        '/Scripts/a4.css'
                    ],
                    toolbar1: "responsivefilemanager insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | variables",
                    toolbar2: 'print preview media | forecolor backcolor emoticons | sizeselect | fontselect  fontsizeselect',
                    external_filemanager_path: "/filemanager/",
                    templates: [
                        { title: 'A4', content: '<body class="document" ><div class="page" contenteditable = "true" ></div></body>' },
                        { title: 'Test template 2', content: 'Test 2' }
                    ],
                    contextmenu: "link image inserttable | cell row column deletetable customtemplate propiedades",
                    //valid_elements: "a[onclick|style],strong/b,div,br,link,img",
                    filemanager_title: "Responsive Filemanager",
                    external_plugins: { "filemanager": "/filemanager/plugin.min.js" },
                    mentions: {
                        source: [
                            { name: 'Valor 1' },
                            { name: 'Valor 2' },
                            { name: 'Valor 3' },
                            { name: 'Valor4 ' }
                        ]
                    },
                    setup: function (editor) {
                        editor.addMenuItem('example', {
                            text: 'Abrir Word',
                            context: 'file',
                            onclick: function () {
                                app.modal.cargar("prueba", "/expedientes/ModelosEscritoADM/files");
                            }
                        });
                        editor.addMenuItem('paper', {
                            text: 'Papel',
                            context: 'format',
                            menu: [
                                {
                                    text: 'A4',
                                    onclick: function () {
                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                    }
                                },
                                {
                                    text: 'Legal',
                                    onclick: function () {
                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Fecha_Expediente]</a>');
                                    }
                                }
                            ]
                        });
                        editor.addMenuItem('orientation', {
                            text: 'Orientación',
                            context: 'format',
                            menu: [
                                {
                                    text: 'Vertical',
                                    onclick: function () {
                                        //tinymce.dom.DomQuery("link[data-mce-href]").remove();
                                        //editor.dom.loadCSS("/scripts/a4l.css");
                                    }
                                },
                                {
                                    text: 'Horizontal',
                                    onclick: function () {
                                        editor.formatter.register('div.page', {
                                            inline: 'div',
                                            styles: { color: '#ff0000' }
                                        });
                                        editor.formatter.apply('div.page');
                                    }
                                }
                            ]
                        });
                        editor.addButton('variables', {
                            text: 'Variables',
                            type: 'menubutton',
                            icon: false,
                            menu: [
                                {
                                    text: 'Expedientes',
                                    menu: [
                                        {
                                            text: 'Numero',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.numero}}');
                                            }
                                        },
                                        {
                                            text: 'Fecha',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.fecha}}');
                                            }
                                        },
                                        {
                                            text: 'Fecha en letras',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.hoy_en_letras}}');
                                            }
                                        },
                                        {
                                            text: 'Caratula',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.caratula}}');
                                            }
                                        },
                                        {
                                            text: 'Iniciador',
                                            onclick: function () {
                                                editor.insertContent('{{expediente.iniciador}}');
                                            }
                                        },
                                        {
                                            text: "Imputacion",
                                            menu: [
                                                {
                                                    text: 'Tabla detalle',
                                                    onclick: function () {
                                                        editor.insertContent('<table data-tipo="imputacion" border="0" width="95%"><tbody data-action="repeat"><tr data-action="repeat"><td width="80%">{{expediente.imputacion.partida}}</td><td width="20%">{{expediente.imputacion.importe}}</td></tr></tbody></table>');
                                                    }
                                                },
                                                {
                                                    text: 'Total imputado',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].total}}');
                                                    }
                                                },
                                                {
                                                    text: 'Total imputado en letra',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].total_en_letras}}');
                                                    }
                                                },
                                                {
                                                    text: 'Año contable',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputaciones[0].anio_contable}}');
                                                    }
                                                },
                                                {
                                                    text: 'Fecha en letras',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.fecha_letras}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Division',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.division}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Importe',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.importe}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Partida',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.partida}}');
                                                    }
                                                },
                                                {
                                                    text: 'Detalle > Nombre de Partida',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.detalle.nombre_partida}}');
                                                    }
                                                },
                                            ]
                                        },
                                        {
                                            text: "Facturas",
                                            menu: [
                                                {
                                                    text: 'Tabla detalle',
                                                    onclick: function () {
                                                        editor.insertContent('<table data-tipo="factura" border="0" width="95%"><tbody data-action="repeat"><tr data-action="repeat" data-tipo="proveedor" data-sum="importe"><td colspan="3" width="100%">{{expediente.imputacion.facturas.nombre_proveedor}}</td></tr><tr data-tipo="detalle"><td>{{expediente.imputacion.facturas.numero}}</td><td>{{expediente.imputacion.facturas.concepto}}</td><td align="left">{{expediente.imputacion.facturas.importe}}</td></tr><tr data-tipo="factura" data-action="total"><td colspan="3" align="rigth">{{sum(expediente.imputacion.facturas.importe)}}</td></tr></tbody></table>');
                                                    }
                                                },
                                                {
                                                    text: 'Numero',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.numero}}');
                                                    }
                                                },
                                                {
                                                    text: 'Proveedor',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.nombre_proveedor}}');
                                                    }
                                                },
                                                {
                                                    text: 'Importe',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.importe}}');
                                                    }
                                                },
                                                {
                                                    text: 'Fecha',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.fecha}}');
                                                    }
                                                },
                                                {
                                                    text: 'Descripcion',
                                                    onclick: function () {
                                                        editor.insertContent('{{expediente.imputacion.facturas.concepto}}');
                                                    }
                                                },
                                            ]
                                        }
                                    ]
                                },
                                {
                                    text: 'Agregar Campo',
                                    onclick: function () {
                                        bootbox.prompt("Ingrese el nombre del campo", function (result) {
                                            editor.insertContent('<a href="#" data-type="text" data-pk="1" data-title="' + result + '">' + result + '</a>');
                                        });
                                    }
                                }
                            ]
                        });
                    }
                });
                //Establece el foco
                this.Titulo.focus();
            }
            Editar.prototype.RemoveTinymce = function () {
                var i = 0;
                if (tinymce.editors.length > 0) {
                    for (i = 0; i < tinymce.editors.length; i++) {
                        tinymce.editors[i].remove();
                    }
                }
            };
            Editar.prototype.limpiar = function () {
                this.Id.val("");
                this.Oficina.val('').trigger("liszt:updated");
                this.Titulo.val("");
                this.TipoActuacion.val('').trigger("liszt:updated");
                this.Contenido.val("");
                this.FechaAlta.val("");
            };
            Editar.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Editar.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Editar;
        }()); //JS
        ts.Editar = Editar;
    })(ts = ModelosEscritoADM.ts || (ModelosEscritoADM.ts = {}));
})(ModelosEscritoADM || (ModelosEscritoADM = {})); // module
