
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
	public partial class ParametrosadmRN
	{
		ParametrosadmAD oParametrosadmAD = new ParametrosadmAD();

		public Parametrosadm ObtenerPorId(int Id)
		{
			return this.oParametrosadmAD.ObtenerPorId(Id);
		}

		public DbQuery<Parametrosadm> ObtenerTodo()
		{
			return this.oParametrosadmAD.ObtenerTodo();
		}


		public DbQuery<ParametrosadmView> ObtenerParaGrilla()
		{
			return this.oParametrosadmAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oParametrosadmAD.ObtenerOptions(filtro);
		}

		public void Guardar(Parametrosadm Objeto)
		{
			try
			{
			this.oParametrosadmAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Parametrosadm Objeto)
		{
			try
			{
			this.oParametrosadmAD.Actualizar(Objeto);
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
			this.oParametrosadmAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oParametrosadmAD.Dispose();
		}
		public DbQuery<ParametrosadmViewT> JsonT(string term)
		{
			return (DbQuery<ParametrosadmViewT>)this.oParametrosadmAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
