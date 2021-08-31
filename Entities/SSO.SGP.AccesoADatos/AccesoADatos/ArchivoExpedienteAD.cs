
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
	public partial class ArchivoExpedienteAD
	{
		private BDEntities db = new BDEntities();

		public ArchivoExpediente ObtenerPorId(int Id)
		{
			return db.ArchivoExpediente.Single(c => c.Id == Id);
		}

		public DbQuery<ArchivoExpediente> ObtenerTodo()
		{
			return (DbQuery<ArchivoExpediente>)db.ArchivoExpediente;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ArchivoExpediente
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ArchivoExpedienteView> ObtenerParaGrilla()
		{
			var x = from c in db.ArchivoExpediente
					select new ArchivoExpedienteView
					{
						 Id = c.Id,
						 Fuero = c.Fuero,
						 Circunscripcion = c.Circunscripcion,
						 Expediente = c.Expediente,
						 NroLegajo = c.NroLegajo,
						 Caratula = c.Caratula,
						 NroPaquete = c.NroPaquete,
						 NroEstanteria = c.NroEstanteria,
						 Estado = c.Estado,
						 FechaProbableExpurgacion = c.FechaProbableExpurgacion,
						 Observaciones = c.Observaciones,
						 Fojas = c.Fojas,
						 OrganismoEnvio = c.OrganismoEnvio,
						 FechaEnvio = c.FechaEnvio,
						 ConfirmadoArchivado = c.ConfirmadoArchivado,
						 TipoArchivado = c.TipoArchivado,
						 CargoArchivo = c.CargoArchivo,
						 FechaRecepcion = c.FechaRecepcion,
						 CircunscripcionArchiva = c.CircunscripcionArchiva,
					};
			return (DbQuery<ArchivoExpedienteView>)x;
		}

		public void Guardar(ArchivoExpediente Objeto)
		{
			try
			{
				db.ArchivoExpediente.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArchivoExpediente Objeto)
		{
			try
			{
				db.ArchivoExpediente.Attach(Objeto);
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
				ArchivoExpediente Objeto = this.ObtenerPorId(IdObjeto);
				db.ArchivoExpediente.Remove(Objeto);
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

		public DbQuery<ArchivoExpedienteViewT> JsonT(string term)
		{
			var x = from c in db.ArchivoExpediente
					select new ArchivoExpedienteViewT
					{
						 Id = c.Id,
						 Fuero = c.Fuero,
						 Circunscripcion = c.Circunscripcion,
						 Expediente = c.Expediente,
						 NroLegajo = c.NroLegajo,
						 Caratula = c.Caratula,
						 NroPaquete = c.NroPaquete,
						 NroEstanteria = c.NroEstanteria,
						 Estado = c.Estado,
						 FechaProbableExpurgacion = c.FechaProbableExpurgacion,
						 Observaciones = c.Observaciones,
						 Fojas = c.Fojas,
						 OrganismoEnvio = c.OrganismoEnvio,
						 FechaEnvio = c.FechaEnvio,
						 ConfirmadoArchivado = c.ConfirmadoArchivado,
						 TipoArchivado = c.TipoArchivado,
						 CargoArchivo = c.CargoArchivo,
						 FechaRecepcion = c.FechaRecepcion,
						 CircunscripcionArchiva = c.CircunscripcionArchiva,
					};
			return (DbQuery<ArchivoExpedienteViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
