using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Data.Objects;
using System.Collections.Generic;
using SSO.SGP.EntidadesDeNegocio.Results;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class SolicitudesDeViaticosAD
	{
		private BDEntities db = new BDEntities();

		public SolicitudesDeViaticos ObtenerPorId(int Id)
		{
			return db.SolicitudesDeViaticos.Single(c => c.Id == Id);
		}

        public SolicitudesDeViaticosResult GetResult(int Id)
        {
            var res = (from x in db.SolicitudesDeViaticos
                      join o in db.OrganismosRef on x.OrganismoSolicitante equals o.Id
                      join l in db.LocalidadesRef on x.Destino equals l.Id
                      where x.Id == Id                      
                      select new SolicitudesDeViaticosResult
                      {
                          //sFechaDeFin = SqlFunctions.DatePart("dd", x.FechaDeInicio) + "/" +                
                          //              SqlFunctions.DateName("m", x.FechaDeInicio) + "/" +
                          //              SqlFunctions.DateName("yyyy", x.FechaDeInicio),
                          Id = x.Id,
                          Fecha = x.Fecha,
                          FechaDeFin = x.FechaDeFin,
                          FechaDeInicio = x.FechaDeInicio,
                          Destino = l.Descripcion,
                          Motivo = x.MotivoDeComision,
                          MedioDeTransporte = x.MedioDeTransporte == 1 ? "Vehículo Poder Judicial" : (x.MedioDeTransporte == 2 ? "Vehículo Particular" : "Colectivo"),
                          OrganismoSolicitante = o.Descripcion,
                          Detalle = (from d in x.SolicitudesDeViaticosAgentes
                                    select new SolicitudDeViaticosAgenteResult
                                    {
                                        Afiliado = d.Agentes.AfiliadoISS,
                                        Nombre = d.Agentes.Personas.Apellidos.Trim() +", " + d.Agentes.Personas.Nombres.Trim(),
                                        Categoria = d.CargoDescripcion,
                                        Dias = d.Dias,
                                        PesosPorDia = d.ImportePorDia,
                                        Gastos = d.ImporteGastos,
                                        Viatico = d.Subtotal,
                                        Total = d.ImporteTotal
                                    })
                      }).FirstOrDefault();

            return res;
        }


        public RendicionResult GetRendicionResult(int Id)
        {
            var res = (from x in db.SolicitudesDeViaticosRendiciones
                       join l in db.LocalidadesRef on x.SolicitudDeViaticos.Destino equals l.Id
                       where x.Id == Id
                       select new RendicionResult
                       {
                           Id = x.Id,
                           Fecha = x.FechaDeAlta,
                           FechaDeFin = x.FechaDeFin,
                           FechaDeInicio = x.FechaDeInicio,     
                           Destino = l.Descripcion + " - " + l.Provincias.Descripcion,             
                           Detalle = (from d in x.SolicitudesDeViaticosRendicionesAgentes
                                      select new RendicionAgenteResult
                                      {
                                          Afiliado = d.Agentes.AfiliadoISS,
                                          Nombre = d.Agentes.Personas.Apellidos.Trim() + ", " + d.Agentes.Personas.Nombres.Trim(),                                         
                                          Dias = d.Dias,
                                          PesosPorDia = d.ImportePorDia,
                                          Gastos = d.Gastos,
                                          Viatico = d.Dias * d.ImportePorDia,
                                          Anticipo = d.Anticipo,
                                          Cobrar = d.Cobrar,
                                          Devolver = d.Devolver,
                                          Total = (d.Dias * d.ImportePorDia) + d.Gastos
                                      })
                       }).FirstOrDefault();

            var bienes = (from x in db.SolicitudesDeViaticosRendicionesDetalle
                          join c in db.ConceptosDeGastosRef on x.Concepto equals c.Id
                          where x.RendicionAgente == Id
                          && c.Partida == 1
                          select x).ToList();

            res.BienesDeConsumo = bienes.Count() > 0 ? bienes.Sum(t => t.Importe) : 0;

            var otros = (from x in db.SolicitudesDeViaticosRendicionesDetalle
                         join c in db.ConceptosDeGastosRef on x.Concepto equals c.Id
                         where x.RendicionAgente == Id
                         && c.Partida != 1
                         select x).ToList();

            res.Otros = otros.Count() > 0 ? otros.Sum(t => t.Importe) : 0;

            return res;
        }

        public List<SolicitudesDeViaticos> ObtenerPorComision(int Id)
        {
            return db.SolicitudesDeViaticos.Where(c => c.Comision == Id).ToList();
        }

        public List<SolicitudesDeViaticosAgentes> ObtenerAgentesDeComision(int comision)
        {
            var res = (from x in db.SolicitudesDeViaticosAgentes
                      where x.SolicitudDeViaticos.Comision == comision
                      select x).ToList();

            return res;
        }

        public DbQuery<SolicitudesDeViaticos> ObtenerTodo()
		{
			return (DbQuery<SolicitudesDeViaticos>)db.SolicitudesDeViaticos;
		}

        public DbQuery<SolicitudesDeViaticosAgentesCustom> ObtenerAgentes(int solicitud)
        {
            var res = from x in db.SolicitudesDeViaticosAgentes
                      where x.SolicitudDeViatico == solicitud
                      select new SolicitudesDeViaticosAgentesCustom {
                          Agente = x.Agente,
                          AgenteDescripcion = x.AgenteDescripcion,
                          CargoDescripcion = x.CargoDescripcion,
                          Dias = x.Dias,
                          Id = x.Id,
                          ImporteGastos = x.ImporteGastos,
                          ImportePorDia = x.ImportePorDia,
                          ImporteTotal = x.ImporteTotal,
                          SolicitudDeViatico = x.SolicitudDeViatico,
                          Subtotal = x.Subtotal,
                          Grupo = x.Grupo,
                          Anticipo = x.SolicitudDeViaticos.Anticipo,
                          Afiliado = x.Agentes.AfiliadoISS                                                                              
                      };

            return (DbQuery<SolicitudesDeViaticosAgentesCustom>)res;
        }

        public DbQuery<SolicitudesDeViaticosRendicionesAgentesCustom> ObtenerAgentesRendicion(int rendicion)
        {
            var res = from x in db.SolicitudesDeViaticosRendicionesAgentes      
                      join s in db.SolicitudesDeViaticosAgentes on x.Rendicions.SolicitudDeViatico equals s.SolicitudDeViatico                                      
                      where x.Rendicion == rendicion && x.Agente == s.Agente
                      select new SolicitudesDeViaticosRendicionesAgentesCustom
                      {
                          Agente = x.Agente,
                          AgenteDescripcion = x.Agentes.Personas.Apellidos + ", " + x.Agentes.Personas.Nombres,                          
                          Dias = x.Dias,
                          Id = x.Id,
                          Gastos = x.Gastos,
                          ImportePorDia = x.ImportePorDia,                          
                          Subtotal = x.Subtotal,
                          Grupo = s.Grupo,
                          Anticipo = x.Anticipo,
                          Cobrar = x.Cobrar,
                          Devolver = x.Devolver,
                          Rendicion = x.Rendicion,
                          Solicitado = s.Subtotal,
                          GastosSolicitados = s.ImporteGastos,
                          SolicitudDeViatico = s.SolicitudDeViatico
                      };

            return (DbQuery<SolicitudesDeViaticosRendicionesAgentesCustom>)res;
        }

        public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SolicitudesDeViaticos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SolicitudesDeViaticosView> ObtenerParaGrilla(int? organismo, int? agente, int? destino)
		{
			var x = from c in db.SolicitudesDeViaticos
                    join o in db.OrganismosRef on c.OrganismoSolicitante equals o.Id
                    join l in db.LocalidadesRef on c.Destino equals l.Id
                    join e in db.EstadosDeViaticosRef on c.Estado equals e.Id
                    where ((organismo.HasValue && c.OrganismoSolicitante == organismo.Value) || !organismo.HasValue)
                    && ((agente.HasValue && c.SolicitudesDeViaticosAgentes.Any(a=>a.Agente == agente.Value)) || (!agente.HasValue))
                    && ((destino.HasValue && c.Destino == destino.Value) || (!destino.HasValue))
                    select new SolicitudesDeViaticosView
					{
						 Id = c.Id,
                         //Agentes_Hide = string.Join(",", c.SolicitudesDeViaticosAgentes.AsEnumerable().Select(z=>z.AgenteDescripcion)),
                         Fecha = c.Fecha,
						 OrganismoSolicitante = o.Descripcion,
						 Destino = l.Descripcion + " - " + l.Provincias.Descripcion,
						 FechaDeInicio = c.FechaDeInicio,
						 FechaDeFin = c.FechaDeFin,
						 Estado = e.Descripcion,
                         Identificador = c.Id,
                         Comision = (c.Comision.HasValue ? c.Comision.Value : 0)
					};

			return (DbQuery<SolicitudesDeViaticosView>)x;
		}

        public DbQuery<SolicitudesDeViaticosView> ObtenerParaGrillaPorEstado(int? organismo, List<int> estado)
        {
            var x = from c in db.SolicitudesDeViaticos
                    join o in db.OrganismosRef on c.OrganismoSolicitante equals o.Id
                    join l in db.LocalidadesRef on c.Destino equals l.Id
                    join e in db.EstadosDeViaticosRef on c.Estado equals e.Id
                    where ((organismo.HasValue && c.OrganismoSolicitante == organismo.Value) || !organismo.HasValue)
                    && estado.Any(est=>est == c.Estado)
                    select new SolicitudesDeViaticosView
                    {
                        Id = c.Id,
                        Fecha = c.Fecha,
                        OrganismoSolicitante = o.Descripcion,
                        Destino = l.Descripcion + " - " + l.Provincias.Descripcion,
                        FechaDeInicio = c.FechaDeInicio,
                        FechaDeFin = c.FechaDeFin,
                        Estado = e.Descripcion,
                        Identificador = c.Id,
                        Comision = (c.Comision.HasValue ? c.Comision.Value : 0)
                    };
            return (DbQuery<SolicitudesDeViaticosView>)x;
        }

        public DbQuery<SolicitudesDeViaticosView> ObtenerParaGrillaPorAnticipo(int? organismo, int? agente, int? destino)
        {
            var x = from c in db.SolicitudesDeViaticos
                    join o in db.OrganismosRef on c.OrganismoSolicitante equals o.Id
                    join l in db.LocalidadesRef on c.Destino equals l.Id
                    join e in db.EstadosDeViaticosRef on c.Estado equals e.Id
                    where ((organismo.HasValue && c.OrganismoSolicitante == organismo.Value) || !organismo.HasValue)
                    && c.SolicitaAnticipo && c.Estado == 2
                    && ((agente.HasValue && c.SolicitudesDeViaticosAgentes.Any(a => a.Agente == agente.Value)) || (!agente.HasValue))
                    && ((destino.HasValue && c.Destino == destino.Value) || (!destino.HasValue))
                    select new SolicitudesDeViaticosView
                    {
                        Id = c.Id,
                        Fecha = c.Fecha,
                        OrganismoSolicitante = o.Descripcion,
                        Destino = l.Descripcion + " - " + l.Provincias.Descripcion,
                        FechaDeInicio = c.FechaDeInicio,
                        FechaDeFin = c.FechaDeFin,
                        Estado = e.Descripcion,
                        Identificador = c.Id,
                        Comision = (c.Comision.HasValue ? c.Comision.Value : 0)
                    };
            return (DbQuery<SolicitudesDeViaticosView>)x;
        }

        public DbQuery<SolicitudesDeViaticosView> ObtenerParaGrillaPorReintegro(int? organismo, int? agente, int? destino)
        {
            var x = from c in db.SolicitudesDeViaticos
                    join o in db.OrganismosRef on c.OrganismoSolicitante equals o.Id
                    join l in db.LocalidadesRef on c.Destino equals l.Id
                    join e in db.EstadosDeViaticosRef on c.Estado equals e.Id
                    where ((organismo.HasValue && c.OrganismoSolicitante == organismo.Value) || !organismo.HasValue)
                    && !c.SolicitaAnticipo & c.Estado == 2
                    && ((agente.HasValue && c.SolicitudesDeViaticosAgentes.Any(a => a.Agente == agente.Value)) || (!agente.HasValue))
                    && ((destino.HasValue && c.Destino == destino.Value) || (!destino.HasValue))
                    select new SolicitudesDeViaticosView
                    {
                        Id = c.Id,
                        Fecha = c.Fecha,
                        OrganismoSolicitante = o.Descripcion,
                        Destino = l.Descripcion + " - " + l.Provincias.Descripcion,
                        FechaDeInicio = c.FechaDeInicio,
                        FechaDeFin = c.FechaDeFin,
                        Estado = e.Descripcion,
                        Identificador = c.Id,
                        Comision = (c.Comision.HasValue ? c.Comision.Value : 0)
                    };
            return (DbQuery<SolicitudesDeViaticosView>)x;
        }

        //public DbQuery<SolicitudesDeViaticosView> ObtenerParaGrillaPorEstado(int? organismo, List<int> estado)
        //{
        //    var x = from c in db.SolicitudesDeViaticos
        //            join o in db.OrganismosRef on c.OrganismoSolicitante equals o.Id
        //            join l in db.LocalidadesRef on c.Destino equals l.Id
        //            join e in db.EstadosDeViaticosRef on c.Estado equals e.Id
        //            where ((organismo.HasValue && c.OrganismoSolicitante == organismo.Value) || !organismo.HasValue)
        //            && estado.Any(est => est == c.Estado)
        //            select new SolicitudesDeViaticosView
        //            {
        //                Id = c.Id,
        //                Fecha = c.Fecha,
        //                OrganismoSolicitante = o.Descripcion,
        //                Destino = l.Descripcion + " - " + l.Provincias.Descripcion,
        //                FechaDeInicio = c.FechaDeInicio,
        //                FechaDeFin = c.FechaDeFin,
        //                Estado = e.Descripcion,
        //                Identificador = c.Id
        //            };
        //    return (DbQuery<SolicitudesDeViaticosView>)x;
        //}

        public bool solapamientoSolicitud(int agente, DateTime desde, DateTime hasta) {

            var res = (from x in db.SolicitudesDeViaticos
                       join a in db.SolicitudesDeViaticosAgentes on x.Id equals a.SolicitudDeViatico
                       where a.Agente == agente && hasta >= x.FechaDeInicio && desde <= x.FechaDeFin && x.Estado != (int)eEstadosDeViaticos.Cancelado_Por_Solicitante
                       select x).ToList();

            return res.Count() > 0;

        }

        public DbQuery<SolicitudesDeViaticosPorComisionView> ObtenerPorComisionGrilla(int? organismo, int? estado)
        {
            var x = (from c in db.SolicitudesDeViaticos
                    join o in db.OrganismosRef on c.OrganismoSolicitante equals o.Id
                    join l in db.LocalidadesRef on c.Destino equals l.Id
                    join e in db.EstadosDeViaticosRef on c.Estado equals e.Id
                    where ((organismo.HasValue && c.OrganismoSolicitante == organismo.Value) || !organismo.HasValue)
                        && ((estado.HasValue && c.Estado == estado.Value) || (!estado.HasValue))
                        && c.Comision.HasValue 
                    select new SolicitudesDeViaticosPorComisionView
                    {
                        Id = c.Comision.Value,
                        Motivo = c.MotivoDeComision,
                        Destino = l.Descripcion + " - " + l.Provincias.Descripcion,
                        FechaDeInicio = c.FechaDeInicio,
                        FechaDeFin = c.FechaDeFin,
                        Estado = e.Descripcion,
                        Comision = c.Comision.Value,
                    }).Distinct();
            return (DbQuery<SolicitudesDeViaticosPorComisionView>)x;
        }

        public void Guardar(SolicitudesDeViaticos Objeto)
		{
			try
			{
				db.SolicitudesDeViaticos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SolicitudesDeViaticos Objeto)
		{
			try
			{
				db.SolicitudesDeViaticos.Attach(Objeto);
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
				SolicitudesDeViaticos Objeto = this.ObtenerPorId(IdObjeto);
				db.SolicitudesDeViaticos.Remove(Objeto);
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

        public DbQuery<SolicitudesDeViaticosCustom> SugerirComisiones(int lugar, DateTime desde)
        {
            var res = from x in db.SolicitudesDeViaticos
                      join l in db.LocalidadesRef on x.Destino equals l.Id
                      where x.Destino == lugar
                      && EntityFunctions.TruncateTime(x.FechaDeInicio) == EntityFunctions.TruncateTime(desde.Date)
                      select new SolicitudesDeViaticosCustom() {
                          Id = x.Id,
                          Destino = x.Destino,
                          Motivo = x.MotivoDeComision,
                          Desde = x.FechaDeInicio,
                          Hasta = x.FechaDeFin,
                          Descripcion_Destino = l.Descripcion,
                          AutoOficial = x.AutoOficial,
                          Patente = x.Patente,
                          Seguro = x.Seguro,
                          VigenciaSeguro = x.VigenciaSeguro,
                          MedioDeTransporte = x.MedioDeTransporte,
                          TipoVehiculo = x.TipoVehiculo,
                          Comision = x.Comision
                      };

            return (DbQuery<SolicitudesDeViaticosCustom>)res;
        }

        //public DbQuery<SolicitudesDeViaticosViewT> JsonT(string term)
        //{
        //	var x = from c in db.SolicitudesDeViaticos
        //			select new SolicitudesDeViaticosViewT
        //			{
        //				 Id = c.Id,
        //				 Fecha = c.Fecha,
        //				 OrganismoSolicitante = c.OrganismoSolicitante,
        //				 Destino = c.Destino,
        //				 FechaDeInicio = c.FechaDeInicio,
        //				 FechaDeFin = c.FechaDeFin,
        //				 MedioDeTransporte = c.MedioDeTransporte,
        //				 AutoOficial = c.AutoOficial,
        //				 ConChofer = c.ConChofer,
        //				 FechaAlta = c.FechaAlta,
        //				 UsuarioAlta = c.UsuarioAlta,
        //				 FechaModifica = c.FechaModifica,
        //				 UsuarioModifica = c.UsuarioModifica,
        //				 Estado = c.Estado,
        //				 MotivoDeComision = c.MotivoDeComision,
        //				 Expediente = c.Expediente,
        //				 Identificador = c.Identificador,
        //			};
        //	return (DbQuery<SolicitudesDeViaticosViewT>)x;
        //}
        /*********************************************
		* Seccion Particular
		* *******************************************/


    }
}
