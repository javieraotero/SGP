
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
	public partial class OrganismosSecuenciaModelosRefAD
	{
		private BDEntities db = new BDEntities();

		public OrganismosSecuenciaModelosRef ObtenerPorId(int Id)
		{
			return db.OrganismosSecuenciaModelosRef.Single(c => c.Id == Id);
		}

		public DbQuery<OrganismosSecuenciaModelosRef> ObtenerTodo()
		{
			return (DbQuery<OrganismosSecuenciaModelosRef>)db.OrganismosSecuenciaModelosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.OrganismosSecuenciaModelosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<OrganismosSecuenciaModelosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.OrganismosSecuenciaModelosRef
					select new OrganismosSecuenciaModelosRefView
					{
						 Id = c.Id,
						 OrganismoOrigen = c.OrganismoOrigen,
						 OrganismoDestino = c.OrganismoDestino,
					};
			return (DbQuery<OrganismosSecuenciaModelosRefView>)x;
		}

		public void Guardar(OrganismosSecuenciaModelosRef Objeto)
		{
			try
			{
				db.OrganismosSecuenciaModelosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OrganismosSecuenciaModelosRef Objeto)
		{
			try
			{
				db.OrganismosSecuenciaModelosRef.Attach(Objeto);
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
				OrganismosSecuenciaModelosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.OrganismosSecuenciaModelosRef.Remove(Objeto);
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

		public DbQuery<OrganismosSecuenciaModelosRefViewT> JsonT(string term)
		{
			var x = from c in db.OrganismosSecuenciaModelosRef
					select new OrganismosSecuenciaModelosRefViewT
					{
						 Id = c.Id,
						 OrganismoOrigen = c.OrganismoOrigen,
						 OrganismoDestino = c.OrganismoDestino,
					};
			return (DbQuery<OrganismosSecuenciaModelosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
