
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
	public partial class ExpedientesElementoAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesElemento ObtenerPorId(int Id)
		{
			return db.ExpedientesElemento.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesElemento> ObtenerTodo()
		{
			return (DbQuery<ExpedientesElemento>)db.ExpedientesElemento.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesElemento
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesElementoView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesElemento
					where c.Activo == true
					select new ExpedientesElementoView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Codigo = c.Codigo,
						 Numerador = c.Numerador,
						 Rol = c.Rol,
						 Descripcion = c.Descripcion,
						 Confirmado = c.Confirmado,
						 Activo = c.Activo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
						 FechaBaja = c.FechaBaja,
						 UsuarioBaja = c.UsuarioBaja,
						 NumeroPaquete = c.NumeroPaquete,
					};
			return (DbQuery<ExpedientesElementoView>)x;
		}

		public void Guardar(ExpedientesElemento Objeto)
		{
			try
			{
				db.ExpedientesElemento.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesElemento Objeto)
		{
			try
			{
				db.ExpedientesElemento.Attach(Objeto);
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
				ExpedientesElemento Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<ExpedientesElementoViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesElemento
					where c.Activo == true
					select new ExpedientesElementoViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Codigo = c.Codigo,
						 Numerador = c.Numerador,
						 Rol = c.Rol,
						 Descripcion = c.Descripcion,
						 Confirmado = c.Confirmado,
						 Activo = c.Activo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
						 FechaBaja = c.FechaBaja,
						 UsuarioBaja = c.UsuarioBaja,
						 NumeroPaquete = c.NumeroPaquete,
					};
			return (DbQuery<ExpedientesElementoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
