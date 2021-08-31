/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
class SyncroTable {

    public t: JQuery;
    public cols: TableCol[];
    public ops: ColOp[];
    public cargar: boolean;
    public url: string;
    public urlupdate: string;
    public nuevo: boolean;
    public editable: boolean;
    public id: number;
    public seleccionable: boolean;
    public Id: string;
    public aSource: Array<any>;
    public index: number;

    constructor(el: JQuery, noeditable?: string[]) {
        var that = this;
        this.t = el;
        this.cols = [];
        this.ops = [];
        this.cargar = this.t.data("cargar");
        this.url = this.t.data("url");
        this.editable = this.t.data("editable");
        this.Id = this.t.attr("id");
        this.aSource = [];
        this.id = 0;

       // console.log("cargar la tabla: " + this.cargar);

        // columnas 
        this.t.find("thead tr th").each(function () {
            var tc = new TableCol($(this).data("propiedad"), $(this).data("propiedad"), that.editable);
            //console.log($(this).data("visible"));
            if (!$(this).data("visible")) {
                $(this).css("display", "none");
                tc.mostrar = false;
            }
            if (noeditable != null) {
                if (noeditable.indexOf(tc.propiedad) >= 0)
                    tc.editable = false;
            }
            that.cols.push(tc);
        });
        if (this.cargar) {
            this.refrescar();
        }
    }
    
    public limpiar(): void {
        this.t.find("tbody").empty();
    }

    public setearSeleccionable(sel: boolean): void {
        var that = this;
        this.seleccionable = sel;
        this.t.find("tbody tr td").click(function () {
            //that.id = $(this).closest("tr").data("id");
            that.id = +$(this).closest("tr").find("td:eq(0)").text();
            that.index = $(this).closest("tr").index();
            that.t.find("tbody tr td").each(function () {
                $(this).removeClass("Seleccionado");
            });
            $(this).closest("tr").find("td").addClass("Seleccionado");
        });
    }

    public agregarOperacion(display: string, func:(id: number)=>void) {
        var op = new ColOp();
        op.name = display;
        op.callback = func;
        this.ops.push(op);
    }


    public setearEditable(propiedad: string, editable: boolean, source?: any) {
        this.cols.forEach(function (c) {
            if (c.propiedad == propiedad) {
                c.editable = editable;
                if (source != null) {
                    c.source = source;
                    c.tipo = "select";
                }
            }
        });
    }

    public fromArray(s:Array<any>) {
        var that = this;
        var str = "";
        //clean table
        this.t.find("tbody tr").remove();

        this.id = 0;

        s.forEach(function (value: any, index) {
            str += '<tr>';
            that.cols.forEach(function (c) {
                if (c.mostrar)
                    str += '<td>' + value[c.propiedad] + '</td>';
                else
                    str += '<td style="display:none">' + value[c.propiedad] + '</td>';
            });
            str += '</tr>';
        });

        this.t.append(str);

        if (this.seleccionable)
            this.setearSeleccionable(true);
    }

    public agregarFila(f:Array<string>): void {
        var fila: string = "<tr>";
        f.forEach(function (value, index) {
            fila += "<td>" + value + "</td>";
        });
        fila += "</tr>"
    }

    public refrescar(newurl?:string) {
        var that = this;
        var totrows = 0;
        var row = "<tr>";
        var obj: TableCol;
        this.url = (newurl != null) ? newurl : this.url;
        this.Bloquear();

        this.id = 0;

        //limpiar la tabla
        this.t.find("tbody tr").remove();

        $.getJSON(this.url, function (data) {
            $.each(data, function (key, val) {
                that.cols.forEach(function (c) {
                    //console.log((c.propiedad.indexOf("Fecha") > -1) ? c.propiedad + " es fecha" : c.propiedad + " no es fecha");
                    var valor = (c.propiedad.indexOf("Fecha") > -1 || c.propiedad.indexOf("Desde") > -1 || c.propiedad.indexOf("Hasta") > -1) ? app.formatearFecha(val[c.propiedad]) : val[c.propiedad];
                    //row += (c.editable) ? "<td><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td>" + valor + "</td>";                
                    if (c.mostrar)
                        row += (c.editable) ? "<td><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td>" + valor + "</td>";
                    else
                        row += (c.editable) ? "<td style='display:none'><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td style='display:none'>" + valor + "</td>";  
                });
                totrows++;
                that.t.find("tbody").append("<tr data-id='"+val["Id"]+"'>"+row+"</tr>");
                row = "";
            });

            if (totrows == 0) {
                that.t.find("tbody").append("<tr><td colspan='"+that.cols.length+"'>No se encontraron registros</td></tr>");
            }

            if (that.editable) {
                that.t.find("tbody tr td a").editable({type:"text"});
            }

            if (that.seleccionable) {
                that.setearSeleccionable(true);                
            }
        });

        this.Desbloquear();

    }

    public refrescarPost(data: any, newurl?: string) {
        var that = this;
        var totrows = 0;
        var row = "<tr>";
        var obj: TableCol;
        this.url = (newurl != null) ? newurl : this.url;
        this.Bloquear();

        //limpiar la tabla
        this.t.find("tbody tr").remove();
        this.id = 0;

        $.post(this.url, data).done(function (data) {
            $.each(data, function (key, val) {
                that.cols.forEach(function (c) {
                    var valor = (c.propiedad.indexOf("Fecha") > -1) ? app.formatearFecha(val[c.propiedad]) : val[c.propiedad];
                    if (c.mostrar) 
                        row += (c.editable) ? "<td><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td>" + valor + "</td>";
                    else
                        row += (c.editable) ? "<td style='display:none'><a href='#' t='editable' data-type='" + c.tipo + "' data-name='" + c.propiedad + "' data-url='" + that.urlupdate + "' data-source='" + c.source + "' data-pk='" + val["Id"] + "' data-title='Ingresar " + c.display + "' data-type='" + c.tipo + "'>" + val[c.propiedad] + "</a></td>" : "<td style='display:none'>" + valor + "</td>";        
                });
                totrows++;
                that.t.find("tbody").append("<tr data-id='" + val["Id"] + "'>" + row + "</tr>");
                row = "";
            });

            if (totrows == 0) {
                that.t.find("tbody").append("<tr><td colspan='" + that.cols.length + "'>No se encontraron registros</td></tr>");
            }

            if (that.editable) {
                that.t.find("tbody tr td a").editable({ type: "text" });
            }

            if (that.seleccionable) {
                that.setearSeleccionable(true);
            }
        });

        this.Desbloquear();

    }


    public Bloquear() {

        var centerY = false;

        if (this.t.height() <= 400) {
            centerY = true;
        }

        this.t.block({
            message: '<img src="./assets/img/ajax-loading.gif" align="">',
            centerY: centerY != undefined ? centerY : true,
            css: {
                top: '10%',
                border: 'none',
                padding: '2px',
                backgroundColor: 'none'
            },
            overlayCSS: {
                backgroundColor: '#000',
                opacity: 0.05,
                cursor: 'wait'
            }
        });
    }

    public Desbloquear() {
        var el: JQuery;
        el = this.t;
        $(this.t).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    }

}

interface funcion {
    (id: number): void;
}

class ColOp {
    public icon: string;
    public name: string;
    public callback: funcion;
}

class TableCol {

    public propiedad: string;
    public display: string;
    public mostrar: boolean;
    public tipo: string;
    public editable: boolean;
    public source: any;

    constructor(propiedad: string, display: string, editable: boolean) {
        this.propiedad = propiedad;
        this.display = display;
        this.mostrar = true;
        this.editable = editable;
        this.tipo = "text";
    }

}
