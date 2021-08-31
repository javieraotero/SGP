
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
	public partial class PresupuestacionRN
	{
		PresupuestacionAD oPresupuestacionAD = new PresupuestacionAD();

		public Presupuestacion ObtenerPorId(int Id)
		{
			return this.oPresupuestacionAD.ObtenerPorId(Id);
		}

		public DbQuery<Presupuestacion> ObtenerTodo()
		{
			return this.oPresupuestacionAD.ObtenerTodo();
		}


		public DbQuery<PresupuestacionView> ObtenerParaGrilla()
		{
			return this.oPresupuestacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPresupuestacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(Presupuestacion Objeto)
		{
			try
			{
			this.oPresupuestacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Presupuestacion Objeto)
		{
			try
			{
			this.oPresupuestacionAD.Actualizar(Objeto);
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
			this.oPresupuestacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPresupuestacionAD.Dispose();
		}
		public DbQuery<PresupuestacionViewT> JsonT(string term)
		{
			return (DbQuery<PresupuestacionViewT>)this.oPresupuestacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
