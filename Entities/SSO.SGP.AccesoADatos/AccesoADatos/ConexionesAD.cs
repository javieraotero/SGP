
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
	public partial class ConexionesAD
	{
		private BDEntities db = new BDEntities();

		public Conexiones ObtenerPorId(int Id)
		{
			return db.Conexiones.Single(c => c.Id == Id);
		}

		public DbQuery<Conexiones> ObtenerTodo()
		{
			return (DbQuery<Conexiones>)db.Conexiones.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Conexiones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ConexionesView> ObtenerParaGrilla()
		{
			var x = from c in db.Conexiones
					where c.Activo == true
					select new ConexionesView
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
			return (DbQuery<ConexionesView>)x;
		}

		public void Guardar(Conexiones Objeto)
		{
			try
			{
				db.Conexiones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Conexiones Objeto)
		{
			try
			{
				db.Conexiones.Attach(Objeto);
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
				Conexiones Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<ConexionesViewT> JsonT(string term)
		{
			var x = from c in db.Conexiones
					where c.Activo == true
					select new ConexionesViewT
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
			return (DbQuery<ConexionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
