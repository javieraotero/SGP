
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
	public partial class CompraDeSuministrosAD
	{
		private BDEntities db = new BDEntities();

		public CompraDeSuministros ObtenerPorId(int Id)
		{
			return db.CompraDeSuministros.Single(c => c.Id == Id);
		}

		public DbQuery<CompraDeSuministros> ObtenerTodo()
		{
			return (DbQuery<CompraDeSuministros>)db.CompraDeSuministros;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CompraDeSuministros
                      where x.FechaDeBaja == null
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CompraDeSuministrosView> ObtenerParaGrilla()
		{
			var x = from c in db.CompraDeSuministros
                    where c.FechaDeBaja == null
					select new CompraDeSuministrosView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Comprobante = c.Comprobante,
						 FechaDeCarga = c.FechaDeCarga
					};
			return (DbQuery<CompraDeSuministrosView>)x;
		}

		public void Guardar(CompraDeSuministros Objeto)
		{
			try
			{
				db.CompraDeSuministros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CompraDeSuministros Objeto)
		{
			try
			{
				db.CompraDeSuministros.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int usuario)
		{
			try
			{
				CompraDeSuministros Objeto = this.ObtenerPorId(IdObjeto);

                Objeto.FechaDeBaja = DateTime.Now;
                Objeto.UsuarioBaja = usuario;
                db.CompraDeSuministros.Attach(Objeto);
                db.Entry(Objeto).State = EntityState.Modified;

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

		public DbQuery<CompraDeSuministrosViewT> JsonT(string term)
		{
			var x = from c in db.CompraDeSuministros
					select new CompraDeSuministrosViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Comprobante = c.Comprobante,
						 Usuario = c.Usuario,
						 FechaDeCarga = c.FechaDeCarga,
					};
			return (DbQuery<CompraDeSuministrosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/

	}
}
