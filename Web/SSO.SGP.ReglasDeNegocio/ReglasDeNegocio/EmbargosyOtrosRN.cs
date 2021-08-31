
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
	public partial class EmbargosyOtrosRN
	{
		EmbargosyOtrosAD oEmbargosyOtrosAD = new EmbargosyOtrosAD();

		public EmbargosyOtros ObtenerPorId(int Id)
		{
			return this.oEmbargosyOtrosAD.ObtenerPorId(Id);
		}

		public DbQuery<EmbargosyOtros> ObtenerTodo()
		{
			return this.oEmbargosyOtrosAD.ObtenerTodo();
		}


		public DbQuery<EmbargosyOtrosView> ObtenerParaGrilla()
		{
			return this.oEmbargosyOtrosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEmbargosyOtrosAD.ObtenerOptions(filtro);
		}

		public void Guardar(EmbargosyOtros Objeto)
		{
			try
			{
			this.oEmbargosyOtrosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EmbargosyOtros Objeto)
		{
			try
			{
			this.oEmbargosyOtrosAD.Actualizar(Objeto);
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
			this.oEmbargosyOtrosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEmbargosyOtrosAD.Dispose();
		}
		public DbQuery<EmbargosyOtrosViewT> JsonT(string term)
		{
			return (DbQuery<EmbargosyOtrosViewT>)this.oEmbargosyOtrosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
