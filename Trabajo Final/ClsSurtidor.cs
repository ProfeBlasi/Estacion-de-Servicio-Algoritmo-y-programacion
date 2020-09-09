/*
 * Creado por SharpDevelop.
 * Usuario: Profe Blasi
 * Fecha: 02/07/2019
 * Hora: 10:25 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Trabajo_Final
{
	/// <summary>
	/// Description of ClsSurtidor.
	/// </summary>
	public class ClsSurtidor
	{
		private string numero;
		private string tipoDeCombustible;
		private double remanenteCombustible;
		private double precioPorLitro;
		private bool habilitar;
		private string PlayeroAsignado;
		private double LitrosVendidos;
		private double DineroAhorradoPromocion;
		private double DineroRecaudado;
		public ClsSurtidor(string numero, string tipoDeCosbustible, double remanenteCombustible, double precioPorLitro, bool habilitar, string PlayeroAsignado, double LitrosVendidos, double DineroAhorradoPromocion,double DineroRecaudado)
		{
			this.numero=numero;
			this.tipoDeCombustible=tipoDeCosbustible;
			this.remanenteCombustible=remanenteCombustible;
			this.precioPorLitro=precioPorLitro;
			this.habilitar=habilitar;
			this.PlayeroAsignado=PlayeroAsignado;
			this.LitrosVendidos=LitrosVendidos;
			this.DineroAhorradoPromocion=DineroAhorradoPromocion;
			this.DineroRecaudado=DineroRecaudado;
		}
		public string getTipoDeCombustible()
		{
			return tipoDeCombustible;
		}
		public string getNumeroSurtidor()
		{
			return numero;
		}
		public bool getHabilitar()
		{
			return habilitar;
		}
		public void setHabilitar(bool habilitar)
		{
			this.habilitar=habilitar;
		}
		public void setPlayeroAsignado(string PlayeroAsignado)
		{
			this.PlayeroAsignado=PlayeroAsignado;
		}
		public string getPlayeroAsignado()
		{
			return PlayeroAsignado;
		}
		public double getRemanenteCombustible()
		{
			return remanenteCombustible;
		}
		public void setRemanenteCombustible(double remanenteCombustible)
		{
			this.remanenteCombustible=remanenteCombustible;
		}
		public double getPrecioPorLitro()
		{
			return precioPorLitro;
		}
		public double getLitrosVendidosSurtidor()
		{
			return LitrosVendidos;
		}
		public void setLitrosVendidosSurtidor(double LitrosVendidos)
		{
			this.LitrosVendidos=LitrosVendidos;
		}
		public double getDineroAhorradoPromocion()
		{
			return DineroAhorradoPromocion;
		}
		public void setDineroAhorradoPromocion(double DineroAhorradoPromocion)
		{
			this.DineroAhorradoPromocion=DineroAhorradoPromocion;
		}
		public double getDineroRecaudado()
		{
			return DineroRecaudado;
		}
		public void setDineroRecaudado(double DineroRecaudado)
		{
			this.DineroRecaudado=DineroRecaudado;
		}
	}
}
