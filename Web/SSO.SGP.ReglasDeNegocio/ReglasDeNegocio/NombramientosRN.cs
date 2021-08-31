
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
	public partial class NombramientosRN
	{
		NombramientosAD oNombramientosAD = new NombramientosAD();

		public Nombramientos ObtenerPorId(int Id)
		{
			return this.oNombramientosAD.ObtenerPorId(Id);
		}

		public DbQuery<Nombramientos> ObtenerTodo()
		{
			return this.oNombramientosAD.ObtenerTodo();
		}


		public DbQuery<NombramientosView> ObtenerParaGrilla()
		{
			return this.oNombramientosAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oNombramientosAD.ObtenerOptions(filtro);
		}

		public void Guardar(Nombramientos Objeto)
		{
			try
			{
			this.oNombramientosAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Nombramientos Objeto)
		{
			try
			{
			this.oNombramientosAD.Actualizar(Objeto);
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
			this.oNombramientosAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oNombramientosAD.Dispose();
		}
		public DbQuery<NombramientosViewT> JsonT(int agente)
		{
			return (DbQuery<NombramientosViewT>)this.oNombramientosAD.JsonT(agente);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/
        public int TotalPlantaPermanente()
        {
            return this.oNombramientosAD.TotalPlantaPermanente();
        }
        public int TotalContratado()
        {
            return this.oNombramientosAD.TotalContratado();
        }
        public int TotalSustitutos()
        {
            return this.oNombramientosAD.TotalSustitutos();
        }
        public int TotalEnLicencia()
        {
            return this.oNombramientosAD.TotalEnLicencia();
        }
	}
}
