
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
	public partial class AmbitosAD
	{
		private BDEntities db = new BDEntities();

		public Ambitos ObtenerPorId(int Id)
		{
			return db.Ambitos.Single(c => c.Id == Id);
		}
     
        public DbQuery<Ambitos> ObtenerTodo()
		{
			return (DbQuery<Ambitos>)db.Ambitos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Ambitos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AmbitosView> ObtenerParaGrilla()
		{
			var x = from c in db.Ambitos
					select new AmbitosView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 AmbitoPrincipal = c.AmbitoPrincipal,
						 EditaDetenidos = c.EditaDetenidos,
						 RecibeCargo = c.RecibeCargo,
						 CircunscripcionUnica = c.CircunscripcionUnica,
						 CambioCircunscripcion = c.CambioCircunscripcion,
						 Protocoliza = c.Protocoliza,
						 CategorizaProtocolo = c.CategorizaProtocolo,
						 Fuero = c.Fuero,
					};
			return (DbQuery<AmbitosView>)x;
		}

		public void Guardar(Ambitos Objeto)
		{
			try
			{
				db.Ambitos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Ambitos Objeto)
		{
			try
			{
				db.Ambitos.Attach(Objeto);
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
				Ambitos Objeto = this.ObtenerPorId(IdObjeto);
				db.Ambitos.Remove(Objeto);
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

		public DbQuery<AmbitosViewT> JsonT(string term)
		{
			var x = from c in db.Ambitos
					select new AmbitosViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 AmbitoPrincipal = c.AmbitoPrincipal,
						 EditaDetenidos = c.EditaDetenidos,
						 RecibeCargo = c.RecibeCargo,
						 CircunscripcionUnica = c.CircunscripcionUnica,
						 CambioCircunscripcion = c.CambioCircunscripcion,
						 Protocoliza = c.Protocoliza,
						 CategorizaProtocolo = c.CategorizaProtocolo,
						 Fuero = c.Fuero,
					};
			return (DbQuery<AmbitosViewT>)x;
		}

		/*********************************************
		* Seccion Particular
		* *******************************************/
        public DbQuery<Ambitos> ObtenerDelFuero(int fuero)
        {
            return (DbQuery<Ambitos>)db.Ambitos.Where(a=>a.Fuero == fuero);
        }

	}
}
