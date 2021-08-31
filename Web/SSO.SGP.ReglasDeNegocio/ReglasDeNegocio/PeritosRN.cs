
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
	public partial class PeritosRN
	{
		PeritosAD oPeritosAD = new PeritosAD();

		public Peritos ObtenerPorId(int Id)
		{
			return this.oPeritosAD.ObtenerPorId(Id);
		}

		public DbQuery<Peritos> ObtenerTodo()
		{
			return this.oPeritosAD.ObtenerTodo();
		}


		public DbQuery<PeritosView> ObtenerParaGrilla()
		{
			return this.oPeritosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPeritosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Peritos Objeto)
		{
			try
			{
			this.oPeritosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Peritos Objeto)
		{
			try
			{
			this.oPeritosAD.Actualizar(Objeto);
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
			this.oPeritosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPeritosAD.Dispose();
		}
		public DbQuery<PeritosViewT> JsonT(string term)
		{
			return (DbQuery<PeritosViewT>)this.oPeritosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
