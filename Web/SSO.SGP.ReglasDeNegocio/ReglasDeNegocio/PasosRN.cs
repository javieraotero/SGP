
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
	public partial class PasosRN
	{
		PasosAD oPasosAD = new PasosAD();

		public Pasos ObtenerPorId(int Id)
		{
			return this.oPasosAD.ObtenerPorId(Id);
		}

		public DbQuery<Pasos> ObtenerTodo()
		{
			return this.oPasosAD.ObtenerTodo();
		}


		public DbQuery<PasosView> ObtenerParaGrilla()
		{
			return this.oPasosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPasosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Pasos Objeto)
		{
			try
			{
			this.oPasosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Pasos Objeto)
		{
			try
			{
			this.oPasosAD.Actualizar(Objeto);
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
			this.oPasosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPasosAD.Dispose();
		}
		public DbQuery<PasosViewT> JsonT(string term)
		{
			return (DbQuery<PasosViewT>)this.oPasosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
