
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
	public partial class GrupoFamiliarAD
	{
		private BDEntities db = new BDEntities();

		public GrupoFamiliar ObtenerPorId(int Id)
		{
			return db.GrupoFamiliar.Single(c => c.Id == Id);
		}

		public DbQuery<GrupoFamiliar> ObtenerTodo()
		{
			return (DbQuery<GrupoFamiliar>)db.GrupoFamiliar.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.GrupoFamiliar
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<GrupoFamiliarView> ObtenerParaGrilla()
		{
			var x = from c in db.GrupoFamiliar
					where c.Activo == true
					select new GrupoFamiliarView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 ApellidosYNombre = c.ApellidosYNombre,
						 FechaDeNacimiento = c.FechaDeNacimiento,
						 Documento = c.Documento,
						 TipoMiembro = c.TipoMiembro,
						 Activo = c.Activo,
						 FechaBaja = c.FechaBaja,
						 FechaAlta = c.FechaAlta,
					};
			return (DbQuery<GrupoFamiliarView>)x;
		}

		public void Guardar(GrupoFamiliar Objeto)
		{
			try
			{
				db.GrupoFamiliar.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GrupoFamiliar Objeto)
		{
			try
			{
				db.GrupoFamiliar.Attach(Objeto);
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
				GrupoFamiliar Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
				Objeto.FechaBaja = DateTime.Now;
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

		public DbQuery<GrupoFamiliarViewT> JsonT(int agente)
		{
			var x = from c in db.GrupoFamiliar
					where c.Activo == true && c.Agente == agente
					select new GrupoFamiliarViewT
					{
						 Id = c.Id,
						 ApellidosYNombre = c.ApellidosYNombre,
						 FechaDeNacimiento = c.FechaDeNacimiento,
						 Documento = c.Documento,
						 TipoMiembro = c.TipoMiembros.Descripcion,
					};
			return (DbQuery<GrupoFamiliarViewT>)x;
		}
	}
}
