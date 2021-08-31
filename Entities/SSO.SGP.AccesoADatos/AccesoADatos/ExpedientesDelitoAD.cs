
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
	public partial class ExpedientesDelitoAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesDelito ObtenerPorId(int Id)
		{
			return db.ExpedientesDelito.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesDelito> ObtenerTodo()
		{
			return (DbQuery<ExpedientesDelito>)db.ExpedientesDelito.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesDelito
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesDelitoView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesDelito
					where c.Activo == true
					select new ExpedientesDelitoView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Delito = c.Delito,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 HoraDesde = c.HoraDesde,
						 HoraHasta = c.HoraHasta,
						 Barrio = c.Barrio,
						 Calle = c.Calle,
						 Calle1 = c.Calle1,
						 Calle2 = c.Calle2,
						 Nro = c.Nro,
						 DescripcionUbicacion = c.DescripcionUbicacion,
						 Observaciones = c.Observaciones,
						 CantidadHechos = c.CantidadHechos,
						 Tentativa = c.Tentativa,
						 UbicacionExacta = c.UbicacionExacta,
						 Flagrancia = c.Flagrancia,
						 Localidad = c.Localidad,
						 Activo = c.Activo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
						 FechaBaja = c.FechaBaja,
						 UsuarioBaja = c.UsuarioBaja,
					};
			return (DbQuery<ExpedientesDelitoView>)x;
		}

		public void Guardar(ExpedientesDelito Objeto)
		{
			try
			{
				db.ExpedientesDelito.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesDelito Objeto)
		{
			try
			{
				db.ExpedientesDelito.Attach(Objeto);
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
				ExpedientesDelito Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
				Objeto.FechaBaja = DateTime.Now;
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

		public DbQuery<ExpedientesDelitoViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesDelito
					where c.Activo == true
					select new ExpedientesDelitoViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Delito = c.Delito,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 HoraDesde = c.HoraDesde,
						 HoraHasta = c.HoraHasta,
						 Barrio = c.Barrio,
						 Calle = c.Calle,
						 Calle1 = c.Calle1,
						 Calle2 = c.Calle2,
						 Nro = c.Nro,
						 DescripcionUbicacion = c.DescripcionUbicacion,
						 Observaciones = c.Observaciones,
						 CantidadHechos = c.CantidadHechos,
						 Tentativa = c.Tentativa,
						 UbicacionExacta = c.UbicacionExacta,
						 Flagrancia = c.Flagrancia,
						 Localidad = c.Localidad,
						 Activo = c.Activo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
						 FechaBaja = c.FechaBaja,
						 UsuarioBaja = c.UsuarioBaja,
					};
			return (DbQuery<ExpedientesDelitoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
