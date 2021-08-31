
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
	public partial class EstadosElementosSecuestradosRefRN
	{
		EstadosElementosSecuestradosRefAD oEstadosElementosSecuestradosRefAD = new EstadosElementosSecuestradosRefAD();

		public EstadosElementosSecuestradosRef ObtenerPorId(int Id)
		{
			return this.oEstadosElementosSecuestradosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosElementosSecuestradosRef> ObtenerTodo()
		{
			return this.oEstadosElementosSecuestradosRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosElementosSecuestradosRefView> ObtenerParaGrilla()
		{
			return this.oEstadosElementosSecuestradosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosElementosSecuestradosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosElementosSecuestradosRef Objeto)
		{
			try
			{
			this.oEstadosElementosSecuestradosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosElementosSecuestradosRef Objeto)
		{
			try
			{
			this.oEstadosElementosSecuestradosRefAD.Actualizar(Objeto);
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
			this.oEstadosElementosSecuestradosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosElementosSecuestradosRefAD.Dispose();
		}
		public DbQuery<EstadosElementosSecuestradosRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosElementosSecuestradosRefViewT>)this.oEstadosElementosSecuestradosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
