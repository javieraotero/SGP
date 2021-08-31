
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
	public partial class ColaDeMovimientoscesidaAD
	{
		private BDEntities db = new BDEntities();

		public ColaDeMovimientoscesida ObtenerPorId(int Id)
		{
			return db.ColaDeMovimientoscesida.Single(c => c.Id == Id);
		}

		public DbQuery<ColaDeMovimientoscesida> ObtenerTodo()
		{
			return (DbQuery<ColaDeMovimientoscesida>)db.ColaDeMovimientoscesida;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ColaDeMovimientoscesida
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ColaDeMovimientoscesidaView> ObtenerParaGrilla()
		{
			var x = from c in db.ColaDeMovimientoscesida
                    join a in db.Agentes on c.Agente equals a.Id
                    join p in db.Personas on a.Persona equals p.Id
                    join m in db.CesidaMovimientos on c.Movimiento equals m.Id
                    join n in db.Nombramientos on c.Nombramiento equals n.Id
					select new ColaDeMovimientoscesidaView
                    {
                        Id = c.Id,
                        Agente = p.Apellidos.Trim() + ", " + p.Nombres.Trim(),
                        Movimiento = m.CodigoCesida,
                        Fecha = c.Fecha,
                        FechaEnvio = c.FechaEnvio.HasValue ? SqlFunctions.DateName("day", c.FechaEnvio) + "/" + SqlFunctions.DateName("month", c.FechaEnvio) + "/" + SqlFunctions.DateName("year", c.FechaEnvio) : "-",
                        Respuesta = c.MensajeRespuesta,
                        Intentos = c.Intentos,
                        FechaDesde = c.FechaDesde.HasValue ? SqlFunctions.DateName("day", c.FechaDesde) + "/" + SqlFunctions.DateName("month", c.FechaDesde) + "/" + SqlFunctions.DateName("year", c.FechaDesde) : "-",
                        FechaHasta = c.FechaHasta.HasValue ? SqlFunctions.DateName("day", c.FechaHasta) + "/" + SqlFunctions.DateName("month", c.FechaHasta) + "/" + SqlFunctions.DateName("year", c.FechaHasta) : "-",
                        Cargo = n.Cargos.Descripcion,
                        Organismo = n.Organismos.Descripcion
                    };

			return (DbQuery<ColaDeMovimientoscesidaView>)x;
		}

		public void Guardar(ColaDeMovimientoscesida Objeto)
		{
			try
			{
				db.ColaDeMovimientoscesida.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ColaDeMovimientoscesida Objeto)
		{
			try
			{
				db.ColaDeMovimientoscesida.Attach(Objeto);
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
				ColaDeMovimientoscesida Objeto = this.ObtenerPorId(IdObjeto);
				db.ColaDeMovimientoscesida.Remove(Objeto);
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

		//public DbQuery<ColaDeMovimientoscesidaViewT> JsonT(string term)
		//{
		//	var x = from c in db.ColaDeMovimientoscesida
		//			select new ColaDeMovimientoscesidaViewT
		//			{
		//				 Id = c.Id,
		//				 Nombramiento = c.Nombramiento,
		//				 Agente = c.Agente,
		//				 Movimiento = c.Movimiento,
		//				 Fecha = c.Fecha,
		//				 FechaEnvio = c.FechaEnvio,
		//				 IdRespuesta = c.IdRespuesta,
		//				 MensajeRespuesta = c.MensajeRespuesta,
		//				 Intentos = c.Intentos,
		//				 Licencia = c.Licencia,
		//				 IdRegistro = c.IdRegistro,
		//				 FechaDesde = c.FechaDesde,
		//				 FechaHasta = c.FechaHasta,
		//				 Cargo = c.Cargo,
		//				 Organismo = c.Organismo,
		//			};
		//	return (DbQuery<ColaDeMovimientoscesidaViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
