
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
	public partial class MotivosDemoraRefAD
	{
		private BDEntities db = new BDEntities();

		public MotivosDemoraRef ObtenerPorId(int Id)
		{
			return db.MotivosDemoraRef.Single(c => c.Id == Id);
		}

		public DbQuery<MotivosDemoraRef> ObtenerTodo()
		{
			return (DbQuery<MotivosDemoraRef>)db.MotivosDemoraRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MotivosDemoraRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MotivosDemoraRefView> ObtenerParaGrilla()
		{
			var x = from c in db.MotivosDemoraRef
					select new MotivosDemoraRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosDemoraRefView>)x;
		}

		public void Guardar(MotivosDemoraRef Objeto)
		{
			try
			{
				db.MotivosDemoraRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MotivosDemoraRef Objeto)
		{
			try
			{
				db.MotivosDemoraRef.Attach(Objeto);
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
				MotivosDemoraRef Objeto = this.ObtenerPorId(IdObjeto);
				db.MotivosDemoraRef.Remove(Objeto);
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

		public DbQuery<MotivosDemoraRefViewT> JsonT(string term)
		{
			var x = from c in db.MotivosDemoraRef
					select new MotivosDemoraRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<MotivosDemoraRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
