
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class EventosCivilAD
	{
		private BDEntities db = new BDEntities();

		public EventosCivil ObtenerPorId(int Id)
		{
			return db.EventosCivil.Single(c => c.Id == Id);
		}

		public DbQuery<EventosCivil> ObtenerTodo()
		{
			return (DbQuery<EventosCivil>)db.EventosCivil.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EventosCivil
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EventosCivilView> ObtenerParaGrilla()
		{
			var x = from c in db.EventosCivil
					where c.Activo == true
					select new EventosCivilView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Oficina = c.Oficina,
						 Usuario = c.Usuario,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 AlcanceEvento = c.AlcanceEvento,
						 Causa = c.Causa,
						 Audiencia = c.Audiencia,
						 FechaAlta = c.FechaAlta,
						 Activo = c.Activo,
					};
			return (DbQuery<EventosCivilView>)x;
		}

		public void Guardar(EventosCivil Objeto)
		{
			try
			{
				db.EventosCivil.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EventosCivil Objeto)
		{
			try
			{
				db.EventosCivil.Attach(Objeto);
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
				EventosCivil Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<EventosCivilViewT> JsonT(string term)
		{
			var x = from c in db.EventosCivil
					where c.Activo == true
					select new EventosCivilViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Oficina = c.Oficina,
						 Usuario = c.Usuario,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 AlcanceEvento = c.AlcanceEvento,
						 Causa = c.Causa,
						 Audiencia = c.Audiencia,
						 FechaAlta = c.FechaAlta,
						 Activo = c.Activo,
					};
			return (DbQuery<EventosCivilViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
