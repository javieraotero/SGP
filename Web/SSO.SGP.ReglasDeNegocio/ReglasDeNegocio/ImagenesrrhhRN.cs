
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
	public partial class ImagenesrrhhRN
	{
		ImagenesrrhhAD oImagenesrrhhAD = new ImagenesrrhhAD();

		public Imagenesrrhh ObtenerPorId(int Id)
		{
			return this.oImagenesrrhhAD.ObtenerPorId(Id);
		}

		public DbQuery<Imagenesrrhh> ObtenerTodo()
		{
			return this.oImagenesrrhhAD.ObtenerTodo();
		}


		public DbQuery<ImagenesrrhhView> ObtenerParaGrilla(int id)
		{
			return this.oImagenesrrhhAD.ObtenerParaGrilla(id);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oImagenesrrhhAD.ObtenerOptions(filtro);
		}

		public void Guardar(Imagenesrrhh Objeto)
		{
			try
			{
			this.oImagenesrrhhAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Imagenesrrhh Objeto)
		{
			try
			{
			this.oImagenesrrhhAD.Actualizar(Objeto);
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
			this.oImagenesrrhhAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oImagenesrrhhAD.Dispose();
		}
		public DbQuery<ImagenesrrhhViewT> JsonT(string term)
		{
			return (DbQuery<ImagenesrrhhViewT>)this.oImagenesrrhhAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
