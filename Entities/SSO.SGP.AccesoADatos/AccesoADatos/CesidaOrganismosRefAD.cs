
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
	public partial class CesidaOrganismosRefAD
	{
		private BDEntities db = new BDEntities();

		public CesidaOrganismosRef ObtenerPorId(int Id)
		{
			return db.CesidaOrganismosRef.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaOrganismosRef> ObtenerTodo()
		{
			return (DbQuery<CesidaOrganismosRef>)db.CesidaOrganismosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaOrganismosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaOrganismosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaOrganismosRef
					select new CesidaOrganismosRefView
					{
						 Id = c.Id,
						 CodCaracter = c.CodCaracter,
						 Caracter = c.Caracter,
						 CodJurisdiccion = c.CodJurisdiccion,
						 Jurisdiccion = c.Jurisdiccion,
						 CodUnidad = c.CodUnidad,
						 Unidad = c.Unidad,
					};
			return (DbQuery<CesidaOrganismosRefView>)x;
		}

		public void Guardar(CesidaOrganismosRef Objeto)
		{
			try
			{
				db.CesidaOrganismosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaOrganismosRef Objeto)
		{
			try
			{
				db.CesidaOrganismosRef.Attach(Objeto);
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
				CesidaOrganismosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaOrganismosRef.Remove(Objeto);
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

		public DbQuery<CesidaOrganismosRefViewT> JsonT(string term)
		{
			var x = from c in db.CesidaOrganismosRef
					select new CesidaOrganismosRefViewT
					{
						 Id = c.Id,
						 CodCaracter = c.CodCaracter,
						 Caracter = c.Caracter,
						 CodJurisdiccion = c.CodJurisdiccion,
						 Jurisdiccion = c.Jurisdiccion,
						 CodUnidad = c.CodUnidad,
						 Unidad = c.Unidad,
					};
			return (DbQuery<CesidaOrganismosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
