
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
	public partial class FormasDePagoRefAD
	{
		private BDEntities db = new BDEntities();

		public FormasDePagoRef ObtenerPorId(int Id)
		{
			return db.FormasDePagoRef.Single(c => c.Id == Id);
		}

		public DbQuery<FormasDePagoRef> ObtenerTodo()
		{
			return (DbQuery<FormasDePagoRef>)db.FormasDePagoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.FormasDePagoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FormasDePagoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.FormasDePagoRef
					select new FormasDePagoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<FormasDePagoRefView>)x;
		}

		public void Guardar(FormasDePagoRef Objeto)
		{
			try
			{
				db.FormasDePagoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FormasDePagoRef Objeto)
		{
			try
			{
				db.FormasDePagoRef.Attach(Objeto);
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
				FormasDePagoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.FormasDePagoRef.Remove(Objeto);
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

		public DbQuery<FormasDePagoRefViewT> JsonT(string term)
		{
			var x = from c in db.FormasDePagoRef
					select new FormasDePagoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<FormasDePagoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
