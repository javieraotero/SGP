
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
	public partial class MotivosPostergacionCivilRefAD
	{
		private BDEntities db = new BDEntities();

		public MotivosPostergacionCivilRef ObtenerPorId(int Id)
		{
			return db.MotivosPostergacionCivilRef.Single(c => c.Id == Id);
		}

		public DbQuery<MotivosPostergacionCivilRef> ObtenerTodo()
		{
			return (DbQuery<MotivosPostergacionCivilRef>)db.MotivosPostergacionCivilRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MotivosPostergacionCivilRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MotivosPostergacionCivilRefView> ObtenerParaGrilla()
		{
			var x = from c in db.MotivosPostergacionCivilRef
					select new MotivosPostergacionCivilRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosPostergacionCivilRefView>)x;
		}

		public void Guardar(MotivosPostergacionCivilRef Objeto)
		{
			try
			{
				db.MotivosPostergacionCivilRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosPostergacionCivilRef Objeto)
		{
			try
			{
				db.MotivosPostergacionCivilRef.Attach(Objeto);
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
				MotivosPostergacionCivilRef Objeto = this.ObtenerPorId(IdObjeto);
				db.MotivosPostergacionCivilRef.Remove(Objeto);
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

		public DbQuery<MotivosPostergacionCivilRefViewT> JsonT(string term)
		{
			var x = from c in db.MotivosPostergacionCivilRef
					select new MotivosPostergacionCivilRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosPostergacionCivilRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
