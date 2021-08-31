
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
	public partial class MovimientoscesidaAD
	{
		private BDEntities db = new BDEntities();

		public Movimientoscesida ObtenerPorId(int Id)
		{
			return db.Movimientoscesida.Single(c => c.Id == Id);
		}

		public DbQuery<Movimientoscesida> ObtenerTodo()
		{
			return (DbQuery<Movimientoscesida>)db.Movimientoscesida;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Movimientoscesida
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MovimientoscesidaView> ObtenerParaGrilla()
		{
			var x = from c in db.Movimientoscesida
					select new MovimientoscesidaView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 CodigoCesida = c.CodigoCesida,
						 ApiURLProduccion = c.ApiURLProduccion,
						 ApiURLPruebas = c.ApiURLPruebas,
					};
			return (DbQuery<MovimientoscesidaView>)x;
		}

		public void Guardar(Movimientoscesida Objeto)
		{
			try
			{
				db.Movimientoscesida.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Movimientoscesida Objeto)
		{
			try
			{
				db.Movimientoscesida.Attach(Objeto);
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
				Movimientoscesida Objeto = this.ObtenerPorId(IdObjeto);
				db.Movimientoscesida.Remove(Objeto);
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

		//public DbQuery<MovimientoscesidaViewT> JsonT(string term)
		//{
		//	var x = from c in db.Movimientoscesida
		//			select new MovimientoscesidaViewT
		//			{
		//				 Id = c.Id,
		//				 Nombre = c.Nombre,
		//				 CodigoCesida = c.CodigoCesida,
		//				 ApiURLProduccion = c.ApiURLProduccion,
		//				 ApiURLPruebas = c.ApiURLPruebas,
		//			};
		//	return (DbQuery<MovimientoscesidaViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
