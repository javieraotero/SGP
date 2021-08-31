/// <reference path="../../ts/types/jquery.d.ts"/>
/// <reference path="../../ts/IControlador.ts"/>
/// <reference path="../../ts/types/jquery.dataTables.d.ts"/>
/// <reference path="../../ts/Syncro/SyncroTabla.ts"/>
/// <reference path="../../ts/Syncro/SyncroModal.ts"/>
/// <reference path="../../ts/Syncro/SyncroUpload.ts"/>
var Personas;
(function (Personas) {
    var ts;
    (function (ts) {
        var Crear = (function () {
            //---  /Propiedades de Formulario --- //
            function Crear(hash) {
                this.form = $("#" + hash);
                this.datatables = [];
                this.Apellidos = $("#Apellidos" + hash);
                this.Nombres = $("#Nombres" + hash);
                this.TipoDocumento = $("#TipoDocumento" + hash);
                this.NroDocumento = $("#NroDocumento" + hash);
                this.FechaNacimiento = $("#FechaNacimiento" + hash);
                this.LugarNacimiento = $("#LugarNacimiento" + hash);
                this.Sexo = $("#Sexo" + hash);
                this.EsMenor = $("#EsMenor" + hash);
                this.Alias = $("#Alias" + hash);
                this.PersonaFisica = $("#PersonaFisica" + hash);
                this.Barrio = $("#Barrio" + hash);
                this.Calle = $("#Calle" + hash);
                this.Domicilio = $("#Domicilio" + hash);
                this.Localidad = $("#Localidad" + hash);
                this.Ocupacion = $("#Ocupacion" + hash);
                this.Nacionalidad = $("#Nacionalidad" + hash);
                this.Telefono = $("#Telefono" + hash);
                this.Fallecido = $("#Fallecido" + hash);
                this.FechaDefuncion = $("#FechaDefuncion" + hash);
                this.TipoEscolaridad = $("#TipoEscolaridad" + hash);
                this.EstadoEscolaridad = $("#EstadoEscolaridad" + hash);
                this.TipoOcupacion = $("#TipoOcupacion" + hash);
                this.EstadoCivil = $("#EstadoCivil" + hash);
                this.Ocupado = $("#Ocupado" + hash);
                this.ObraSocial = $("#ObraSocial" + hash);
                this.Detenido = $("#Detenido" + hash);
                this.ColorOjos = $("#ColorOjos" + hash);
                this.ColorPelo = $("#ColorPelo" + hash);
                this.LongitudPelo = $("#LongitudPelo" + hash);
                this.Altura = $("#Altura" + hash);
                this.Peso = $("#Peso" + hash);
                this.Piel = $("#Piel" + hash);
                this.BarbaBigote = $("#BarbaBigote" + hash);
                this.LongitudBarbaBigote = $("#LongitudBarbaBigote" + hash);
                this.ColorBarbaBigote = $("#ColorBarbaBigote" + hash);
                this.PielVarios = $("#PielVarios" + hash);
                this.Varios = $("#Varios" + hash);
                this.Tonada = $("#Tonada" + hash);
                this.CriterioOportunidadArt15 = $("#CriterioOportunidadArt15" + hash);
                this.Celular = $("#Celular" + hash);
                this.TelefonoTrabajo = $("#TelefonoTrabajo" + hash);
                this.DomicilioTrabajo = $("#DomicilioTrabajo" + hash);
                this.Observaciones = $("#Observaciones" + hash);
                this.NombrePadre = $("#NombrePadre" + hash);
                this.NombreMadre = $("#NombreMadre" + hash);
                this.DomicilioProcesal = $("#DomicilioProcesal" + hash);
                this.LocalidadProcesal = $("#LocalidadProcesal" + hash);
                this.Conyugue = $("#Conyugue" + hash);
                this.Inscripcion = $("#Inscripcion" + hash);
                this.FolioInscripcion = $("#FolioInscripcion" + hash);
                this.TomoInscripcion = $("#TomoInscripcion" + hash);
                this.AnioInscripcion = $("#AnioInscripcion" + hash);
                this.FechaInscripcion = $("#FechaInscripcion" + hash);
                this.LocalidadDefuncion = $("#LocalidadDefuncion" + hash);
                this.ProvinciaDefuncion = $("#ProvinciaDefuncion" + hash);
                this.ConyugeVive = $("#ConyugeVive" + hash);
                //operaciones
                this.Cancelar = $("#Cancelar" + hash);
                this.Guardar = $("#Guardar" + hash);
                this.GuardarYNuevo = $("#GuardarYNuevo" + hash);
                //Establece el foco
                this.Apellidos.focus();
            }
            Crear.prototype.limpiar = function () {
                this.Apellidos.val("");
                this.Nombres.val("");
                this.NroDocumento.val("");
                this.FechaNacimiento.val("");
                this.LugarNacimiento.val("");
                this.EsMenor.removeAttr('checked');
                this.Alias.val("");
                this.PersonaFisica.removeAttr('checked');
                this.Domicilio.val("");
                this.Ocupacion.val("");
                this.Nacionalidad.val("");
                this.Telefono.val("");
                this.Fallecido.removeAttr('checked');
                this.FechaDefuncion.val("");
                this.Ocupado.removeAttr('checked');
                this.ObraSocial.removeAttr('checked');
                this.Detenido.removeAttr('checked');
                this.CriterioOportunidadArt15.removeAttr('checked');
                this.Celular.val("");
                this.TelefonoTrabajo.val("");
                this.DomicilioTrabajo.val("");
                this.Observaciones.val("");
                this.NombrePadre.val("");
                this.NombreMadre.val("");
                this.DomicilioProcesal.val("");
                this.LocalidadProcesal.val("");
                this.Conyugue.val("");
                this.Inscripcion.val("");
                this.FolioInscripcion.val("");
                this.TomoInscripcion.val("");
                this.AnioInscripcion.val("");
                this.FechaInscripcion.val("");
                this.LocalidadDefuncion.val("");
                this.ProvinciaDefuncion.val("");
                this.ConyugeVive.removeAttr('checked');
            };
            //--- Funciones para seteo de Datatables ---/
            Crear.prototype.getData = function (col) {
                return (this.Agentes.fnGetData(this.index)[col]);
            };
            //--- /Funciones para seteo de Datatables ---/
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
        })();
        ts.Crear = Crear; //JS
    })(ts = Personas.ts || (Personas.ts = {}));
})(Personas || (Personas = {})); // module
