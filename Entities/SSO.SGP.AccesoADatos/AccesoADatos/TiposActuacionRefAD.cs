
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
	public partial class TiposActuacionRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposActuacionRef ObtenerPorId(int Id)
		{
			return db.TiposActuacionRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposActuacionRef> ObtenerTodo()
		{
			return (DbQuery<TiposActuacionRef>)db.TiposActuacionRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposActuacionRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposActuacionRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposActuacionRef
					select new TiposActuacionRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EstadoExpediente = c.EstadoExpediente,
						 PersonaDelito = c.PersonaDelito,
						 Activa = c.Activa,
						 Grupo = c.Grupo,
						 CambiaEtapa = c.CambiaEtapa,
						 PaseOJ = c.PaseOJ,
						 GenerarAudiencia = c.GenerarAudiencia,
						 TipoAudiencia = c.TipoAudiencia,
						 Plazo = c.Plazo,
						 RequiereNotificacion = c.RequiereNotificacion,
						 MostrarDefensor = c.MostrarDefensor,
						 MostrarFiscal = c.MostrarFiscal,
						 MostrarJuez = c.MostrarJuez,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 CantidadFirmantes = c.CantidadFirmantes,
						 MostrarTIP = c.MostrarTIP,
						 MostrarSTJ = c.MostrarSTJ,
						 Protocolo = c.Protocolo,
						 ModalidadDiasFechaPlazo = c.ModalidadDiasFechaPlazo,
						 Protocoliza = c.Protocoliza,
						 ProtocoloCategoria = c.ProtocoloCategoria,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaElimina = c.FechaElimina,
						 ProtocoloCategoriaSubAmbito = c.ProtocoloCategoriaSubAmbito,
						 PasaAMPF = c.PasaAMPF,
					};
			return (DbQuery<TiposActuacionRefView>)x;
		}

		public void Guardar(TiposActuacionRef Objeto)
		{
			try
			{
				db.TiposActuacionRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposActuacionRef Objeto)
		{
			try
			{
				db.TiposActuacionRef.Attach(Objeto);
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
				TiposActuacionRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposActuacionRef.Remove(Objeto);
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

		public DbQuery<TiposActuacionRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposActuacionRef
					select new TiposActuacionRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EstadoExpediente = c.EstadoExpediente,
						 PersonaDelito = c.PersonaDelito,
						 Activa = c.Activa,
						 Grupo = c.Grupo,
						 CambiaEtapa = c.CambiaEtapa,
						 PaseOJ = c.PaseOJ,
						 GenerarAudiencia = c.GenerarAudiencia,
						 TipoAudiencia = c.TipoAudiencia,
						 Plazo = c.Plazo,
						 RequiereNotificacion = c.RequiereNotificacion,
						 MostrarDefensor = c.MostrarDefensor,
						 MostrarFiscal = c.MostrarFiscal,
						 MostrarJuez = c.MostrarJuez,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 CantidadFirmantes = c.CantidadFirmantes,
						 MostrarTIP = c.MostrarTIP,
						 MostrarSTJ = c.MostrarSTJ,
						 Protocolo = c.Protocolo,
						 ModalidadDiasFechaPlazo = c.ModalidadDiasFechaPlazo,
						 Protocoliza = c.Protocoliza,
						 ProtocoloCategoria = c.ProtocoloCategoria,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaElimina = c.FechaElimina,
						 ProtocoloCategoriaSubAmbito = c.ProtocoloCategoriaSubAmbito,
						 PasaAMPF = c.PasaAMPF,
					};
			return (DbQuery<TiposActuacionRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
