
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
	public partial class OperacionesContablesRefRN
	{
		OperacionesContablesRefAD oOperacionesContablesRefAD = new OperacionesContablesRefAD();

		public OperacionesContablesRef ObtenerPorId(int Id)
		{
			return this.oOperacionesContablesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<OperacionesContablesRef> ObtenerTodo()
		{
			return this.oOperacionesContablesRefAD.ObtenerTodo();
		}


		public DbQuery<OperacionesContablesRefView> ObtenerParaGrilla()
		{
			return this.oOperacionesContablesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oOperacionesContablesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(OperacionesContablesRef Objeto)
		{
			try
			{
			this.oOperacionesContablesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OperacionesContablesRef Objeto)
		{
			try
			{
			this.oOperacionesContablesRefAD.Actualizar(Objeto);
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
			this.oOperacionesContablesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oOperacionesContablesRefAD.Dispose();
		}
		public DbQuery<OperacionesContablesRefViewT> JsonT(string term)
		{
			return (DbQuery<OperacionesContablesRefViewT>)this.oOperacionesContablesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
