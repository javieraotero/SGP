
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
	public partial class ModalidadesPoliciaRefAD
	{
		private BDEntities db = new BDEntities();

		public ModalidadesPoliciaRef ObtenerPorId(int Id)
		{
			return db.ModalidadesPoliciaRef.Single(c => c.Id == Id);
		}

		public DbQuery<ModalidadesPoliciaRef> ObtenerTodo()
		{
			return (DbQuery<ModalidadesPoliciaRef>)db.ModalidadesPoliciaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ModalidadesPoliciaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ModalidadesPoliciaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.ModalidadesPoliciaRef
					select new ModalidadesPoliciaRefView
					{
						 Id = c.Id,
						 IdModalidad = c.IdModalidad,
						 Modalidad = c.Modalidad,
					};
			return (DbQuery<ModalidadesPoliciaRefView>)x;
		}

		public void Guardar(ModalidadesPoliciaRef Objeto)
		{
			try
			{
				db.ModalidadesPoliciaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ModalidadesPoliciaRef Objeto)
		{
			try
			{
				db.ModalidadesPoliciaRef.Attach(Objeto);
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
				ModalidadesPoliciaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.ModalidadesPoliciaRef.Remove(Objeto);
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

		public DbQuery<ModalidadesPoliciaRefViewT> JsonT(string term)
		{
			var x = from c in db.ModalidadesPoliciaRef
					select new ModalidadesPoliciaRefViewT
					{
						 Id = c.Id,
						 IdModalidad = c.IdModalidad,
						 Modalidad = c.Modalidad,
					};
			return (DbQuery<ModalidadesPoliciaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
