
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
	public partial class ParametrosReceptoriaAD
	{
		private BDEntities db = new BDEntities();

		public ParametrosReceptoria ObtenerPorId(int Id)
		{
			return db.ParametrosReceptoria.Single(c => c.Id == Id);
		}

		public DbQuery<ParametrosReceptoria> ObtenerTodo()
		{
			return (DbQuery<ParametrosReceptoria>)db.ParametrosReceptoria;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ParametrosReceptoria
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ParametrosReceptoriaView> ObtenerParaGrilla()
		{
			var x = from c in db.ParametrosReceptoria
					select new ParametrosReceptoriaView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Valor = c.Valor,
						 Tipo = c.Tipo,
						 ExpresionRegular = c.ExpresionRegular,
					};
			return (DbQuery<ParametrosReceptoriaView>)x;
		}

		public void Guardar(ParametrosReceptoria Objeto)
		{
			try
			{
				db.ParametrosReceptoria.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ParametrosReceptoria Objeto)
		{
			try
			{
				db.ParametrosReceptoria.Attach(Objeto);
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
				ParametrosReceptoria Objeto = this.ObtenerPorId(IdObjeto);
				db.ParametrosReceptoria.Remove(Objeto);
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

		public DbQuery<ParametrosReceptoriaViewT> JsonT(string term)
		{
			var x = from c in db.ParametrosReceptoria
					select new ParametrosReceptoriaViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Valor = c.Valor,
						 Tipo = c.Tipo,
						 ExpresionRegular = c.ExpresionRegular,
					};
			return (DbQuery<ParametrosReceptoriaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
