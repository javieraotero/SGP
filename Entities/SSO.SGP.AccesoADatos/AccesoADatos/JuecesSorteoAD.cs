
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
	public partial class JuecesSorteoAD
	{
		private BDEntities db = new BDEntities();

		public JuecesSorteo ObtenerPorId(int Id)
		{
			return db.JuecesSorteo.Single(c => c.Id == Id);
		}

		public DbQuery<JuecesSorteo> ObtenerTodo()
		{
			return (DbQuery<JuecesSorteo>)db.JuecesSorteo.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.JuecesSorteo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<JuecesSorteoView> ObtenerParaGrilla()
		{
			var x = from c in db.JuecesSorteo
					where c.Activo == true
					select new JuecesSorteoView
					{
						 Id = c.Id,
						 JuezSorteado = c.JuezSorteado,
						 Delito = c.Delito,
						 UsuarioSorteo = c.UsuarioSorteo,
						 Fecha = c.Fecha,
						 Expediente = c.Expediente,
						 Observaciones = c.Observaciones,
						 Activo = c.Activo,
					};
			return (DbQuery<JuecesSorteoView>)x;
		}

		public void Guardar(JuecesSorteo Objeto)
		{
			try
			{
				db.JuecesSorteo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(JuecesSorteo Objeto)
		{
			try
			{
				db.JuecesSorteo.Attach(Objeto);
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
				JuecesSorteo Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<JuecesSorteoViewT> JsonT(string term)
		{
			var x = from c in db.JuecesSorteo
					where c.Activo == true
					select new JuecesSorteoViewT
					{
						 Id = c.Id,
						 JuezSorteado = c.JuezSorteado,
						 Delito = c.Delito,
						 UsuarioSorteo = c.UsuarioSorteo,
						 Fecha = c.Fecha,
						 Expediente = c.Expediente,
						 Observaciones = c.Observaciones,
						 Activo = c.Activo,
					};
			return (DbQuery<JuecesSorteoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
