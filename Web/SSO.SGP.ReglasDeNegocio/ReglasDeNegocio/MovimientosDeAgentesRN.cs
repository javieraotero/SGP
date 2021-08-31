
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
	public partial class MovimientosDeAgentesRN
	{
		MovimientosDeAgentesAD oMovimientosDeAgentesAD = new MovimientosDeAgentesAD();

		public MovimientosDeAgentes ObtenerPorId(int Id)
		{
			return this.oMovimientosDeAgentesAD.ObtenerPorId(Id);
		}

		public DbQuery<MovimientosDeAgentes> ObtenerTodo()
		{
			return this.oMovimientosDeAgentesAD.ObtenerTodo();
		}


		public DbQuery<MovimientosDeAgentesView> ObtenerParaGrilla()
		{
			return this.oMovimientosDeAgentesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMovimientosDeAgentesAD.ObtenerOptions(filtro);
		}

		public void Guardar(MovimientosDeAgentes Objeto)
		{
			try
			{
			this.oMovimientosDeAgentesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MovimientosDeAgentes Objeto)
		{
			try
			{
			this.oMovimientosDeAgentesAD.Actualizar(Objeto);
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
			this.oMovimientosDeAgentesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMovimientosDeAgentesAD.Dispose();
		}
		public DbQuery<MovimientosDeAgentesViewT> JsonT(string term)
		{
			return (DbQuery<MovimientosDeAgentesViewT>)this.oMovimientosDeAgentesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
