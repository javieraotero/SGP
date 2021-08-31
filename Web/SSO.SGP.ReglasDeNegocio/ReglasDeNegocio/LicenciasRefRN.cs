
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
	public partial class LicenciasRefRN
	{
		LicenciasRefAD oLicenciasRefAD = new LicenciasRefAD();

		public LicenciasRef ObtenerPorId(int Id)
		{
			return this.oLicenciasRefAD.ObtenerPorId(Id);
		}

		public DbQuery<LicenciasRef> ObtenerTodo()
		{
			return this.oLicenciasRefAD.ObtenerTodo();
		}


		public DbQuery<LicenciasRefView> ObtenerParaGrilla()
		{
			return this.oLicenciasRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oLicenciasRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(LicenciasRef Objeto)
		{
			try
			{
			this.oLicenciasRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LicenciasRef Objeto)
		{
			try
			{
			this.oLicenciasRefAD.Actualizar(Objeto);
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
			this.oLicenciasRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oLicenciasRefAD.Dispose();
		}
		public DbQuery<LicenciasRefViewT> JsonT(string term)
		{
			return (DbQuery<LicenciasRefViewT>)this.oLicenciasRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/
        public DbQuery<SelectOptionsView> ObtenerUnidadesTemporales()
        {
            return this.oLicenciasRefAD.ObtenerUnidadesTemporales();
        }
        public DbQuery<SelectOptionsView> ObtenerUnidadesDeContexto()
        {
            return this.oLicenciasRefAD.ObtenerUnidadesDeContexto();
        }

	}
}
