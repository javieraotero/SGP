
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
	public partial class OrganismosSecuenciaRefAD
	{
		private BDEntities db = new BDEntities();

		public OrganismosSecuenciaRef ObtenerPorId(int Id)
		{
			return db.OrganismosSecuenciaRef.Single(c => c.Id == Id);
		}

		public DbQuery<OrganismosSecuenciaRef> ObtenerTodo()
		{
			return (DbQuery<OrganismosSecuenciaRef>)db.OrganismosSecuenciaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.OrganismosSecuenciaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<OrganismosSecuenciaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.OrganismosSecuenciaRef
					select new OrganismosSecuenciaRefView
					{
						 Id = c.Id,
						 OrganismoOrigen = c.OrganismoOrigen,
						 OrganismoDestino = c.OrganismoDestino,
					};
			return (DbQuery<OrganismosSecuenciaRefView>)x;
		}

		public void Guardar(OrganismosSecuenciaRef Objeto)
		{
			try
			{
				db.OrganismosSecuenciaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OrganismosSecuenciaRef Objeto)
		{
			try
			{
				db.OrganismosSecuenciaRef.Attach(Objeto);
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
				OrganismosSecuenciaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.OrganismosSecuenciaRef.Remove(Objeto);
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

		public DbQuery<OrganismosSecuenciaRefViewT> JsonT(string term)
		{
			var x = from c in db.OrganismosSecuenciaRef
					select new OrganismosSecuenciaRefViewT
					{
						 Id = c.Id,
						 OrganismoOrigen = c.OrganismoOrigen,
						 OrganismoDestino = c.OrganismoDestino,
					};
			return (DbQuery<OrganismosSecuenciaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
