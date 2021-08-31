
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class OrganismosRefAD
	{
		private BDEntities db = new BDEntities();

		public OrganismosRef ObtenerPorId(int Id)
		{
			return db.OrganismosRef.Single(c => c.Id == Id);
		}

		public DbQuery<SelectOptionsTurnosView> ObtenerPorLocalidad(int id)
		{
			var res = from x in db.OrganismosRef
					  join p in db.TurnosWebParametros on x.Id equals p.Organismo
					  where p.Localidad == id
					  orderby p.Orden ascending
					  select new SelectOptionsTurnosView { text = x.Descripcion, value = x.Id, descripcion = p.Ayuda, solo_abogado = p.SoloAbogado, descripcion_corta = p.DescripcionCorta  };
			return (DbQuery<SelectOptionsTurnosView>)res;
		}

		public DbQuery<SelectOptionsTurnosView> ObtenerParaTurnos()
		{
			var res = from x in db.OrganismosRef
					  join p in db.TurnosWebParametros on x.Id equals p.Organismo
					  //where p.Localidad == id
					  orderby p.Orden ascending
					  select new SelectOptionsTurnosView { text = x.Descripcion, value = x.Id, descripcion = p.Ayuda, solo_abogado = p.SoloAbogado, descripcion_corta = p.DescripcionCorta };
			return (DbQuery<SelectOptionsTurnosView>)res;
		}


		public DbQuery<OrganismosRef> ObtenerTodo()
		{
			return (DbQuery<OrganismosRef>)db.OrganismosRef;
		}

        public DbQuery<OrganismosRef> ObtenerSoloRRHH()
        {
            var res = (from x in db.Nombramientos
                       orderby x.Organismos.Descripcion
                       select x.Organismos).Distinct();

            return (DbQuery<OrganismosRef>)res;
        }

        public DbQuery<Agentes> ObtenerAgentes(int organismo)
        {
            var res = (from x in db.Nombramientos
                       where x.Organismo == organismo && !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue
                       orderby x.Cargos.Grupo, x.Cargos.Orden
                       select x.Agentes).Distinct();

            return (DbQuery<Agentes>)res;
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.OrganismosRef
                      where x.Descripcion.Contains(filtro)
				select new SelectOptionsView {text = x.Descripcion, value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<OrganismosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.OrganismosRef
					select new OrganismosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TipoOrganismo = c.TipoOrganismo,
						 Localidad = c.Localidad,
						 Abreviatura = c.Abreviatura,
						 DependeDe = c.DependeDe,
						 Circunscripcion = c.Circunscripcion,
						 UltimoPreventivo = c.UltimoPreventivo,
						 Domicilio = c.Domicilio,
						 Telefono = c.Telefono,
						 HorarioAtencion = c.HorarioAtencion,
						 SubAmbito = c.SubAmbito,
						 Fuero = c.Fuero,
						 EncabezadoPDF = c.EncabezadoPDF,
						 ParaNotificaciones = c.ParaNotificaciones,
						 RecibeNotificaciones = c.RecibeNotificaciones,
						 ReceptoriaDeCausas = c.ReceptoriaDeCausas,
					};
			return (DbQuery<OrganismosRefView>)x;
		}

		public void Guardar(OrganismosRef Objeto)
		{
			try
			{
				db.OrganismosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OrganismosRef Objeto)
		{
			try
			{
				db.OrganismosRef.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

        public OrganismosExtensionesRRHH getExtensiones(int organismo) {

            var res = from x in db.OrganismosExtensionesRRHH
                      where x.Organismo == organismo
                      select x;

            return res.FirstOrDefault();

        }

		public void Eliminar(int IdObjeto)
		{
			try
			{
				OrganismosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.OrganismosRef.Remove(Objeto);
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

		public DbQuery<OrganismosRefViewT> JsonT(string term)
		{
			var x = from c in db.OrganismosRef
					select new OrganismosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TipoOrganismo = c.TipoOrganismo,
						 Localidad = c.Localidad,
						 Abreviatura = c.Abreviatura,
						 DependeDe = c.DependeDe,
						 Circunscripcion = c.Circunscripcion,
						 UltimoPreventivo = c.UltimoPreventivo,
						 Domicilio = c.Domicilio,
						 Telefono = c.Telefono,
						 HorarioAtencion = c.HorarioAtencion,
						 SubAmbito = c.SubAmbito,
						 Fuero = c.Fuero,
						 EncabezadoPDF = c.EncabezadoPDF,
						 ParaNotificaciones = c.ParaNotificaciones,
						 RecibeNotificaciones = c.RecibeNotificaciones,
						 ReceptoriaDeCausas = c.ReceptoriaDeCausas,
					};
			return (DbQuery<OrganismosRefViewT>)x;
		}
        /*********************************************
		* Seccion Particular
		* *******************************************/
        public List<AgentesView> AgentesDelOrganismo(int Organismo)
        {

            var res = (from x in db.Agentes
                       where x.Nombramientos.Any(n => !n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue && n.Organismo == Organismo)         
                       orderby x.Nombramientos.Where(z=>!z.FechaDeBaja.HasValue).FirstOrDefault().Cargos.Grupo ascending, x.Nombramientos.Where(z => !z.FechaDeBaja.HasValue).FirstOrDefault().Cargos.Orden ascending
                       select new AgentesView
                       {
                           Id = x.Id,
                           Nombre = x.Personas.Apellidos.Trim() + " " + x.Personas.Nombres.Trim(),						   
                           Legajo = x.Legajo,
						   Cargo = x.Nombramientos.Where(c=>!x.FechaBaja.HasValue && !c.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion,
						   Organismo = x.Nombramientos.Where(c => !x.FechaBaja.HasValue && !c.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Descripcion,
					   }).ToList();

            return res;

        }

		public List<AgentesTrazabilidadView> AgentesDelOrganismoTrazabilidad(int Organismo)
		{

			var res = (from x in db.Agentes
					   where x.Nombramientos.Any(n => !n.FechaDeBaja.HasValue && !n.FechaEliminacion.HasValue && n.Organismo == Organismo)
					   orderby x.Nombramientos.Where(z => !z.FechaDeBaja.HasValue).FirstOrDefault().Cargos.Grupo ascending, x.Nombramientos.Where(z => !z.FechaDeBaja.HasValue).FirstOrDefault().Cargos.Orden ascending
					   select new AgentesTrazabilidadView
					   {
						   Id = x.Id,
						   Nombre = x.Personas.Apellidos.Trim() + " " + x.Personas.Nombres.Trim(),
						   Legajo = x.Legajo,
						   Cargo = x.Nombramientos.Where(c => !x.FechaBaja.HasValue && !c.FechaEliminacion.HasValue).FirstOrDefault().Cargos.Descripcion,
						   Organismo = x.Nombramientos.Where(c => !x.FechaBaja.HasValue && !c.FechaEliminacion.HasValue).FirstOrDefault().Organismos.Descripcion,
						   Documento = x.Personas.NroDocumento,
						   Telefono = x.Personas.Telefono,
						   Persona = x.Persona
					   }).ToList();

			return res;

		}


		public List<ResumenLicenciasPorOrganismoViewT> ResumenLicenciasPorOrganismo(int Organismo)
        {

            var par1 = new SqlParameter();
            par1.ParameterName = "@Organismo";
            par1.Direction = System.Data.ParameterDirection.Input;
            par1.Value = Organismo;
            par1.SqlDbType = System.Data.SqlDbType.Int;

            //par2.TypeName = "INT";

            var x = ((IObjectContextAdapter)this.db).ObjectContext.ExecuteStoreQuery<ResumenLicenciasPorOrganismoViewT>("EXEC ResumenDeLicenciaPorOrganismo @Organismo", par1);

            return x.ToList<ResumenLicenciasPorOrganismoViewT>();

            //var parames = new object[] {new SqlParameter("@FirstName", "Bob")};
        }

	}
}
