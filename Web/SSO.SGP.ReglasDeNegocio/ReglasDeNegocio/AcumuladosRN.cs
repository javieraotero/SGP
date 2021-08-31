
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
	public partial class AcumuladosRN
	{
		AcumuladosAD oAcumuladosAD = new AcumuladosAD();

		public Acumulados ObtenerPorId(int Id)
		{
			return this.oAcumuladosAD.ObtenerPorId(Id);
		}

		public DbQuery<Acumulados> ObtenerTodo()
		{
			return this.oAcumuladosAD.ObtenerTodo();
		}


		public DbQuery<AcumuladosView> ObtenerParaGrilla()
		{
			return this.oAcumuladosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAcumuladosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Acumulados Objeto)
		{
			try
			{
			this.oAcumuladosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Acumulados Objeto)
		{
			try
			{
			this.oAcumuladosAD.Actualizar(Objeto);
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
			this.oAcumuladosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAcumuladosAD.Dispose();
		}
		public DbQuery<AcumuladosViewT> JsonT(string term)
		{
			return (DbQuery<AcumuladosViewT>)this.oAcumuladosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
