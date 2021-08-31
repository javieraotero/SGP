
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
	public partial class ParametrosReceptoriaRN
	{
		ParametrosReceptoriaAD oParametrosReceptoriaAD = new ParametrosReceptoriaAD();

		public ParametrosReceptoria ObtenerPorId(int Id)
		{
			return this.oParametrosReceptoriaAD.ObtenerPorId(Id);
		}

		public DbQuery<ParametrosReceptoria> ObtenerTodo()
		{
			return this.oParametrosReceptoriaAD.ObtenerTodo();
		}


		public DbQuery<ParametrosReceptoriaView> ObtenerParaGrilla()
		{
			return this.oParametrosReceptoriaAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oParametrosReceptoriaAD.ObtenerOptions(filtro);
		}

		public void Guardar(ParametrosReceptoria Objeto)
		{
			try
			{
			this.oParametrosReceptoriaAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ParametrosReceptoria Objeto)
		{
			try
			{
			this.oParametrosReceptoriaAD.Actualizar(Objeto);
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
			this.oParametrosReceptoriaAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oParametrosReceptoriaAD.Dispose();
		}
		public DbQuery<ParametrosReceptoriaViewT> JsonT(string term)
		{
			return (DbQuery<ParametrosReceptoriaViewT>)this.oParametrosReceptoriaAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
