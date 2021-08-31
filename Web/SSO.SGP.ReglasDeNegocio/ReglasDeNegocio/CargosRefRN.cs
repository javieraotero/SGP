
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
	public partial class CargosRefRN
	{
		CargosRefAD oCargosRefAD = new CargosRefAD();

		public CargosRef ObtenerPorId(int Id)
		{
			return this.oCargosRefAD.ObtenerPorId(Id);
		}

		public DbQuery<CargosRef> ObtenerTodo()
		{
			return this.oCargosRefAD.ObtenerTodo();
		}


		public DbQuery<CargosRefView> ObtenerParaGrilla()
		{
			return this.oCargosRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCargosRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(CargosRef Objeto)
		{
			try
			{
			this.oCargosRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CargosRef Objeto)
		{
			try
			{
			this.oCargosRefAD.Actualizar(Objeto);
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
			this.oCargosRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCargosRefAD.Dispose();
		}
		public DbQuery<CargosRefViewT> JsonT(string term)
		{
			return (DbQuery<CargosRefViewT>)this.oCargosRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/
        public List<PlantaDePersonalResult> PlantaDePersonal()
        {
            return this.oCargosRefAD.PlantaDePersonal();
        }

	}
}
