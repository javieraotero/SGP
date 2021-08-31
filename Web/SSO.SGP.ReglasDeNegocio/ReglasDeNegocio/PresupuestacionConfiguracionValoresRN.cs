
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
	public partial class PresupuestacionConfiguracionValoresRN
	{
		PresupuestacionConfiguracionValoresAD oPresupuestacionConfiguracionValoresAD = new PresupuestacionConfiguracionValoresAD();

		public PresupuestacionConfiguracionValores ObtenerPorId(int Id)
		{
			return this.oPresupuestacionConfiguracionValoresAD.ObtenerPorId(Id);
		}

		public DbQuery<PresupuestacionConfiguracionValores> ObtenerTodo()
		{
			return this.oPresupuestacionConfiguracionValoresAD.ObtenerTodo();
		}


		public DbQuery<PresupuestacionConfiguracionValoresView> ObtenerParaGrilla()
		{
			return this.oPresupuestacionConfiguracionValoresAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPresupuestacionConfiguracionValoresAD.ObtenerOptions(filtro);
		}

		public void Guardar(PresupuestacionConfiguracionValores Objeto)
		{
			try
			{
			this.oPresupuestacionConfiguracionValoresAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresupuestacionConfiguracionValores Objeto)
		{
			try
			{
			this.oPresupuestacionConfiguracionValoresAD.Actualizar(Objeto);
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
			this.oPresupuestacionConfiguracionValoresAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPresupuestacionConfiguracionValoresAD.Dispose();
		}
		public DbQuery<PresupuestacionConfiguracionValoresViewT> JsonT(string term)
		{
			return (DbQuery<PresupuestacionConfiguracionValoresViewT>)this.oPresupuestacionConfiguracionValoresAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
