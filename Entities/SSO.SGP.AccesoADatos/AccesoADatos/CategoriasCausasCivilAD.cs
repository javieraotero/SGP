
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
	public partial class CategoriasCausasCivilAD
	{
		private BDEntities db = new BDEntities();

		public CategoriasCausasCivil ObtenerPorId(int Id)
		{
			return db.CategoriasCausasCivil.Single(c => c.Id == Id);
		}

		public DbQuery<CategoriasCausasCivil> ObtenerTodo()
		{
			return (DbQuery<CategoriasCausasCivil>)db.CategoriasCausasCivil;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CategoriasCausasCivil
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CategoriasCausasCivilView> ObtenerParaGrilla()
		{
			var x = from c in db.CategoriasCausasCivil
					select new CategoriasCausasCivilView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 SubAmbito = c.SubAmbito,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<CategoriasCausasCivilView>)x;
		}

		public void Guardar(CategoriasCausasCivil Objeto)
		{
			try
			{
				db.CategoriasCausasCivil.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasCausasCivil Objeto)
		{
			try
			{
				db.CategoriasCausasCivil.Attach(Objeto);
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
				CategoriasCausasCivil Objeto = this.ObtenerPorId(IdObjeto);
				db.CategoriasCausasCivil.Remove(Objeto);
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

		public DbQuery<CategoriasCausasCivilViewT> JsonT(string term)
		{
			var x = from c in db.CategoriasCausasCivil
					select new CategoriasCausasCivilViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 SubAmbito = c.SubAmbito,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<CategoriasCausasCivilViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
