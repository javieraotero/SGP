
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
	public partial class FacturasImputadasRN
	{
		FacturasImputadasAD oFacturasImputadasAD = new FacturasImputadasAD();

		public FacturasImputadas ObtenerPorId(int Id)
		{
			return this.oFacturasImputadasAD.ObtenerPorId(Id);
		}

		public DbQuery<FacturasImputadas> ObtenerTodo()
		{
			return this.oFacturasImputadasAD.ObtenerTodo();
		}


		public DbQuery<FacturasImputadasView> ObtenerParaGrilla()
		{
			return this.oFacturasImputadasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oFacturasImputadasAD.ObtenerOptions(filtro);
		}

		public void Guardar(FacturasImputadas Objeto)
		{
			try
			{
			this.oFacturasImputadasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FacturasImputadas Objeto)
		{
			try
			{
			this.oFacturasImputadasAD.Actualizar(Objeto);
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
			this.oFacturasImputadasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oFacturasImputadasAD.Dispose();
		}
		public DbQuery<FacturasImputadasViewT> JsonT(string term)
		{
			return (DbQuery<FacturasImputadasViewT>)this.oFacturasImputadasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
