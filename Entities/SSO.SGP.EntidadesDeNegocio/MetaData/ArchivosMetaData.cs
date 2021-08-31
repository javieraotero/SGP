using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ArchivosMetaData
	{

        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }


    }
}
