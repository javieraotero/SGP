
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ArchivosAdjuntosAD
	{
		private BDEntities db = new BDEntities();

		public ArchivosAdjuntos ObtenerPorId(int Id)
		{
			return db.ArchivosAdjuntos.Single(c => c.Id == Id);
		}

		public DbQuery<ArchivosAdjuntos> ObtenerTodo()
		{
			return (DbQuery<ArchivosAdjuntos>)db.ArchivosAdjuntos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ArchivosAdjuntos
                      select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}


		public void Guardar(ArchivosAdjuntos Objeto)
		{
			try
			{
				db.ArchivosAdjuntos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ArchivosAdjuntos Objeto)
		{
			try
			{
				db.ArchivosAdjuntos.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
                ArchivosAdjuntos Objeto = this.ObtenerPorId(IdObjeto);
				db.ArchivosAdjuntos.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}

		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
