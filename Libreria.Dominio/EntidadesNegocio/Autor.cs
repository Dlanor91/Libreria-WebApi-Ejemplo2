using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Libreria.Dominio.EntidadesNegocio
{
	/// <summary>
	/// Entidad POCO (Plain Old CLR Object)
	/// </summary>
	public class Autor:InterfacesEntidades.IValidable, IEquatable<Autor>
	{
		#region Properties
		 
		public string Nombre { get; set; }
		public string Nacionalidad { get; set; }
		public int Id { get ; set ; }

		#endregion
		#region Implementación de interfaces de las Entidades
		public bool Validar()
		{
			return !string.IsNullOrEmpty(Nombre) 
				&& !string.IsNullOrEmpty(Nacionalidad);
		}
		#endregion
		#region Métodos básicos

		public bool Equals([AllowNull] Autor other)
		{
			if (other ==null)
				return false;
			return other.Nombre.ToUpper().Trim()
				.Equals(this.Nombre.ToUpper().Trim());
		}
		public override string ToString()
		{
			return $"({Id}) {Nombre} - {Nacionalidad}";
		}
		#endregion
	}
}
