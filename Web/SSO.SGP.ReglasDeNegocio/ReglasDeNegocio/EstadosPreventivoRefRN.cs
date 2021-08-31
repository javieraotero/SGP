
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
	public partial class EstadosPreventivoRefRN
	{
		EstadosPreventivoRefAD oEstadosPreventivoRefAD = new EstadosPreventivoRefAD();

		public EstadosPreventivoRef ObtenerPorId(int Id)
		{
			return this.oEstadosPreventivoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosPreventivoRef> ObtenerTodo()
		{
			return this.oEstadosPreventivoRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosPreventivoRefView> ObtenerParaGrilla()
		{
			return this.oEstadosPreventivoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosPreventivoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosPreventivoRef Objeto)
		{
			try
			{
			this.oEstadosPreventivoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosPreventivoRef Objeto)
		{
			try
			{
			this.oEstadosPreventivoRefAD.Actualizar(Objeto);
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
			this.oEstadosPreventivoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosPreventivoRefAD.Dispose();
		}
		public DbQuery<EstadosPreventivoRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosPreventivoRefViewT>)this.oEstadosPreventivoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
