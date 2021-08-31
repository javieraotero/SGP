
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
	public partial class ParametrosSeguridadRefAD
	{
		private BDEntities db = new BDEntities();

		public ParametrosSeguridadRef ObtenerPorId(int Id)
		{
			return db.ParametrosSeguridadRef.Single(c => c.Id == Id);
		}

		public DbQuery<ParametrosSeguridadRef> ObtenerTodo()
		{
			return (DbQuery<ParametrosSeguridadRef>)db.ParametrosSeguridadRef.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ParametrosSeguridadRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ParametrosSeguridadRefView> ObtenerParaGrilla()
		{
			var x = from c in db.ParametrosSeguridadRef
					where c.Activo == true
					select new ParametrosSeguridadRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 CambioClavePrimerInicio = c.CambioClavePrimerInicio,
						 LongitudMinimaClave = c.LongitudMinimaClave,
						 ClavesAlfanumericasObligatorias = c.ClavesAlfanumericasObligatorias,
						 IntervaloCaducidadClave = c.IntervaloCaducidadClave,
						 MaximoIntentosAccesoFallidos = c.MaximoIntentosAccesoFallidos,
						 DiasInactividadBloqueo = c.DiasInactividadBloqueo,
						 ClavesEnRegistroHistorico = c.ClavesEnRegistroHistorico,
						 Activo = c.Activo,
					};
			return (DbQuery<ParametrosSeguridadRefView>)x;
		}

		public void Guardar(ParametrosSeguridadRef Objeto)
		{
			try
			{
				db.ParametrosSeguridadRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ParametrosSeguridadRef Objeto)
		{
			try
			{
				db.ParametrosSeguridadRef.Attach(Objeto);
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
				ParametrosSeguridadRef Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<ParametrosSeguridadRefViewT> JsonT(string term)
		{
			var x = from c in db.ParametrosSeguridadRef
					where c.Activo == true
					select new ParametrosSeguridadRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 CambioClavePrimerInicio = c.CambioClavePrimerInicio,
						 LongitudMinimaClave = c.LongitudMinimaClave,
						 ClavesAlfanumericasObligatorias = c.ClavesAlfanumericasObligatorias,
						 IntervaloCaducidadClave = c.IntervaloCaducidadClave,
						 MaximoIntentosAccesoFallidos = c.MaximoIntentosAccesoFallidos,
						 DiasInactividadBloqueo = c.DiasInactividadBloqueo,
						 ClavesEnRegistroHistorico = c.ClavesEnRegistroHistorico,
						 Activo = c.Activo,
					};
			return (DbQuery<ParametrosSeguridadRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
