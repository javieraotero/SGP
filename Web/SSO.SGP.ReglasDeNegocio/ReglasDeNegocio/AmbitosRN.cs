
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
	public partial class AmbitosRN
	{
		AmbitosAD oAmbitosAD = new AmbitosAD();

		public Ambitos ObtenerPorId(int Id)
		{
			return this.oAmbitosAD.ObtenerPorId(Id);
		}

		public DbQuery<Ambitos> ObtenerTodo()
		{
			return this.oAmbitosAD.ObtenerTodo();
		}


		public DbQuery<AmbitosView> ObtenerParaGrilla()
		{
			return this.oAmbitosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oAmbitosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Ambitos Objeto)
		{
			try
			{
			this.oAmbitosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Ambitos Objeto)
		{
			try
			{
			this.oAmbitosAD.Actualizar(Objeto);
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
			this.oAmbitosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oAmbitosAD.Dispose();
		}
		public DbQuery<AmbitosViewT> JsonT(string term)
		{
			return (DbQuery<AmbitosViewT>)this.oAmbitosAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/
        public DbQuery<Ambitos> ObtenerDelFuero(int fuero)
        {
            return this.oAmbitosAD.ObtenerDelFuero(fuero);
        }


	}
}
