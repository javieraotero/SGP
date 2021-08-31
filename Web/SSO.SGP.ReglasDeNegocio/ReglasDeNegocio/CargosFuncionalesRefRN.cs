
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
	public partial class CargosFuncionalesRefRN
	{
		CargosFuncionalesRefAD oCargosFuncionalesRefAD = new CargosFuncionalesRefAD();

		public CargosFuncionalesRef ObtenerPorId(int Id)
		{
			return this.oCargosFuncionalesRefAD.ObtenerPorId(Id);
		}

		public DbQuery<CargosFuncionalesRef> ObtenerTodo()
		{
			return this.oCargosFuncionalesRefAD.ObtenerTodo();
		}


		public DbQuery<CargosFuncionalesRefView> ObtenerParaGrilla()
		{
			return this.oCargosFuncionalesRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCargosFuncionalesRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(CargosFuncionalesRef Objeto)
		{
			try
			{
			this.oCargosFuncionalesRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CargosFuncionalesRef Objeto)
		{
			try
			{
			this.oCargosFuncionalesRefAD.Actualizar(Objeto);
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
			this.oCargosFuncionalesRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCargosFuncionalesRefAD.Dispose();
		}
		public DbQuery<CargosFuncionalesRefViewT> JsonT(string term)
		{
			return (DbQuery<CargosFuncionalesRefViewT>)this.oCargosFuncionalesRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
