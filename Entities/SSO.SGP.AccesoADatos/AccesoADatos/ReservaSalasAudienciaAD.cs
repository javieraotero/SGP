
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
	public partial class ReservaSalasAudienciaAD
	{
		private BDEntities db = new BDEntities();

		public ReservaSalasAudiencia ObtenerPorId(int Id)
		{
			return db.ReservaSalasAudiencia.Single(c => c.Id == Id);
		}

		public DbQuery<ReservaSalasAudiencia> ObtenerTodo()
		{
			return (DbQuery<ReservaSalasAudiencia>)db.ReservaSalasAudiencia;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ReservaSalasAudiencia
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ReservaSalasAudienciaView> ObtenerParaGrilla()
		{
			var x = from c in db.ReservaSalasAudiencia
					select new ReservaSalasAudienciaView
					{
						 Id = c.Id,
						 Sala = c.Sala,
						 Descripcion = c.Descripcion,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Activa = c.Activa,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
					};
			return (DbQuery<ReservaSalasAudienciaView>)x;
		}

		public void Guardar(ReservaSalasAudiencia Objeto)
		{
			try
			{
				db.ReservaSalasAudiencia.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ReservaSalasAudiencia Objeto)
		{
			try
			{
				db.ReservaSalasAudiencia.Attach(Objeto);
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
				ReservaSalasAudiencia Objeto = this.ObtenerPorId(IdObjeto);
				db.ReservaSalasAudiencia.Remove(Objeto);
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

		public DbQuery<ReservaSalasAudienciaViewT> JsonT(string term)
		{
			var x = from c in db.ReservaSalasAudiencia
					select new ReservaSalasAudienciaViewT
					{
						 Id = c.Id,
						 Sala = c.Sala,
						 Descripcion = c.Descripcion,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Activa = c.Activa,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
					};
			return (DbQuery<ReservaSalasAudienciaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
