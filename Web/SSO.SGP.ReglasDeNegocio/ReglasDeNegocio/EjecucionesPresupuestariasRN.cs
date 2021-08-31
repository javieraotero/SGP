
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System.Collections.Generic;

namespace SSO.SGP.ReglasDeNegocio
{
	/// <summary>
	/// Reglas De Negocio Generada por el Generador de codigo.
	/// </summary>
	public partial class EjecucionesPresupuestariasRN
	{
		EjecucionesPresupuestariasAD oEjecucionesPresupuestariasAD = new EjecucionesPresupuestariasAD();

		public EjecucionesPresupuestarias ObtenerPorId(int Id)
		{
			return this.oEjecucionesPresupuestariasAD.ObtenerPorId(Id);
		}

		public DbQuery<EjecucionesPresupuestarias> ObtenerTodo()
		{
			return this.oEjecucionesPresupuestariasAD.ObtenerTodo();
		}


		public DbQuery<EjecucionesPresupuestariasView> ObtenerParaGrilla()
		{
			return this.oEjecucionesPresupuestariasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oEjecucionesPresupuestariasAD.ObtenerOptions(filtro);
		}

		public void Guardar(EjecucionesPresupuestarias Objeto)
		{
			try
			{
			this.oEjecucionesPresupuestariasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EjecucionesPresupuestarias Objeto)
		{
			try
			{
			this.oEjecucionesPresupuestariasAD.Actualizar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto, int usuario)
		{
			try
			{
			this.oEjecucionesPresupuestariasAD.Eliminar(IdObjeto, usuario);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oEjecucionesPresupuestariasAD.Dispose();
		}
		public DbQuery<EjecucionesPresupuestariasViewT> JsonT(string term)
		{
			return (DbQuery<EjecucionesPresupuestariasViewT>)this.oEjecucionesPresupuestariasAD.JsonT(term);
		}
        /*********************************************
		* Seccion Particular
		* *******************************************/
        public List<string> CrearAnual(int anio, int unidad_de_organizacion) {
            return this.oEjecucionesPresupuestariasAD.CrearAnual(anio, unidad_de_organizacion);
        }

	}
}
