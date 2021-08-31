
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
	public partial class EstadosCivilRefRN
	{
		EstadosCivilRefAD oEstadosCivilRefAD = new EstadosCivilRefAD();

		public EstadosCivilRef ObtenerPorId(int Id)
		{
			return this.oEstadosCivilRefAD.ObtenerPorId(Id);
		}

		public DbQuery<EstadosCivilRef> ObtenerTodo()
		{
			return this.oEstadosCivilRefAD.ObtenerTodo();
		}


		public DbQuery<EstadosCivilRefView> ObtenerParaGrilla()
		{
			return this.oEstadosCivilRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEstadosCivilRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(EstadosCivilRef Objeto)
		{
			try
			{
			this.oEstadosCivilRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosCivilRef Objeto)
		{
			try
			{
			this.oEstadosCivilRefAD.Actualizar(Objeto);
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
			this.oEstadosCivilRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEstadosCivilRefAD.Dispose();
		}
		public DbQuery<EstadosCivilRefViewT> JsonT(string term)
		{
			return (DbQuery<EstadosCivilRefViewT>)this.oEstadosCivilRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
