
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
	public partial class FeriasAgentesAD
	{
		private BDEntities db = new BDEntities();

		public FeriasAgentes ObtenerPorId(int Id)
		{
			return db.FeriasAgentes.Single(c => c.Id == Id);
		}

		public DbQuery<FeriasAgentes> ObtenerTodo()
		{
			return (DbQuery<FeriasAgentes>)db.FeriasAgentes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.FeriasAgentes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FeriasAgentesView> ObtenerParaGrilla()
		{
			var x = from c in db.FeriasAgentes
					select new FeriasAgentesView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Feria = c.Feria,
						 Dias = c.Dias,
						 Desde1 = c.Desde1,
						 Desde2 = c.Desde2,
						 Desde3 = c.Desde3,
						 Hasta1 = c.Hasta1,
						 Hasta2 = c.Hasta2,
						 Hasta3 = c.Hasta3,
						 Instancia = c.Instancia,
					};
			return (DbQuery<FeriasAgentesView>)x;
		}

		public void Guardar(FeriasAgentes Objeto, int Dias, bool SinEfecto)
		{
			try
			{

                int c = (from x in db.FeriasAgentes 
                        where x.Agente == Objeto.Agente
                        && x.Feria == Objeto.Feria
                        && x.Instancia == Objeto.Instancia
                        select x).Count();

                //es la primera vez que se carga la instancia
                if (c == 0) {

				    db.FeriasAgentes.Add(Objeto);
				    db.SaveChanges();

                    var anio = (from x in db.FeriasRef
                                where x.Id == Objeto.Feria
                                select x).FirstOrDefault().Anio;

                    var saldo = db.LicenciasOrdinariasIniciales.Where(s => s.Anio == anio && s.Agente == Objeto.Agente).FirstOrDefault();


                    // El agente no tiene saldo para el año.
                    if (saldo == null)
                    {

                        saldo = new LicenciasOrdinariasIniciales()
                        {
                            Agente = Objeto.Agente,
                            Anio = Objeto.Ferias.Anio,
                            Fecha = DateTime.Now,
                            FechaAlta = DateTime.Now,
                            FechaModifica = DateTime.Now,
                            Saldo = Objeto.Dias,
                            UsuarioAlta = 4130,
                            UsuarioModifica = 4130
                        };

                        //Se marco como sin efecto por primera vez
                        if (SinEfecto && !Objeto.SinEfecto)
                        {
                            saldo.Saldo = saldo.Saldo - Dias;
                            Objeto.Observaciones = "/SIN EFECTO";
                            Objeto.SinEfecto = true;
                        }

                        // Viene SIN MARCAR sin efecto y no estaba marcado sin efecto
                        if (!SinEfecto && !Objeto.SinEfecto)
                            saldo.Saldo = saldo.Saldo - Dias + Objeto.Dias;

                        //Viene sin efecto y estaba marcado sin efecto
                        if (!SinEfecto && Objeto.SinEfecto)
                        {
                            saldo.Saldo = saldo.Saldo + Objeto.Dias;
                            Objeto.Observaciones = Objeto.Observaciones.Replace("/SIN EFECTO", "");
                            Objeto.SinEfecto = false;
                        }

                        db.FeriasAgentes.Attach(Objeto);
                        db.Entry(Objeto).State = EntityState.Modified;
                        db.SaveChanges();

                        db.LicenciasOrdinariasIniciales.Add(saldo);
                        db.SaveChanges();
                    }
                    else {
                        //el agente tiene saldo

                        //Si es paso 2 -> hay que rectificar el paso 1
                        if (Objeto.Instancia == 2)
                        {

                            var paso1 = (from x in db.FeriasAgentes
                                         where x.Agente == Objeto.Agente
                                         && x.Instancia == 1
                                         && x.Feria == Objeto.Feria
                                         select x).FirstOrDefault();

                            if (paso1 != null)
                            {
                                if (paso1.Dias != Objeto.Dias)
                                {
                                    saldo.Saldo = saldo.Saldo - paso1.Dias + Objeto.Dias;
                                    saldo.FechaModifica = DateTime.Now;
                                    saldo.UsuarioModifica = 4130;
                                }
                            }
                            else
                            {
                                saldo.Saldo = saldo.Saldo + Objeto.Dias;
                                saldo.FechaModifica = DateTime.Now;
                                saldo.UsuarioModifica = 4130;
                            }
                        }
                        else
                        {
                            saldo.Saldo = saldo.Saldo + Objeto.Dias;
                            saldo.FechaModifica = DateTime.Now;
                            saldo.UsuarioModifica = 4130;
                        }

                        //Se marco como sin efecto por primera vez
                        if (SinEfecto && !Objeto.SinEfecto)
                        {
                            saldo.Saldo = saldo.Saldo - Dias;
                            Objeto.Observaciones = "/SIN EFECTO";
                            Objeto.SinEfecto = true;
                        }

                        // Viene SIN MARCAR sin efecto y no estaba marcado sin efecto
                        if (!SinEfecto && !Objeto.SinEfecto)
                            saldo.Saldo = saldo.Saldo - Dias + Objeto.Dias;

                        //Viene sin efecto y estaba marcado sin efecto
                        if (!SinEfecto && Objeto.SinEfecto)
                        {
                            saldo.Saldo = saldo.Saldo + Objeto.Dias;
                            Objeto.Observaciones = Objeto.Observaciones.Replace("/SIN EFECTO", "");
                            Objeto.SinEfecto = false;
                        }

                        db.FeriasAgentes.Attach(Objeto);
                        db.Entry(Objeto).State = EntityState.Modified;
                        db.SaveChanges();

                        db.LicenciasOrdinariasIniciales.Attach(saldo);
                        db.Entry(saldo).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }

			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FeriasAgentes Objeto, int Dias, bool SinEfecto)
		{
			try
			{

                //var fa = db.FeriasAgentes.Where(f=>f.Id == Objeto.Id).FirstOrDefault();

                var anio = (from x in db.FeriasRef
                            where x.Id == Objeto.Feria
                            select x).FirstOrDefault().Anio;

                var saldo = db.LicenciasOrdinariasIniciales.Where(s => s.Anio == anio && s.Agente == Objeto.Agente).FirstOrDefault();

                //Se marco como sin efecto por primera vez
                if (SinEfecto && !Objeto.SinEfecto)
                {
                    saldo.Saldo = saldo.Saldo - Dias;
                    Objeto.Observaciones = "/SIN EFECTO";
                    Objeto.SinEfecto = true;
                }
                
                // Viene SIN MARCAR sin efecto y no estaba marcado sin efecto
                if (!SinEfecto && !Objeto.SinEfecto)
                   saldo.Saldo = saldo.Saldo - Dias + Objeto.Dias;

                //Viene sin efecto y estaba marcado sin efecto
                if (!SinEfecto && Objeto.SinEfecto)
                {
                    saldo.Saldo = saldo.Saldo + Objeto.Dias;
                    Objeto.Observaciones = Objeto.Observaciones.Replace("/SIN EFECTO", "");
                    Objeto.SinEfecto = false;
                }

                db.LicenciasOrdinariasIniciales.Attach(saldo);
                db.Entry(saldo).State = EntityState.Modified;
                db.SaveChanges();

				db.FeriasAgentes.Attach(Objeto);
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
				FeriasAgentes Objeto = this.ObtenerPorId(IdObjeto);
				db.FeriasAgentes.Remove(Objeto);
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

		public DbQuery<FeriasAgentesViewT> JsonT(string term)
		{
			var x = from c in db.FeriasAgentes
					select new FeriasAgentesViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Feria = c.Feria,
						 Dias = c.Dias,
						 Desde1 = c.Desde1,
						 Desde2 = c.Desde2,
						 Desde3 = c.Desde3,
						 Hasta1 = c.Hasta1,
						 Hasta2 = c.Hasta2,
						 Hasta3 = c.Hasta3,
						 Instancia = c.Instancia,
					};
			return (DbQuery<FeriasAgentesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
