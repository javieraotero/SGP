
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
	public partial class ConceptosDeGastosRefAD
	{
		private BDEntities db = new BDEntities();

		public ConceptosDeGastosRef ObtenerPorId(int Id)
		{
			return db.ConceptosDeGastosRef.Single(c => c.Id == Id);
		}

		public DbQuery<ConceptosDeGastosRef> ObtenerTodo()
		{
			return (DbQuery<ConceptosDeGastosRef>)db.ConceptosDeGastosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ConceptosDeGastosRef
                      where x.Descripcion.Contains(filtro)
				select new SelectOptionsView {text = x.Descripcion, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ConceptosDeGastosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.ConceptosDeGastosRef
                    join p in db.PartidasPresupuestarias on c.Partida equals p.Id
					select new ConceptosDeGastosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Partida = p.NumeroDePartida + " - " + p.Descripcion
					};
			return (DbQuery<ConceptosDeGastosRefView>)x;
		}

		public void Guardar(ConceptosDeGastosRef Objeto)
		{
			try
			{
				db.ConceptosDeGastosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ConceptosDeGastosRef Objeto)
		{
			try
			{
				db.ConceptosDeGastosRef.Attach(Objeto);
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
				ConceptosDeGastosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.ConceptosDeGastosRef.Remove(Objeto);
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

		public DbQuery<ConceptosDeGastosRefViewT> JsonT(string term)
		{
			var x = from c in db.ConceptosDeGastosRef
					select new ConceptosDeGastosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Partida = c.Partida,
					};
			return (DbQuery<ConceptosDeGastosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
