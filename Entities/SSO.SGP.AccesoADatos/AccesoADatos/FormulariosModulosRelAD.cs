
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
	public partial class FormulariosModulosRelAD
	{
		private BDEntities db = new BDEntities();

		public FormulariosModulosRel ObtenerPorId(int Id)
		{
			return db.FormulariosModulosRel.Single(c => c.ID == Id);
		}

		public DbQuery<FormulariosModulosRel> ObtenerTodo()
		{
			return (DbQuery<FormulariosModulosRel>)db.FormulariosModulosRel;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.FormulariosModulosRel
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FormulariosModulosRelView> ObtenerParaGrilla()
		{
			var x = from c in db.FormulariosModulosRel
					select new FormulariosModulosRelView
					{
						 Formulario = c.Formulario,
						 Modulo = c.Modulo,
					};
			return (DbQuery<FormulariosModulosRelView>)x;
		}

		public void Guardar(FormulariosModulosRel Objeto)
		{
			try
			{
				db.FormulariosModulosRel.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FormulariosModulosRel Objeto)
		{
			try
			{
				db.FormulariosModulosRel.Attach(Objeto);
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
				FormulariosModulosRel Objeto = this.ObtenerPorId(IdObjeto);
				db.FormulariosModulosRel.Remove(Objeto);
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

		public DbQuery<FormulariosModulosRelViewT> JsonT(string term)
		{
			var x = from c in db.FormulariosModulosRel
					select new FormulariosModulosRelViewT
					{
						 Formulario = c.Formulario,
						 Modulo = c.Modulo,
					};
			return (DbQuery<FormulariosModulosRelViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
