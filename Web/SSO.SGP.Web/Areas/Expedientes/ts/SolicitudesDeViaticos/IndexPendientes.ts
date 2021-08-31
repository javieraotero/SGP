/// <reference path="../types/chosen.jquery.d.ts" />
/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/types/jquery.validation.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
module SolicitudesDeViaticos.ts {
	
	export class IndexPendientes implements IControlador {
		
        public hash: string;
		public form: JQuery;
		public datatables: DataTables.DataTable[];
        public SolicitudesDeViaticos: DataTables.DataTable;
        public SolicitudesDeViaticosBorrador: DataTables.DataTable;
        public SolicitudesDeViaticosPendientes: DataTables.DataTable;
        public SolicitudesDeViaticosPorRendir: DataTables.DataTable;

        public SolicitudesDeViaticos_id: number;
        public SolicitudesDeViaticos_index: number;

        public SolicitudesDeViaticosBorrador_id: number;
        public SolicitudesDeViaticosBorrador_index: number;

        public SolicitudesDeViaticosPendientes_id: number;
        public SolicitudesDeViaticosPendientes_index: number

        public SolicitudesDeViaticosPorRendir_id: number;
        public SolicitudesDeViaticosPorRendir_index: number;

        public Comisiones: DataTables.DataTable;
        public Comisiones_id: number;
        public Comisiones_index: number;
        public Agente: SyncroAutocomplete;
        public Destino: SyncroAutocomplete;
        public Oficina: SyncroAutocomplete;
        public Buscar: JQuery;

        public Anticipos: DataTables.DataTable;
        public Anticipos_id: number;
        public Anticipos_index: number;

        public ModalSolicitud: SyncroModal;
        public TextoSolicitud: JQuery;
        public CancelarSolicitud: JQuery;
        public Parsered: JQuery;

