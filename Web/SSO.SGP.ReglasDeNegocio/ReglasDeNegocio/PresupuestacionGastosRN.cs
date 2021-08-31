
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
	public partial class PresupuestacionGastosRN
	{
		PresupuestacionGastosAD oPresupuestacionGastosAD = new PresupuestacionGastosAD();

		public PresupuestacionGastos ObtenerPorId(int Id)
		{
			return this.oPresupuestacionGastosAD.ObtenerPorId(Id);
		}

		public DbQuery<PresupuestacionGastos> ObtenerTodo()
		{
			return this.oPresupuestacionGastosAD.ObtenerTodo();
		}


		public DbQuery<PresupuestacionGastosView> ObtenerParaGrilla()
		{
			return this.oPresupuestacionGastosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPresupuestacionGastosAD.ObtenerOptions(filtro);
		}

		public void Guardar(PresupuestacionGastos Objeto)
		{
			try
			{
			this.oPresupuestacionGastosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresupuestacionGastos Objeto)
		{
			try
			{
			this.oPresupuestacionGastosAD.Actualizar(Objeto);
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
			this.oPresupuestacionGastosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPresupuestacionGastosAD.Dispose();
		}
		public DbQuery<PresupuestacionGastosViewT> JsonT(string term)
		{
			return (DbQuery<PresupuestacionGastosViewT>)this.oPresupuestacionGastosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
