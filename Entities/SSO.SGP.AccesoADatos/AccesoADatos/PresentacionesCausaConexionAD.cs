
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
	public partial class PresentacionesCausaConexionAD
	{
		private BDEntities db = new BDEntities();

		public PresentacionesCausaConexion ObtenerPorId(int Id)
		{
			return db.PresentacionesCausaConexion.Single(c => c.Id == Id);
		}

		public DbQuery<PresentacionesCausaConexion> ObtenerTodo()
		{
			return (DbQuery<PresentacionesCausaConexion>)db.PresentacionesCausaConexion.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PresentacionesCausaConexion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PresentacionesCausaConexionView> ObtenerParaGrilla()
		{
			var x = from c in db.PresentacionesCausaConexion
					where c.Activo == true
					select new PresentacionesCausaConexionView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Persona = c.Persona,
						 DomicilioReal = c.DomicilioReal,
						 Localidad = c.Localidad,
						 DomicilioConstituido = c.DomicilioConstituido,
						 Apoderado = c.Apoderado,
						 Provincia = c.Provincia,
						 LocalidadResidual = c.LocalidadResidual,
						 Orden = c.Orden,
						 Rol = c.Rol,
						 Activo = c.Activo,
					};
			return (DbQuery<PresentacionesCausaConexionView>)x;
		}

		public void Guardar(PresentacionesCausaConexion Objeto)
		{
			try
			{
				db.PresentacionesCausaConexion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresentacionesCausaConexion Objeto)
		{
			try
			{
				db.PresentacionesCausaConexion.Attach(Objeto);
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
				PresentacionesCausaConexion Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<PresentacionesCausaConexionViewT> JsonT(string term)
		{
			var x = from c in db.PresentacionesCausaConexion
					where c.Activo == true
					select new PresentacionesCausaConexionViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Persona = c.Persona,
						 DomicilioReal = c.DomicilioReal,
						 Localidad = c.Localidad,
						 DomicilioConstituido = c.DomicilioConstituido,
						 Apoderado = c.Apoderado,
						 Provincia = c.Provincia,
						 LocalidadResidual = c.LocalidadResidual,
						 Orden = c.Orden,
						 Rol = c.Rol,
						 Activo = c.Activo,
					};
			return (DbQuery<PresentacionesCausaConexionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
