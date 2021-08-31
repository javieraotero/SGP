
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
	public partial class BarriosRefAD
	{
		private BDEntities db = new BDEntities();

		public BarriosRef ObtenerPorId(int Id)
		{
			return db.BarriosRef.Single(c => c.Id == Id);
		}

		public DbQuery<BarriosRef> ObtenerTodo()
		{
			return (DbQuery<BarriosRef>)db.BarriosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.BarriosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<BarriosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.BarriosRef
					select new BarriosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Localidad = c.Localidad,
					};
			return (DbQuery<BarriosRefView>)x;
		}

		public void Guardar(BarriosRef Objeto)
		{
			try
			{
				db.BarriosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(BarriosRef Objeto)
		{
			try
			{
				db.BarriosRef.Attach(Objeto);
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
				BarriosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.BarriosRef.Remove(Objeto);
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

		public DbQuery<BarriosRefViewT> JsonT(string term)
		{
			var x = from c in db.BarriosRef
					select new BarriosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Localidad = c.Localidad,
					};
			return (DbQuery<BarriosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
