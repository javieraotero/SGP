
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
	public partial class MotivosCancelacionRefAD
	{
		private BDEntities db = new BDEntities();

		public MotivosCancelacionRef ObtenerPorId(int Id)
		{
			return db.MotivosCancelacionRef.Single(c => c.Id == Id);
		}

		public DbQuery<MotivosCancelacionRef> ObtenerTodo()
		{
			return (DbQuery<MotivosCancelacionRef>)db.MotivosCancelacionRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MotivosCancelacionRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MotivosCancelacionRefView> ObtenerParaGrilla()
		{
			var x = from c in db.MotivosCancelacionRef
					select new MotivosCancelacionRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosCancelacionRefView>)x;
		}

		public void Guardar(MotivosCancelacionRef Objeto)
		{
			try
			{
				db.MotivosCancelacionRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosCancelacionRef Objeto)
		{
			try
			{
				db.MotivosCancelacionRef.Attach(Objeto);
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
				MotivosCancelacionRef Objeto = this.ObtenerPorId(IdObjeto);
				db.MotivosCancelacionRef.Remove(Objeto);
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

		public DbQuery<MotivosCancelacionRefViewT> JsonT(string term)
		{
			var x = from c in db.MotivosCancelacionRef
					select new MotivosCancelacionRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosCancelacionRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
