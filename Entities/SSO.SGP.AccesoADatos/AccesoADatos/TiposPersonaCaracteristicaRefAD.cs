
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
	public partial class TiposPersonaCaracteristicaRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposPersonaCaracteristicaRef ObtenerPorId(int Id)
		{
			return db.TiposPersonaCaracteristicaRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposPersonaCaracteristicaRef> ObtenerTodo()
		{
			return (DbQuery<TiposPersonaCaracteristicaRef>)db.TiposPersonaCaracteristicaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposPersonaCaracteristicaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposPersonaCaracteristicaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposPersonaCaracteristicaRef
					select new TiposPersonaCaracteristicaRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposPersonaCaracteristicaRefView>)x;
		}

		public void Guardar(TiposPersonaCaracteristicaRef Objeto)
		{
			try
			{
				db.TiposPersonaCaracteristicaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposPersonaCaracteristicaRef Objeto)
		{
			try
			{
				db.TiposPersonaCaracteristicaRef.Attach(Objeto);
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
				TiposPersonaCaracteristicaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposPersonaCaracteristicaRef.Remove(Objeto);
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

		public DbQuery<TiposPersonaCaracteristicaRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposPersonaCaracteristicaRef
					select new TiposPersonaCaracteristicaRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposPersonaCaracteristicaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
