
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
	public partial class FormasDePagoRefRN
	{
		FormasDePagoRefAD oFormasDePagoRefAD = new FormasDePagoRefAD();

		public FormasDePagoRef ObtenerPorId(int Id)
		{
			return this.oFormasDePagoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<FormasDePagoRef> ObtenerTodo()
		{
			return this.oFormasDePagoRefAD.ObtenerTodo();
		}


		public DbQuery<FormasDePagoRefView> ObtenerParaGrilla()
		{
			return this.oFormasDePagoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFormasDePagoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(FormasDePagoRef Objeto)
		{
			try
			{
			this.oFormasDePagoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FormasDePagoRef Objeto)
		{
			try
			{
			this.oFormasDePagoRefAD.Actualizar(Objeto);
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
			this.oFormasDePagoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFormasDePagoRefAD.Dispose();
		}
		public DbQuery<FormasDePagoRefViewT> JsonT(string term)
		{
			return (DbQuery<FormasDePagoRefViewT>)this.oFormasDePagoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
