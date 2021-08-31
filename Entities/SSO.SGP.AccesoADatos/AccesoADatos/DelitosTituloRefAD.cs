
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
	public partial class DelitosTituloRefAD
	{
		private BDEntities db = new BDEntities();

		public DelitosTituloRef ObtenerPorId(int Id)
		{
			return db.DelitosTituloRef.Single(c => c.Id == Id);
		}

		public DbQuery<DelitosTituloRef> ObtenerTodo()
		{
			return (DbQuery<DelitosTituloRef>)db.DelitosTituloRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.DelitosTituloRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<DelitosTituloRefView> ObtenerParaGrilla()
		{
			var x = from c in db.DelitosTituloRef
					select new DelitosTituloRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<DelitosTituloRefView>)x;
		}

		public void Guardar(DelitosTituloRef Objeto)
		{
			try
			{
				db.DelitosTituloRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DelitosTituloRef Objeto)
		{
			try
			{
				db.DelitosTituloRef.Attach(Objeto);
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
				DelitosTituloRef Objeto = this.ObtenerPorId(IdObjeto);
				db.DelitosTituloRef.Remove(Objeto);
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

		public DbQuery<DelitosTituloRefViewT> JsonT(string term)
		{
			var x = from c in db.DelitosTituloRef
					select new DelitosTituloRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<DelitosTituloRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
