
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
	public partial class MesesRefAD
	{
		private BDEntities db = new BDEntities();

		public MesesRef ObtenerPorId(int Id)
		{
			return db.MesesRef.Single(c => c.Id == Id);
		}

		public DbQuery<MesesRef> ObtenerTodo()
		{
			return (DbQuery<MesesRef>)db.MesesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MesesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MesesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.MesesRef
					select new MesesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Abreviatura = c.Abreviatura,
					};
			return (DbQuery<MesesRefView>)x;
		}

		public void Guardar(MesesRef Objeto)
		{
			try
			{
				db.MesesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MesesRef Objeto)
		{
			try
			{
				db.MesesRef.Attach(Objeto);
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
				MesesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.MesesRef.Remove(Objeto);
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

		public DbQuery<MesesRefViewT> JsonT(string term)
		{
			var x = from c in db.MesesRef
					select new MesesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Abreviatura = c.Abreviatura,
					};
			return (DbQuery<MesesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
