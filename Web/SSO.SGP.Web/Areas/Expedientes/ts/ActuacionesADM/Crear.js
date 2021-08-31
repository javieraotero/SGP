/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
var ActuacionesADM;
(function (ActuacionesADM) {
    var ts;
    (function (ts) {
        var Crear = /** @class */ (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.TipoActuacion = $("#TipoActuacion" + hash);
                this.ModeloAplicado = $("#ModelosEscrito" + hash);
                this.Descripcion = $("#Descripcion" + hash);
                this.Fecha = $("#Fecha" + hash);
                this.Observaciones = $("#Observaciones" + hash);
                this.Texto = $("#Texto" + hash);
                this.RequiereCargo = $("#RequiereCargo" + hash);
                this.SubAmbitoCargo = $("#SubAmbitoCargo" + hash);
                this.Fojas = $("#Fojas" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                this.Expediente = $("#Expediente" + hash);
                this.OrganismoCargo = $("#OrganismoCargo" + hash);
                this.div_imputaciones = $("#div_imputaciones");
                this.tr_imputacion = $("tr[data-type=tr_imputacion]");
                this.RemoveTinymce();
                tinymce.init({
                    mode: "exact",
                    height: 600,
                    theme: 'modern',
                    language: "es",
                    selector: "#Texto" + hash,
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
                            text: 'Orientaci�n',
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
                                            text: 'N&uacute;mero',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: 'Fecha',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Fecha_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: 'Car&aacute;tula',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Caratula_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: 'Iniciador',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Iniciador_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: 'Imputado',
                                            onclick: function () {
                                                editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Imputado_Expediente]</a>');
                                            }
                                        },
                                        {
                                            text: "Detalle Imputaci&oacute;n",
                                            menu: [
                                                {
                                                    text: 'Partida',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Division',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Importe',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                            ]
                                        },
                                        {
                                            text: "Detalle Factura",
                                            menu: [
                                                {
                                                    text: 'N&uacute;mero',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Proveedor',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
                                                    }
                                                },
                                                {
                                                    text: 'Importe',
                                                    onclick: function () {
                                                        editor.insertContent('<a data-label="Numero" onclick="parent.propiedades()" style="background-color:yellow">[Numero_Expediente]</a>');
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
                this.TipoActuacion.focus();
            }
            Crear.prototype.RemoveTinymce = function () {
                //if (tinymce.editors.length > 0) {
                //    for (i = 0; i < tinymce.editors.length; i++) {
                //        tinymce.editors[i].remove();
                //    }
                //}
            };
            Crear.prototype.limpiar = function () {
                this.TipoActuacion.val('').trigger("liszt:updated");
                this.ModeloAplicado.val('').trigger("liszt:updated");
                this.Descripcion.val("");
                this.Fecha.val("");
                this.Observaciones.val("");
                this.Texto.val("");
                this.RequiereCargo.removeAttr('checked');
                this.SubAmbitoCargo.val('').trigger("liszt:updated");
                this.Expediente.val("");
                this.Fojas.val("");
            };
            Crear.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            Crear.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return Crear;
        }()); //JS
        ts.Crear = Crear;
    })(ts = ActuacionesADM.ts || (ActuacionesADM.ts = {}));
})(ActuacionesADM || (ActuacionesADM = {})); // module
