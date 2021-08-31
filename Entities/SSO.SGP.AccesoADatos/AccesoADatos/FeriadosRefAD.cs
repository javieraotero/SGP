
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
	public partial class FeriadosRefAD
	{
		private BDEntities db = new BDEntities();

		public FeriadosRef ObtenerPorId(int Id)
		{
			return db.FeriadosRef.Single(c => c.Id == Id);
		}

		public DbQuery<FeriadosRef> ObtenerTodo()
		{
			return (DbQuery<FeriadosRef>)db.FeriadosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.FeriadosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FeriadosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.FeriadosRef
					select new FeriadosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Dia = c.Dia,
						 Mes = c.Mes,
						 Anio = c.Anio,
						 Movil = c.Movil,
						 Nacional = c.Nacional,
					};
			return (DbQuery<FeriadosRefView>)x;
		}

		public void Guardar(FeriadosRef Objeto)
		{
			try
			{
				db.FeriadosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FeriadosRef Objeto)
		{
			try
			{
				db.FeriadosRef.Attach(Objeto);
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
				FeriadosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.FeriadosRef.Remove(Objeto);
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

		public DbQuery<FeriadosRefViewT> JsonT(string term)
		{
			var x = from c in db.FeriadosRef
					select new FeriadosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Dia = c.Dia,
						 Mes = c.Mes,
						 Anio = c.Anio,
						 Movil = c.Movil,
						 Nacional = c.Nacional,
					};
			return (DbQuery<FeriadosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
