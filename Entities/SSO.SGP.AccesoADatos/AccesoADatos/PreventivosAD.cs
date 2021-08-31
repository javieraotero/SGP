
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
	public partial class PreventivosAD
	{
		private BDEntities db = new BDEntities();

		public Preventivos ObtenerPorId(int Id)
		{
			return db.Preventivos.Single(c => c.Id == Id);
		}

		public DbQuery<Preventivos> ObtenerTodo()
		{
			return (DbQuery<Preventivos>)db.Preventivos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Preventivos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PreventivosView> ObtenerParaGrilla()
		{
			var x = from c in db.Preventivos
					select new PreventivosView
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Comisaria = c.Comisaria,
						 FechaDenuncia = c.FechaDenuncia,
						 FechaHecho = c.FechaHecho,
						 Caratula = c.Caratula,
						 AlertaActiva = c.AlertaActiva,
						 Estado = c.Estado,
						 Reclamo = c.Reclamo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaRecepcion = c.FechaRecepcion,
						 UsuarioRecepcion = c.UsuarioRecepcion,
						 FechaAnulado = c.FechaAnulado,
						 UsuarioAnulado = c.UsuarioAnulado,
						 Confirmado = c.Confirmado,
						 Bloqueado = c.Bloqueado,
						 UsuarioBloquea = c.UsuarioBloquea,
						 FechaBloqueo = c.FechaBloqueo,
						 AutoresIgnorados = c.AutoresIgnorados,
						 Ubicacion = c.Ubicacion,
						 Firmante = c.Firmante,
						 NroPreventivoPolicia = c.NroPreventivoPolicia,
						 NroSumarioPolicia = c.NroSumarioPolicia,
						 Sector = c.Sector,
						 Sitio = c.Sitio,
						 JusticiaProvincial = c.JusticiaProvincial,
						 Modalidad = c.Modalidad,
						 Calle = c.Calle,
						 Altura = c.Altura,
					};
			return (DbQuery<PreventivosView>)x;
		}

		public void Guardar(Preventivos Objeto)
		{
			try
			{
				db.Preventivos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Preventivos Objeto)
		{
			try
			{
				db.Preventivos.Attach(Objeto);
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
				Preventivos Objeto = this.ObtenerPorId(IdObjeto);
				db.Preventivos.Remove(Objeto);
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

		public DbQuery<PreventivosViewT> JsonT(string term)
		{
			var x = from c in db.Preventivos
					select new PreventivosViewT
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Comisaria = c.Comisaria,
						 FechaDenuncia = c.FechaDenuncia,
						 FechaHecho = c.FechaHecho,
						 Caratula = c.Caratula,
						 AlertaActiva = c.AlertaActiva,
						 Estado = c.Estado,
						 Reclamo = c.Reclamo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaRecepcion = c.FechaRecepcion,
						 UsuarioRecepcion = c.UsuarioRecepcion,
						 FechaAnulado = c.FechaAnulado,
						 UsuarioAnulado = c.UsuarioAnulado,
						 Confirmado = c.Confirmado,
						 Bloqueado = c.Bloqueado,
						 UsuarioBloquea = c.UsuarioBloquea,
						 FechaBloqueo = c.FechaBloqueo,
						 AutoresIgnorados = c.AutoresIgnorados,
						 Ubicacion = c.Ubicacion,
						 Firmante = c.Firmante,
						 NroPreventivoPolicia = c.NroPreventivoPolicia,
						 NroSumarioPolicia = c.NroSumarioPolicia,
						 Sector = c.Sector,
						 Sitio = c.Sitio,
						 JusticiaProvincial = c.JusticiaProvincial,
						 Modalidad = c.Modalidad,
						 Calle = c.Calle,
						 Altura = c.Altura,
					};
			return (DbQuery<PreventivosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
