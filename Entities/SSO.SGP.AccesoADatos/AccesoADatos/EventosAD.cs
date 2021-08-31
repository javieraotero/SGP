
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
	public partial class EventosAD
	{
		private BDEntities db = new BDEntities();

		public Eventos ObtenerPorId(int Id)
		{
			return db.Eventos.Single(c => c.Id == Id);
		}

		public DbQuery<Eventos> ObtenerTodo()
		{
			return (DbQuery<Eventos>)db.Eventos.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Eventos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EventosView> ObtenerParaGrilla()
		{
			var x = from c in db.Eventos
					where c.Activo == true
					select new EventosView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Oficina = c.Oficina,
						 Usuario = c.Usuario,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 AlcanceEvento = c.AlcanceEvento,
						 Expediente = c.Expediente,
						 Audiencia = c.Audiencia,
						 FechaAlta = c.FechaAlta,
						 Activo = c.Activo,
					};
			return (DbQuery<EventosView>)x;
		}

		public void Guardar(Eventos Objeto)
		{
			try
			{
				db.Eventos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Eventos Objeto)
		{
			try
			{
				db.Eventos.Attach(Objeto);
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
				Eventos Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<EventosViewT> JsonT(string term)
		{
			var x = from c in db.Eventos
					where c.Activo == true
					select new EventosViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Oficina = c.Oficina,
						 Usuario = c.Usuario,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 AlcanceEvento = c.AlcanceEvento,
						 Expediente = c.Expediente,
						 Audiencia = c.Audiencia,
						 FechaAlta = c.FechaAlta,
						 Activo = c.Activo,
					};
			return (DbQuery<EventosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
