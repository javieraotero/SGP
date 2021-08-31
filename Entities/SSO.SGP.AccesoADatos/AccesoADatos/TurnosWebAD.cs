
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class TurnosWebAD
	{
		private BDEntities db = new BDEntities();

		public TurnosWeb ObtenerPorId(int Id)
		{
			return db.TurnosWeb.Single(c => c.Id == Id);
		}

		public TurnosWeb ObtenerPorDni(long dni)
		{
			return db.TurnosWeb.Where(x => x.DNI == dni).OrderByDescending(x => x.Id).FirstOrDefault();
		}

		public DbQuery<TurnosWeb> ObtenerTodo()
		{
			return (DbQuery<TurnosWeb>)db.TurnosWeb;
		}

		public DateTime ProximoTurnoUrgente() {
			var anio = DateTime.Now.Year;
			var mes = DateTime.Now.Month;

			var dia18 = DateTime.Parse("13/10/2020");

			var feriados = (from f in db.FeriadosRef
							where f.Anio >= anio && f.Mes >= mes
							select f).ToList();

			var aux_fecha = DateTime.Now.Date >= dia18.Date ? DateTime.Now.AddDays(1) : dia18;

			while (EsFeriado(aux_fecha, feriados))
			{
				aux_fecha = aux_fecha.AddDays(1);
			}

			return aux_fecha;

		}


		public bool FechaValida(DateTime fecha)
		{
			var anio = DateTime.Now.Year;
			var mes = DateTime.Now.Month;

			var feriados = (from f in db.FeriadosRef
							where f.Anio >= anio && f.Mes >= mes
							select f).ToList();

			if (!EsFeriado(fecha, feriados) && fecha > DateTime.Now)
			{
				return true;
			}
			else
				return false;

		}

		public TurnosWeb TieneTurnoUrgente(long dni, int organismo) {

			var hoy = DateTime.Now.AddHours(-3);
			var hora = DateTime.Now.TimeOfDay;
			var hora_13 = new TimeSpan(13, 0, 0);

			var turno = (from x in db.TurnosWeb
						where x.DNI == dni && x.Urgente && x.Organismo == organismo && x.Fecha > hoy
						&& x.Estado != (int)eEstadosTurnos.Eliminado
						 select x).FirstOrDefault();

			return turno;

		}

		public TurnosWeb TieneTurnoExpediente(long dni, int organismo)
		{

			var hoy = DateTime.Now.AddHours(-3);
			var hora = DateTime.Now.TimeOfDay;

			var turno = (from x in db.TurnosWeb
						 where x.DNI == dni && !string.IsNullOrEmpty(x.Expedientes) && x.Organismo == organismo && x.Fecha > hoy
						 && x.Estado != (int)eEstadosTurnos.Eliminado
						 select x).FirstOrDefault();

			return turno;

		}

		public TurnosWeb TieneTurnoPerito(long dni, int organismo)
		{

			var hoy = DateTime.Now.AddHours(-3);
			var hora = DateTime.Now.TimeOfDay;

			var turno = (from x in db.TurnosWeb
						 where x.DNI == dni && x.EsPerito && x.Organismo == organismo && x.Fecha > hoy
							 && x.Estado != (int)eEstadosTurnos.Eliminado
						 select x).FirstOrDefault();

			return turno;

		}

		public int TotalTurnos(DateTime fecha, int organismo) {

			var total = (from x in db.TurnosWeb
						 where x.Fecha == fecha && x.EsAbogado && !x.Urgente && x.Organismo == organismo && string.IsNullOrEmpty(x.Expedientes)
						 && x.Estado != (int)eEstadosTurnos.Eliminado
						 select x
								).Count();

			return total;
		}

		public int CheckTurnos(long dni, int localidad)
		{
			var hoy = DateTime.Now;

			var turno_activo = (from x in db.TurnosWeb
								join p in db.TurnosWebParametros on x.Organismo equals p.Organismo
								where x.DNI == dni && hoy <= x.Fecha && p.Localidad == localidad
								&& x.Estado != (int)eEstadosTurnos.Eliminado && !x.Urgente && string.IsNullOrEmpty(x.Expedientes)
								select x.Fecha).Distinct().Count();

			return turno_activo;
		}

		public bool Disponibilidad(DateTime fecha, int organismo, long dni)
		{
			var anio = DateTime.Now.Year;
			var mes = DateTime.Now.Month;
			var hoy = DateTime.Now.Date;
			var hora = DateTime.Now.TimeOfDay;

			var p = (from x in db.TurnosWebParametros
					 where x.Organismo == organismo select x).FirstOrDefault().AbogadosPorDia;

			var feriados = (from f in db.FeriadosRef
							where f.Anio >= anio && f.Mes >= mes
							select f).ToList();

			var turno_activo = (from x in db.TurnosWeb
							   where x.DNI == dni && x.Organismo == organismo && x.Fecha.Day == fecha.Day && fecha.Month == x.Fecha.Month 
							   && x.Estado != (int)eEstadosTurnos.Eliminado
								select x).Count();

			if (turno_activo > 0)
				return false;

			if (!EsFeriado(fecha, feriados))
			{
				var total = (from x in db.TurnosWeb
							 where x.Fecha == fecha && x.EsAbogado && !x.Urgente && x.Organismo == organismo && string.IsNullOrEmpty(x.Expedientes)
							 && x.Estado != (int)eEstadosTurnos.Eliminado
							 select x
							).Count();

				if (total < p)
					return true;
				else
					return false;

			}
			else
				return false;



		}

			public PersonaTurnosWeb BuscarPersonaPorDNI(long dni, int localidad)
		{
			var res = (from p in db.Personas
					   where p.NroDocumento == dni && p.Activa
					   select p).ToList();

			PersonaTurnosWeb persona_web = new PersonaTurnosWeb { id_persona = 0, cargo = 0 };

			Personas persona = new Personas { Id = 0 };
			Usuarios usuario = new Usuarios { Id = 0 };

			if (res.Count() > 0) {
				persona = res.FirstOrDefault();

				persona_web.id_persona = persona.Id;
				persona_web.nombre = persona.Apellidos.Trim() + ", " + persona.Nombres.Trim();

				var usu = (from u in db.Usuarios
						   where u.Persona == persona.Id && u.Estado == 1
						   select u).ToList();

				if (usu.Count() > 0) {

					if (usu.Count() > 1) {
						usuario = usu.Where(x => x.Cargo == 11).FirstOrDefault();
					}

					if (usuario != null)
					{
						if (usuario.Id == 0)
						{
							usuario = usu.FirstOrDefault();
						}

						persona_web.cargo = usuario.Cargo;
						persona_web.id_usuario = usuario.Id;
					}
				}

				persona_web.dias_acumulados = this.CheckTurnos(dni, localidad);

			}

			return persona_web;
		}

		private bool EsFeriado(DateTime fecha, List<FeriadosRef> feriados)
		{

			if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
				return true;

			if (feriados.Where(x => x.Anio == fecha.Year && x.Mes == fecha.Month && x.Dia == fecha.Day).Count() > 0)
				return true;

			return false;
		}

		public TurnosWeb TieneTurnoActivo(long dni, int organismo) {

			var hoy = DateTime.Now.Date;

			var res = (from x in db.TurnosWeb
					   where x.DNI == dni && x.Fecha >= hoy && x.Organismo == organismo && x.Estado != (int)eEstadosTurnos.Eliminado
					   select x).FirstOrDefault();

			return res;

		}

		public TurnoWebResult ObtenerTurno(int Organismo, bool es_abogado)
		{

			var anio = DateTime.Now.Year;
			var mes = DateTime.Now.Month;

			var date = DateTime.Now.Date;
			var hora = DateTime.Now.TimeOfDay.Add(new TimeSpan(2, 0, 0));

			DateTime inicio_feria = new DateTime(2020, 7, 13).Date;
			DateTime fin_feria = new DateTime(2020, 7, 24).Date;

			DateTime? fecha_result = null;
			TimeSpan? hora_result = null;

			DateTime aux_fecha;

			var param = (from p in db.TurnosWebParametros
						 where p.Organismo == Organismo
						 select p).FirstOrDefault();

			var dia18 = DateTime.Parse("13/10/2020");

			aux_fecha = DateTime.Now.Date > dia18.Date ? DateTime.Now.AddDays(1) : dia18;

			if (!es_abogado && param.SoloAbogado)
			{
				return new TurnoWebResult
				{
					no_es_turno = true,
					solo_mensaje = param.SoloMensaje
				};
			}

			var feriados = (from f in db.FeriadosRef
							where f.Anio >= anio && f.Mes >= mes
							select f).ToList();

			var max = (from x in db.TurnosWeb
					   where x.Organismo == Organismo && x.Estado != (int)eEstadosTurnos.Eliminado
					   && x.Fecha >= date
					   orderby x.Fecha descending, x.Hora descending
					   select x).ToList();

			if (max.Count() > 0)
			{
				var last = max.FirstOrDefault();

				if (((last.Fecha.Date >= inicio_feria && last.Fecha.Date <= fin_feria) && last.Hora < new TimeSpan(12,0,0)) 
					|| ((last.Fecha.Date < inicio_feria || last.Fecha.Date > fin_feria) && (last.Hora < param.HoraDeFin)))
				{
					

					fecha_result = last.Fecha;
				
					hora_result = last.Hora.Add(new TimeSpan(0, param.Intervalo, 0));

					if (fecha_result.Value.Date == DateTime.Now.Date &&  DateTime.Now.TimeOfDay > hora_result)
						hora_result = new TimeSpan(DateTime.Now.TimeOfDay.Hours + 1, param.Intervalo, 0);

					//if (hora_result > param.HoraDeFin) {
					//	aux_fecha = last.Fecha.AddDays(1);
					if (((last.Fecha.Date >= inicio_feria && last.Fecha.Date <= fin_feria) && last.Hora > new TimeSpan(12, 0, 0))
					|| ((last.Fecha.Date < inicio_feria || last.Fecha.Date > fin_feria) && (last.Hora > param.HoraDeFin))) {
						
						aux_fecha = last.Fecha.AddDays(1);
						while (EsFeriado(aux_fecha, feriados))
						{
							aux_fecha = aux_fecha.AddDays(1);
						}

						fecha_result = aux_fecha;
						hora_result = (aux_fecha >= inicio_feria && aux_fecha <= fin_feria) ? new TimeSpan(8, 0, 0) : param.HoraDeInicio;
					}

				}
				else
				{
					aux_fecha = last.Fecha.AddDays(1);

					while (EsFeriado(aux_fecha, feriados))
					{
						aux_fecha = aux_fecha.AddDays(1);
					}

					fecha_result = aux_fecha;
					hora_result = (aux_fecha >= inicio_feria && aux_fecha <= fin_feria) ? new TimeSpan(8, 0, 0) : param.HoraDeInicio;

				}

			}
			else
			{
				if (DateTime.Now.Date > dia18)
				{

					if (DateTime.Now.TimeOfDay.Add(new TimeSpan(2, 0, 0)) < param.HoraDeFin)
					{
						aux_fecha = DateTime.Now.Date;
					}
					else
						aux_fecha = DateTime.Now.Date.AddDays(1);

				}
				else {

					aux_fecha = dia18;

				}

				

				while (EsFeriado(aux_fecha, feriados))
				{
					aux_fecha = aux_fecha.AddDays(1);
				}

				fecha_result = aux_fecha;

				if (aux_fecha == DateTime.Now.Date)
					hora_result = new TimeSpan(DateTime.Now.TimeOfDay.Hours + 1, 0, 0);
				else
					hora_result = (aux_fecha >= inicio_feria && aux_fecha <= fin_feria) ? new TimeSpan(8, 0, 0) : param.HoraDeInicio;
			}

			var turno = new TurnoWebResult
			{
				fecha = fecha_result.Value,
				hora = hora_result.Value,
				no_es_turno = false,
				solo_mensaje = param.SoloMensaje
			};

			return turno;

		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TurnosWeb
					  select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public TurnosWebParametros ObtenerParametro(int organismo)
		{
			var res = (from x in db.TurnosWebParametros
					  where x.Organismo == organismo
					  select x).OrderBy(x=>x.Ayuda).FirstOrDefault();
			return res;
		}

		public DbQuery<TurnosWebView> ObtenerParaGrilla(int? organismo, DateTime? desde, DateTime? hasta, int usuario, int estado)
		{
			var ahora = DateTime.Now.Date;
			var x = from c in db.TurnosWeb
					join o in db.OrganismosRef on c.Organismo equals o.Id
					where (organismo.HasValue && c.Organismo == organismo.Value) && c.Estado != (int)eEstadosTurnos.Eliminado
					&& ((c.Contactar && c.Estado == 1) || (!c.Contactar && (estado == -1 && c.Fecha >= ahora) || (estado == 0)))		
					&& ((desde.HasValue && c.Fecha >= desde.Value) || (!desde.HasValue))
					&& ((hasta.HasValue && c.Fecha <= hasta.Value) || (!hasta.HasValue))
					select new TurnosWebView
					{
						Id = c.Id,
						Nombre = c.ApellidoYNombre,
						Telefono = c.Telefono,
						DNI = c.DNI,
						Abogado = c.EsAbogado ? "SI" : "NO",
						Comentarios = c.Observaciones,
						Contactar = c.Contactar ? "SI" : "NO",
						Fecha = c.Fecha,
						Hora = c.Hora,
						//Expedientes = c.Expedientes,
						Estado = c.Estado == 1 ? "<span class='label label-info'>EN ESPERA</span>" : (c.Estado == (int)eEstadosTurnos.Cancelado ? "<span class='label label-error'>NO ASISTIO</span>" : "<span class='label label-success'>ATENDIDO</span>"),
						Tipo = c.Urgente ? "Art. 116 CPC" : (!string.IsNullOrEmpty(c.Expedientes) ? "Expedientes" : "Normal"),
						Perido = c.EsPerito ? "SI" : "NO",
						Urgente = c.Urgente ? "SI" : "NO",
						operacion = "<a href='#' onclick='ver(this)'><img src='/assets/img/icons/16x16/detail.fw.png' /></a>" + (usuario == 4130 ? "&nbsp;<a href='#' data-tipo='23' onclick='quitar(this)'><img src='/assets/img/icons/16x16/delete.png' /></a>" : "")
					};
			return (DbQuery<TurnosWebView>)x;
		}

		public void Guardar(TurnosWeb Objeto)
		{
			try
			{
				db.TurnosWeb.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TurnosWeb Objeto)
		{
			try
			{
				db.TurnosWeb.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
				TurnosWeb Objeto = this.ObtenerPorId(IdObjeto);
				db.TurnosWeb.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}

		public DbQuery<BarriosRefViewT> JsonT(string term)
		{
			var x = from c in db.BarriosRef
					select new BarriosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Localidad = c.Localidad,
					};
			return (DbQuery<BarriosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/
	}
}
