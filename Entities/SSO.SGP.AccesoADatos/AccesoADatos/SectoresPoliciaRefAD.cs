
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
	public partial class SectoresPoliciaRefAD
	{
		private BDEntities db = new BDEntities();

		public SectoresPoliciaRef ObtenerPorId(int Id)
		{
			return db.SectoresPoliciaRef.Single(c => c.Id == Id);
		}

		public DbQuery<SectoresPoliciaRef> ObtenerTodo()
		{
			return (DbQuery<SectoresPoliciaRef>)db.SectoresPoliciaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SectoresPoliciaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SectoresPoliciaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.SectoresPoliciaRef
					select new SectoresPoliciaRefView
					{
						 Id = c.Id,
						 IdSector = c.IdSector,
						 Sector = c.Sector,
						 Barrio = c.Barrio,
						 Unidad = c.Unidad,
						 Comisaria = c.Comisaria,
					};
			return (DbQuery<SectoresPoliciaRefView>)x;
		}

		public void Guardar(SectoresPoliciaRef Objeto)
		{
			try
			{
				db.SectoresPoliciaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SectoresPoliciaRef Objeto)
		{
			try
			{
				db.SectoresPoliciaRef.Attach(Objeto);
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
				SectoresPoliciaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.SectoresPoliciaRef.Remove(Objeto);
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

		public DbQuery<SectoresPoliciaRefViewT> JsonT(string term)
		{
			var x = from c in db.SectoresPoliciaRef
					select new SectoresPoliciaRefViewT
					{
						 Id = c.Id,
						 IdSector = c.IdSector,
						 Sector = c.Sector,
						 Barrio = c.Barrio,
						 Unidad = c.Unidad,
						 Comisaria = c.Comisaria,
					};
			return (DbQuery<SectoresPoliciaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
