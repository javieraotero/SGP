
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
	public partial class JuecesSorteoRN
	{
		JuecesSorteoAD oJuecesSorteoAD = new JuecesSorteoAD();

		public JuecesSorteo ObtenerPorId(int Id)
		{
			return this.oJuecesSorteoAD.ObtenerPorId(Id);
		}

		public DbQuery<JuecesSorteo> ObtenerTodo()
		{
			return this.oJuecesSorteoAD.ObtenerTodo();
		}


		public DbQuery<JuecesSorteoView> ObtenerParaGrilla()
		{
			return this.oJuecesSorteoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oJuecesSorteoAD.ObtenerOptions(filtro);
		}

		public void Guardar(JuecesSorteo Objeto)
		{
			try
			{
			this.oJuecesSorteoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(JuecesSorteo Objeto)
		{
			try
			{
			this.oJuecesSorteoAD.Actualizar(Objeto);
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
			this.oJuecesSorteoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oJuecesSorteoAD.Dispose();
		}
		public DbQuery<JuecesSorteoViewT> JsonT(string term)
		{
			return (DbQuery<JuecesSorteoViewT>)this.oJuecesSorteoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
