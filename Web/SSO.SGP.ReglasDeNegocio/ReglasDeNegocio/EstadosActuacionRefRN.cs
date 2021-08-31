
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
	public partial class EstadosActuacionRefRN
	{
		EstadosActuacionRefAD oEstadosActuacionRefAD = new EstadosActuacionRefAD();

		public EstadosActuacionRef ObtenerPorId(int Id)
		{
			return this.oEstadosActuacionRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosActuacionRef> ObtenerTodo()
		{
			return this.oEstadosActuacionRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosActuacionRefView> ObtenerParaGrilla()
		{
			return this.oEstadosActuacionRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosActuacionRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosActuacionRef Objeto)
		{
			try
			{
			this.oEstadosActuacionRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosActuacionRef Objeto)
		{
			try
			{
			this.oEstadosActuacionRefAD.Actualizar(Objeto);
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
			this.oEstadosActuacionRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosActuacionRefAD.Dispose();
		}
		public DbQuery<EstadosActuacionRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosActuacionRefViewT>)this.oEstadosActuacionRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
