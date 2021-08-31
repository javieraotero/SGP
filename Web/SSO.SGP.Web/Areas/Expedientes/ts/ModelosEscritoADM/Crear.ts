/// <reference path="../../../../ts/types/jquery.d.ts"/>
/// <reference path="../../../../ts/IControlador.ts"/>
/// <reference path="../../../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../../../ts/types/tinymce.d.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../../../ts/Syncro/SyncroUpload.ts"/>
module ModelosEscritoADM.ts {
	
	export class Crear implements IControlador {
		
		//---  Propiedades de Formulario --- //
		public form: JQuery;
        public datatables: DataTables.DataTable[];
        private index: number;
		
		 
		public Oficina:JQuery; 
		public Titulo:JQuery; 
		public TipoActuacion:JQuery; 
		public Contenido:any;
		public Cancelar: JQuery;
		public Guardar: JQuery;
        public GuardarYNuevo: JQuery;
        public Tipo: JQuery;
		//---  /Propiedades de Formulario --- //
		
		constructor(hash: string){
			this.form = $("#" + hash);
			this.datatables = [];

			this.Oficina = $("#OrganismosRef"+hash); 
			this.Titulo = $("#Titulo"+hash); 
			this.TipoActuacion = $("#TipoActuacion"+hash);
			//operaciones
			this.Cancelar = $("#Cancelar"+hash);
			this.Guardar = $("#Guardar"+hash);
            this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
            this.Tipo = $("#Tipo" + hash);

            //this.RemoveTinymce();
            //tinymce.remove();
            if (typeof window.tinymce != 'undefined' && $(window.tinymce.editors).length > 0) {
                $(window.tinymce.editors).each(function (idx) {
                    try {
                        tinymce.remove(idx);
                    } catch (e) { }
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
                    '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
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
                        text: 'Orientaciòn',
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
                                    text: 'Agregar Campo',
                                    onclick: function () {
                                        bootbox.prompt("Ingrese el nombre del campo", function (result) {
                                            editor.insertContent('<a href="#" data-type="text" data-pk="1" data-title="' + result + '">' + result + '</a>');
                                        });
                                    }
                                }
                            ]
                        }]
                        });

                }
            });
           
            //tinymce.init({
            //    mode: "exact",
            //    height: 500,
            //    language: "es",
            //    selector: "textarea",
            //    //elements: "Contenido" + hash,                
            //    plugins: [
            //        "advlist autolink lists link image charmap print preview anchor mention",
            //        "searchreplace visualblocks code fullscreen",
            //        "insertdatetime media table contextmenu paste responsivefilemanager"
            //    ],
            //    toolbar: "responsivefilemanager insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | variables",
            //    external_filemanager_path: "/filemanager/",
            //    filemanager_title: "Responsive Filemanager",
            //    external_plugins: { "filemanager": "/filemanager/plugin.min.js" },
            //    mentions: {
            //        source: [
            //            { name: 'Tyra Porcelli' },
            //            { name: 'Brigid Reddish' },
            //            { name: 'Ashely Buckler' },
            //            { name: 'Teddy Whelan' }
            //        ]
            //    },
            //    setup: function (editor) {
            //        editor.addButton('variables',
            //            {
            //                text: 'Variables',
            //                type: 'menubutton',
            //                icon: false,
            //                menu: [
            //                    {
            //                        text: 'Expedientes',
            //                        menu: [
            //                            {
            //                                text: 'N�mero',
            //                                onclick: function () {
            //                                    editor.insertContent('[Numero]');
            //                                }
            //                            },
            //                            {
            //                                text: 'Fecha',
            //                                onclick: function () {
            //                                    editor.insertContent('[Fecha]');
            //                                }
            //                            },
            //                            {
            //                                text: 'Car�tula',
            //                                onclick: function () {
            //                                    editor.insertContent('[Caratula]');
            //                                }
            //                            },
            //                            {
            //                                text: 'Iniciador',
            //                                onclick: function () {
            //                                    editor.insertContent('[Iniciador]');
            //                                }
            //                            },
            //                            {
            //                                text: 'Total Imputado',
            //                                onclick: function () {
            //                                    editor.insertContent('[TotalImputado]');
            //                                }
            //                            },
            //                            {
            //                                text: '�ltimo total imputado',
            //                                onclick: function () {
            //                                    editor.insertContent('[UltimoTotalImputado]');
            //                                }
            //                            },

            //                        ]
            //                    },
            //                    {
            //                        text: 'Agregar Campo',
            //                        onclick: function () {
            //                            bootbox.prompt("Ingrese el nombre del campo", function (result) {
            //                                editor.insertContent('<a href="#" data-type="text" data-pk="1" data-title="'+result+'">'+result+'</a>');
            //                            });
            //                        }
            //                    }
            //                ]
            //            });

            //    }
            //});

			//Establece el foco
			this.Oficina.focus();
        }

        public RemoveTinymce() {
            var i = 0;
            if (tinymce.editors.length > 0) {
                for (i = 0; i < tinymce.editors.length; i++) {
                    tinymce.editors[i].remove();
                }
            }
       }
		
		public limpiar():void {
			
			this.Oficina.val('').trigger("liszt:updated");
			this.Titulo.val("");
			this.TipoActuacion.val('').trigger("liszt:updated");
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
