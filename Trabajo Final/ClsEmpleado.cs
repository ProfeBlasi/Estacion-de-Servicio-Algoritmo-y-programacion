/*
 * Creado por SharpDevelop.
 * Usuario: Profe Blasi
 * Fecha: 02/07/2019
 * Hora: 10:24 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Trabajo_Final
{
	/// <summary>
	/// Description of ClsEmpleado.
	/// </summary>
	public class ClsEmpleado
	{
		private string NombreApellido;
		private int Dni;
		private string Horario;
		private double Recaudacion;
		private double LitrosVendidosPlayero;
		
		public ClsEmpleado(string NombreApellido,int Dni,string Horario, double Recaudacion, double LitrosVendidosPlayero)
		{
			this.NombreApellido=NombreApellido;
			this.Dni=Dni;
			this.Horario=Horario;
			this.Recaudacion=Recaudacion;
			this.LitrosVendidosPlayero=LitrosVendidosPlayero;
		}
		public int getDniEmpleado()
		{
			return Dni;
		}
		public string getNombreApellido()
		{
			return NombreApellido;
		}
		public double getRecaudacion()
		{
			return Recaudacion;
		}
		public void setRecaudacion(double Recaudacion)
		{
			this.Recaudacion=Recaudacion;
		}
		public double getLitrosVendidosPlayero()
		{
			return LitrosVendidosPlayero;
		}
		public void setLitrosVendidosPlayero(double LitrosVendidosPlayero)
		{
			this.LitrosVendidosPlayero=LitrosVendidosPlayero;
		}
	}

}
