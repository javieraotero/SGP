
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class PersonasTrazabilidadAD
	{
		private BDEntities db = new BDEntities();

		public PersonasTrazabilidad ObtenerPorId(int Id)
		{
			return db.PersonasTrazabilidad.Single(c => c.Id == Id);
		}

		//public PersonasTrazabilidad ObtenerPorDni(long dni)
		//{
		//	return db.PersonasTrazabilidad.Where(x => x.DNI == dni).OrderByDescending(x => x.Id).FirstOrDefault();
		//}

		public DbQuery<PersonasTrazabilidad> ObtenerTodo()
		{
			return (DbQuery<PersonasTrazabilidad>)db.PersonasTrazabilidad;
		}

		public TurnosWebParametros ObtenerParametro(int organismo)
		{
			var res = (from x in db.TurnosWebParametros
					  where x.Organismo == organismo
					  select x).FirstOrDefault();
			return res;
		}

		public DbQuery<PersonasTrazabilidadView> ObtenerParaGrilla(int? organismo, DateTime? desde, DateTime? hasta, long? dni)
		{
			var ahora = DateTime.Now.Date;
			var x = from c in db.PersonasTrazabilidad
					join p in db.Personas on c.Persona equals p.Id
					where (organismo.HasValue && c.Organismo == organismo.Value) 
					&& ((desde.HasValue && c.Fecha >= desde.Value) || (!desde.HasValue))
					&& ((hasta.HasValue && c.Fecha <= hasta.Value) || (!hasta.HasValue))
					&& ((dni.HasValue && p.NroDocumento == dni) || !dni.HasValue)
					select new PersonasTrazabilidadView
					{
						Id = c.Id,
						Nombre = p.Apellidos.Trim() +", "+p.Nombres,
						Telefono = p.Telefono,
						DNI = p.NroDocumento,
						Fecha = c.Fecha,
						Hora = c.Hora
					};
			return (DbQuery<PersonasTrazabilidadView>)x;
		}

		public DbQuery<PersonasTrazabilidadDetalleView> ObtenerParaGrillaDetalle(int? organismo, DateTime? desde, DateTime? hasta, long? dni, bool excluir_empleados, bool todos_organismos)
		{
			var ahora = DateTime.Now.Date;
			var x = from c in db.PersonasTrazabilidad
					join p in db.Personas on c.Persona equals p.Id
					join o in db.OrganismosRef on c.Organismo equals o.Id
					join uc in db.Agentes on p.Id equals uc.Persona into gm
					from ucg in gm.DefaultIfEmpty()
					where ((organismo.HasValue && c.Organismo == organismo.Value) || (!organismo.HasValue))
					&& ((desde.HasValue && c.Fecha >= desde.Value) || (!desde.HasValue))
					&& ((hasta.HasValue && c.Fecha <= hasta.Value) || (!hasta.HasValue))
					&& ((dni.HasValue && p.NroDocumento == dni) || !dni.HasValue)
					&& ((excluir_empleados && ucg == null) || (!excluir_empleados))
					select new PersonasTrazabilidadDetalleView
					{
						Id = c.Id,
						Nombre = p.Apellidos.Trim() + ", " + p.Nombres,
						Telefono = p.Telefono,
						DNI = p.NroDocumento,
						Fecha = c.Fecha,
						Hora = c.Hora,
						Organismo = o.Descripcion
					};
			return (DbQuery<PersonasTrazabilidadDetalleView>)x;
		}

		public void Guardar(PersonasTrazabilidad Objeto)
		{
			try
			{
				db.PersonasTrazabilidad.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasTrazabilidad Objeto)
		{
			try
			{
				db.PersonasTrazabilidad.Attach(Objeto);
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
				PersonasTrazabilidad Objeto = this.ObtenerPorId(IdObjeto);
				db.PersonasTrazabilidad.Remove(Objeto);
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
		
		/*********************************************
		* Seccion Particular
		* *******************************************/
	}
}
