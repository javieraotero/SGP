
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
	public partial class ImputacionesContablesDetalleRN
	{
		ImputacionesContablesDetalleAD oImputacionesContablesDetalleAD = new ImputacionesContablesDetalleAD();

		public ImputacionesContablesDetalle ObtenerPorId(int Id)
		{
			return this.oImputacionesContablesDetalleAD.ObtenerPorId(Id);
		}

		public DbQuery<ImputacionesContablesDetalle> ObtenerTodo()
		{
			return this.oImputacionesContablesDetalleAD.ObtenerTodo();
		}


		public DbQuery<ImputacionesContablesDetalleView> ObtenerParaGrilla()
		{
			return this.oImputacionesContablesDetalleAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oImputacionesContablesDetalleAD.ObtenerOptions(filtro);
		}

		public void Guardar(ImputacionesContablesDetalle Objeto)
		{
			try
			{
			this.oImputacionesContablesDetalleAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ImputacionesContablesDetalle Objeto)
		{
			try
			{
			this.oImputacionesContablesDetalleAD.Actualizar(Objeto);
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
			this.oImputacionesContablesDetalleAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oImputacionesContablesDetalleAD.Dispose();
		}
		public DbQuery<ImputacionesContablesDetalleViewT> JsonT(string term)
		{
			return (DbQuery<ImputacionesContablesDetalleViewT>)this.oImputacionesContablesDetalleAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
