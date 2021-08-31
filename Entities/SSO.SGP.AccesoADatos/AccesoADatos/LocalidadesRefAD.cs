
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class LocalidadesRefAD
	{
		private BDEntities db = new BDEntities();

		public LocalidadesRef ObtenerPorId(int Id)
		{
			return db.LocalidadesRef.Single(c => c.Id == Id);
		}

		public List<LocalidadesRef> ObtenerPorIdProvincia(int Id)
		{
			return db.LocalidadesRef.Where(c => c.Provincia == Id).ToList();
		}

		public DbQuery<LocalidadesRef> ObtenerTodo()
		{
			return (DbQuery<LocalidadesRef>)db.LocalidadesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LocalidadesRef
                      where x.Descripcion.Contains(filtro)
				select new SelectOptionsView {text = x.Descripcion + " - " + x.Provincias.Descripcion, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LocalidadesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.LocalidadesRef
					select new LocalidadesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 CodigoPostal = c.CodigoPostal,
						 Provincia = c.Provincia,
						 Abreviatura = c.Abreviatura,
						 TieneCallesCargadas = c.TieneCallesCargadas,
					};
			return (DbQuery<LocalidadesRefView>)x;
		}

		public void Guardar(LocalidadesRef Objeto)
		{
			try
			{
				db.LocalidadesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LocalidadesRef Objeto)
		{
			try
			{
				db.LocalidadesRef.Attach(Objeto);
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
				LocalidadesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.LocalidadesRef.Remove(Objeto);
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

		public DbQuery<LocalidadesRefViewT> JsonT(string term)
		{
			var x = from c in db.LocalidadesRef
					select new LocalidadesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 CodigoPostal = c.CodigoPostal,
						 Provincia = c.Provincia,
						 Abreviatura = c.Abreviatura,
						 TieneCallesCargadas = c.TieneCallesCargadas,
					};
			return (DbQuery<LocalidadesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
