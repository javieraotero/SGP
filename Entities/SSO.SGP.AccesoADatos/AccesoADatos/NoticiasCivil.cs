
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
	public partial class NoticiasCivilAD
	{
		private BDEntities db = new BDEntities();

		public NoticiasCivil ObtenerPorId(int Id)
		{
			return db.NoticiasCivil.Single(c => c.Id == Id);
		}

		public DbQuery<NoticiasCivil> ObtenerTodo()
		{
			return (DbQuery<NoticiasCivil>)db.NoticiasCivil.Where(c => c.Activo == true);
		}

        public DbQuery<NoticiasCivil> ObtenerUltimas()
        {
            return (DbQuery<NoticiasCivil>)db.NoticiasCivil.Where(c => c.Activo == true && (c.FechaAlta-DateTime.Now).Days < 15);
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.NoticiasCivil
                      select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<NoticiasView> ObtenerParaGrilla()
		{
			var x = from c in db.NoticiasCivil
                    where c.Activo == true
					select new NoticiasView
					{
						 Id = c.Id,
						 FechaAlta = c.FechaAlta,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 Activo = c.Activo,
						 UsuarioAlta = c.UsuarioAlta,
						 Ambito = c.Ambito,
					};
			return (DbQuery<NoticiasView>)x;
		}

		public void Guardar(NoticiasCivil Objeto)
		{
			try
			{
				db.NoticiasCivil.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(NoticiasCivil Objeto)
		{
			try
			{
				db.NoticiasCivil.Attach(Objeto);
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
                NoticiasCivil Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<NoticiasViewT> JsonT(string term)
		{
			var x = from c in db.NoticiasCivil
                    where c.Activo == true
					select new NoticiasViewT
					{
						 Id = c.Id,
						 FechaAlta = c.FechaAlta,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 Activo = c.Activo,
						 UsuarioAlta = c.UsuarioAlta,
						 Ambito = c.Ambito,
					};
			return (DbQuery<NoticiasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
