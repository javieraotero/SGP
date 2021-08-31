
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
	public partial class ElementosSecuestradosMovimientoRN
	{
		ElementosSecuestradosMovimientoAD oElementosSecuestradosMovimientoAD = new ElementosSecuestradosMovimientoAD();

		public ElementosSecuestradosMovimiento ObtenerPorId(int Id)
		{
			return this.oElementosSecuestradosMovimientoAD.ObtenerPorId(Id);
		}

		public DbQuery<ElementosSecuestradosMovimiento> ObtenerTodo()
		{
			return this.oElementosSecuestradosMovimientoAD.ObtenerTodo();
		}


		public DbQuery<ElementosSecuestradosMovimientoView> ObtenerParaGrilla()
		{
			return this.oElementosSecuestradosMovimientoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oElementosSecuestradosMovimientoAD.ObtenerOptions(filtro);
		}

		public void Guardar(ElementosSecuestradosMovimiento Objeto)
		{
			try
			{
			this.oElementosSecuestradosMovimientoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ElementosSecuestradosMovimiento Objeto)
		{
			try
			{
			this.oElementosSecuestradosMovimientoAD.Actualizar(Objeto);
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
			this.oElementosSecuestradosMovimientoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oElementosSecuestradosMovimientoAD.Dispose();
		}
		public DbQuery<ElementosSecuestradosMovimientoViewT> JsonT(string term)
		{
			return (DbQuery<ElementosSecuestradosMovimientoViewT>)this.oElementosSecuestradosMovimientoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
