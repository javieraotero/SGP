/// <reference path="../types/jquery.contextMenu.d.ts" />
/// <reference path='../types/jquery.d.ts'/>
/// <reference path="../types/blockui.d.ts"/>
/// <reference path="../types/editable.d.ts"/>
var SyncroTable = (function () {
    function SyncroTable(el, noeditable) {
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
    SyncroTable.prototype.limpiar = function () {
        this.t.find("tbody").empty();
    };
    SyncroTable.prototype.setearSeleccionable = function (sel) {
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
    };
    SyncroTable.prototype.agregarOperacion = function (display, func) {
        var op = new ColOp();
        op.name = display;
        op.callback = func;
        this.ops.push(op);
    };
    SyncroTable.prototype.setearEditable = function (propiedad, editable, source) {
        this.cols.forEach(function (c) {
            if (c.propiedad == propiedad) {
                c.editable = editable;
                if (source != null) {
                    c.source = source;
                    c.tipo = "select";
                }
            }
        });
    };
    SyncroTable.prototype.fromArray = function (s) {
        var that = this;
        var str = "";
        //clean table
        this.t.find("tbody tr").remove();
        this.id = 0;
        s.forEach(function (value, index) {
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
    };
    SyncroTable.prototype.agregarFila = function (f) {
        var fila = "<tr>";
        f.forEach(function (value, index) {
            fila += "<td>" + value + "</td>";
        });
        fila += "</tr>";
    };
    SyncroTable.prototype.refrescar = function (newurl) {
        var that = this;
        var totrows = 0;
        var row = "<tr>";
        var obj;
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
    };
    SyncroTable.prototype.refrescarPost = function (data, newurl) {
        var that = this;
        var totrows = 0;
        var row = "<tr>";
        var obj;
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
    };
    SyncroTable.prototype.Bloquear = function () {
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
    };
    SyncroTable.prototype.Desbloquear = function () {
        var el;
        el = this.t;
        $(this.t).unblock({
            onUnblock: function () {
                $(el).css('position', '');
                jQuery(el).css('zoom', '');
            }
        });
    };
    return SyncroTable;
})();
var ColOp = (function () {
    function ColOp() {
    }
    return ColOp;
})();
var TableCol = (function () {
    function TableCol(propiedad, display, editable) {
        this.propiedad = propiedad;
        this.display = display;
        this.mostrar = true;
        this.editable = editable;
        this.tipo = "text";
    }
    return TableCol;
})();
