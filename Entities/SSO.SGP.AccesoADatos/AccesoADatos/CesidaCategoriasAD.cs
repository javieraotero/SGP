
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
	public partial class CesidaCategoriasAD
	{
		private BDEntities db = new BDEntities();

		public CesidaCategorias ObtenerPorId(int Id)
		{
			return db.CesidaCategorias.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaCategorias> ObtenerTodo()
		{
			return (DbQuery<CesidaCategorias>)db.CesidaCategorias;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaCategorias
                      where x.DESCRIPCION.Contains(filtro) && x.NRO_CONVENIO == 6
				select new SelectOptionsView {text = x.DESCRIPCION, value = x.NRO_CATEGORIA.Value };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaCategoriasView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaCategorias
					select new CesidaCategoriasView
					{
						 Id = c.Id,
						 NRO_CONVENIO = c.NRO_CONVENIO,
						 NRO_RAMA = c.NRO_RAMA,
						 NRO_CATEGORIA = c.NRO_CATEGORIA,
						 DESCRIPCION = c.DESCRIPCION,
					};
			return (DbQuery<CesidaCategoriasView>)x;
		}

		public void Guardar(CesidaCategorias Objeto)
		{
			try
			{
				db.CesidaCategorias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaCategorias Objeto)
		{
			try
			{
				db.CesidaCategorias.Attach(Objeto);
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
				CesidaCategorias Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaCategorias.Remove(Objeto);
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

		public DbQuery<CesidaCategoriasViewT> JsonT(string term)
		{
			var x = from c in db.CesidaCategorias
					select new CesidaCategoriasViewT
					{
						 Id = c.Id,
						 NRO_CONVENIO = c.NRO_CONVENIO,
						 NRO_RAMA = c.NRO_RAMA,
						 NRO_CATEGORIA = c.NRO_CATEGORIA,
						 DESCRIPCION = c.DESCRIPCION,
					};
			return (DbQuery<CesidaCategoriasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
