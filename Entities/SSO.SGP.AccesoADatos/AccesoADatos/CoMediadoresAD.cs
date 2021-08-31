
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
	public partial class CoMediadoresAD
	{
		private BDEntities db = new BDEntities();

		public CoMediadores ObtenerPorId(int Id)
		{
			return db.CoMediadores.Single(c => c.Id == Id);
		}

		public DbQuery<CoMediadores> ObtenerTodo()
		{
			return (DbQuery<CoMediadores>)db.CoMediadores.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CoMediadores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CoMediadoresView> ObtenerParaGrilla()
		{
			var x = from c in db.CoMediadores
					where c.Activo == true
					select new CoMediadoresView
					{
						 Id = c.Id,
						 UsuarioCarga = c.UsuarioCarga,
						 FechaCarga = c.FechaCarga,
						 UsuarioCoMediador = c.UsuarioCoMediador,
						 Activo = c.Activo,
						 Tipo = c.Tipo,
					};
			return (DbQuery<CoMediadoresView>)x;
		}

		public void Guardar(CoMediadores Objeto)
		{
			try
			{
				db.CoMediadores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CoMediadores Objeto)
		{
			try
			{
				db.CoMediadores.Attach(Objeto);
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
				CoMediadores Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<CoMediadoresViewT> JsonT(string term)
		{
			var x = from c in db.CoMediadores
					where c.Activo == true
					select new CoMediadoresViewT
					{
						 Id = c.Id,
						 UsuarioCarga = c.UsuarioCarga,
						 FechaCarga = c.FechaCarga,
						 UsuarioCoMediador = c.UsuarioCoMediador,
						 Activo = c.Activo,
						 Tipo = c.Tipo,
					};
			return (DbQuery<CoMediadoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
