/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
var SolicitudesDeViaticos;
(function (SolicitudesDeViaticos) {
    var ts;
    (function (ts) {
        var CrearRendicion = (function () {
            function CrearRendicion(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Fecha = $('#Fecha' + hash);
                this.OrganismoSolicitante = $('#OrganismoSolicitante' + hash);
                //this.Destino = new SyncroAutocomplete("Destino" + hash, "Expedientes/MontosDeViaticos/JsonOptionsLocalidades");
                this.FechaDeInicio = $('#FechaDeInicio' + hash);
                this.FechaDeFin = $('#FechaDeFin' + hash);
                this.MedioDeTransporte = $('#MedioDeTransporte' + hash);
                this.AutoOficial = $('#AutoOficial' + hash);
                this.ConChofer = $('#ConChofer' + hash);
                this.Estado = $('#Estado' + hash);
                this.MotivoDeComision = $('#MotivoDeComision' + hash);
                this.Expediente = $('#Expediente' + hash);
                this.Identificador = $('#Identificador' + hash);
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYConfirmar" + hash);
                this.bodyAgente = $("#bodyAgentes" + hash);
                this.spTotalViatico = $("#TotalViatico" + hash);
                this.spTotalAnticipo = $("#TotalAnticipo" + hash);
                this.spTotalCobrar = $("#TotalCobrar" + hash);
                this.spTotalDevolver = $("#TotalDevolver" + hash);
                this.spTotalGastos = $("#TotalGastos" + hash);
                this.spTotalGastosSolicitados = $("#TotalGastosSolicitados" + hash);
                this.spTotalTotal = $("#TotalTotal" + hash);
                this.spBienesDeConsumo = $("#TotalBienesDeConsumo" + hash);
                this.spServiciosNoPersonales = $("#TotalServiciosNoPersonales" + hash);
                this.SolicitudDeViatico = $("#SolicitudDeViatico" + hash);
                this.Id = $("#Id" + hash);
                this.FechaAlta = $("#FechaAlta" + hash);
                this.UsuarioAlta = $("#UsuarioAlta" + hash);
                this.Destino = $("#Destino" + hash);
                this.ModalGastos = new SyncroModal($("#ModalGastos"));
                this.Concepto_Gastos = $("#concepto_gastos" + hash);
                this.Importe_Gastos = $("#importe_gastos" + hash);
                this.Guardar_Gastos = $("#guardar_gastos" + hash);
                this.Body_Gastos = $("#body_gastos" + hash);
                this.Listo_Gastos = $("#listo_gastos" + hash);
                this.Body_Partidas = $("#body_partidas" + hash);
                this.ModalSolicitud = new SyncroModal($("#ImprimirRendicionModal"));
                this.Imprimir = $("#Imprimir" + hash);
                //this.Agente = new SyncroAutocomplete("Agente" + hash, "RRHH/Agentes/GetJson");
                this.Boleta = $("#Boleta" + hash);
                this.rowBoleta = $("#rowBoleta" + hash);
                tinymce.init({
                    mode: "exact",
                    height: 600,
                    theme: 'modern',
                    language: "es",
                    selector: "#TextoSolicitud" + hash,
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
                            text: 'Orientacion',
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
                this.validacion();
            }
            CrearRendicion.prototype.validacion = function () {
                this.form.validate({
                    errorClass: "field-validation-error",
                    rules: {
                        Fecha: { required: true, number: false, maxlength: 12 },
                        OrganismoSolicitante: { required: true, number: true, maxlength: 4 },
                        Destino: { required: true, number: true, maxlength: 4 },
                        FechaDeInicio: { required: true, number: false, maxlength: 12 },
                        FechaDeFin: { required: true, number: false, maxlength: 12 },
                        MedioDeTransporte: { required: true, number: true, maxlength: 4 },
                        AutoOficial: { required: false, number: true, maxlength: 4 },
                        ConChofer: { required: true, number: false, maxlength: 1 },
                        Estado: { required: true, number: true, maxlength: 4 },
                        MotivoDeComision: { required: true, number: false, maxlength: 150 },
                        Expediente: { required: false, number: false, maxlength: 10 },
                        Identificador: { required: true, number: true, maxlength: 4 }, },
                    messages: {
                        Fecha: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        OrganismoSolicitante: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        Destino: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        FechaDeInicio: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        FechaDeFin: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 12 caracteres" },
                        MedioDeTransporte: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        AutoOficial: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        ConChofer: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 1 caracteres" },
                        Estado: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" },
                        MotivoDeComision: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 150 caracteres" },
                        Expediente: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 10 caracteres" },
                        Identificador: { required: "Debe ingresar un valor", number: "Ingrese un valor númerico", maxlength: "El campo no puede superar los 4 caracteres" }, }
                });
            };
            CrearRendicion.prototype.limpiar = function () {
                this.Fecha.val("");
                this.OrganismoSolicitante.val("");
                this.Destino.val("");
                this.FechaDeInicio.val("");
                this.FechaDeFin.val("");
                this.MedioDeTransporte.val("");
                this.AutoOficial.val("");
                this.ConChofer.removeAttr('checked');
                this.Estado.val("");
                this.MotivoDeComision.val("");
                this.Expediente.val("");
                this.Identificador.val("");
            };
            CrearRendicion.prototype.fnRegistrarDataTable = function (d) {
                this.datatables.push(d);
            };
            CrearRendicion.prototype.fnRefrescarDataTables = function () {
                var that = this;
                this.datatables.forEach(function (d) {
                    d.fnDraw();
                });
            };
            return CrearRendicion;
        })();
        ts.CrearRendicion = CrearRendicion; //JS
    })(ts = SolicitudesDeViaticos.ts || (SolicitudesDeViaticos.ts = {}));
})(SolicitudesDeViaticos || (SolicitudesDeViaticos = {})); // module
