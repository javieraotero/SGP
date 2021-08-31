
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
	public partial class PeritosEspecialidadAD
	{
		private BDEntities db = new BDEntities();

		public PeritosEspecialidad ObtenerPorId(int Id)
		{
			return db.PeritosEspecialidad.Single(c => c.Id == Id);
		}

		public DbQuery<PeritosEspecialidad> ObtenerTodo()
		{
			return (DbQuery<PeritosEspecialidad>)db.PeritosEspecialidad.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PeritosEspecialidad
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PeritosEspecialidadView> ObtenerParaGrilla()
		{
			var x = from c in db.PeritosEspecialidad
					where c.Activo == true
					select new PeritosEspecialidadView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Activo = c.Activo,
						 SubEspecialidad = c.SubEspecialidad,
						 TipoPeriodo = c.TipoPeriodo,
					};
			return (DbQuery<PeritosEspecialidadView>)x;
		}

		public void Guardar(PeritosEspecialidad Objeto)
		{
			try
			{
				db.PeritosEspecialidad.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosEspecialidad Objeto)
		{
			try
			{
				db.PeritosEspecialidad.Attach(Objeto);
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
				PeritosEspecialidad Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<PeritosEspecialidadViewT> JsonT(string term)
		{
			var x = from c in db.PeritosEspecialidad
					where c.Activo == true
					select new PeritosEspecialidadViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Activo = c.Activo,
						 SubEspecialidad = c.SubEspecialidad,
						 TipoPeriodo = c.TipoPeriodo,
					};
			return (DbQuery<PeritosEspecialidadViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
