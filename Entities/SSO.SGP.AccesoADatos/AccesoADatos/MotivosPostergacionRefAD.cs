
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
	public partial class MotivosPostergacionRefAD
	{
		private BDEntities db = new BDEntities();

		public MotivosPostergacionRef ObtenerPorId(int Id)
		{
			return db.MotivosPostergacionRef.Single(c => c.Id == Id);
		}

		public DbQuery<MotivosPostergacionRef> ObtenerTodo()
		{
			return (DbQuery<MotivosPostergacionRef>)db.MotivosPostergacionRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MotivosPostergacionRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MotivosPostergacionRefView> ObtenerParaGrilla()
		{
			var x = from c in db.MotivosPostergacionRef
					select new MotivosPostergacionRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosPostergacionRefView>)x;
		}

		public void Guardar(MotivosPostergacionRef Objeto)
		{
			try
			{
				db.MotivosPostergacionRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosPostergacionRef Objeto)
		{
			try
			{
				db.MotivosPostergacionRef.Attach(Objeto);
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
				MotivosPostergacionRef Objeto = this.ObtenerPorId(IdObjeto);
				db.MotivosPostergacionRef.Remove(Objeto);
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

		public DbQuery<MotivosPostergacionRefViewT> JsonT(string term)
		{
			var x = from c in db.MotivosPostergacionRef
					select new MotivosPostergacionRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosPostergacionRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
