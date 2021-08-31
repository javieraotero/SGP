
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
	public partial class CoMediadoresInscripcionAD
	{
		private BDEntities db = new BDEntities();

		public CoMediadoresInscripcion ObtenerPorId(int Id)
		{
			return db.CoMediadoresInscripcion.Single(c => c.Id == Id);
		}

		public DbQuery<CoMediadoresInscripcion> ObtenerTodo()
		{
			return (DbQuery<CoMediadoresInscripcion>)db.CoMediadoresInscripcion.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CoMediadoresInscripcion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CoMediadoresInscripcionView> ObtenerParaGrilla()
		{
			var x = from c in db.CoMediadoresInscripcion
					where c.Activo == true
					select new CoMediadoresInscripcionView
					{
						 Id = c.Id,
						 Circunscripcion1 = c.Circunscripcion1,
						 Circunscripcion2 = c.Circunscripcion2,
						 Circunscripcion3 = c.Circunscripcion3,
						 Circunscripcion4 = c.Circunscripcion4,
						 FechaInscripcion = c.FechaInscripcion,
						 Especialidad = c.Especialidad,
						 UsuarioCarga = c.UsuarioCarga,
						 Periodo = c.Periodo,
						 CoMediador = c.CoMediador,
						 Estado = c.Estado,
						 Activo = c.Activo,
					};
			return (DbQuery<CoMediadoresInscripcionView>)x;
		}

		public void Guardar(CoMediadoresInscripcion Objeto)
		{
			try
			{
				db.CoMediadoresInscripcion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CoMediadoresInscripcion Objeto)
		{
			try
			{
				db.CoMediadoresInscripcion.Attach(Objeto);
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
				CoMediadoresInscripcion Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<CoMediadoresInscripcionViewT> JsonT(string term)
		{
			var x = from c in db.CoMediadoresInscripcion
					where c.Activo == true
					select new CoMediadoresInscripcionViewT
					{
						 Id = c.Id,
						 Circunscripcion1 = c.Circunscripcion1,
						 Circunscripcion2 = c.Circunscripcion2,
						 Circunscripcion3 = c.Circunscripcion3,
						 Circunscripcion4 = c.Circunscripcion4,
						 FechaInscripcion = c.FechaInscripcion,
						 Especialidad = c.Especialidad,
						 UsuarioCarga = c.UsuarioCarga,
						 Periodo = c.Periodo,
						 CoMediador = c.CoMediador,
						 Estado = c.Estado,
						 Activo = c.Activo,
					};
			return (DbQuery<CoMediadoresInscripcionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
