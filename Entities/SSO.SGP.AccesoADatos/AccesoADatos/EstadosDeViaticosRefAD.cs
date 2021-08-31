
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
	public partial class EstadosDeViaticosRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosDeViaticosRef ObtenerPorId(int Id)
		{
			return db.EstadosDeViaticosRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosDeViaticosRef> ObtenerTodo()
		{
			return (DbQuery<EstadosDeViaticosRef>)db.EstadosDeViaticosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosDeViaticosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosDeViaticosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosDeViaticosRef
					select new EstadosDeViaticosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EditaOrganismo = c.EditaOrganismo,
						 EditaEconomia = c.EditaEconomia,
					};
			return (DbQuery<EstadosDeViaticosRefView>)x;
		}

		public void Guardar(EstadosDeViaticosRef Objeto)
		{
			try
			{
				db.EstadosDeViaticosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosDeViaticosRef Objeto)
		{
			try
			{
				db.EstadosDeViaticosRef.Attach(Objeto);
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
				EstadosDeViaticosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosDeViaticosRef.Remove(Objeto);
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

		//public DbQuery<EstadosDeViaticosRefViewT> JsonT(string term)
		//{
		//	var x = from c in db.EstadosDeViaticosRef
		//			select new EstadosDeViaticosRefViewT
		//			{
		//				 Id = c.Id,
		//				 Descripcion = c.Descripcion,
		//				 EditaOrganismo = c.EditaOrganismo,
		//				 EditaEconomia = c.EditaEconomia,
		//			};
		//	return (DbQuery<EstadosDeViaticosRefViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
