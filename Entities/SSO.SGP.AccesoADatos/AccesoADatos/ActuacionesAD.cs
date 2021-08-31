
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
	public partial class ActuacionesAD
	{
		private BDEntities db = new BDEntities();

		public Actuaciones ObtenerPorId(int Id)
		{
			return db.Actuaciones.Single(c => c.Id == Id);
		}

		public DbQuery<Actuaciones> ObtenerTodo()
		{
			return (DbQuery<Actuaciones>)db.Actuaciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Actuaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActuacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.Actuaciones
					select new ActuacionesView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Descripcion = c.Descripcion,
						 Preventivo = c.Preventivo,
						 TipoActuacion = c.TipoActuacion,
						 Fecha = c.Fecha,
						 FechaVencimiento = c.FechaVencimiento,
						 FechaAlerta = c.FechaAlerta,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 Usuario = c.Usuario,
						 Estado = c.Estado,
						 FechaUltimaModificacion = c.FechaUltimaModificacion,
						 Fundamento = c.Fundamento,
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
						 Protocolizado = c.Protocolizado,
						 FechaProtocolizado = c.FechaProtocolizado,
						 UsuarioProtocolizado = c.UsuarioProtocolizado,
						 Protocolo = c.Protocolo,
						 OficinaCargo = c.OficinaCargo,
						 Bloqueado = c.Bloqueado,
						 UsuarioBloquea = c.UsuarioBloquea,
						 FechaBloqueo = c.FechaBloqueo,
						 ModalidadDiasFechaPlazo = c.ModalidadDiasFechaPlazo,
						 MostrarJuezAudiencia = c.MostrarJuezAudiencia,
						 SubAmbitoProtocolizado = c.SubAmbitoProtocolizado,
						 CategoriaProtocolizado = c.CategoriaProtocolizado,
						 ModeloAplicado = c.ModeloAplicado,
						 VisadoJefatura = c.VisadoJefatura,
						 UsuarioJefatura = c.UsuarioJefatura,
						 FechaJefatura = c.FechaJefatura,
						 VisadoSubJefatura = c.VisadoSubJefatura,
						 UsuarioSubJefatura = c.UsuarioSubJefatura,
						 FechaSubJefatura = c.FechaSubJefatura,
						 VisadoJefeDeptoJudiciales = c.VisadoJefeDeptoJudiciales,
						 UsuarioJefeDeptoJudiciales = c.UsuarioJefeDeptoJudiciales,
						 FechaJefeDeptoJudiciales = c.FechaJefeDeptoJudiciales,
						 VisadoJefeUnidRegional = c.VisadoJefeUnidRegional,
						 UsuarioJefeUnidRegional = c.UsuarioJefeUnidRegional,
						 FechaJefeUnidRegional = c.FechaJefeUnidRegional,
						 FundamentoMax = c.FundamentoMax,
					};
			return (DbQuery<ActuacionesView>)x;
		}

		public void Guardar(Actuaciones Objeto)
		{
			try
			{
				db.Actuaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Actuaciones Objeto)
		{
			try
			{
				db.Actuaciones.Attach(Objeto);
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
				Actuaciones Objeto = this.ObtenerPorId(IdObjeto);
				db.Actuaciones.Remove(Objeto);
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

		public DbQuery<ActuacionesViewT> JsonT(string term)
		{
			var x = from c in db.Actuaciones
					select new ActuacionesViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Descripcion = c.Descripcion,
						 Preventivo = c.Preventivo,
						 TipoActuacion = c.TipoActuacion,
						 Fecha = c.Fecha,
						 FechaVencimiento = c.FechaVencimiento,
						 FechaAlerta = c.FechaAlerta,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 Usuario = c.Usuario,
						 Estado = c.Estado,
						 FechaUltimaModificacion = c.FechaUltimaModificacion,
						 Fundamento = c.Fundamento,
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
						 Protocolizado = c.Protocolizado,
						 FechaProtocolizado = c.FechaProtocolizado,
						 UsuarioProtocolizado = c.UsuarioProtocolizado,
						 Protocolo = c.Protocolo,
						 OficinaCargo = c.OficinaCargo,
						 Bloqueado = c.Bloqueado,
						 UsuarioBloquea = c.UsuarioBloquea,
						 FechaBloqueo = c.FechaBloqueo,
						 ModalidadDiasFechaPlazo = c.ModalidadDiasFechaPlazo,
						 MostrarJuezAudiencia = c.MostrarJuezAudiencia,
						 SubAmbitoProtocolizado = c.SubAmbitoProtocolizado,
						 CategoriaProtocolizado = c.CategoriaProtocolizado,
						 ModeloAplicado = c.ModeloAplicado,
						 VisadoJefatura = c.VisadoJefatura,
						 UsuarioJefatura = c.UsuarioJefatura,
						 FechaJefatura = c.FechaJefatura,
						 VisadoSubJefatura = c.VisadoSubJefatura,
						 UsuarioSubJefatura = c.UsuarioSubJefatura,
						 FechaSubJefatura = c.FechaSubJefatura,
						 VisadoJefeDeptoJudiciales = c.VisadoJefeDeptoJudiciales,
						 UsuarioJefeDeptoJudiciales = c.UsuarioJefeDeptoJudiciales,
						 FechaJefeDeptoJudiciales = c.FechaJefeDeptoJudiciales,
						 VisadoJefeUnidRegional = c.VisadoJefeUnidRegional,
						 UsuarioJefeUnidRegional = c.UsuarioJefeUnidRegional,
						 FechaJefeUnidRegional = c.FechaJefeUnidRegional,
						 FundamentoMax = c.FundamentoMax,
					};
			return (DbQuery<ActuacionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
