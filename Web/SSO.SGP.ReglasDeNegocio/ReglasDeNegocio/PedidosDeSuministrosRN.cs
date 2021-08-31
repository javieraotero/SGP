
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
	public partial class PedidosDeSuministrosRN
	{
		PedidosDeSuministrosAD oPedidosDeSuministrosAD = new PedidosDeSuministrosAD();

		public PedidosDeSuministros ObtenerPorId(int Id)
		{
			return this.oPedidosDeSuministrosAD.ObtenerPorId(Id);
		}

		public DbQuery<PedidosDeSuministros> ObtenerTodo()
		{
			return this.oPedidosDeSuministrosAD.ObtenerTodo();
		}


		public DbQuery<PedidosDeSuministrosView> ObtenerParaGrilla()
		{
			return this.oPedidosDeSuministrosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPedidosDeSuministrosAD.ObtenerOptions(filtro);
		}

		public void Guardar(PedidosDeSuministros Objeto)
		{
			try
			{
			this.oPedidosDeSuministrosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PedidosDeSuministros Objeto)
		{
			try
			{
			this.oPedidosDeSuministrosAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int usuario)
		{
			try
			{
			    this.oPedidosDeSuministrosAD.Eliminar(IdObjeto, usuario);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPedidosDeSuministrosAD.Dispose();
		}
		public DbQuery<PedidosDeSuministrosViewT> JsonT(string term)
		{
			return (DbQuery<PedidosDeSuministrosViewT>)this.oPedidosDeSuministrosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
