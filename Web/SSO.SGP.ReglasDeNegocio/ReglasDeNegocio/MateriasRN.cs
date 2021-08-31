
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
	public partial class MateriasRN
	{
		MateriasAD oMateriasAD = new MateriasAD();

		public Materias ObtenerPorId(int Id)
		{
			return this.oMateriasAD.ObtenerPorId(Id);
		}

		public DbQuery<Materias> ObtenerTodo()
		{
			return this.oMateriasAD.ObtenerTodo();
		}


		public DbQuery<MateriasView> ObtenerParaGrilla()
		{
			return this.oMateriasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMateriasAD.ObtenerOptions(filtro);
		}

		public void Guardar(Materias Objeto)
		{
			try
			{
			this.oMateriasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Materias Objeto)
		{
			try
			{
			this.oMateriasAD.Actualizar(Objeto);
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
			this.oMateriasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMateriasAD.Dispose();
		}
		public DbQuery<MateriasViewT> JsonT(string term)
		{
			return (DbQuery<MateriasViewT>)this.oMateriasAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
