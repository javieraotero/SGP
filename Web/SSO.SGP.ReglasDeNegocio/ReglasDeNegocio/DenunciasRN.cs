
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
	public partial class DenunciasRN
	{
		DenunciasAD oDenunciasAD = new DenunciasAD();

		public Denuncias ObtenerPorId(int Id)
		{
			return this.oDenunciasAD.ObtenerPorId(Id);
		}

		public DbQuery<Denuncias> ObtenerTodo()
		{
			return this.oDenunciasAD.ObtenerTodo();
		}


		public DbQuery<DenunciasView> ObtenerParaGrilla()
		{
			return this.oDenunciasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oDenunciasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Denuncias Objeto)
		{
			try
			{
			this.oDenunciasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Denuncias Objeto)
		{
			try
			{
			this.oDenunciasAD.Actualizar(Objeto);
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
			this.oDenunciasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oDenunciasAD.Dispose();
		}
		public DbQuery<DenunciasViewT> JsonT(string term)
		{
			return (DbQuery<DenunciasViewT>)this.oDenunciasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
