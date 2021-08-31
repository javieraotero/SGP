
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
	public partial class GruposTipoActuacionRefAD
	{
		private BDEntities db = new BDEntities();

		public GruposTipoActuacionRef ObtenerPorId(int Id)
		{
			return db.GruposTipoActuacionRef.Single(c => c.Id == Id);
		}

		public DbQuery<GruposTipoActuacionRef> ObtenerTodo()
		{
			return (DbQuery<GruposTipoActuacionRef>)db.GruposTipoActuacionRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.GruposTipoActuacionRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<GruposTipoActuacionRefView> ObtenerParaGrilla()
		{
			var x = from c in db.GruposTipoActuacionRef
					select new GruposTipoActuacionRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Modulo = c.Modulo,
						 SubAmbito = c.SubAmbito,
						 Ambito = c.Ambito,
					};
			return (DbQuery<GruposTipoActuacionRefView>)x;
		}

		public void Guardar(GruposTipoActuacionRef Objeto)
		{
			try
			{
				db.GruposTipoActuacionRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposTipoActuacionRef Objeto)
		{
			try
			{
				db.GruposTipoActuacionRef.Attach(Objeto);
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
				GruposTipoActuacionRef Objeto = this.ObtenerPorId(IdObjeto);
				db.GruposTipoActuacionRef.Remove(Objeto);
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

		public DbQuery<GruposTipoActuacionRefViewT> JsonT(string term)
		{
			var x = from c in db.GruposTipoActuacionRef
					select new GruposTipoActuacionRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Modulo = c.Modulo,
						 SubAmbito = c.SubAmbito,
						 Ambito = c.Ambito,
					};
			return (DbQuery<GruposTipoActuacionRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
