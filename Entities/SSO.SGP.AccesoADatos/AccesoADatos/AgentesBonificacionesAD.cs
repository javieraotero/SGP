
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
	public partial class AgentesBonificacionesAD
	{
		private BDEntities db = new BDEntities();

		public AgentesBonificaciones ObtenerPorId(int Id)
		{
			return db.AgentesBonificaciones.Single(c => c.Id == Id);
		}

		public DbQuery<AgentesBonificaciones> ObtenerTodo()
		{
			return (DbQuery<AgentesBonificaciones>)db.AgentesBonificaciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AgentesBonificaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AgentesBonificacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.AgentesBonificaciones
                    join ca in db.CargosRef on c.Cargo equals ca.Id
                    join o in db.OrganismosRef on c.Organismo equals o.Id
					select new AgentesBonificacionesView
					{
						 Id = c.Id,
						 Agente = c.Agentes.Personas.Apellidos + ", " + c.Agentes.Personas.Nombres,
						 Aplica = c.Aplica,
						 Porcentaje = c.Porcentaje,
						 Cargo = ca.Descripcion,
						 Organismo = o.Descripcion,
						 Mes = c.Mes,
						 Anio = c.Anio,
						 DiasDeLicencia = c.DiasDeLicencia,
                         Autorizados = 30 - c.DiasDeLicencia
                   };
			return (DbQuery<AgentesBonificacionesView>)x;
		}

		public void Guardar(AgentesBonificaciones Objeto)
		{
			try
			{
				db.AgentesBonificaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AgentesBonificaciones Objeto)
		{
			try
			{
				db.AgentesBonificaciones.Attach(Objeto);
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
				AgentesBonificaciones Objeto = this.ObtenerPorId(IdObjeto);
				db.AgentesBonificaciones.Remove(Objeto);
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

		public DbQuery<AgentesBonificacionesViewT> JsonT(string term)
		{
			var x = from c in db.AgentesBonificaciones
					select new AgentesBonificacionesViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 FechaAlta = c.FechaAlta,
						 Porcentaje = c.Porcentaje,
						 Aprobado = c.Aprobado,
						 Cargo = c.Cargo,
						 Organismo = c.Organismo,
						 Mes = c.Mes,
						 Anio = c.Anio,
						 DiasDeLicencia = c.DiasDeLicencia,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
					};
			return (DbQuery<AgentesBonificacionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
