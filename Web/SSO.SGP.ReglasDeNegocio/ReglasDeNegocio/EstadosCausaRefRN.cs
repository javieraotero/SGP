
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
	public partial class EstadosCausaRefRN
	{
		EstadosCausaRefAD oEstadosCausaRefAD = new EstadosCausaRefAD();

		public EstadosCausaRef ObtenerPorId(int Id)
		{
			return this.oEstadosCausaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosCausaRef> ObtenerTodo()
		{
			return this.oEstadosCausaRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosCausaRefView> ObtenerParaGrilla()
		{
			return this.oEstadosCausaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosCausaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosCausaRef Objeto)
		{
			try
			{
			this.oEstadosCausaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosCausaRef Objeto)
		{
			try
			{
			this.oEstadosCausaRefAD.Actualizar(Objeto);
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
			this.oEstadosCausaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosCausaRefAD.Dispose();
		}
		public DbQuery<EstadosCausaRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosCausaRefViewT>)this.oEstadosCausaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
