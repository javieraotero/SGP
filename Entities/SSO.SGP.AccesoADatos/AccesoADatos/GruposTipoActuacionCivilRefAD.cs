
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
	public partial class GruposTipoActuacionCivilRefAD
	{
		private BDEntities db = new BDEntities();

		public GruposTipoActuacionCivilRef ObtenerPorId(int Id)
		{
			return db.GruposTipoActuacionCivilRef.Single(c => c.Id == Id);
		}

		public DbQuery<GruposTipoActuacionCivilRef> ObtenerTodo()
		{
			return (DbQuery<GruposTipoActuacionCivilRef>)db.GruposTipoActuacionCivilRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.GruposTipoActuacionCivilRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<GruposTipoActuacionCivilRefView> ObtenerParaGrilla()
		{
			var x = from c in db.GruposTipoActuacionCivilRef
					select new GruposTipoActuacionCivilRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Modulo = c.Modulo,
						 SubAmbito = c.SubAmbito,
						 Ambito = c.Ambito,
					};
			return (DbQuery<GruposTipoActuacionCivilRefView>)x;
		}

		public void Guardar(GruposTipoActuacionCivilRef Objeto)
		{
			try
			{
				db.GruposTipoActuacionCivilRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposTipoActuacionCivilRef Objeto)
		{
			try
			{
				db.GruposTipoActuacionCivilRef.Attach(Objeto);
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
				GruposTipoActuacionCivilRef Objeto = this.ObtenerPorId(IdObjeto);
				db.GruposTipoActuacionCivilRef.Remove(Objeto);
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

		public DbQuery<GruposTipoActuacionCivilRefViewT> JsonT(string term)
		{
			var x = from c in db.GruposTipoActuacionCivilRef
					select new GruposTipoActuacionCivilRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Modulo = c.Modulo,
						 SubAmbito = c.SubAmbito,
						 Ambito = c.Ambito,
					};
			return (DbQuery<GruposTipoActuacionCivilRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
