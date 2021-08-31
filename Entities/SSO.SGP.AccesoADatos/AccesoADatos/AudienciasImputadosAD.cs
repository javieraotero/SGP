
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
	public partial class AudienciasImputadosAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasImputados ObtenerPorId(int Id)
		{
			return db.AudienciasImputados.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasImputados> ObtenerTodo()
		{
			return (DbQuery<AudienciasImputados>)db.AudienciasImputados;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasImputados
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasImputadosView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasImputados
					select new AudienciasImputadosView
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Parte = c.Parte,
						 CesacionPrisionPreventiva = c.CesacionPrisionPreventiva,
						 CesacionPrisionPreventivaRestricciones = c.CesacionPrisionPreventivaRestricciones,
						 PedidoCaptura = c.PedidoCaptura,
						 RestriccionAcercamiento = c.RestriccionAcercamiento,
						 PrisionPreventivaCantidadDias = c.PrisionPreventivaCantidadDias,
						 FechaLiberacion = c.FechaLiberacion,
						 LugarDetencion = c.LugarDetencion,
						 GeneraOficioLibertad = c.GeneraOficioLibertad,
						 OficioLibertadEmitido = c.OficioLibertadEmitido,
						 OficioLibertadCancelado = c.OficioLibertadCancelado,
						 Formalizacion = c.Formalizacion,
						 SuspensionProcesoPrueba = c.SuspensionProcesoPrueba,
						 Conciliacion = c.Conciliacion,
						 ControlDetencion = c.ControlDetencion,
						 MedidasCoercion = c.MedidasCoercion,
						 ReexamenMedidaCoercion = c.ReexamenMedidaCoercion,
						 PrisionPreventiva = c.PrisionPreventiva,
						 SobreSeimiento = c.SobreSeimiento,
						 PruebaJurisdiccional = c.PruebaJurisdiccional,
						 JuicioAbreviado = c.JuicioAbreviado,
						 SinResolucion = c.SinResolucion,
						 SobreseimientoSimple = c.SobreseimientoSimple,
						 SobreseimientoCriterioOportunidad = c.SobreseimientoCriterioOportunidad,
						 JuicioAbreviadoAdmite = c.JuicioAbreviadoAdmite,
						 JuicioAbreviadoRechaza = c.JuicioAbreviadoRechaza,
						 JuicioAbreviadoCondena = c.JuicioAbreviadoCondena,
						 JuicioAbreviadoAbsolucion = c.JuicioAbreviadoAbsolucion,
						 JuicioAbreviadoResponsPenal = c.JuicioAbreviadoResponsPenal,
						 JuicioCondena = c.JuicioCondena,
						 JuicioAbsolucion = c.JuicioAbsolucion,
						 JuicioResponsPenal = c.JuicioResponsPenal,
						 JuicioDirectoAdmite = c.JuicioDirectoAdmite,
						 JuicioDirectoRechaza = c.JuicioDirectoRechaza,
					};
			return (DbQuery<AudienciasImputadosView>)x;
		}

		public void Guardar(AudienciasImputados Objeto)
		{
			try
			{
				db.AudienciasImputados.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasImputados Objeto)
		{
			try
			{
				db.AudienciasImputados.Attach(Objeto);
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
				AudienciasImputados Objeto = this.ObtenerPorId(IdObjeto);
				db.AudienciasImputados.Remove(Objeto);
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

		public DbQuery<AudienciasImputadosViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasImputados
					select new AudienciasImputadosViewT
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Parte = c.Parte,
						 CesacionPrisionPreventiva = c.CesacionPrisionPreventiva,
						 CesacionPrisionPreventivaRestricciones = c.CesacionPrisionPreventivaRestricciones,
						 PedidoCaptura = c.PedidoCaptura,
						 RestriccionAcercamiento = c.RestriccionAcercamiento,
						 PrisionPreventivaCantidadDias = c.PrisionPreventivaCantidadDias,
						 FechaLiberacion = c.FechaLiberacion,
						 LugarDetencion = c.LugarDetencion,
						 GeneraOficioLibertad = c.GeneraOficioLibertad,
						 OficioLibertadEmitido = c.OficioLibertadEmitido,
						 OficioLibertadCancelado = c.OficioLibertadCancelado,
						 Formalizacion = c.Formalizacion,
						 SuspensionProcesoPrueba = c.SuspensionProcesoPrueba,
						 Conciliacion = c.Conciliacion,
						 ControlDetencion = c.ControlDetencion,
						 MedidasCoercion = c.MedidasCoercion,
						 ReexamenMedidaCoercion = c.ReexamenMedidaCoercion,
						 PrisionPreventiva = c.PrisionPreventiva,
						 SobreSeimiento = c.SobreSeimiento,
						 PruebaJurisdiccional = c.PruebaJurisdiccional,
						 JuicioAbreviado = c.JuicioAbreviado,
						 SinResolucion = c.SinResolucion,
						 SobreseimientoSimple = c.SobreseimientoSimple,
						 SobreseimientoCriterioOportunidad = c.SobreseimientoCriterioOportunidad,
						 JuicioAbreviadoAdmite = c.JuicioAbreviadoAdmite,
						 JuicioAbreviadoRechaza = c.JuicioAbreviadoRechaza,
						 JuicioAbreviadoCondena = c.JuicioAbreviadoCondena,
						 JuicioAbreviadoAbsolucion = c.JuicioAbreviadoAbsolucion,
						 JuicioAbreviadoResponsPenal = c.JuicioAbreviadoResponsPenal,
						 JuicioCondena = c.JuicioCondena,
						 JuicioAbsolucion = c.JuicioAbsolucion,
						 JuicioResponsPenal = c.JuicioResponsPenal,
						 JuicioDirectoAdmite = c.JuicioDirectoAdmite,
						 JuicioDirectoRechaza = c.JuicioDirectoRechaza,
					};
			return (DbQuery<AudienciasImputadosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
