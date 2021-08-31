
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.ReglasDeNegocio
{
	/// <summary>
	/// Reglas De Negocio Generada por el Generador de codigo.
	/// </summary>
	public partial class ReservaSalasAudienciaRN
	{
		ReservaSalasAudienciaAD oReservaSalasAudienciaAD = new ReservaSalasAudienciaAD();

		public ReservaSalasAudiencia ObtenerPorId(int Id)
		{
			return this.oReservaSalasAudienciaAD.ObtenerPorId(Id);
		}

		public DbQuery<ReservaSalasAudiencia> ObtenerTodo()
		{
			return this.oReservaSalasAudienciaAD.ObtenerTodo();
		}


		public DbQuery<ReservaSalasAudienciaView> ObtenerParaGrilla()
		{
			return this.oReservaSalasAudienciaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oReservaSalasAudienciaAD.ObtenerOptions(filtro);
		}

		public void Guardar(ReservaSalasAudiencia Objeto)
		{
			try
			{
			this.oReservaSalasAudienciaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ReservaSalasAudiencia Objeto)
		{
			try
			{
			this.oReservaSalasAudienciaAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
			this.oReservaSalasAudienciaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oReservaSalasAudienciaAD.Dispose();
		}
		public DbQuery<ReservaSalasAudienciaViewT> JsonT(string term)
		{
			return (DbQuery<ReservaSalasAudienciaViewT>)this.oReservaSalasAudienciaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
