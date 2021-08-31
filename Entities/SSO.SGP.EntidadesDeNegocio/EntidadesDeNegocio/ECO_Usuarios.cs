
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{

	//[MetadataTypeAttribute(typeof(TurnosWebParametrosMetaData))]
	[Table("ECO_Usuarios")]
	public partial class ECO_Usuarios
	{
		#region Constructor
		public ECO_Usuarios()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[MaxLength(200)]

		public string Nombre { get; set; }
		[MaxLength(200)]

		public string Apellido { get; set; }
		[MaxLength(200)]
		public string Mail { get; set; }

		[MaxLength(255)]
		public string Password { get; set; }

		public DateTime FechaAlta { get; set; }

		//[NotMapped]
		//public string DecryptedPassword
		//{
		//	get { return Decrypt(Password); }
		//	set { Password = Encrypt(value); }
		//}

		//private string Decrypt(string cipherText)
		//{
		//	return EntityHelper.Decrypt(cipherText);
		//}
		//private string Encrypt(string clearText)
		//{
		//	return EntityHelper.Encrypt(clearText);
		//}

		#endregion

	}
}
