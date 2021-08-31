
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
	public partial class ActuacionesCivilAD
	{
		private BDEntities db = new BDEntities();

		public ActuacionesCivil ObtenerPorId(int Id)
		{
			return db.ActuacionesCivil.Single(c => c.Id == Id);
		}

		public DbQuery<ActuacionesCivil> ObtenerTodo()
		{
			return (DbQuery<ActuacionesCivil>)db.ActuacionesCivil;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ActuacionesCivil
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActuacionesCivilView> ObtenerParaGrilla()
		{
			var x = from c in db.ActuacionesCivil
					select new ActuacionesCivilView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Descripcion = c.Descripcion,
						 TipoActuacion = c.TipoActuacion,
						 Fecha = c.Fecha,
						 FechaVencimiento = c.FechaVencimiento,
						 FechaAlerta = c.FechaAlerta,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 Usuario = c.Usuario,
						 Estado = c.Estado,
						 FechaUltimaModificacion = c.FechaUltimaModificacion,
						 FundamentoMax = c.FundamentoMax,
						 FechaRecepcion = c.FechaRecepcion,
						 UsuarioRecepcion = c.UsuarioRecepcion,
						 Confirmado = c.Confirmado,
						 FechaFinPlazo = c.FechaFinPlazo,
						 OficinaOrigen = c.OficinaOrigen,
						 SubAmbitoOrigen = c.SubAmbitoOrigen,
						 MostrarDefensor = c.MostrarDefensor,
						 MostrarFiscal = c.MostrarFiscal,
						 MostrarJuez = c.MostrarJuez,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 FechaCargo = c.FechaCargo,
						 UsuarioCargo = c.UsuarioCargo,
						 FechaEliminada = c.FechaEliminada,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaPublicacion = c.FechaPublicacion,
						 UsuarioPublica = c.UsuarioPublica,
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
						 CantidadFirmantes = c.CantidadFirmantes,
						 MostrarTIP = c.MostrarTIP,
						 MostrarSTJ = c.MostrarSTJ,
						 MotivoAnulacion = c.MotivoAnulacion,
						 FechaAnulacion = c.FechaAnulacion,
						 UsuarioAnulacion = c.UsuarioAnulacion,
						 OficinaCargo = c.OficinaCargo,
						 Bloqueado = c.Bloqueado,
						 UsuarioBloquea = c.UsuarioBloquea,
						 FechaBloqueo = c.FechaBloqueo,
						 ModalidadDiasFechaPlazo = c.ModalidadDiasFechaPlazo,
						 MostrarJuezAudiencia = c.MostrarJuezAudiencia,
						 ModeloAplicado = c.ModeloAplicado,
					};
			return (DbQuery<ActuacionesCivilView>)x;
		}

		public void Guardar(ActuacionesCivil Objeto)
		{
			try
			{
				db.ActuacionesCivil.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesCivil Objeto)
		{
			try
			{
				db.ActuacionesCivil.Attach(Objeto);
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
				ActuacionesCivil Objeto = this.ObtenerPorId(IdObjeto);
				db.ActuacionesCivil.Remove(Objeto);
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

		public DbQuery<ActuacionesCivilViewT> JsonT(string term)
		{
			var x = from c in db.ActuacionesCivil
					select new ActuacionesCivilViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Descripcion = c.Descripcion,
						 TipoActuacion = c.TipoActuacion,
						 Fecha = c.Fecha,
						 FechaVencimiento = c.FechaVencimiento,
						 FechaAlerta = c.FechaAlerta,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 Usuario = c.Usuario,
						 Estado = c.Estado,
						 FechaUltimaModificacion = c.FechaUltimaModificacion,
						 FundamentoMax = c.FundamentoMax,
						 FechaRecepcion = c.FechaRecepcion,
						 UsuarioRecepcion = c.UsuarioRecepcion,
						 Confirmado = c.Confirmado,
						 FechaFinPlazo = c.FechaFinPlazo,
						 OficinaOrigen = c.OficinaOrigen,
						 SubAmbitoOrigen = c.SubAmbitoOrigen,
						 MostrarDefensor = c.MostrarDefensor,
						 MostrarFiscal = c.MostrarFiscal,
						 MostrarJuez = c.MostrarJuez,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 FechaCargo = c.FechaCargo,
						 UsuarioCargo = c.UsuarioCargo,
						 FechaEliminada = c.FechaEliminada,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaPublicacion = c.FechaPublicacion,
						 UsuarioPublica = c.UsuarioPublica,
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
						 CantidadFirmantes = c.CantidadFirmantes,
						 MostrarTIP = c.MostrarTIP,
						 MostrarSTJ = c.MostrarSTJ,
						 MotivoAnulacion = c.MotivoAnulacion,
						 FechaAnulacion = c.FechaAnulacion,
						 UsuarioAnulacion = c.UsuarioAnulacion,
						 OficinaCargo = c.OficinaCargo,
						 Bloqueado = c.Bloqueado,
						 UsuarioBloquea = c.UsuarioBloquea,
						 FechaBloqueo = c.FechaBloqueo,
						 ModalidadDiasFechaPlazo = c.ModalidadDiasFechaPlazo,
						 MostrarJuezAudiencia = c.MostrarJuezAudiencia,
						 ModeloAplicado = c.ModeloAplicado,
					};
			return (DbQuery<ActuacionesCivilViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
