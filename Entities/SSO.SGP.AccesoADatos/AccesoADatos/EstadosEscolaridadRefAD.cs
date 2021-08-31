
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
	public partial class EstadosEscolaridadRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosEscolaridadRef ObtenerPorId(int Id)
		{
			return db.EstadosEscolaridadRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosEscolaridadRef> ObtenerTodo()
		{
			return (DbQuery<EstadosEscolaridadRef>)db.EstadosEscolaridadRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosEscolaridadRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosEscolaridadRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosEscolaridadRef
					select new EstadosEscolaridadRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosEscolaridadRefView>)x;
		}

		public void Guardar(EstadosEscolaridadRef Objeto)
		{
			try
			{
				db.EstadosEscolaridadRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosEscolaridadRef Objeto)
		{
			try
			{
				db.EstadosEscolaridadRef.Attach(Objeto);
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
				EstadosEscolaridadRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosEscolaridadRef.Remove(Objeto);
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

		public DbQuery<EstadosEscolaridadRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosEscolaridadRef
					select new EstadosEscolaridadRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosEscolaridadRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
