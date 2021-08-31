using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Common;
using SSO.SGP.EntidadesDeNegocio.Vistas;

namespace SSO.SGP.EntidadesDeNegocio
{
	public class BDEntities : DbContext
	{
        public BDEntities()
            : base("name=DefaultConnection")
        {

        }
        
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<Menus> Menus { get; set; }

       // public DbSet<Agentes> Agentes { get; set; }
        //public DbSet<CargosRef> CargosRef { get; set; }
        //public DbSet<Personas> Personas { get; set; }

        public DbSet<ActividadesInternasRef> ActividadesInternasRef { get; set; }
        public DbSet<Actuaciones> Actuaciones { get; set; }
        public DbSet<Actuacionesadm> Actuacionesadm { get; set; }
        public DbSet<ActuacionesCivil> ActuacionesCivil { get; set; }
        public DbSet<ActuacionesCivilNotificacion> ActuacionesCivilNotificacion { get; set; }
        public DbSet<ActuacionesNotificacion> ActuacionesNotificacion { get; set; }
        public DbSet<ActuacionesPersonaDelito> ActuacionesPersonaDelito { get; set; }
        public DbSet<ActuacionesProvisorias> ActuacionesProvisorias { get; set; }
        public DbSet<ActuacionesVoces> ActuacionesVoces { get; set; }
        public DbSet<Acumulados> Acumulados { get; set; }
        public DbSet<Agentes> Agentes { get; set; }
        public DbSet<Ambitos> Ambitos { get; set; }
        public DbSet<ArchivoExpediente> ArchivoExpediente { get; set; }
        public DbSet<ArchivoExpedientePases> ArchivoExpedientePases { get; set; }
        public DbSet<ArticulosDeComprasDeSuministros> ArticulosDeComprasDeSuministros { get; set; }
        public DbSet<ArticulosDePedidoDeSuministros> ArticulosDePedidoDeSuministros { get; set; }
        public DbSet<ArticulosDeSuministros> ArticulosDeSuministros { get; set; }
        public DbSet<AtencionesRef> AtencionesRef { get; set; }
        public DbSet<Audiencias> Audiencias { get; set; }
        public DbSet<AudienciasAnteriores> AudienciasAnteriores { get; set; }
        public DbSet<AudienciasCivil> AudienciasCivil { get; set; }
        public DbSet<AudienciasDemoras> AudienciasDemoras { get; set; }
        public DbSet<AudienciasEstados> AudienciasEstados { get; set; }
        public DbSet<AudienciasEstadosCivil> AudienciasEstadosCivil { get; set; }
        public DbSet<AudienciasImputados> AudienciasImputados { get; set; }
        public DbSet<AudienciasNotificacion> AudienciasNotificacion { get; set; }
        public DbSet<AudienciasNotificacionCivil> AudienciasNotificacionCivil { get; set; }
        public DbSet<AudienciasSolicitud> AudienciasSolicitud { get; set; }
        //public DbSet<AudienciasSolicitudPersonasRel> AudienciasSolicitudPersonasRel { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<BarriosRef> BarriosRef { get; set; }
        public DbSet<CajaForense> CajaForense { get; set; }
        public DbSet<CallesRef> CallesRef { get; set; }
        public DbSet<CambiosRadicacion> CambiosRadicacion { get; set; }
        public DbSet<CargosFuncionalesRef> CargosFuncionalesRef { get; set; }
        public DbSet<CargosRef> CargosRef { get; set; }
        public DbSet<CategoriasCausas> CategoriasCausas { get; set; }
        public DbSet<CategoriasCausasCivil> CategoriasCausasCivil { get; set; }
        public DbSet<CategoriasDeImagenesRef> CategoriasDeImagenesRef { get; set; }
        public DbSet<CategoriasExpedienteadmRef> CategoriasExpedienteadmRef { get; set; }
        public DbSet<CategoriasExpedientes> CategoriasExpedientes { get; set; }
        public DbSet<CategoriasRef> CategoriasRef { get; set; }
        public DbSet<Causas> Causas { get; set; }
        public DbSet<CausasAccesos> CausasAccesos { get; set; }
        public DbSet<CausasDocumento> CausasDocumento { get; set; }
        public DbSet<CausasEstado> CausasEstado { get; set; }
        public DbSet<CausasReceptoria> CausasReceptoria { get; set; }
        public DbSet<CausasResponsable> CausasResponsable { get; set; }
        public DbSet<CircunscripcionesRef> CircunscripcionesRef { get; set; }
        public DbSet<Columnas> Columnas { get; set; }
        public DbSet<CoMediadores> CoMediadores { get; set; }
        public DbSet<CoMediadoresContadores> CoMediadoresContadores { get; set; }
        public DbSet<CoMediadoresEspecialidad> CoMediadoresEspecialidad { get; set; }
        public DbSet<CoMediadoresInscripcion> CoMediadoresInscripcion { get; set; }
        public DbSet<CompraDeSuministros> CompraDeSuministros { get; set; }
        public DbSet<Concursos> Concursos { get; set; }
        public DbSet<Conexiones> Conexiones { get; set; }
        public DbSet<Contadores> Contadores { get; set; }
        public DbSet<ControlPresentaciones> ControlPresentaciones { get; set; }
        public DbSet<DelitosCapituloRef> DelitosCapituloRef { get; set; }
        public DbSet<DelitosRef> DelitosRef { get; set; }
        public DbSet<DelitosTituloRef> DelitosTituloRef { get; set; }
        public DbSet<Denegatoriasrrhh> Denegatoriasrrhh { get; set; }
        public DbSet<Denuncias> Denuncias { get; set; }
        public DbSet<DerivacionesOaVyt> DerivacionesOaVyt { get; set; }
        public DbSet<ElementosSecuestrados> ElementosSecuestrados { get; set; }
        public DbSet<ElementosSecuestradosDocumento> ElementosSecuestradosDocumento { get; set; }
        public DbSet<ElementosSecuestradosMovimiento> ElementosSecuestradosMovimiento { get; set; }
        public DbSet<EmbargosyOtros> EmbargosyOtros { get; set; }
        public DbSet<EstadosActuacionRef> EstadosActuacionRef { get; set; }
        public DbSet<EstadosArchivoExpedienteRef> EstadosArchivoExpedienteRef { get; set; }
        public DbSet<EstadosAudienciaRef> EstadosAudienciaRef { get; set; }
        public DbSet<EstadosCausaRef> EstadosCausaRef { get; set; }
        public DbSet<EstadosCivilRef> EstadosCivilRef { get; set; }
        public DbSet<EstadosElementosSecuestradosRef> EstadosElementosSecuestradosRef { get; set; }
        public DbSet<EstadosEscolaridadRef> EstadosEscolaridadRef { get; set; }
        public DbSet<EstadosExpedienteRef> EstadosExpedienteRef { get; set; }
        public DbSet<EstadosIncidentes> EstadosIncidentes { get; set; }
        public DbSet<EstadosPreventivoRef> EstadosPreventivoRef { get; set; }
        public DbSet<EstadosUsuarioRef> EstadosUsuarioRef { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<EventosCivil> EventosCivil { get; set; }
        public DbSet<Excusaciones> Excusaciones { get; set; }
        public DbSet<Expedientes> Expedientes { get; set; }
        public DbSet<ExpedientesAccesos> ExpedientesAccesos { get; set; }
        public DbSet<Expedientesadm> Expedientesadm { get; set; }
        public DbSet<ExpedientesAnotaciones> ExpedientesAnotaciones { get; set; }
        public DbSet<ExpedientesArchivo> ExpedientesArchivo { get; set; }
        //public DbSet<ExpedientesCategoriasRel> ExpedientesCategoriasRel { get; set; }
        public DbSet<ExpedientesDelito> ExpedientesDelito { get; set; }
        public DbSet<ExpedientesDocumento> ExpedientesDocumento { get; set; }
        public DbSet<ExpedientesDocumentoadm> ExpedientesDocumentoadm { get; set; }
        public DbSet<ExpedientesElemento> ExpedientesElemento { get; set; }
        public DbSet<ExpedientesEstado> ExpedientesEstado { get; set; }
        //public DbSet<ExpedientesOficinasRel> ExpedientesOficinasRel { get; set; }
        public DbSet<ExpedientesPase> ExpedientesPase { get; set; }
        public DbSet<ExpedientesPaseadm> ExpedientesPaseadm { get; set; }
        public DbSet<ExpedientesPersona> ExpedientesPersona { get; set; }
        public DbSet<ExpedientesPersonaadm> ExpedientesPersonaadm { get; set; }
        public DbSet<ExpedientesPersonaDetenida> ExpedientesPersonaDetenida { get; set; }
        public DbSet<ExpedientesResponsable> ExpedientesResponsable { get; set; }
        //public DbSet<ExpedientesSumariantesRel> ExpedientesSumariantesRel { get; set; }
        public DbSet<FeriadosRef> FeriadosRef { get; set; }
        public DbSet<FeriasAgentes> FeriasAgentes { get; set; }
        public DbSet<FeriasRef> FeriasRef { get; set; }
        public DbSet<Formularios> Formularios { get; set; }
        //public DbSet<FormulariosModulosRel> FormulariosModulosRel { get; set; }
        public DbSet<FuerosRef> FuerosRef { get; set; }
        public DbSet<GrupoElementosPoliciaRef> GrupoElementosPoliciaRef { get; set; }
        public DbSet<GrupoFamiliar> GrupoFamiliar { get; set; }
        public DbSet<GruposEstadoAudienciaRef> GruposEstadoAudienciaRef { get; set; }
        public DbSet<GruposEstadoCausaRef> GruposEstadoCausaRef { get; set; }
        public DbSet<GruposEstadoExpedienteRef> GruposEstadoExpedienteRef { get; set; }
        public DbSet<GruposTipoActuacionCivilRef> GruposTipoActuacionCivilRef { get; set; }
        public DbSet<GruposTipoActuacionRef> GruposTipoActuacionRef { get; set; }
        public DbSet<GruposUsuarioRef> GruposUsuarioRef { get; set; }
        public DbSet<Imagenesrrhh> Imagenesrrhh { get; set; }
        public DbSet<Incidentes> Incidentes { get; set; }
        public DbSet<IncidentesEstado> IncidentesEstado { get; set; }
        public DbSet<ItemsMenu> ItemsMenu { get; set; }
        //public DbSet<ItemsMenuGruposUsuarioRel> ItemsMenuGruposUsuarioRel { get; set; }
        public DbSet<JuecesContadores> JuecesContadores { get; set; }
        public DbSet<JuecesSorteo> JuecesSorteo { get; set; }
        public DbSet<LicenciasAgente> LicenciasAgente { get; set; }
        public DbSet<LicenciasRef> LicenciasRef { get; set; }
        public DbSet<Liquidacion> Liquidacion { get; set; }
        public DbSet<LiquidacionAbogados> LiquidacionAbogados { get; set; }
        public DbSet<LiquidacionCapitales> LiquidacionCapitales { get; set; }
        public DbSet<LiquidacionConfiguracionValores> LiquidacionConfiguracionValores { get; set; }
        public DbSet<LiquidacionGastos> LiquidacionGastos { get; set; }
        public DbSet<LocalidadesRef> LocalidadesRef { get; set; }
        public DbSet<LogsReceptoria> LogsReceptoria { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Mediadores> Mediadores { get; set; }
        public DbSet<MediadoresContadores> MediadoresContadores { get; set; }
        public DbSet<MediadoresInscripcion> MediadoresInscripcion { get; set; }
        public DbSet<MediadoresInscripcionEstado> MediadoresInscripcionEstado { get; set; }
        public DbSet<MediadoresPeriodo> MediadoresPeriodo { get; set; }
        public DbSet<MediadoresPeriodosTipo> MediadoresPeriodosTipo { get; set; }
        public DbSet<MediadoresTipo> MediadoresTipo { get; set; }
        public DbSet<MedidasDisciplinarias> MedidasDisciplinarias { get; set; }
        public DbSet<MesesRef> MesesRef { get; set; }
        public DbSet<ModalidadesAsistenciaoaVyt> ModalidadesAsistenciaoaVyt { get; set; }
        public DbSet<ModalidadesPoliciaRef> ModalidadesPoliciaRef { get; set; }
        public DbSet<ModelosEscrito> ModelosEscrito { get; set; }
        public DbSet<Modulos> Modulos { get; set; }
        public DbSet<MonitoreoActividades> MonitoreoActividades { get; set; }
        public DbSet<MotivosCancelacionCivilRef> MotivosCancelacionCivilRef { get; set; }
        public DbSet<MotivosCancelacionRef> MotivosCancelacionRef { get; set; }
        public DbSet<MotivosDemoraRef> MotivosDemoraRef { get; set; }
        public DbSet<MotivosElementosSecuentradosMovimientoRef> MotivosElementosSecuentradosMovimientoRef { get; set; }
        public DbSet<MotivosPostergacionCivilRef> MotivosPostergacionCivilRef { get; set; }
        public DbSet<MotivosPostergacionRef> MotivosPostergacionRef { get; set; }
        public DbSet<MovimientosDeAgentes> MovimientosDeAgentes { get; set; }
        public DbSet<MovimientosDeStock> MovimientosDeStock { get; set; }
        public DbSet<Nombramientos> Nombramientos { get; set; }
        public DbSet<NombramientosMovimientos> NombramientosMovimientos { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<NoticiasCivil> NoticiasCivil { get; set; }
        public DbSet<Notificaciones> Notificaciones { get; set; }
        public DbSet<NotificacionesCivil> NotificacionesCivil { get; set; }
        public DbSet<OrdenesCaptura> OrdenesCaptura { get; set; }
        public DbSet<OrganismosRef> OrganismosRef { get; set; }
        public DbSet<OrganismosSecuenciaModelosRef> OrganismosSecuenciaModelosRef { get; set; }
        public DbSet<OrganismosSecuenciaRef> OrganismosSecuenciaRef { get; set; }
        public DbSet<ParametrosReceptoria> ParametrosReceptoria { get; set; }
        public DbSet<ParametrosSeguridadRef> ParametrosSeguridadRef { get; set; }
        public DbSet<ParametrosTrabajoCivilRef> ParametrosTrabajoCivilRef { get; set; }
        public DbSet<ParametrosTrabajoRef> ParametrosTrabajoRef { get; set; }
        public DbSet<Pasos> Pasos { get; set; }
        public DbSet<PedidosDeSuministros> PedidosDeSuministros { get; set; }
        public DbSet<Peritos> Peritos { get; set; }
        public DbSet<PeritosContadores> PeritosContadores { get; set; }
        public DbSet<PeritosEspecialidad> PeritosEspecialidad { get; set; }
        public DbSet<PeritosInscripcion> PeritosInscripcion { get; set; }
        public DbSet<PeritosPeriodo> PeritosPeriodo { get; set; }
        public DbSet<PeritosSanciones> PeritosSanciones { get; set; }
        public DbSet<PeritosSorteo> PeritosSorteo { get; set; }
        public DbSet<PeritosTiposPeriodo> PeritosTiposPeriodo { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        //public DbSet<PermisosGruposUsuarioRel> PermisosGruposUsuarioRel { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<PersonasCaracteristicasRef> PersonasCaracteristicasRef { get; set; }
        public DbSet<PersonasDocumentacion> PersonasDocumentacion { get; set; }
        public DbSet<PersonasParentescos> PersonasParentescos { get; set; }
        public DbSet<PersonasPertenencias> PersonasPertenencias { get; set; }
        public DbSet<PresentacionesCausa> PresentacionesCausa { get; set; }
        public DbSet<PresentacionesCausaConexion> PresentacionesCausaConexion { get; set; }
        public DbSet<PrestacionesRef> PrestacionesRef { get; set; }
        public DbSet<Presupuestacion> Presupuestacion { get; set; }
        public DbSet<PresupuestacionCapitales> PresupuestacionCapitales { get; set; }
        public DbSet<PresupuestacionConfiguracion> PresupuestacionConfiguracion { get; set; }
        public DbSet<PresupuestacionConfiguracionValores> PresupuestacionConfiguracionValores { get; set; }
        public DbSet<PresupuestacionGastos> PresupuestacionGastos { get; set; }
        public DbSet<Preventivos> Preventivos { get; set; }
        public DbSet<PreventivosDelitos> PreventivosDelitos { get; set; }
        public DbSet<PreventivosElementos> PreventivosElementos { get; set; }
        public DbSet<PreventivosPersona> PreventivosPersona { get; set; }
        public DbSet<Protocolos> Protocolos { get; set; }
        public DbSet<ProtocolosCategorias> ProtocolosCategorias { get; set; }
        public DbSet<ProvinciasRef> ProvinciasRef { get; set; }
        public DbSet<ReservaSalasAudiencia> ReservaSalasAudiencia { get; set; }
        public DbSet<ResultadosNotificacion> ResultadosNotificacion { get; set; }
        public DbSet<RolesElementoRef> RolesElementoRef { get; set; }
        public DbSet<RolesPersonaadmRef> RolesPersonaadmRef { get; set; }
        public DbSet<RolesPersonaCivilRef> RolesPersonaCivilRef { get; set; }
        public DbSet<RolesPersonaRef> RolesPersonaRef { get; set; }
        public DbSet<SaldosDeLicenciasOrdinarias> SaldosDeLicenciasOrdinarias { get; set; }
        public DbSet<SectoresNotificacion> SectoresNotificacion { get; set; }
        public DbSet<SectoresPoliciaRef> SectoresPoliciaRef { get; set; }
        public DbSet<SexosRef> SexosRef { get; set; }
        public DbSet<SitiosPoliciaRef> SitiosPoliciaRef { get; set; }
        public DbSet<SituacionesDeRevista> SituacionesDeRevista { get; set; }
        public DbSet<Sucesos> Sucesos { get; set; }
        public DbSet<SucesosCausas> SucesosCausas { get; set; }
        public DbSet<SucesosReceptoria> SucesosReceptoria { get; set; }
        public DbSet<SucesosTitulos> SucesosTitulos { get; set; }
        public DbSet<SuspensionPlazo> SuspensionPlazo { get; set; }
        public DbSet<Sustituciones> Sustituciones { get; set; }
        public DbSet<Tablas> Tablas { get; set; }
        public DbSet<TiposActuacionadmRef> TiposActuacionadmRef { get; set; }
        public DbSet<TiposActuacionCivilRef> TiposActuacionCivilRef { get; set; }
        public DbSet<TiposActuacionRef> TiposActuacionRef { get; set; }
        public DbSet<TiposArchivadoRef> TiposArchivadoRef { get; set; }
        public DbSet<TiposAudienciaCivilRef> TiposAudienciaCivilRef { get; set; }
        public DbSet<TiposAudienciaRef> TiposAudienciaRef { get; set; }
        public DbSet<TiposCambiosCircunscripcion> TiposCambiosCircunscripcion { get; set; }
        public DbSet<TiposDatoRef> TiposDatoRef { get; set; }
        public DbSet<TiposDenunciasRef> TiposDenunciasRef { get; set; }
        public DbSet<TiposDocumentacionPersonaRef> TiposDocumentacionPersonaRef { get; set; }
        public DbSet<TiposDocumentoRef> TiposDocumentoRef { get; set; }
        public DbSet<TiposEscolaridadRef> TiposEscolaridadRef { get; set; }
        public DbSet<TiposExpedienteadmRef> TiposExpedienteadmRef { get; set; }
        public DbSet<TiposFormatoArchivoRef> TiposFormatoArchivoRef { get; set; }
        public DbSet<TiposMateriasRef> TiposMateriasRef { get; set; }
        public DbSet<TiposModeloEscritoRef> TiposModeloEscritoRef { get; set; }
        public DbSet<TiposModelosEscritoadmRef> TiposModelosEscritoadmRef { get; set; }
        public DbSet<TiposNotificacion> TiposNotificacion { get; set; }
        public DbSet<TiposOcupacionRef> TiposOcupacionRef { get; set; }
        public DbSet<TiposOrganismoRef> TiposOrganismoRef { get; set; }
        public DbSet<TiposOrigenExpedienteRef> TiposOrigenExpedienteRef { get; set; }
        public DbSet<TiposOrigenoaVyt> TiposOrigenoaVyt { get; set; }
        public DbSet<TiposParentescosRef> TiposParentescosRef { get; set; }
        public DbSet<TiposPersonaCaracteristicaRef> TiposPersonaCaracteristicaRef { get; set; }
        public DbSet<TiposRelevarControl> TiposRelevarControl { get; set; }
        public DbSet<TiposSucesos> TiposSucesos { get; set; }
        //public DbSet<TraceProduccion> TraceProduccion { get; set; }
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<UsuariosAccesos> UsuariosAccesos { get; set; }
        public DbSet<UsuariosCambiosClave> UsuariosCambiosClave { get; set; }
        public DbSet<UsuariosOrganismosGrupos> UsuariosOrganismosGrupos { get; set; }
        public DbSet<Voces> Voces { get; set; }
        public DbSet<LicenciasOrdinariasIniciales> LicenciasOrdinariasIniciales { get; set; }
        public DbSet<Reportes> Reportes { get; set; }
        public DbSet<ReportesParametros> ReportesParametros { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<FormasDePagoRef> FormasDePagoRef { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<TiposCuentasBancariasRef> TiposCuentasBancariasRef { get; set; }
        public DbSet<Parametrosadm> Parametrosadm { get; set; }
        public DbSet<DivisionesExtraPresupuestarias> DivisionesExtraPresupuestarias { get; set; }
        public DbSet<EjecucionesPresupuestarias> EjecucionesPresupuestarias { get; set; }
        public DbSet<FacturasImputadas> FacturasImputadas { get; set; }
        public DbSet<FacturasImputadasDetalle> FacturasImputadasDetalle { get; set; }
        public DbSet<ImputacionesContables> ImputacionesContables { get; set; }
        public DbSet<ImputacionesContablesDetalle> ImputacionesContablesDetalle { get; set; }
        public DbSet<PartidasPresupuestarias> PartidasPresupuestarias { get; set; }
        public DbSet<UnidadesDeOrganizacionRef> UnidadesDeOrganizacionRef { get; set; }
        public DbSet<OperacionesContablesRef> OperacionesContablesRef { get; set; }
        public DbSet<ModelosEscritoadm> ModelosEscritoadm { get; set; }
        public DbSet<UnidadesrrhhRef> UnidadesrrhhRef { get; set; }
        public DbSet<UnidadDeContextoRef> UnidadDeContextoRef { get; set; }
        public DbSet<UnidadTemporalRef> UnidadTemporalRef { get; set; }
        public DbSet<LicenciasAgenteExcepciones> LicenciasAgenteExcepciones { get; set; }
        public DbSet<ColaDeMovimientoscesida> ColaDeMovimientoscesida { get; set; }
        public DbSet<Movimientoscesida> Movimientoscesida { get; set; }
        public DbSet<AgentesDocencia> AgentesDocencia { get; set; }
        public DbSet<CesidaCargosRef> CesidaCargosRef { get; set; }
        public DbSet<CesidaCategorias> CesidaCategorias { get; set; }
        public DbSet<CesidaEmpresasRef> CesidaEmpresasRef { get; set; }
        public DbSet<CesidaFuncionesRef> CesidaFuncionesRef { get; set; }
        public DbSet<CesidaJornadasRef> CesidaJornadasRef { get; set; }
        public DbSet<CesidaMovimientoAgentes> CesidaMovimientoAgentes { get; set; }
        public DbSet<CesidaMovimientos> CesidaMovimientos { get; set; }
        public DbSet<CesidaMovimientosAgentesDetalles> CesidaMovimientosAgentesDetalles { get; set; }
        public DbSet<CesidaOrganismosRef> CesidaOrganismosRef { get; set; }
        public DbSet<CesidaParametrosDeMovimientos> CesidaParametrosDeMovimientos { get; set; }
        public DbSet<CesidaRevistasRef> CesidaRevistasRef { get; set; }
        public DbSet<CesidaTitulosRef> CesidaTitulosRef { get; set; }
        public DbSet<CesidaUbicaciones> CesidaUbicaciones { get; set; }
        public DbSet<CesidaValoresDeParametros> CesidaValoresDeParametros { get; set; }
        public DbSet<AgentesBonificaciones> AgentesBonificaciones { get; set; }
        public DbSet<EjecucionesPresupuestariasReestructuras> EjecucionesPresupuestariasReestructuras { get; set; }
        public DbSet<ConcursosDeIngreso> ConcursosDeIngreso { get; set; }
        public DbSet<ConcursosDeIngresoInscripciones> ConcursosDeIngresoInscripciones { get; set; }
        public DbSet<RegistroRebeldiaDTO> RegistroRebeldiaDTO { get; set; }
        public DbSet<Bienes> Bienes { get; set; }
        public DbSet<BienesEliminados> BienesEliminados { get; set; }
        public DbSet<ModelosDeBienes> ModelosDeBienes { get; set; }
        public DbSet<TiposDeBienes> TiposDeBienes { get; set; }
        public DbSet<TiposDeIngresoDeBienes> TiposDeIngresoDeBienes { get; set; }
        public DbSet<TransferenciaDeBienes> TransferenciaDeBienes { get; set; }
        public DbSet<EstadosDeViaticosRef> EstadosDeViaticosRef { get; set; }
        public DbSet<MontosDeViaticos> MontosDeViaticos { get; set; }
        public DbSet<SolicitudesDeViaticos> SolicitudesDeViaticos { get; set; }
        public DbSet<SolicitudesDeViaticosAgentes> SolicitudesDeViaticosAgentes { get; set; }
        public DbSet<SolicitudesDeViaticosRendiciones> SolicitudesDeViaticosRendiciones { get; set; }
        public DbSet<SolicitudesDeViaticosRendicionesAgentes> SolicitudesDeViaticosRendicionesAgentes { get; set; }
        public DbSet<VehiculosOficialesRef> VehiculosOficialesRef { get; set; }
        public DbSet<SolicitudesDeViaticosRendicionesDetalle> SolicitudesDeViaticosRendicionesDetalle { get; set; }
        public DbSet<ConceptosDeGastosRef> ConceptosDeGastosRef { get; set; }
        public DbSet<ConcursosDeIngresoEvaluaciones> ConcursosDeIngresoEvaluaciones { get; set; }
        public DbSet<ConcursosDeIngresoPreguntas> ConcursosDeIngresoPreguntas { get; set; }
        public DbSet<ConcursosDeIngresoRespuestas> ConcursosDeIngresoRespuestas { get; set; }
        public DbSet<ConcursosInscripcionesEvaluaciones> ConcursosInscripcionesEvaluaciones { get; set; }
        public DbSet<ConcursosEvaluacionesRespuestas> ConcursosEvaluacionesRespuestas { get; set; }
        public DbSet<ArchivosAdjuntos> ArchivosAdjuntos { get; set; }
        public DbSet<OrganismosExtensionesRRHH> OrganismosExtensionesRRHH { get; set; }
        public DbSet<AdministracionPedidos> AdministracionPedidos { get; set; }
        public DbSet<AdministracionPedidosActuaciones> AdministracionPedidosActuaciones { get; set; }
        public DbSet<LicenciasAgentesAprobaciones> LicenciasAgentesAprobaciones { get; set; }
        public DbSet<TurnosWeb> TurnosWeb { get; set; }
        public DbSet<TurnosWebParametros> TurnosWebParametros { get; set; }
        public DbSet<PersonasTrazabilidad> PersonasTrazabilidad { get; set; }
        public DbSet<ECO_Proveedores> ECO_Proveedores { get; set; }
        public DbSet<ECO_ProveedoresAdjuntos> ECO_ProveedoresAdjuntos { get; set; }
        public DbSet<ECO_ProveedoresRubroRef> ECO_ProveedoresRubroRef { get; set; }
        public DbSet<ECO_ProveedoresSocios> ECO_ProveedoresSocios { get; set; }
        public DbSet<ECO_ProveedoresSubRubroRef> ECO_ProveedoresSubRubroRef { get; set; }
        public DbSet<ECO_ProveedoresSubRubros> ECO_ProveedoresSubRubros { get; set; }
        public DbSet<CIERef> CIERef { get; set; }

        public DbSet<ECO_Usuarios> ECO_Usuarios { get; set; }
        public DbSet<ConcursosDeIngresoPreguntasInscripto> ConcursosDeIngresoPreguntasInscripto { get; set; }
        //public DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }

        // Mappings muchos a muchos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<webpages_Roles>()
                .HasMany<Menus>(m => m.Menus)
                .WithMany(s => s.webpages_Roles)
                .Map(p =>
                {
                    p.MapLeftKey(new string[] { "Rol_Id" });
                    p.MapRightKey(new string[] { "Men_id" });
                    p.ToTable("RolesItemsMenu");
                });

            modelBuilder.Entity<Usuarios>()
                .HasMany<webpages_Roles>(m => m.webpages_Roles)
                .WithMany(s => s.Usuarios)
                .Map(p =>
                {
                    p.MapLeftKey(new string[] { "UserId" });
                    p.MapRightKey(new string[] { "RoleId" });
                    p.ToTable("webpages_UsersInRoles");
                });
        }

        //Stored Procedures
        public virtual int ActivarUsuario(int IdUsuario, bool Activar)
        {

            var par1 = new SqlParameter();
            par1.ParameterName = "@IdUsuario";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = IdUsuario;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            var par2 = new SqlParameter();
            par2.ParameterName = "@Activar";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = Activar;
            par2.SqlDbType = System.Data.SqlDbType.Bit;
            //par2.TypeName = "INT";

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<int>("EXEC ActivarUsuario @IdUsuario, @Activar", par1, par2).FirstOrDefault();

            //var parames = new object[] {new SqlParameter("@FirstName", "Bob")};
        }


        //Stored Procedures
        public virtual int DiasDeLicenciaOrdinariaSustituos(int Agente, DateTime Fecha)
        {

            var par1 = new SqlParameter();
            par1.ParameterName = "@Agente";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = Agente;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            var par2 = new SqlParameter();
            par2.ParameterName = "@Fecha";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = Fecha;
            par2.SqlDbType = System.Data.SqlDbType.DateTime;
            //par2.TypeName = "INT";

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<int>("EXEC DiasDeLicenciaOrdinariaSustitutos @Agente, @Fecha", par1, par2).FirstOrDefault();

        }

        //Stored Procedures
        public virtual ObjectResult<DiasDeLicenciaDeAgenteViewT> DiasDeLicenciaDisponibles(int agente, int anio)
        {

            var par1 = new SqlParameter();
            par1.ParameterName = "@Agente";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = agente;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            var par2 = new SqlParameter();
            par2.ParameterName = "@Anio";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = anio;
            par2.SqlDbType = System.Data.SqlDbType.Int;
            //par2.TypeName = "INT";

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<DiasDeLicenciaDeAgenteViewT>("EXEC DiasDeLicenciasDisponibles @Agente, @Anio", par1, par2);

            //var parames = new object[] {new SqlParameter("@FirstName", "Bob")};
        }

        //Stored Procedures
        public virtual ObjectResult<ResumenLicenciasPorOrganismoViewT> ResumenLicenciasPorOrganismo(int Organismo)
        {

            var par1 = new SqlParameter();
            par1.ParameterName = "@Organismo";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = Organismo;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            //par2.TypeName = "INT";

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<ResumenLicenciasPorOrganismoViewT>("EXEC ResumenDeLicenciaPorOrganismo @Organismo", par1);

            //var parames = new object[] {new SqlParameter("@FirstName", "Bob")};
        }

        //Stored Procedures
        public virtual string ControlarLicencia(int Id, int Agente, int Licencia, DateTime Desde, DateTime Hasta)
        {

            string Error = "";

            var par1 = new SqlParameter();
            par1.ParameterName = "@Id";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = Id;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            var par2 = new SqlParameter();
            par2.ParameterName = "@Agente";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = Agente;
            par2.SqlDbType = System.Data.SqlDbType.Int;

            var par3 = new SqlParameter();
            par3.ParameterName = "@Licencia";
            par3.Direction = System.Data.ParameterDirection.Input;
            par3.Value = Licencia;
            par3.SqlDbType = System.Data.SqlDbType.Int;

            var par4 = new SqlParameter();
            par4.ParameterName = "@Desde";
            par4.Direction = System.Data.ParameterDirection.Input;
            par4.Value = Desde;
            par4.SqlDbType = System.Data.SqlDbType.DateTime;
            //par2.TypeName = "INT";

            var par5 = new SqlParameter();
            par5.ParameterName = "@Hasta";
            par5.Direction = System.Data.ParameterDirection.Input;
            par5.Value = Hasta;
            par5.SqlDbType = System.Data.SqlDbType.DateTime;

            var par6 = new SqlParameter();
            par6.ParameterName = "@Error";
            par6.Direction = System.Data.ParameterDirection.Output;
            par6.Value = Error;
            par6.SqlDbType = System.Data.SqlDbType.VarChar;

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<string>("EXEC ControlarInicioDeLicenciaAgente @Id, @Agente, @Licencia, @Desde, @Hasta", par1, par2, par3, par4, par5).FirstOrDefault();

            //var parames = new object[] {new SqlParameter("@FirstName", "Bob")};
        }

        public List<T> ExecuteQuery<T>(string query)
        {
            var par1 = new SqlParameter();
            par1.ParameterName = "@Query";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = query;
            par1.SqlDbType = System.Data.SqlDbType.VarChar;

            var x = ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<T>("EXEC ObtenerConsulta @Query", par1);

            return x.ToList<T>();
        }


        public Query ExecuteQueryForExcel(string query)
        {
            if (this.Database.Connection.State == System.Data.ConnectionState.Open)
                this.Database.Connection.Close();
            this.Database.Connection.Open();
            var columnas = new List<string>();
            List<List<object>> items = new List<List<object>>();
            var result = new Query();

            var f = 0;

            var cmd = this.Database.Connection.CreateCommand();
            cmd.CommandText = "ObtenerConsulta @Query";
            cmd.Parameters.Add(new SqlParameter("Query", query));

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (f == 0)
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        columnas.Add(reader.GetName(i));
                }
                f++;

                var item = new List<Object>();
                items.Add(item);

                for (int i = 0; i < reader.FieldCount; i++)
                    item.Add(reader[i]);
            }

            result.resultado = items;
            result.columnas = columnas;

            return result;
        }

        public virtual int GestionarRolesItemsMenu(int idRol, int idItem, bool agregar)
        {
            var par1 = new SqlParameter();
            par1.ParameterName = "@idRol";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = idRol;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            var par2 = new SqlParameter();
            par2.ParameterName = "@idItem";
            par2.Direction = System.Data.ParameterDirection.Input;
            par2.Value = idItem;
            par2.SqlDbType = System.Data.SqlDbType.Int;

            var par3 = new SqlParameter();
            par3.ParameterName = "@agregar";
            par3.Direction = System.Data.ParameterDirection.Input;
            par3.Value = agregar;
            par3.SqlDbType = System.Data.SqlDbType.Bit;

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<int>("EXEC GestionarRolesItemsMenu @idRol, @idItem, @agregar", par1, par2, par3).FirstOrDefault();
        }



    }
}
