/*
 * Creado por SharpDevelop.
 * Usuario: Profe Blasi
 * Fecha: 02/07/2019
 * Hora: 10:26 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Trabajo_Final
{
	/// <summary>
	/// Description of ClsPromociones.
	/// </summary>
	class ClsPromociones
	{
		private string TarjetaPromocion;
		private string BancoPromocion;
		private double PuntosPromocion;
		private double DescuentoPromocion;
		
		public ClsPromociones(string TarjetaPromocion,string BancoPromocion,double PuntosPromocion, double DescuentoPromocion)
		{
			this.TarjetaPromocion=TarjetaPromocion;
			this.BancoPromocion=BancoPromocion;
			this.PuntosPromocion=PuntosPromocion;
			this.DescuentoPromocion=DescuentoPromocion;
		}
		
		public string getBancoPromocion()
		{
			return BancoPromocion;
		}
		public string getTarjetaPromocion()
		{
			return TarjetaPromocion;
		}
		public double getPuntosPromocion()
		{
			return PuntosPromocion;
		}
		public double getDescuentoPromocion()
		{
			return DescuentoPromocion;
		}
	}
}
