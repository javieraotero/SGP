
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
	public partial class CausasAD
	{
		private BDEntities db = new BDEntities();

		public Causas ObtenerPorId(int Id)
		{
			return db.Causas.Single(c => c.Id == Id);
		}

		public DbQuery<Causas> ObtenerTodo()
		{
			return (DbQuery<Causas>)db.Causas;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Causas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CausasView> ObtenerParaGrilla()
		{
			var x = from c in db.Causas
					select new CausasView
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Fecha = c.Fecha,
						 FechaPresentacion = c.FechaPresentacion,
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
						 UsuarioRecepciono = c.UsuarioRecepciono,
						 EspecialidadCoMediador = c.EspecialidadCoMediador,
						 Demanda = c.Demanda,
						 ModeloAplicado = c.ModeloAplicado,
						 ReciboTRMed = c.ReciboTRMed,
						 MontoTRMed = c.MontoTRMed,
						 Observaciones = c.Observaciones,
						 OrganismoRecepciono = c.OrganismoRecepciono,
						 QuiebraAbierta = c.QuiebraAbierta,
						 QuiebraConcluida = c.QuiebraConcluida,
					};
			return (DbQuery<CausasView>)x;
		}

		public void Guardar(Causas Objeto)
		{
			try
			{
				db.Causas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Causas Objeto)
		{
			try
			{
				db.Causas.Attach(Objeto);
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
				Causas Objeto = this.ObtenerPorId(IdObjeto);
				db.Causas.Remove(Objeto);
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

		public DbQuery<CausasViewT> JsonT(string term)
		{
			var x = from c in db.Causas
					select new CausasViewT
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Fecha = c.Fecha,
						 FechaPresentacion = c.FechaPresentacion,
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
						 UsuarioRecepciono = c.UsuarioRecepciono,
						 EspecialidadCoMediador = c.EspecialidadCoMediador,
						 Demanda = c.Demanda,
						 ModeloAplicado = c.ModeloAplicado,
						 ReciboTRMed = c.ReciboTRMed,
						 MontoTRMed = c.MontoTRMed,
						 Observaciones = c.Observaciones,
						 OrganismoRecepciono = c.OrganismoRecepciono,
						 QuiebraAbierta = c.QuiebraAbierta,
						 QuiebraConcluida = c.QuiebraConcluida,
					};
			return (DbQuery<CausasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
