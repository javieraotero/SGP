using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalQuartz.Owin;

namespace SSO.SGP.Web.Jobs
{
    public class JobScheduler
    {
       
        public static void Start()
        {
           
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail jobRecordatorio = JobBuilder.Create<RecordatorioDeExamenes>()
                .WithIdentity("Envío de recordatorios de Evaluaciones de Concursos", "group1")
                .Build();
       

            ITrigger trigger_Actualizador = TriggerBuilder.Create()
             .WithIdentity("Disparador_Recordatorios", "group1")
             .StartNow()
             .WithSimpleSchedule(x => x
                 .WithIntervalInHours(24)
                 .RepeatForever())
             .Build();

            scheduler.ScheduleJob(jobRecordatorio, trigger_Actualizador);
        
        }
    }
}