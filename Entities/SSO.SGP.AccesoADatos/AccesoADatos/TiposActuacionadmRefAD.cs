
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
	public partial class TiposActuacionadmRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposActuacionadmRef ObtenerPorId(int Id)
		{
			return db.TiposActuacionadmRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposActuacionadmRef> ObtenerTodo()
		{
			return (DbQuery<TiposActuacionadmRef>)db.TiposActuacionadmRef.Where(a=>a.Activa == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposActuacionadmRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposActuacionadmRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposActuacionadmRef
					select new TiposActuacionadmRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Activa = c.Activa,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaElimina = c.FechaElimina,
						 CantidadFirmantes = c.CantidadFirmantes,
					};
			return (DbQuery<TiposActuacionadmRefView>)x;
		}

		public void Guardar(TiposActuacionadmRef Objeto)
		{
			try
			{
				db.TiposActuacionadmRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposActuacionadmRef Objeto)
		{
			try
			{
				db.TiposActuacionadmRef.Attach(Objeto);
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
				TiposActuacionadmRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposActuacionadmRef.Remove(Objeto);
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

		public DbQuery<TiposActuacionadmRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposActuacionadmRef
					select new TiposActuacionadmRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Activa = c.Activa,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaElimina = c.FechaElimina,
						 CantidadFirmantes = c.CantidadFirmantes,
					};
			return (DbQuery<TiposActuacionadmRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
