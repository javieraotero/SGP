
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
	public partial class ECO_ProveedoresSociosAD
	{
		private BDEntities db = new BDEntities();

		public ECO_ProveedoresSocios ObtenerPorId(int Id)
		{
			return db.ECO_ProveedoresSocios.Single(c => c.Id == Id);
		}

		public ECO_ProveedoresSocios ObtenerPorIdProveedor(int Id)
		{
			return db.ECO_ProveedoresSocios.Single(c => c.Proveedor == Id);
		}

        public List<ECO_ProveedoresSocios> ObtenerSociosPorProveedor(int Id)
        {
            return db.ECO_ProveedoresSocios.Where(c => c.Proveedor == Id).ToList();
        }


        public ECO_ProveedoresSocios ObtenerPorIdCuitProveedor(string Id)
		{
			return db.ECO_ProveedoresSocios.Single(c => c.Proveedor_.CUIT == Id);
		}

		public DbQuery<ECO_ProveedoresSocios> ObtenerTodo()
		{
			return (DbQuery<ECO_ProveedoresSocios>)db.ECO_ProveedoresSocios;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ECO_ProveedoresSocios
					  where x.Socio.Contains(filtro)
				select new SelectOptionsView {text = x.Socio, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<ECO_ProveedoresSocios> GetAutocomplete(string filtro)
        {
            var res = from x in db.ECO_ProveedoresSocios
					  where x.Socio.Contains(filtro)
                      select x;
            return (DbQuery<ECO_ProveedoresSocios>)res;
        }


		public void Guardar(ECO_ProveedoresSocios Objeto)
		{
			try
			{
				db.ECO_ProveedoresSocios.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ECO_ProveedoresSocios Objeto)
		{
			try
			{
				db.ECO_ProveedoresSocios.Attach(Objeto);
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
				ECO_ProveedoresSocios Objeto = this.ObtenerPorId(IdObjeto);
				db.ECO_ProveedoresSocios.Remove(Objeto);
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
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
