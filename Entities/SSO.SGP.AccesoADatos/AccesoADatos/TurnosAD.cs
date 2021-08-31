
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
	public partial class TurnosAD
	{
		private BDEntities db = new BDEntities();

		public Turnos ObtenerPorId(int Id)
		{
			return db.Turnos.Single(c => c.Id == Id);
		}

		public DbQuery<Turnos> ObtenerTodo()
		{
			return (DbQuery<Turnos>)db.Turnos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Turnos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		private bool EsFeriado(DateTime fecha, List<FeriadosRef> feriados) {

			if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
				return true;

			if (feriados.Where(x => x.Anio == fecha.Year && x.Mes == fecha.Month && x.Dia == fecha.Day).Count() > 0)
				return true;

			return false;
		}

		public TurnoWebResult ObtenerTurno(int Organismo, bool es_abogado)
		{

			var anio = DateTime.Now.Year;
			var mes = DateTime.Now.Month;

			var date = DateTime.Now.Date;
			var hora = DateTime.Now.TimeOfDay.Add(new TimeSpan(2, 0, 0));

			DateTime? fecha_result = null;
			TimeSpan? hora_result = null;

			DateTime aux_fecha; 
			
			var param = (from p in db.TurnosWebParametros
						 where p.Organismo == Organismo
						 select p).FirstOrDefault();

			if (!es_abogado && param.SoloAbogado) {
				return new TurnoWebResult
				{
					no_es_turno = true
				};
			}

			var feriados = (from f in db.FeriadosRef
							where f.Anio >= anio && f.Mes >= mes
							select f).ToList();

			var max = (from x in db.TurnosWeb
					   where x.Organismo == Organismo
					   && x.Fecha >= date && x.Hora >= hora
					   orderby x.Fecha descending, x.Hora descending
					   select x).ToList();

			if (max.Count() > 0)
			{
				var last = max.FirstOrDefault();

				if (last.Hora < param.HoraDeFin)
				{
					fecha_result = last.Fecha;
					hora_result = last.Hora.Add(new TimeSpan(0, param.Intervalo, 0));
				}
				else
				{
					aux_fecha = last.Fecha.AddDays(1);
					
					while (EsFeriado(aux_fecha, feriados))
					{
						aux_fecha = aux_fecha.AddDays(1);
					}

					fecha_result = aux_fecha;
					hora_result = param.HoraDeInicio;

				}

			}
			else {

				if (DateTime.Now.TimeOfDay.Add(new TimeSpan(2, 0, 0)) < param.HoraDeFin)
				{
					aux_fecha = DateTime.Now.Date;
				}
				else
					aux_fecha = DateTime.Now.Date.AddDays(1);

				while (EsFeriado(aux_fecha, feriados))
				{
					aux_fecha = aux_fecha.AddDays(1);
				}

				if (aux_fecha == DateTime.Now.Date)
					hora_result = new TimeSpan(DateTime.Now.TimeOfDay.Hours + 1, 45, 0);
				else
					hora_result = param.HoraDeInicio;
			}

			var turno = new TurnoWebResult
			{
				fecha = fecha_result.Value,
				hora = hora_result.Value,
				no_es_turno = false
			};

			return turno;

		}

		public DbQuery<TurnosView> ObtenerParaGrilla()
		{
			var x = from c in db.Turnos
					select new TurnosView
					{
						 Id = c.Id,
						 Funcionario = c.Funcionario,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Cantidad = c.Cantidad,
						 Activa = c.Activa,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModificacion = c.UsuarioModificacion,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
						 FechaEliminacion = c.FechaEliminacion,
					};
			return (DbQuery<TurnosView>)x;
		}

		public void Guardar(Turnos Objeto)
		{
			try
			{
				db.Turnos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Turnos Objeto)
		{
			try
			{
				db.Turnos.Attach(Objeto);
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
				Turnos Objeto = this.ObtenerPorId(IdObjeto);
				db.Turnos.Remove(Objeto);
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

		public DbQuery<TurnosViewT> JsonT(string term)
		{
			var x = from c in db.Turnos
					select new TurnosViewT
					{
						 Id = c.Id,
						 Funcionario = c.Funcionario,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Cantidad = c.Cantidad,
						 Activa = c.Activa,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModificacion = c.UsuarioModificacion,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
						 FechaEliminacion = c.FechaEliminacion,
					};
			return (DbQuery<TurnosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
