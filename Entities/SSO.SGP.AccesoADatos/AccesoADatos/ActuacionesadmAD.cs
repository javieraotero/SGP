
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
	public partial class ActuacionesadmAD
	{
		private BDEntities db = new BDEntities();

		public Actuacionesadm ObtenerPorId(int Id)
		{
			return db.Actuacionesadm.Single(c => c.Id == Id);
		}

		public DbQuery<Actuacionesadm> ObtenerTodo()
		{
			return (DbQuery<Actuacionesadm>)db.Actuacionesadm;
		}

        public Actuacionesadm ObtenerPorExpedienteYOrganismo(int expediente, int organismo)
        {
            var res = (from x in db.Actuacionesadm
                       where x.Expediente == expediente && x.OrganismoCargo == organismo && !x.FechaCargo.HasValue select x).FirstOrDefault();

            return res;
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Actuacionesadm
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActuacionesadmView> ObtenerParaGrilla()
		{
			var x = from c in db.Actuacionesadm
					select new ActuacionesadmView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Descripcion = c.Descripcion,
						 Fecha = c.Fecha,
						 FechaRecepcion = c.FechaRecepcion,
						 UsuarioRecepcion = c.UsuarioRecepcion,
						 OficinaOrigen = c.OficinaOrigen,
						 SubAmbitoOrigen = c.SubAmbitoOrigen,
						 Anulado = c.Anulado,
						 FechaAnulado = c.FechaAnulado,
						 UsuarioAnulacion = c.UsuarioAnulacion,
						 MotivoAnulacion = c.MotivoAnulacion,
						 Texto = c.Texto,
						 FechaPublicacion = c.FechaPublicacion,
						 UsuarioPublica = c.UsuarioPublica,
						 FechaUltimaModificacion = c.FechaUltimaModificacion,
						 TipoActuacion = c.TipoActuacion,
						 ModeloAplicado = c.ModeloAplicado,
						 Firmante1 = c.Firmante1,
						 FechaFirmante1 = c.FechaFirmante1,
						 Firmante2 = c.Firmante2,
						 FechaFirmante2 = c.FechaFirmante2,
						 Firmante3 = c.Firmante3,
						 FechaFirmante3 = c.FechaFirmante3,
						 Firmante4 = c.Firmante4,
						 FechaFirmante4 = c.FechaFirmante4,
						 Firmante5 = c.Firmante5,
						 FechaFirmante5 = c.FechaFirmante5,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 FechaCargo = c.FechaCargo,
						 UsuarioCargo = c.UsuarioCargo,
						 Fojas = c.Fojas,
					};
			return (DbQuery<ActuacionesadmView>)x;
		}

		public void Guardar(Actuacionesadm Objeto)
		{
			try
			{
				db.Actuacionesadm.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Actuacionesadm Objeto)
		{
			try
			{
				db.Actuacionesadm.Attach(Objeto);
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
				Actuacionesadm Objeto = this.ObtenerPorId(IdObjeto);
				db.Actuacionesadm.Remove(Objeto);
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

		public DbQuery<ActuacionesadmViewT> JsonT(string term)
		{
			var x = from c in db.Actuacionesadm
					select new ActuacionesadmViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Fecha = c.Fecha,
						 FechaPublicacion = c.FechaPublicacion,
						 TipoActuacion = c.TipoActuacions.Descripcion,
						 SubAmbitoCargo = c.SubAmbitoCargos.Descripcion,
						 Fojas = (c.Fojas.HasValue) ? c.Fojas.Value : 0
					};
			return (DbQuery<ActuacionesadmViewT>)x;
		}
        /*********************************************
		* Seccion Particular
		* *******************************************/
        public DbQuery<ActuacionesadmViewT> ActuacionConCargoPendiente(int organismo)
        {
            var x = from c in db.Actuacionesadm
                    where c.RequiereCargo && c.OrganismoCargo == organismo && !c.FechaCargo.HasValue
                    select new ActuacionesadmViewT
                    {
                        Id = c.Id,
                        Descripcion = c.Descripcion,
                        Fecha = c.Fecha,
                        FechaPublicacion = c.FechaPublicacion,
                        TipoActuacion = c.TipoActuacions.Descripcion,
                        SubAmbitoCargo = c.SubAmbitoCargos.Descripcion,
                        Fojas = (c.Fojas.HasValue) ? c.Fojas.Value : 0,
                        Expediente = c.Expediente,
                        Numero = c.Expedientes.Numero
                    };
            return (DbQuery<ActuacionesadmViewT>)x;
        }

    }
}
