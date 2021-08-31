
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
	public partial class ParametrosTrabajoCivilRefRN
	{
		ParametrosTrabajoCivilRefAD oParametrosTrabajoCivilRefAD = new ParametrosTrabajoCivilRefAD();

		public ParametrosTrabajoCivilRef ObtenerPorId(int Id)
		{
			return this.oParametrosTrabajoCivilRefAD.ObtenerPorId(Id);
		}

		public DbQuery<ParametrosTrabajoCivilRef> ObtenerTodo()
		{
			return this.oParametrosTrabajoCivilRefAD.ObtenerTodo();
		}


		public DbQuery<ParametrosTrabajoCivilRefView> ObtenerParaGrilla()
		{
			return this.oParametrosTrabajoCivilRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oParametrosTrabajoCivilRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(ParametrosTrabajoCivilRef Objeto)
		{
			try
			{
			this.oParametrosTrabajoCivilRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ParametrosTrabajoCivilRef Objeto)
		{
			try
			{
			this.oParametrosTrabajoCivilRefAD.Actualizar(Objeto);
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
			this.oParametrosTrabajoCivilRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oParametrosTrabajoCivilRefAD.Dispose();
		}
		public DbQuery<ParametrosTrabajoCivilRefViewT> JsonT(string term)
		{
			return (DbQuery<ParametrosTrabajoCivilRefViewT>)this.oParametrosTrabajoCivilRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
