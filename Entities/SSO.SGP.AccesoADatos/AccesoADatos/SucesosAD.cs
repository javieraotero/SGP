
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
	public partial class SucesosAD
	{
		private BDEntities db = new BDEntities();

		public Sucesos ObtenerPorId(int Id)
		{
			return db.Sucesos.Single(c => c.Id == Id);
		}

		public DbQuery<Sucesos> ObtenerTodo()
		{
			return (DbQuery<Sucesos>)db.Sucesos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Sucesos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SucesosView> ObtenerParaGrilla()
		{
			var x = from c in db.Sucesos
					select new SucesosView
					{
						 Id = c.Id,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 SubAmbito = c.SubAmbito,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 TiposSuceso = c.TiposSuceso,
						 FechaMostrar = c.FechaMostrar,
						 TareaRealizada = c.TareaRealizada,
						 FechaRealizada = c.FechaRealizada,
						 UsuarioRealizada = c.UsuarioRealizada,
						 Expediente = c.Expediente,
						 Actuacion = c.Actuacion,
						 Activa = c.Activa,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
						 ResponsableEvento = c.ResponsableEvento,
						 OficinaEvento = c.OficinaEvento,
						 ModificadoPorSuspension = c.ModificadoPorSuspension,
					};
			return (DbQuery<SucesosView>)x;
		}

		public void Guardar(Sucesos Objeto)
		{
			try
			{
				db.Sucesos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Sucesos Objeto)
		{
			try
			{
				db.Sucesos.Attach(Objeto);
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
				Sucesos Objeto = this.ObtenerPorId(IdObjeto);
				db.Sucesos.Remove(Objeto);
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

		public DbQuery<SucesosViewT> JsonT(string term)
		{
			var x = from c in db.Sucesos
					select new SucesosViewT
					{
						 Id = c.Id,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 SubAmbito = c.SubAmbito,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 TiposSuceso = c.TiposSuceso,
						 FechaMostrar = c.FechaMostrar,
						 TareaRealizada = c.TareaRealizada,
						 FechaRealizada = c.FechaRealizada,
						 UsuarioRealizada = c.UsuarioRealizada,
						 Expediente = c.Expediente,
						 Actuacion = c.Actuacion,
						 Activa = c.Activa,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
						 ResponsableEvento = c.ResponsableEvento,
						 OficinaEvento = c.OficinaEvento,
						 ModificadoPorSuspension = c.ModificadoPorSuspension,
					};
			return (DbQuery<SucesosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
