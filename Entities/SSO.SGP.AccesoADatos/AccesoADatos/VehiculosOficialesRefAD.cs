
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
	public partial class VehiculosOficialesRefAD
	{
		private BDEntities db = new BDEntities();

		public VehiculosOficialesRef ObtenerPorId(int Id)
		{
			return db.VehiculosOficialesRef.Single(c => c.Id == Id);
		}

		public DbQuery<VehiculosOficialesRef> ObtenerTodo()
		{
			return (DbQuery<VehiculosOficialesRef>)db.VehiculosOficialesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.VehiculosOficialesRef
				select new SelectOptionsView {text = x.Descripcion + " - " + x.Patente, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<VehiculosOficialesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.VehiculosOficialesRef
					select new VehiculosOficialesRefView
					{
						 Id = c.Id,
						 Legajo = c.Legajo,
						 Patente = c.Patente,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<VehiculosOficialesRefView>)x;
		}

		public void Guardar(VehiculosOficialesRef Objeto)
		{
			try
			{
				db.VehiculosOficialesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(VehiculosOficialesRef Objeto)
		{
			try
			{
				db.VehiculosOficialesRef.Attach(Objeto);
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
				VehiculosOficialesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.VehiculosOficialesRef.Remove(Objeto);
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

		//public DbQuery<VehiculosOficialesRefViewT> JsonT(string term)
		//{
		//	var x = from c in db.VehiculosOficialesRef
		//			select new VehiculosOficialesRefViewT
		//			{
		//				 Id = c.Id,
		//				 Legajo = c.Legajo,
		//				 Patente = c.Patente,
		//				 Descripcion = c.Descripcion,
		//			};
		//	return (DbQuery<VehiculosOficialesRefViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
