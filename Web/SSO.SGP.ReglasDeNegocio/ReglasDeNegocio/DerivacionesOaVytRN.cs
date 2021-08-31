
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
	public partial class DerivacionesOaVytRN
	{
		DerivacionesOaVytAD oDerivacionesOaVytAD = new DerivacionesOaVytAD();

		public DerivacionesOaVyt ObtenerPorId(int Id)
		{
			return this.oDerivacionesOaVytAD.ObtenerPorId(Id);
		}

		public DbQuery<DerivacionesOaVyt> ObtenerTodo()
		{
			return this.oDerivacionesOaVytAD.ObtenerTodo();
		}


		public DbQuery<DerivacionesOaVytView> ObtenerParaGrilla()
		{
			return this.oDerivacionesOaVytAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oDerivacionesOaVytAD.ObtenerOptions(filtro);
		}

		public void Guardar(DerivacionesOaVyt Objeto)
		{
			try
			{
			this.oDerivacionesOaVytAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DerivacionesOaVyt Objeto)
		{
			try
			{
			this.oDerivacionesOaVytAD.Actualizar(Objeto);
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
			this.oDerivacionesOaVytAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oDerivacionesOaVytAD.Dispose();
		}
		public DbQuery<DerivacionesOaVytViewT> JsonT(string term)
		{
			return (DbQuery<DerivacionesOaVytViewT>)this.oDerivacionesOaVytAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