        constructor(hash: string) {
            this.Destino = new SyncroAutocomplete("Destino" + hash, "Expedientes/MontosDeViaticos/JsonOptionsLocalidades");
            this.Agente = new SyncroAutocomplete("Agente" + hash, "RRHH/Agentes/GetJson");
            this.Buscar = $("#Buscar" + hash);
            //this.Oficina = new SyncroAutocomplete("Oficina" + hash, "RRHH/OrganismosRef/GetJson");
			this.form = $("#" + hash);
            this.datatables = [];
            this.hash = hash;

            //this.ImprimirSolicitud = $("#ImprimirSolicitud" + hash);
            //this.Anticipo = $("#Anticipo" + hash);
            //this.CancelarSolicitud = $("#CancelarSolicitud" + hash);

            this.Parsered = $("#parsered" + hash);

            this.ModalSolicitud = new SyncroModal($("#ImprimirSolicitudModal" + hash));


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
                    editor.addButton('variables',
                        {
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

		public validacion() {
            this.form.validate({
                errorClass: "field-validation-error",                
                rules: {
                
                    SolicitudesDeViaticos:{required:true, number:false, maxlength:0 },                },
                messages: {
 
                    SolicitudesDeViaticos: {required: "Debe ingresar un valor", number:"Ingrese un valor númerico", maxlength:"El campo no puede superar los 0 caracteres"},                }
            });

        }

		public limpiar() {
		}

		public setSolicitudesDeViaticos(dt: DataTables.DataTable):void {
            var self = this;
            this.SolicitudesDeViaticos = dt;

            $("#dtSolicitudesDeViaticos"+self.hash+" tbody").click(function (event) {
                $(self.SolicitudesDeViaticos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticos.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticos_id = id;
                self.SolicitudesDeViaticos_index = $(event.target).closest("tr").index();
            });			
        }

        public setSolicitudesDeViaticosBorrador(dt: DataTables.DataTable): void {
            var self = this;
            this.SolicitudesDeViaticosBorrador = dt;

            $("#dtSolicitudesDeViaticos" + self.hash + " tbody").click(function (event) {
                $(self.SolicitudesDeViaticosBorrador.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticosBorrador.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticosBorrador_id = id;
                self.SolicitudesDeViaticosBorrador_index = $(event.target).closest("tr").index();
            });
        }

        public setSolicitudesDeViaticosAnticipo(dt: DataTables.DataTable): void {
            var self = this;
            this.Anticipos = dt;

            $("#dtSolicitudesDeViaticosAnticipo tbody").click(function (event) {
                $(self.Anticipos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.Anticipos.fnGetData($(event.target).closest("tr").index())[0];
                self.Anticipos_id = id;
                self.Anticipos_index = $(event.target).closest("tr").index();
            });
        }

        public setSolicitudesDeViaticosReintegro(dt: DataTables.DataTable): void {
            var self = this;
            this.SolicitudesDeViaticos = dt;

            $("#dtSolicitudesDeViaticosReintegro tbody").click(function (event) {
                $(self.SolicitudesDeViaticos.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.SolicitudesDeViaticos.fnGetData($(event.target).closest("tr").index())[0];
                self.SolicitudesDeViaticos_id = id;
                self.SolicitudesDeViaticos_index = $(event.target).closest("tr").index();
            });
        }

        public setComisiones(dt: DataTables.DataTable): void {
            var self = this;
            this.Comisiones = dt;

            $("#dtComisiones tbody").click(function (event) {
                $(self.Comisiones.fnSettings().aoData).each(function () {
                    $(this.nTr).removeClass('row_selected');
                });
                $(event.target).closest("tr").addClass('row_selected');
                var id = self.Comisiones.fnGetData($(event.target).closest("tr").index())[0];
                self.Comisiones_id = id;
                self.Comisiones_index = $(event.target).closest("tr").index();
            });
        }
		
		public getData_SolicitudesDeViaticos(col: number): any {
            return(this.SolicitudesDeViaticos.fnGetData(this.SolicitudesDeViaticos_index)[col]); 
        }

        public getData_SolicitudesDeViaticosBorrador(col: number): any {
            return (this.SolicitudesDeViaticosBorrador.fnGetData(this.SolicitudesDeViaticosBorrador_index)[col]);
        }

        public getData_SolicitudesDeViaticosAnticipo(col: number): any {
            return (this.Anticipos.fnGetData(this.Anticipos_index)[col]);
        }

        public getData_Comisiones(col: number): any {
            return (this.Comisiones.fnGetData(this.Comisiones_index)[col]);
        }

		public selectRow_SolicitudesDeViaticos(event) {
            var self = this;
            $(self.SolicitudesDeViaticos.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.SolicitudesDeViaticos.fnGetData($(event).closest("tr").index())[0];
            self.SolicitudesDeViaticos_id = id;
            self.SolicitudesDeViaticos_index = $(event).closest("tr").index();
        }

        public selectRow_SolicitudesDeViaticosAnticipo(event) {
            var self = this;
            $(self.Anticipos.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.Anticipos.fnGetData($(event).closest("tr").index())[0];
            self.Anticipos_id = id;
            self.Anticipos_index = $(event).closest("tr").index();
        }

        public selectRow_Comisiones(event) {
            var self = this;
            $(self.Comisiones.fnSettings().aoData).each(function () {
                $(this.nTr).removeClass('row_selected');
            });
            $(event.target).closest("tr").addClass('row_selected');
            var id = self.Comisiones.fnGetData($(event).closest("tr").index())[0];
            self.Comisiones_id = id;
            self.Comisiones_index = $(event).closest("tr").index();
        }
		
		public fnRegistrarDataTable(d: DataTables.DataTable): void {
			this.datatables.push(d);
		}

		public fnRefrescarDataTables():void {
			var that = this;
			this.datatables.forEach(function (d) {
				d.fnDraw();
			});    
		}
	} //JS
} // module