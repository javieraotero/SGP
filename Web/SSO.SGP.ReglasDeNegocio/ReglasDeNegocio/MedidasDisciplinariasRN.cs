
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
	public partial class MedidasDisciplinariasRN
	{
		MedidasDisciplinariasAD oMedidasDisciplinariasAD = new MedidasDisciplinariasAD();

		public MedidasDisciplinarias ObtenerPorId(int Id)
		{
			return this.oMedidasDisciplinariasAD.ObtenerPorId(Id);
		}

		public DbQuery<MedidasDisciplinarias> ObtenerTodo()
		{
			return this.oMedidasDisciplinariasAD.ObtenerTodo();
		}


		public DbQuery<MedidasDisciplinariasView> ObtenerParaGrilla()
		{
			return this.oMedidasDisciplinariasAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oMedidasDisciplinariasAD.ObtenerOptions(filtro);
		}

		public void Guardar(MedidasDisciplinarias Objeto)
		{
			try
			{
			this.oMedidasDisciplinariasAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MedidasDisciplinarias Objeto)
		{
			try
			{
			this.oMedidasDisciplinariasAD.Actualizar(Objeto);
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
			this.oMedidasDisciplinariasAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oMedidasDisciplinariasAD.Dispose();
		}
		public DbQuery<MedidasDisciplinariasViewT> JsonT(int agente)
		{
			return (DbQuery<MedidasDisciplinariasViewT>)this.oMedidasDisciplinariasAD.JsonT(agente);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
