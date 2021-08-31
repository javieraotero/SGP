
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
	public partial class SucesosCausasAD
	{
		private BDEntities db = new BDEntities();

		public SucesosCausas ObtenerPorId(int Id)
		{
			return db.SucesosCausas.Single(c => c.Id == Id);
		}

		public DbQuery<SucesosCausas> ObtenerTodo()
		{
			return (DbQuery<SucesosCausas>)db.SucesosCausas;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SucesosCausas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SucesosCausasView> ObtenerParaGrilla()
		{
			var x = from c in db.SucesosCausas
					select new SucesosCausasView
					{
						 Id = c.Id,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 SubAmbito = c.SubAmbito,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 TipoSuceso = c.TipoSuceso,
						 FechaMostrar = c.FechaMostrar,
						 TareaRealizada = c.TareaRealizada,
						 FechaRealizada = c.FechaRealizada,
						 UsuarioRealizada = c.UsuarioRealizada,
						 Causa = c.Causa,
						 Actuacion = c.Actuacion,
						 Activa = c.Activa,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
						 ResponsableEvento = c.ResponsableEvento,
						 OficinaEvento = c.OficinaEvento,
						 ModificadoPorSuspencion = c.ModificadoPorSuspencion,
					};
			return (DbQuery<SucesosCausasView>)x;
		}

		public void Guardar(SucesosCausas Objeto)
		{
			try
			{
				db.SucesosCausas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SucesosCausas Objeto)
		{
			try
			{
				db.SucesosCausas.Attach(Objeto);
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
				SucesosCausas Objeto = this.ObtenerPorId(IdObjeto);
				db.SucesosCausas.Remove(Objeto);
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

		public DbQuery<SucesosCausasViewT> JsonT(string term)
		{
			var x = from c in db.SucesosCausas
					select new SucesosCausasViewT
					{
						 Id = c.Id,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 SubAmbito = c.SubAmbito,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 TipoSuceso = c.TipoSuceso,
						 FechaMostrar = c.FechaMostrar,
						 TareaRealizada = c.TareaRealizada,
						 FechaRealizada = c.FechaRealizada,
						 UsuarioRealizada = c.UsuarioRealizada,
						 Causa = c.Causa,
						 Actuacion = c.Actuacion,
						 Activa = c.Activa,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
						 ResponsableEvento = c.ResponsableEvento,
						 OficinaEvento = c.OficinaEvento,
						 ModificadoPorSuspencion = c.ModificadoPorSuspencion,
					};
			return (DbQuery<SucesosCausasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
