
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
	public partial class EstadosEscolaridadRefRN
	{
		EstadosEscolaridadRefAD oEstadosEscolaridadRefAD = new EstadosEscolaridadRefAD();

		public EstadosEscolaridadRef ObtenerPorId(int Id)
		{
			return this.oEstadosEscolaridadRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosEscolaridadRef> ObtenerTodo()
		{
			return this.oEstadosEscolaridadRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosEscolaridadRefView> ObtenerParaGrilla()
		{
			return this.oEstadosEscolaridadRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosEscolaridadRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosEscolaridadRef Objeto)
		{
			try
			{
			this.oEstadosEscolaridadRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosEscolaridadRef Objeto)
		{
			try
			{
			this.oEstadosEscolaridadRefAD.Actualizar(Objeto);
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
			this.oEstadosEscolaridadRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosEscolaridadRefAD.Dispose();
		}
		public DbQuery<EstadosEscolaridadRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosEscolaridadRefViewT>)this.oEstadosEscolaridadRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
