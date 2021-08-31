
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
	public partial class PresupuestacionCapitalesRN
	{
		PresupuestacionCapitalesAD oPresupuestacionCapitalesAD = new PresupuestacionCapitalesAD();

		public PresupuestacionCapitales ObtenerPorId(int Id)
		{
			return this.oPresupuestacionCapitalesAD.ObtenerPorId(Id);
		}

		public DbQuery<PresupuestacionCapitales> ObtenerTodo()
		{
			return this.oPresupuestacionCapitalesAD.ObtenerTodo();
		}


		public DbQuery<PresupuestacionCapitalesView> ObtenerParaGrilla()
		{
			return this.oPresupuestacionCapitalesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPresupuestacionCapitalesAD.ObtenerOptions(filtro);
		}

		public void Guardar(PresupuestacionCapitales Objeto)
		{
			try
			{
			this.oPresupuestacionCapitalesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresupuestacionCapitales Objeto)
		{
			try
			{
			this.oPresupuestacionCapitalesAD.Actualizar(Objeto);
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
			this.oPresupuestacionCapitalesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPresupuestacionCapitalesAD.Dispose();
		}
		public DbQuery<PresupuestacionCapitalesViewT> JsonT(string term)
		{
			return (DbQuery<PresupuestacionCapitalesViewT>)this.oPresupuestacionCapitalesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
