
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
	public partial class ElementosSecuestradosMovimientoAD
	{
		private BDEntities db = new BDEntities();

		public ElementosSecuestradosMovimiento ObtenerPorId(int Id)
		{
			return db.ElementosSecuestradosMovimiento.Single(c => c.Id == Id);
		}

		public DbQuery<ElementosSecuestradosMovimiento> ObtenerTodo()
		{
			return (DbQuery<ElementosSecuestradosMovimiento>)db.ElementosSecuestradosMovimiento;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ElementosSecuestradosMovimiento
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ElementosSecuestradosMovimientoView> ObtenerParaGrilla()
		{
			var x = from c in db.ElementosSecuestradosMovimiento
					select new ElementosSecuestradosMovimientoView
					{
						 Id = c.Id,
						 Elemento = c.Elemento,
						 Persona = c.Persona,
						 Motivo = c.Motivo,
						 Fecha = c.Fecha,
						 Estado = c.Estado,
						 Observaciones = c.Observaciones,
						 FechaAlta = c.FechaAlta,
						 Usuario = c.Usuario,
					};
			return (DbQuery<ElementosSecuestradosMovimientoView>)x;
		}

		public void Guardar(ElementosSecuestradosMovimiento Objeto)
		{
			try
			{
				db.ElementosSecuestradosMovimiento.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ElementosSecuestradosMovimiento Objeto)
		{
			try
			{
				db.ElementosSecuestradosMovimiento.Attach(Objeto);
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
				ElementosSecuestradosMovimiento Objeto = this.ObtenerPorId(IdObjeto);
				db.ElementosSecuestradosMovimiento.Remove(Objeto);
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

		public DbQuery<ElementosSecuestradosMovimientoViewT> JsonT(string term)
		{
			var x = from c in db.ElementosSecuestradosMovimiento
					select new ElementosSecuestradosMovimientoViewT
					{
						 Id = c.Id,
						 Elemento = c.Elemento,
						 Persona = c.Persona,
						 Motivo = c.Motivo,
						 Fecha = c.Fecha,
						 Estado = c.Estado,
						 Observaciones = c.Observaciones,
						 FechaAlta = c.FechaAlta,
						 Usuario = c.Usuario,
					};
			return (DbQuery<ElementosSecuestradosMovimientoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
