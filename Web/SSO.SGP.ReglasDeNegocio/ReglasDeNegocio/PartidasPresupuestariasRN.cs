
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
	public partial class PartidasPresupuestariasRN
	{
		PartidasPresupuestariasAD oPartidasPresupuestariasAD = new PartidasPresupuestariasAD();

		public PartidasPresupuestarias ObtenerPorId(int Id)
		{
			return this.oPartidasPresupuestariasAD.ObtenerPorId(Id);
		}

		public DbQuery<PartidasPresupuestarias> ObtenerTodo()
		{
			return this.oPartidasPresupuestariasAD.ObtenerTodo();
		}

        public DbQuery<PartidasPresupuestarias> ObtenerPorUnidadDeOrganizacion(int unidad)
        {
            return this.oPartidasPresupuestariasAD.ObtenerPorUnidadDeOrganizacion(unidad);
        }

        public DbQuery<PartidasPresupuestariasView> ObtenerParaGrilla()
		{
			return this.oPartidasPresupuestariasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPartidasPresupuestariasAD.ObtenerOptions(filtro);
		}

		public void Guardar(PartidasPresupuestarias Objeto)
		{
			try
			{
			this.oPartidasPresupuestariasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PartidasPresupuestarias Objeto)
		{
			try
			{
			this.oPartidasPresupuestariasAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int Usuario)
		{
			try
			{
			this.oPartidasPresupuestariasAD.Eliminar(IdObjeto, Usuario);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPartidasPresupuestariasAD.Dispose();
		}
		public DbQuery<PartidasPresupuestariasViewT> JsonT(string term)
		{
			return (DbQuery<PartidasPresupuestariasViewT>)this.oPartidasPresupuestariasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
