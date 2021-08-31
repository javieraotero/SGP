
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
	public partial class ProtocolosCategoriasAD
	{
		private BDEntities db = new BDEntities();

		public ProtocolosCategorias ObtenerPorId(int Id)
		{
			return db.ProtocolosCategorias.Single(c => c.Id == Id);
		}

		public DbQuery<ProtocolosCategorias> ObtenerTodo()
		{
			return (DbQuery<ProtocolosCategorias>)db.ProtocolosCategorias.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ProtocolosCategorias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ProtocolosCategoriasView> ObtenerParaGrilla()
		{
			var x = from c in db.ProtocolosCategorias
					where c.Activo == true
					select new ProtocolosCategoriasView
					{
						 Id = c.Id,
						 Protocolo = c.Protocolo,
						 Ambito = c.Ambito,
						 Descripcion = c.Descripcion,
						 Activo = c.Activo,
					};
			return (DbQuery<ProtocolosCategoriasView>)x;
		}

		public void Guardar(ProtocolosCategorias Objeto)
		{
			try
			{
				db.ProtocolosCategorias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ProtocolosCategorias Objeto)
		{
			try
			{
				db.ProtocolosCategorias.Attach(Objeto);
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
				ProtocolosCategorias Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<ProtocolosCategoriasViewT> JsonT(string term)
		{
			var x = from c in db.ProtocolosCategorias
					where c.Activo == true
					select new ProtocolosCategoriasViewT
					{
						 Id = c.Id,
						 Protocolo = c.Protocolo,
						 Ambito = c.Ambito,
						 Descripcion = c.Descripcion,
						 Activo = c.Activo,
					};
			return (DbQuery<ProtocolosCategoriasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
