
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
	public partial class PresentacionesCausaAD
	{
		private BDEntities db = new BDEntities();

		public PresentacionesCausa ObtenerPorId(int Id)
		{
			return db.PresentacionesCausa.Single(c => c.Id == Id);
		}

		public DbQuery<PresentacionesCausa> ObtenerTodo()
		{
			return (DbQuery<PresentacionesCausa>)db.PresentacionesCausa;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PresentacionesCausa
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PresentacionesCausaView> ObtenerParaGrilla()
		{
			var x = from c in db.PresentacionesCausa
					select new PresentacionesCausaView
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Fecha = c.Fecha,
						 Caratula = c.Caratula,
						 Autos = c.Autos,
						 JuzgadoSorteo = c.JuzgadoSorteo,
						 Juzgado = c.Juzgado,
						 Categoria = c.Categoria,
						 Fuero = c.Fuero,
						 Materia = c.Materia,
						 Reserva = c.Reserva,
						 CausaMadre = c.CausaMadre,
						 AnioCausaMadre = c.AnioCausaMadre,
						 Monto = c.Monto,
						 ReciboCajaForense = c.ReciboCajaForense,
						 MontoCajaForense = c.MontoCajaForense,
						 ReciboRentas = c.ReciboRentas,
						 MontoRentas = c.MontoRentas,
						 Origen = c.Origen,
						 Ciudad = c.Ciudad,
						 Provincia = c.Provincia,
						 ASolicitudDe = c.ASolicitudDe,
						 Confirmada = c.Confirmada,
						 Estado = c.Estado,
						 Circunscripcion = c.Circunscripcion,
						 Mediador = c.Mediador,
						 CoMediador = c.CoMediador,
						 GenCuentaBancaria = c.GenCuentaBancaria,
						 Recepcionada = c.Recepcionada,
						 Usuario = c.Usuario,
						 Mediacion = c.Mediacion,
						 RequiereCoMediador = c.RequiereCoMediador,
						 EspecialidadCoMediador = c.EspecialidadCoMediador,
						 Causa = c.Causa,
						 Demanda = c.Demanda,
						 ModeloAplicado = c.ModeloAplicado,
						 ReciboTRMed = c.ReciboTRMed,
						 MontoTRMed = c.MontoTRMed,
						 Observaciones = c.Observaciones,
						 OrganismoRecepciona = c.OrganismoRecepciona,
					};
			return (DbQuery<PresentacionesCausaView>)x;
		}

		public void Guardar(PresentacionesCausa Objeto)
		{
			try
			{
				db.PresentacionesCausa.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresentacionesCausa Objeto)
		{
			try
			{
				db.PresentacionesCausa.Attach(Objeto);
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
				PresentacionesCausa Objeto = this.ObtenerPorId(IdObjeto);
				db.PresentacionesCausa.Remove(Objeto);
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

		public DbQuery<PresentacionesCausaViewT> JsonT(string term)
		{
			var x = from c in db.PresentacionesCausa
					select new PresentacionesCausaViewT
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Fecha = c.Fecha,
						 Caratula = c.Caratula,
						 Autos = c.Autos,
						 JuzgadoSorteo = c.JuzgadoSorteo,
						 Juzgado = c.Juzgado,
						 Categoria = c.Categoria,
						 Fuero = c.Fuero,
						 Materia = c.Materia,
						 Reserva = c.Reserva,
						 CausaMadre = c.CausaMadre,
						 AnioCausaMadre = c.AnioCausaMadre,
						 Monto = c.Monto,
						 ReciboCajaForense = c.ReciboCajaForense,
						 MontoCajaForense = c.MontoCajaForense,
						 ReciboRentas = c.ReciboRentas,
						 MontoRentas = c.MontoRentas,
						 Origen = c.Origen,
						 Ciudad = c.Ciudad,
						 Provincia = c.Provincia,
						 ASolicitudDe = c.ASolicitudDe,
						 Confirmada = c.Confirmada,
						 Estado = c.Estado,
						 Circunscripcion = c.Circunscripcion,
						 Mediador = c.Mediador,
						 CoMediador = c.CoMediador,
						 GenCuentaBancaria = c.GenCuentaBancaria,
						 Recepcionada = c.Recepcionada,
						 Usuario = c.Usuario,
						 Mediacion = c.Mediacion,
						 RequiereCoMediador = c.RequiereCoMediador,
						 EspecialidadCoMediador = c.EspecialidadCoMediador,
						 Causa = c.Causa,
						 Demanda = c.Demanda,
						 ModeloAplicado = c.ModeloAplicado,
						 ReciboTRMed = c.ReciboTRMed,
						 MontoTRMed = c.MontoTRMed,
						 Observaciones = c.Observaciones,
						 OrganismoRecepciona = c.OrganismoRecepciona,
					};
			return (DbQuery<PresentacionesCausaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
