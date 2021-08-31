
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
	public partial class MotivosElementosSecuentradosMovimientoRefAD
	{
		private BDEntities db = new BDEntities();

		public MotivosElementosSecuentradosMovimientoRef ObtenerPorId(int Id)
		{
			return db.MotivosElementosSecuentradosMovimientoRef.Single(c => c.Id == Id);
		}

		public DbQuery<MotivosElementosSecuentradosMovimientoRef> ObtenerTodo()
		{
			return (DbQuery<MotivosElementosSecuentradosMovimientoRef>)db.MotivosElementosSecuentradosMovimientoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MotivosElementosSecuentradosMovimientoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MotivosElementosSecuentradosMovimientoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.MotivosElementosSecuentradosMovimientoRef
					select new MotivosElementosSecuentradosMovimientoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Entrada = c.Entrada,
						 EsBaja = c.EsBaja,
					};
			return (DbQuery<MotivosElementosSecuentradosMovimientoRefView>)x;
		}

		public void Guardar(MotivosElementosSecuentradosMovimientoRef Objeto)
		{
			try
			{
				db.MotivosElementosSecuentradosMovimientoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosElementosSecuentradosMovimientoRef Objeto)
		{
			try
			{
				db.MotivosElementosSecuentradosMovimientoRef.Attach(Objeto);
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
				MotivosElementosSecuentradosMovimientoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.MotivosElementosSecuentradosMovimientoRef.Remove(Objeto);
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

		public DbQuery<MotivosElementosSecuentradosMovimientoRefViewT> JsonT(string term)
		{
			var x = from c in db.MotivosElementosSecuentradosMovimientoRef
					select new MotivosElementosSecuentradosMovimientoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Entrada = c.Entrada,
						 EsBaja = c.EsBaja,
					};
			return (DbQuery<MotivosElementosSecuentradosMovimientoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
