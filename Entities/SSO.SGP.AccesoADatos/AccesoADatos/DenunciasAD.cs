
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
	public partial class DenunciasAD
	{
		private BDEntities db = new BDEntities();

		public Denuncias ObtenerPorId(int Id)
		{
			return db.Denuncias.Single(c => c.Id == Id);
		}

		public DbQuery<Denuncias> ObtenerTodo()
		{
			return (DbQuery<Denuncias>)db.Denuncias.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Denuncias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<DenunciasView> ObtenerParaGrilla()
		{
			var x = from c in db.Denuncias
					where c.Activo == true
					select new DenunciasView
					{
						 Id = c.Id,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 Tipo = c.Tipo,
						 Comisaria = c.Comisaria,
						 GeneradaEnPreventivo = c.GeneradaEnPreventivo,
						 Preventivo = c.Preventivo,
						 Activo = c.Activo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModifica = c.FechaModifica,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaElimina = c.FechaElimina,
						 UsuarioElimina = c.UsuarioElimina,
					};
			return (DbQuery<DenunciasView>)x;
		}

		public void Guardar(Denuncias Objeto)
		{
			try
			{
				db.Denuncias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Denuncias Objeto)
		{
			try
			{
				db.Denuncias.Attach(Objeto);
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
				Denuncias Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<DenunciasViewT> JsonT(string term)
		{
			var x = from c in db.Denuncias
					where c.Activo == true
					select new DenunciasViewT
					{
						 Id = c.Id,
						 Titulo = c.Titulo,
						 Descripcion = c.Descripcion,
						 Tipo = c.Tipo,
						 Comisaria = c.Comisaria,
						 GeneradaEnPreventivo = c.GeneradaEnPreventivo,
						 Preventivo = c.Preventivo,
						 Activo = c.Activo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModifica = c.FechaModifica,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaElimina = c.FechaElimina,
						 UsuarioElimina = c.UsuarioElimina,
					};
			return (DbQuery<DenunciasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
