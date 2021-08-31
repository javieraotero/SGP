
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
	public partial class PersonasAD
	{
		private BDEntities db = new BDEntities();

		public Personas ObtenerPorId(int Id)
		{
			return db.Personas.Single(c => c.Id == Id);
		}

		public DbQuery<Personas> ObtenerTodo()
		{
			return (DbQuery<Personas>)db.Personas;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Personas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}
       
		public DbQuery<PersonasView> ObtenerParaGrilla()
		{
			var x = from c in db.Personas
					select new PersonasView
					{
						 Id = c.Id,
						 Apellidos = c.Apellidos,
						 Nombres = c.Nombres,
						 TipoDocumento = c.TipoDocumento,
						 NroDocumento = c.NroDocumento,
						 FechaNacimiento = c.FechaNacimiento,
						 LugarNacimiento = c.LugarNacimiento,
						 Sexo = c.Sexo,
						 EsMenor = c.EsMenor,
						 Alias = c.Alias,
						 PersonaFisica = c.PersonaFisica,
						 Barrio = c.Barrio,
						 Calle = c.Calle,
						 Domicilio = c.Domicilio,
						 Localidad = c.Localidad,
						 Ocupacion = c.Ocupacion,
						 Nacionalidad = c.Nacionalidad,
						 Activa = c.Activa,
						 Telefono = c.Telefono,
						 Fallecido = c.Fallecido,
						 FechaDefuncion = c.FechaDefuncion,
						 TipoEscolaridad = c.TipoEscolaridad,
						 EstadoEscolaridad = c.EstadoEscolaridad,
						 TipoOcupacion = c.TipoOcupacion,
						 EstadoCivil = c.EstadoCivil,
						 Ocupado = c.Ocupado,
						 ObraSocial = c.ObraSocial,
						 Detenido = c.Detenido,
						 IncluirIdentikit = c.IncluirIdentikit,
						 FotoIdentikit = c.FotoIdentikit,
						 RegistroVoz = c.RegistroVoz,
						 ColorOjos = c.ColorOjos,
						 ColorPelo = c.ColorPelo,
						 LongitudPelo = c.LongitudPelo,
						 Altura = c.Altura,
						 Peso = c.Peso,
						 Piel = c.Piel,
						 BarbaBigote = c.BarbaBigote,
						 LongitudBarbaBigote = c.LongitudBarbaBigote,
						 ColorBarbaBigote = c.ColorBarbaBigote,
						 PielVarios = c.PielVarios,
						 Varios = c.Varios,
						 Tonada = c.Tonada,
						 CriterioOportunidadArt15 = c.CriterioOportunidadArt15,
						 Celular = c.Celular,
						 TelefonoTrabajo = c.TelefonoTrabajo,
						 DomicilioTrabajo = c.DomicilioTrabajo,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 ActuacionCriterioOportunidad = c.ActuacionCriterioOportunidad,
						 FechaCriterioOportunidad = c.FechaCriterioOportunidad,
						 UsuarioCriterioOportunidad = c.UsuarioCriterioOportunidad,
						 ObservacionCriterioOportunidad = c.ObservacionCriterioOportunidad,
						 Observaciones = c.Observaciones,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
						 NombrePadre = c.NombrePadre,
						 NombreMadre = c.NombreMadre,
						 ActuacionSuspencionProcesoAPrueba = c.ActuacionSuspencionProcesoAPrueba,
						 FechaSuspencionProcesoAPrueba = c.FechaSuspencionProcesoAPrueba,
						 UsuarioSuspencionProcesoAPrueba = c.UsuarioSuspencionProcesoAPrueba,
						 ObservacionSuspencionProcesoAPrueba = c.ObservacionSuspencionProcesoAPrueba,
						 SuspencionProcesoAPrueba = c.SuspencionProcesoAPrueba,
						 Concurso = c.Concurso,
						 DomicilioProcesal = c.DomicilioProcesal,
						 LocalidadProcesal = c.LocalidadProcesal,
					};
			return (DbQuery<PersonasView>)x;
		}

		public void Guardar(Personas Objeto)
		{
			try
			{
				db.Personas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Personas Objeto)
		{
			try
			{
				db.Personas.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

        public bool ExisteDocumento(long? documento)
        {
            var existe = false;

            var c = (from x in db.Personas
                     where x.NroDocumento == documento && x.Activa
                     select x).ToList().Count();

            if (c > 0)
                existe = true;

            return existe;
        }

		public void Eliminar(int IdObjeto)
		{
			try
			{
				Personas Objeto = this.ObtenerPorId(IdObjeto);
				db.Personas.Remove(Objeto);
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

		public DbQuery<PersonasViewT> JsonT(string term)
		{
			var x = from c in db.Personas
					select new PersonasViewT
					{
						 Id = c.Id,
						 Apellidos = c.Apellidos,
						 Nombres = c.Nombres,
						 TipoDocumento = c.TipoDocumento.HasValue ? c.TipoDocumentos.Descripcion : "",
						 NroDocumento = c.NroDocumento.HasValue ? c.NroDocumento.Value : 0,						
						 Localidad = c.Localidad.HasValue ? c.Localidads.Descripcion : "",						
					};
			return (DbQuery<PersonasViewT>)x;
		}

        public DbQuery<PersonasViewT> BuscarPersona(long documento, string apellido, string nombre, int sexo)
        {
            var x = from c in db.Personas
                    where ((documento > 0 && c.NroDocumento == documento) || (documento == 0)) &&
                            ((apellido.Length > 0 && c.Apellidos.Contains(apellido)) || (apellido.Length < 1)) &&
                            ((nombre.Length > 0 && c.Nombres.Contains(nombre)) || (nombre.Length < 1))
							&& c.Activa
                    select new PersonasViewT
                    {
                        Id = c.Id,
                        Apellidos = c.Apellidos,
                        Nombres = c.Nombres,
                        TipoDocumento = c.TipoDocumento.HasValue ? c.TipoDocumentos.Descripcion : "",
                        NroDocumento = c.NroDocumento.HasValue ? c.NroDocumento.Value : 0,
                        Localidad = c.Localidad.HasValue ? c.Localidads.Descripcion : "",
						sexo = c.Sexo,
						Telefono = c.Telefono
                    };
            return (DbQuery<PersonasViewT>)x;
        }
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
