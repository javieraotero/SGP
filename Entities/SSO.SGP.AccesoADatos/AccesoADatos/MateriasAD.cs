
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
	public partial class MateriasAD
	{
		private BDEntities db = new BDEntities();

		public Materias ObtenerPorId(int Id)
		{
			return db.Materias.Single(c => c.Id == Id);
		}

		public DbQuery<Materias> ObtenerTodo()
		{
			return (DbQuery<Materias>)db.Materias.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Materias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MateriasView> ObtenerParaGrilla()
		{
			var x = from c in db.Materias
					where c.Activo == true
					select new MateriasView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Mnemo = c.Mnemo,
						 Tipo = c.Tipo,
						 EjerceAtraccion = c.EjerceAtraccion,
						 Civil = c.Civil,
						 Laboral = c.Laboral,
						 Publica = c.Publica,
						 Familia = c.Familia,
						 Exorto = c.Exorto,
						 Vigente = c.Vigente,
						 Mediacion = c.Mediacion,
						 Concursos_Quiebras = c.Concursos_Quiebras,
						 Activo = c.Activo,
						 CategoriaUnica = c.CategoriaUnica,
					};
			return (DbQuery<MateriasView>)x;
		}

		public void Guardar(Materias Objeto)
		{
			try
			{
				db.Materias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Materias Objeto)
		{
			try
			{
				db.Materias.Attach(Objeto);
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
				Materias Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<MateriasViewT> JsonT(string term)
		{
			var x = from c in db.Materias
					where c.Activo == true
					select new MateriasViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Mnemo = c.Mnemo,
						 Tipo = c.Tipo,
						 EjerceAtraccion = c.EjerceAtraccion,
						 Civil = c.Civil,
						 Laboral = c.Laboral,
						 Publica = c.Publica,
						 Familia = c.Familia,
						 Exorto = c.Exorto,
						 Vigente = c.Vigente,
						 Mediacion = c.Mediacion,
						 Concursos_Quiebras = c.Concursos_Quiebras,
						 Activo = c.Activo,
						 CategoriaUnica = c.CategoriaUnica,
					};
			return (DbQuery<MateriasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
