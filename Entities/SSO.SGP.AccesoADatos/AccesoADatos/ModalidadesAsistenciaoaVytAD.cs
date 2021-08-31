
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
	public partial class ModalidadesAsistenciaoaVytAD
	{
		private BDEntities db = new BDEntities();

		public ModalidadesAsistenciaoaVyt ObtenerPorId(int Id)
		{
			return db.ModalidadesAsistenciaoaVyt.Single(c => c.Id == Id);
		}

		public DbQuery<ModalidadesAsistenciaoaVyt> ObtenerTodo()
		{
			return (DbQuery<ModalidadesAsistenciaoaVyt>)db.ModalidadesAsistenciaoaVyt;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ModalidadesAsistenciaoaVyt
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ModalidadesAsistenciaoaVytView> ObtenerParaGrilla()
		{
			var x = from c in db.ModalidadesAsistenciaoaVyt
					select new ModalidadesAsistenciaoaVytView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<ModalidadesAsistenciaoaVytView>)x;
		}

		public void Guardar(ModalidadesAsistenciaoaVyt Objeto)
		{
			try
			{
				db.ModalidadesAsistenciaoaVyt.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ModalidadesAsistenciaoaVyt Objeto)
		{
			try
			{
				db.ModalidadesAsistenciaoaVyt.Attach(Objeto);
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
				ModalidadesAsistenciaoaVyt Objeto = this.ObtenerPorId(IdObjeto);
				db.ModalidadesAsistenciaoaVyt.Remove(Objeto);
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

		public DbQuery<ModalidadesAsistenciaoaVytViewT> JsonT(string term)
		{
			var x = from c in db.ModalidadesAsistenciaoaVyt
					select new ModalidadesAsistenciaoaVytViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<ModalidadesAsistenciaoaVytViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
