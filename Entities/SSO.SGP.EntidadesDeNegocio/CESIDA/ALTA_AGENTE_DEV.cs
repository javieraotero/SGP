
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio.CESIDA
{

    public class ALTA_AGENTE_DEV
    {

        public int ID_PERSONA { get; set; }
        public string COD_REVISTA { get; set; }
        //public string CODIGO_PLANTA { get; set; } //no
        public int NRO_JORNADA { get; set; }
        public string FECHA_ALTA { get; set; }
        public int NRO_CONVENIO { get; set; }
        public int NRO_RAMA { get; set; }
        public int NRO_CATEGORIA { get; set; }
        public string COD_JURISDICCION { get; set; }
        public string NRO_UNIDAD_ORG { get; set; }
        public string COD_EMPRESA { get; set; }
        public int NRO_UBICACION { get; set; }
        public int ID_EXTERNO { get; set; }
        public int NRO_FUNCION { get; set; }
        //public string FECHA_APROBACION { get; set; } //NO
        public string FECHA_VIGENCIA_DESDE { get; set; }
        public string FECHA_ALTA_OBRA_SOCIAL { get; set; }
        public int COD_OBRA_SOCIAL { get; set; }
        public string NRO_LEGAJO { get; set; }

    }
}

