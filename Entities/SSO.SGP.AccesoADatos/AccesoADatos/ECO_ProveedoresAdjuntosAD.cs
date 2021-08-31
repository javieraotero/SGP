
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ECO_ProveedoresAdjuntosAD
	{
		private BDEntities db = new BDEntities();

		public ECO_ProveedoresAdjuntos ObtenerPorId(int Id)
		{
			return db.ECO_ProveedoresAdjuntos.Single(c => c.Id == Id);
		}

		public DbQuery<ECO_ProveedoresAdjuntos> ObtenerTodo()
		{
			return (DbQuery<ECO_ProveedoresAdjuntos>)db.ECO_ProveedoresAdjuntos;
		}

        public List<ECO_ProveedoresAdjuntos> ObtenerPorProveedor(int id)
        {
			List<ECO_ProveedoresAdjuntos> listaAdjuntos = new List<ECO_ProveedoresAdjuntos>();

			var adjuntos = (from x in db.ECO_ProveedoresAdjuntos
							where x.Proveedor == id
							select x).Distinct().ToList();

			foreach (ECO_ProveedoresAdjuntos adjunto in adjuntos)
			{

				var obj = (from x in db.ECO_ProveedoresAdjuntos
						   where x.Proveedor == id && x.TipoAdjunto == adjunto.TipoAdjunto
						   orderby x.Rectificacion descending
						   select x).FirstOrDefault();
				if (!listaAdjuntos.Contains(obj))
					listaAdjuntos.Add(obj);
			}

			return listaAdjuntos;
		}

		public List<ECO_ProveedoresAdjuntos> ObtenerHistorialAdjuntos(int id)
		{
			var res = (from x in db.ECO_ProveedoresAdjuntos
					  where x.Proveedor == id
					  orderby x.TipoAdjunto,x.Rectificacion ascending
					  select x).ToList();
			return res;
		}


		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ECO_ProveedoresAdjuntos
					  where x.URL.Contains(filtro)
				select new SelectOptionsView {text = x.URL, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<ECO_ProveedoresAdjuntos> GetAutocomplete(string filtro)
        {
            var res = from x in db.ECO_ProveedoresAdjuntos
					  where x.URL.Contains(filtro)
                      select x;
            return (DbQuery<ECO_ProveedoresAdjuntos>)res;
        }


		public void Guardar(ECO_ProveedoresAdjuntos Objeto)
		{
			try
			{
				db.ECO_ProveedoresAdjuntos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ECO_ProveedoresAdjuntos Objeto)
		{
			try
			{
				db.ECO_ProveedoresAdjuntos.Attach(Objeto);
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
				ECO_ProveedoresAdjuntos Objeto = this.ObtenerPorId(IdObjeto);
				db.ECO_ProveedoresAdjuntos.Remove(Objeto);
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
