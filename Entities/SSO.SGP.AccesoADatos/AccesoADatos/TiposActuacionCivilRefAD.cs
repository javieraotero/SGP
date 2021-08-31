
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
	public partial class TiposActuacionCivilRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposActuacionCivilRef ObtenerPorId(int Id)
		{
			return db.TiposActuacionCivilRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposActuacionCivilRef> ObtenerTodo()
		{
			return (DbQuery<TiposActuacionCivilRef>)db.TiposActuacionCivilRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposActuacionCivilRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposActuacionCivilRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposActuacionCivilRef
					select new TiposActuacionCivilRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EstadoCausa = c.EstadoCausa,
						 Activa = c.Activa,
						 Grupo = c.Grupo,
						 CambiaEtapa = c.CambiaEtapa,
						 Plazo = c.Plazo,
						 RequiereNotificacion = c.RequiereNotificacion,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 CantidadFirmantes = c.CantidadFirmantes,
						 ModalidadDiasFechaPlazo = c.ModalidadDiasFechaPlazo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaElimina = c.FechaElimina,
					};
			return (DbQuery<TiposActuacionCivilRefView>)x;
		}

		public void Guardar(TiposActuacionCivilRef Objeto)
		{
			try
			{
				db.TiposActuacionCivilRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposActuacionCivilRef Objeto)
		{
			try
			{
				db.TiposActuacionCivilRef.Attach(Objeto);
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
				TiposActuacionCivilRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposActuacionCivilRef.Remove(Objeto);
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

		public DbQuery<TiposActuacionCivilRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposActuacionCivilRef
					select new TiposActuacionCivilRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EstadoCausa = c.EstadoCausa,
						 Activa = c.Activa,
						 Grupo = c.Grupo,
						 CambiaEtapa = c.CambiaEtapa,
						 Plazo = c.Plazo,
						 RequiereNotificacion = c.RequiereNotificacion,
						 RequiereCargo = c.RequiereCargo,
						 SubAmbitoCargo = c.SubAmbitoCargo,
						 CantidadFirmantes = c.CantidadFirmantes,
						 ModalidadDiasFechaPlazo = c.ModalidadDiasFechaPlazo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 UsuarioElimina = c.UsuarioElimina,
						 FechaElimina = c.FechaElimina,
					};
			return (DbQuery<TiposActuacionCivilRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
