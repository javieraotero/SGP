
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
	public partial class MotivosCancelacionCivilRefAD
	{
		private BDEntities db = new BDEntities();

		public MotivosCancelacionCivilRef ObtenerPorId(int Id)
		{
			return db.MotivosCancelacionCivilRef.Single(c => c.Id == Id);
		}

		public DbQuery<MotivosCancelacionCivilRef> ObtenerTodo()
		{
			return (DbQuery<MotivosCancelacionCivilRef>)db.MotivosCancelacionCivilRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MotivosCancelacionCivilRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MotivosCancelacionCivilRefView> ObtenerParaGrilla()
		{
			var x = from c in db.MotivosCancelacionCivilRef
					select new MotivosCancelacionCivilRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosCancelacionCivilRefView>)x;
		}

		public void Guardar(MotivosCancelacionCivilRef Objeto)
		{
			try
			{
				db.MotivosCancelacionCivilRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosCancelacionCivilRef Objeto)
		{
			try
			{
				db.MotivosCancelacionCivilRef.Attach(Objeto);
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
				MotivosCancelacionCivilRef Objeto = this.ObtenerPorId(IdObjeto);
				db.MotivosCancelacionCivilRef.Remove(Objeto);
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

		public DbQuery<MotivosCancelacionCivilRefViewT> JsonT(string term)
		{
			var x = from c in db.MotivosCancelacionCivilRef
					select new MotivosCancelacionCivilRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosCancelacionCivilRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
