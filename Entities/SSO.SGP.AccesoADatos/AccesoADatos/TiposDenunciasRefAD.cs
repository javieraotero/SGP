
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
	public partial class TiposDenunciasRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposDenunciasRef ObtenerPorId(int Id)
		{
			return db.TiposDenunciasRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposDenunciasRef> ObtenerTodo()
		{
			return (DbQuery<TiposDenunciasRef>)db.TiposDenunciasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposDenunciasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposDenunciasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposDenunciasRef
					select new TiposDenunciasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Modelo = c.Modelo,
					};
			return (DbQuery<TiposDenunciasRefView>)x;
		}

		public void Guardar(TiposDenunciasRef Objeto)
		{
			try
			{
				db.TiposDenunciasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposDenunciasRef Objeto)
		{
			try
			{
				db.TiposDenunciasRef.Attach(Objeto);
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
				TiposDenunciasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposDenunciasRef.Remove(Objeto);
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

		public DbQuery<TiposDenunciasRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposDenunciasRef
					select new TiposDenunciasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Modelo = c.Modelo,
					};
			return (DbQuery<TiposDenunciasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
