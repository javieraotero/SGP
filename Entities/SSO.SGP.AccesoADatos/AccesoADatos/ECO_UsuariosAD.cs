
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ECO_UsuariosAD
	{
		private BDEntities db = new BDEntities();

		public ECO_Usuarios ObtenerPorId(int Id)
		{
			return db.ECO_Usuarios.Single(c => c.Id == Id);
		}

        public ECO_Usuarios ObtenerPorMail(string mail)
        {
            try
            {
				return db.ECO_Usuarios.SingleOrDefault(c => c.Mail == mail);
			}
            catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}

        }

		public int ObtenerIdPorMail(string mail)
		{

			try
			{
				var res = (from x in db.ECO_Usuarios
						   where x.Mail == mail
						   select x.Id).FirstOrDefault();
				return res;
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public DbQuery<ECO_Usuarios> ObtenerTodo()
		{
			return (DbQuery<ECO_Usuarios>)db.ECO_Usuarios;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ECO_Usuarios
					  where x.Mail.Contains(filtro)
				select new SelectOptionsView {text = x.Mail, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<ECO_Usuarios> GetAutocomplete(string filtro)
        {
            var res = from x in db.ECO_Usuarios
					  where x.Nombre.Contains(filtro)
                      select x;
            return (DbQuery<ECO_Usuarios>)res;
        }


		public void Guardar(ECO_Usuarios Objeto)
		{
			try
			{
				db.ECO_Usuarios.Add(Objeto);
				db.SaveChanges();
				EntityHelper.EnviarMailAlta(Objeto,EntityHelper.Decrypt(Objeto.Password));
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ECO_Usuarios Objeto)
		{
			try
			{
				db.ECO_Usuarios.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
				ECO_Usuarios Objeto = this.ObtenerPorId(IdObjeto);
				db.ECO_Usuarios.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
