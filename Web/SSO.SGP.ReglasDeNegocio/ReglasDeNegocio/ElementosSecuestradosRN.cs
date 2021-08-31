
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
	public partial class ElementosSecuestradosRN
	{
		ElementosSecuestradosAD oElementosSecuestradosAD = new ElementosSecuestradosAD();

		public ElementosSecuestrados ObtenerPorId(int Id)
		{
			return this.oElementosSecuestradosAD.ObtenerPorId(Id);
		}

		public DbQuery<ElementosSecuestrados> ObtenerTodo()
		{
			return this.oElementosSecuestradosAD.ObtenerTodo();
		}


		public DbQuery<ElementosSecuestradosView> ObtenerParaGrilla()
		{
			return this.oElementosSecuestradosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oElementosSecuestradosAD.ObtenerOptions(filtro);
		}

		public void Guardar(ElementosSecuestrados Objeto)
		{
			try
			{
			this.oElementosSecuestradosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ElementosSecuestrados Objeto)
		{
			try
			{
			this.oElementosSecuestradosAD.Actualizar(Objeto);
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
			this.oElementosSecuestradosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oElementosSecuestradosAD.Dispose();
		}
		public DbQuery<ElementosSecuestradosViewT> JsonT(string term)
		{
			return (DbQuery<ElementosSecuestradosViewT>)this.oElementosSecuestradosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
