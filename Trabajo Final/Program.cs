/*
 * Creado por SharpDevelop.
 * Usuario: Profe Blasi
 * Fecha: 02/07/2019
 * Hora: 09:21 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
namespace Trabajo_Final
{
	class Program
	{
		public static ArrayList listaEmpleados=new ArrayList();
		public static ArrayList listaSurtidores= new ArrayList();
		public static ArrayList listaPromociones=new ArrayList();
		public static double AhorroDePromociones=0;
		public static void Main(string[] args)
		{
			
			AgregandoElementosDePrueba();
			Menu();
		}
		public static void Menu()
		{
			string numero_de_opcion="";
			while(numero_de_opcion!="5"){
				PantallaMenuPrincipal();
				numero_de_opcion=Console.ReadLine();
				switch(numero_de_opcion)
				{
					case "1":
						{
							MenuSurtidores();
						}
						break;
					case "2":
						{
							MenuPlayeros();
						}
						break;
					case "3":
						{
							MenuPromociones();
						}
						break;
						
					case "4":
						{
							MenuAdministracion();
						}
						break;
					case "5":
						{
							Console.Clear();
							Console.WriteLine("Gracias por utilizar nuestros servicios"+"\n");
							Console.WriteLine("Para mas informacion comunicarse con profeblasi@gmail.com"+"\n");
							
							PresioneUnaTeclaParaContinuar();
							break;
						}
						
					default:
						{
							Console.WriteLine("La opcion ingresada no es valida,intente nuevamente por favor");
							System.Threading.Thread.Sleep(1000);
							break;
						}
						
				}
			}
		}
		public static bool VerificarSurtidor(int NumeroDeSurtidor)
		{
			bool verificarSurtidor=false;
			try
			{
				verificarSurtidor=((ClsSurtidor)listaSurtidores[NumeroDeSurtidor-1]).getHabilitar();
			}
			catch
			{
				Console.Clear();
				Console.WriteLine("Ha ocurrido un error intentelo nuevamente");
				PresioneUnaTeclaParaContinuar();
				VerificarSurtidor(NumeroDeSurtidor);
			}
			
			if(verificarSurtidor==true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool VerificarPlayeroAsignado(int numeroSurtidor)
		{
			string PlayeroAsignadoAlSurtidor=((ClsSurtidor)listaSurtidores[numeroSurtidor-1]).getPlayeroAsignado();
			bool pruebaDeRonda=false;
			for (int i=0; i<listaEmpleados.Count;i++)
			{
				if(((ClsEmpleado)listaEmpleados[i]).getNombreApellido()==PlayeroAsignadoAlSurtidor)
				{
					pruebaDeRonda=true;
				}
			}
			
			return pruebaDeRonda;
		}
		public static void RealizandoLaCarga(int surtidor)
		{
			double remanenteActual=((ClsSurtidor)listaSurtidores[surtidor-1]).getRemanenteCombustible();
			Console.WriteLine("Cuantos litros desea cargarle, este surtidor tiene un remaente de "+remanenteActual);
			double litrosCargados=IngreseNumeroDou(0);
			if(remanenteActual>=litrosCargados)
			{
				((ClsSurtidor)listaSurtidores[surtidor-1]).setRemanenteCombustible(remanenteActual-litrosCargados);
				double precio=((ClsSurtidor)listaSurtidores[surtidor-1]).getPrecioPorLitro();
				double montoDeLaVenta=litrosCargados*precio;
				Console.WriteLine("El monto de su compra es "+montoDeLaVenta+"$");
				Console.WriteLine("Paga con alguna promocion s/n");
				string FormaDePago=Console.ReadLine();
				string PlayeroAsignadoAlsurtidor=((ClsSurtidor)listaSurtidores[surtidor-1]).getPlayeroAsignado();
				switch(FormaDePago)
				{
					case "n":
						Console.WriteLine("Ud fue atendido por "+PlayeroAsignadoAlsurtidor);
						for (int i=0; i<listaEmpleados.Count;i++)
						{
							string nombreEmpleado=((ClsEmpleado)listaEmpleados[i]).getNombreApellido();
							if(nombreEmpleado==PlayeroAsignadoAlsurtidor)
							{
								double LitrosVendidosActualmentePlayero=((ClsEmpleado)listaEmpleados[i]).getLitrosVendidosPlayero();
								((ClsEmpleado)listaEmpleados[i]).setLitrosVendidosPlayero(LitrosVendidosActualmentePlayero+litrosCargados);
								double RecaudacionActualmente=((ClsEmpleado)listaEmpleados[i]).getRecaudacion();
								((ClsEmpleado)listaEmpleados[i]).setRecaudacion(RecaudacionActualmente+montoDeLaVenta);
							}
							
						}
						double LitrosVendidosActualmenteSurtidor=((ClsSurtidor)listaSurtidores[surtidor-1]).getLitrosVendidosSurtidor();
						((ClsSurtidor)listaSurtidores[surtidor-1]).setLitrosVendidosSurtidor(LitrosVendidosActualmenteSurtidor+litrosCargados);
						double DineroRecaudoPorSurtidor=((ClsSurtidor)listaSurtidores[surtidor-1]).getDineroRecaudado();
						((ClsSurtidor)listaSurtidores[surtidor-1]).setDineroRecaudado(DineroRecaudoPorSurtidor+montoDeLaVenta);
						break;
						
					case "s":
						Console.Clear();
						listarPromociones();
						Console.WriteLine("Con cual promocion desea pagar");
						int Promocion=IngreseNumeroInt(0);
						double puntos=((ClsPromociones)listaPromociones[Promocion-1]).getPuntosPromocion();
						double descuento=((ClsPromociones)listaPromociones[Promocion-1]).getDescuentoPromocion();
						puntos=puntos*litrosCargados;
						double montoConDescuento=montoDeLaVenta*(1-(descuento/100));
						Console.WriteLine("El precio es "+montoConDescuento+" y con esta compra acumulo "+puntos+" puntos");
						for (int i=0; i<listaEmpleados.Count;i++)
						{
							string nombredelEmpleado=((ClsEmpleado)listaEmpleados[i]).getNombreApellido();
							if(nombredelEmpleado==PlayeroAsignadoAlsurtidor)
							{
								double LitrosVendidosActualmentePlayero1=((ClsEmpleado)listaEmpleados[i]).getLitrosVendidosPlayero();
								((ClsEmpleado)listaEmpleados[i]).setLitrosVendidosPlayero(LitrosVendidosActualmentePlayero1+litrosCargados);
								double RecaudacionActualmente1=((ClsEmpleado)listaEmpleados[i]).getRecaudacion();
								((ClsEmpleado)listaEmpleados[i]).setRecaudacion(RecaudacionActualmente1+montoConDescuento);
							}
							
						}
						double LitrosVendidosActualmenteSurtidor1=((ClsSurtidor)listaSurtidores[surtidor-1]).getLitrosVendidosSurtidor();
						((ClsSurtidor)listaSurtidores[surtidor-1]).setLitrosVendidosSurtidor(LitrosVendidosActualmenteSurtidor1+litrosCargados);
						double DineroAhorrado=montoDeLaVenta-montoConDescuento;
						Console.WriteLine("Ud en esta compra se ahorro "+DineroAhorrado+"$ "+"y fue atendido por "+PlayeroAsignadoAlsurtidor);
						AhorroDePromociones=AhorroDePromociones+DineroAhorrado;
						double DineroAhrradoActualementeSurtidor=((ClsSurtidor)listaSurtidores[surtidor-1]).getDineroAhorradoPromocion();
						((ClsSurtidor)listaSurtidores[surtidor-1]).setDineroAhorradoPromocion(DineroAhrradoActualementeSurtidor+DineroAhorrado);
						double DineroRecaudoPorSurtidor1=((ClsSurtidor)listaSurtidores[surtidor-1]).getDineroRecaudado();
						((ClsSurtidor)listaSurtidores[surtidor-1]).setDineroRecaudado(DineroRecaudoPorSurtidor1+montoConDescuento);
						break;
						
					default:
						Console.WriteLine("Ud ha seleccionado una opcion incorrecta, vuelva a intentarlo por favor");
						break;
				}
				Console.WriteLine("Muchas Gracias por elegirnos\nVuelva Pronto");
			}
			else
			{
				Console.WriteLine("Este surtidor no cuenta con esa cantidad de combustible\nAvanece al siguiente");
			}
		}
		public static void MenuSurtidores()
		{
			string opcion_surtidor="";
			while(opcion_surtidor!="6")
			{
				PantallaSubMenuSurtidores();
				opcion_surtidor=Console.ReadLine();
				switch (opcion_surtidor)
				{
					case "0":
						AgregarSurtidor();
						break;
					case "1":
						HabilitarSurtidor();
						//hay que arreglar la excepcion fuera de rango
						break;
					case "2":
						DeshabilitarSurtidor();
						break;
					case "3":
						LitrosVendidos();
						PresioneUnaTeclaParaContinuar();
						break;
					case "4":
						CargarCombustible();
						break;
					case "5":
						PantallaSubMenuListarSurtidores();
						listarSurtidores();
						PresioneUnaTeclaParaContinuar();
						break;
				}
			}
		}
		public static void AgregarSurtidor()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO SURTIDORES   					*****");
			Console.WriteLine("*****					Agregar surtidor					*****");
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("Ingrese el numero del surtidor");
			string numero_surtidor=Console.ReadLine();
			string tipoDeCombustible="";
			string tipoCombustible="NO";
			while(tipoCombustible=="NO")
			{
				Console.WriteLine("Ingrese el tipo de combustible, recuerde que vendemos Infinia, Super, Gas, Kerosene, Diesel");
				tipoDeCombustible=Console.ReadLine();
				switch(tipoDeCombustible)
				{
					case "Infinia":
						tipoCombustible="Infinia";
						break;
					case "Super":
						tipoCombustible="Super";
						break;
					case "Gas":
						tipoCombustible="Gas";
						break;
					case "Kerosene":
						tipoCombustible="Kerosene";
						break;
					default:
						Console.WriteLine("No vendemos ese combustible");
						break;
				}
			}
			
			Console.WriteLine("Ingrese el remanente de combustible");
			double remanente=IngreseNumeroDou(0);
			Console.WriteLine("Ingrese el precio del combustible");
			double precio=IngreseNumeroDou(0);
			string playeroAsignado="";
			double LitrosVendidos=0;
			double DineroAhorradoPromocion=0;
			double DineroRecaudado=0;
			bool existeSurtidor=false;
			for (int i=0; i<listaSurtidores.Count;i++)
			{
				if(numero_surtidor==((ClsSurtidor)listaSurtidores[i]).getNumeroSurtidor())
				{
					existeSurtidor=true;
				}
			}
			//se validan las condiciones de los dni
			if(existeSurtidor==false)
			{
				listaSurtidores.Add(new ClsSurtidor(numero_surtidor,tipoCombustible,remanente,precio,false,playeroAsignado,LitrosVendidos,DineroAhorradoPromocion,DineroRecaudado));
				Console.WriteLine("El surtidor fue registrado con exito");
				Console.WriteLine("Presione una tecla para continuar");
				Console.ReadKey(true);
			}
			if(existeSurtidor==true)
			{
				Console.WriteLine("Ya existe un surtidor registrado con ese codigo");
				Console.WriteLine("Presione una tecla para continuar");
				Console.ReadKey(true);
			}
		}
		public static void HabilitarSurtidor()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO SURTIDORES   					*****");
			Console.WriteLine("*****					Habilitar surtidor   					*****");
			Console.WriteLine("*****************************************************************************************************");
			bool SehaceOnoSeHace=false;
			for (int i=0; i<listaSurtidores.Count;i++)
			{
				bool surtidorHabili_Desabili=((ClsSurtidor)listaSurtidores[i]).getHabilitar();
				if(surtidorHabili_Desabili==false)
				{
					Console.WriteLine("El surtidor "+(i+1)+") se encuentra desahabilitado");
					SehaceOnoSeHace=true;
				}
				else
				{
					Console.WriteLine("El surtidor "+(i+1)+") se encuentra habilitado");
				}
			}
			if(SehaceOnoSeHace==false)
			{
				Console.Clear();
				Console.WriteLine("Todos los surtidores estan habilitados");
				PresioneUnaTeclaParaContinuar();
			}
			else
			{
				Console.WriteLine("Que numero de surtidor desea habilitar");
				int surtidor_habilitado=IngreseNumeroInt(0);
				try
				{
					if(((ClsSurtidor)listaSurtidores[surtidor_habilitado-1]).getHabilitar()==false)
					{
						((ClsSurtidor)listaSurtidores[surtidor_habilitado-1]).setHabilitar(true);
						Console.WriteLine("El surtidor "+surtidor_habilitado+" Fue habilitado");
						PresioneUnaTeclaParaContinuar();
					}
					else
					{
						Console.WriteLine("El surtidor "+surtidor_habilitado+" ya se encontraba habilitado");
						PresioneUnaTeclaParaContinuar();
					}
				}
				catch
				{
					Console.Clear();
					Console.WriteLine("Ha ocurrido un error intentelo nuevamente");
					PresioneUnaTeclaParaContinuar();
					HabilitarSurtidor();
				}
				
			}
		}
		public static void DeshabilitarSurtidor()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO SURTIDORES   					*****");
			Console.WriteLine("*****					Deshabilitar surtidor 					*****");
			Console.WriteLine("*****************************************************************************************************");
			bool SehaceOnoSeHace=false;
			for (int i=0; i<listaSurtidores.Count;i++)
			{
				bool surtidorHabili_Desabili=((ClsSurtidor)listaSurtidores[i]).getHabilitar();
				if(surtidorHabili_Desabili==true)
				{
					Console.WriteLine("El surtidor "+(i+1)+") se encuentra habilitado");
					SehaceOnoSeHace=true;
				}
				else
				{
					Console.WriteLine("El surtidor "+(i+1)+") se encuentra Deshabilitado");
				}
			}
			if(SehaceOnoSeHace==false)
			{
				Console.Clear();
				Console.WriteLine("Todos los surtidores estan deshabilitados");
				PresioneUnaTeclaParaContinuar();
			}
			else
			{
				Console.WriteLine("Que numero de surtidor desea deshabilitar");
				int surtidor_deshabilitado=IngreseNumeroInt(0);
				try
				{
					if(((ClsSurtidor)listaSurtidores[surtidor_deshabilitado-1]).getHabilitar()==true)
					{
						((ClsSurtidor)listaSurtidores[surtidor_deshabilitado-1]).setHabilitar(false);
						Console.WriteLine("El surtidor "+surtidor_deshabilitado+" Fue deshabilitado");
						PresioneUnaTeclaParaContinuar();
					}
					else
					{
						Console.WriteLine("El surtidor "+surtidor_deshabilitado+") ya se encontraba desabilitado");
						PresioneUnaTeclaParaContinuar();
					}
				}
				catch
				{
					Console.Clear();
					Console.WriteLine("Ha ocurrido un error intentelo nuevamente");
					PresioneUnaTeclaParaContinuar();
					DeshabilitarSurtidor();
				}
			}
		}
		public static void LitrosVendidos()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO SURTIDORES   					*****");
			Console.WriteLine("*****					Consultar surtidores		 			*****");
			Console.WriteLine("*****************************************************************************************************");
			double LitrosVendidosTotal=0;
			Console.WriteLine("Listado de surtidores habilitados");
			for (int i=0; i<listaSurtidores.Count;i++)
			{
				bool surtidorHabili_Desabili=((ClsSurtidor)listaSurtidores[i]).getHabilitar();
				string TipoDeCombustible=((ClsSurtidor)listaSurtidores[i]).getTipoDeCombustible();
				if(surtidorHabili_Desabili==true)
				{
					Console.WriteLine("Surtidor ="+(i+1)+" Tipo de combustible "+TipoDeCombustible);
				}
			}
			Console.WriteLine(" ");
			Console.WriteLine("Ingrese el numero de surtidor a consultar: ");
			int surtidorAconsultar=IngreseNumeroInt(0);
			
			try
			{
				double datos=((ClsSurtidor)listaSurtidores[surtidorAconsultar-1]).getLitrosVendidosSurtidor();
				Console.WriteLine("El surtidor "+surtidorAconsultar+" vendio "+datos+" litros de combustible");
			}
			catch
			{
				Console.Clear();
				Console.WriteLine("Ha ocurrido un error intentelo nuevamente");
				PresioneUnaTeclaParaContinuar();
			}
			for (int n = 0; n < listaSurtidores.Count; n++)
			{
				double datoss=((ClsSurtidor)listaSurtidores[n]).getLitrosVendidosSurtidor();
				LitrosVendidosTotal=LitrosVendidosTotal+datoss;
			}
			Console.WriteLine("----------------------------------------------------");
			Console.WriteLine("En total se vendieron "+LitrosVendidosTotal+" litros");
		}
		public static void CargarCombustible()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO SURTIDORES   					*****");
			Console.WriteLine("*****					Cargar combustible		 			*****");
			Console.WriteLine("*****************************************************************************************************");
			listarSurtidoresCarga();
			Console.WriteLine(" ");
			Console.WriteLine("Ingrese el numero de surtidor a ocupar");
			int surtidorAocupar=IngreseNumeroInt(0);
			bool EstaHabilitado=VerificarSurtidor(surtidorAocupar);
			bool TieneUnPlayeroAsignado=VerificarPlayeroAsignado(surtidorAocupar);

			if(EstaHabilitado==false)
			{
				Console.WriteLine("El surtidor esta desabilitado avance al siguiente");
				PresioneUnaTeclaParaContinuar();
			}
			if(TieneUnPlayeroAsignado==false)
			{
				Console.WriteLine("Nadie atiende este surtidor avance al siguiente");
				PresioneUnaTeclaParaContinuar();
			}
			if(EstaHabilitado==true)
				if(TieneUnPlayeroAsignado)
			{
				RealizandoLaCarga(surtidorAocupar);
				PresioneUnaTeclaParaContinuar();
			}
		}
		public static void listarSurtidores()
		{
			for (int n = 0; n < listaSurtidores.Count; n++)
			{
				bool tienePlayeroAsignado=false;
				string tipoDeCombustible=((ClsSurtidor)listaSurtidores[n]).getTipoDeCombustible();
				string numeroSurtidor=((ClsSurtidor)listaSurtidores[n]).getNumeroSurtidor();
				double precioDeCombustible=((ClsSurtidor)listaSurtidores[n]).getPrecioPorLitro();
				string playeroAsignado=((ClsSurtidor)listaSurtidores[n]).getPlayeroAsignado();
				for (int i = 0; i < listaEmpleados.Count; i++)
				{
					string NombreDelPlayero=((ClsEmpleado)listaEmpleados[i]).getNombreApellido();
					if(NombreDelPlayero==playeroAsignado)
					{
						tienePlayeroAsignado=true;
					}
				}
				if(tienePlayeroAsignado==false)
				{
					Console.WriteLine("El surtidor "+(n+1)+" vende "+tipoDeCombustible+" a "+precioDeCombustible+"$ pero no tiene un playero asignado");
				}
				if(tienePlayeroAsignado==true)
				{
					Console.WriteLine("El surtidor "+(n+1)+" vende "+tipoDeCombustible+" a "+precioDeCombustible+"$ y es atendido por "+playeroAsignado);
				}
			}
		}
		public static void listarSurtidoresCarga()
		{
			for (int n = 0; n < listaSurtidores.Count; n++)
			{
				bool tienePlayeroAsignado=false;
				string tipoDeCombustible=((ClsSurtidor)listaSurtidores[n]).getTipoDeCombustible();
				string numeroSurtidor=((ClsSurtidor)listaSurtidores[n]).getNumeroSurtidor();
				double precioDeCombustible=((ClsSurtidor)listaSurtidores[n]).getPrecioPorLitro();
				string playeroAsignado=((ClsSurtidor)listaSurtidores[n]).getPlayeroAsignado();
				bool habilitado=((ClsSurtidor)listaSurtidores[n]).getHabilitar();
				for (int i = 0; i < listaEmpleados.Count; i++)
				{
					string NombreDelPlayero=((ClsEmpleado)listaEmpleados[i]).getNombreApellido();
					if(NombreDelPlayero==playeroAsignado)
					{
						tienePlayeroAsignado=true;
					}
				}
				if(tienePlayeroAsignado==false)
				{
					if(habilitado==true)
					{
						Console.WriteLine("El surtidor "+(n+1)+" vende "+tipoDeCombustible+" a "+precioDeCombustible+"$ pero no tiene un playero asignado y el surtidor se encuentra habilitado");
					}
					if(habilitado==false)
					{
						Console.WriteLine("El surtidor "+(n+1)+" vende "+tipoDeCombustible+" a "+precioDeCombustible+"$ pero no tiene un playero asignado y el surtidor se encuentra deshabilitado");
					}
				}
				if(tienePlayeroAsignado==true)
				{
					if(habilitado==true)
					{
						Console.WriteLine("El surtidor "+(n+1)+" vende "+tipoDeCombustible+" a "+precioDeCombustible+"$ y es atendido por "+playeroAsignado+" y el surtidor se encuentra habilitado");
					}
					if(habilitado==false)
					{
						Console.WriteLine("El surtidor "+(n+1)+" vende "+tipoDeCombustible+" a "+precioDeCombustible+"$ y es atendido por "+playeroAsignado+" y el surtidor se encuentra deshabilitado");
					}
				}
			}
		}
		public static void MenuPlayeros()
		{
			string opcion_playero="";
			while(opcion_playero!="5")
			{
				PantallaSubMenuPlayeros();
				opcion_playero=Console.ReadLine();
				switch (opcion_playero)
				{
					case "1":
						{
							AltaPlayero();
						}
						break;
					case "2":
						{
							BajaPlayero();
						}
						break;

					case "3":
						AsignarPlayeroAUnSurtidor();
						break;
					case "4":
						PantallaSubmenuListarPlayeros();
						listarPlayeros();
						PresioneUnaTeclaParaContinuar();
						break;
					case "5":
						break;
					default:
						Console.WriteLine("La opcion ingresada no es valida,intente nuevamente por favor");
						System.Threading.Thread.Sleep(1000);
						break;
				}

			}
		}
		public static void AltaPlayero()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO PLAYEROS   					*****");
			Console.WriteLine("*****				   	Alta de playero   					*****");
			Console.WriteLine("*****************************************************************************************************");
			
			Console.WriteLine("Ingrese el nombre y apellido del empleado");
			string nombreEmpleado=Console.ReadLine();
			Console.WriteLine("Ingrese el dni del empleado");
			int dniEmpleado=IngreseNumeroInt(0);
			Console.WriteLine("Ingrese el horario de trabajo, se recomienda el formato 14:00 a 22:00hs por ej.");
			string horarioDelEmpleado=Console.ReadLine();
			Console.WriteLine(" ");
			double Recaudacion=0;
			double LitrosVendidosPlayero=0;
			//Validacion del empleado existe
			bool existePlayero=false;
			for (int i=0; i<listaEmpleados.Count;i++)
			{
				if(dniEmpleado==((ClsEmpleado)listaEmpleados[i]).getDniEmpleado())
				{
					existePlayero=true;
				}
			}
			//se validan las condiciones de los dni
			if(existePlayero==false)
			{
				Console.WriteLine("El empleado fue registrado con exito");
				Console.WriteLine(" ");
				Console.WriteLine("Presione una tecla para continuar");
				Console.ReadKey(true);
				listaEmpleados.Add(new ClsEmpleado(nombreEmpleado,dniEmpleado,horarioDelEmpleado,Recaudacion,LitrosVendidosPlayero));
			}
			if(existePlayero==true)
			{
				Console.WriteLine("Ya existe un empelado con ese dni");
				Console.WriteLine(" ");
				Console.WriteLine("Presione una tecla para continuar");
				Console.ReadKey(true);
			}
		}
		public static void BajaPlayero()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO PLAYEROS   					*****");
			Console.WriteLine("*****				   	Baja de playero   					*****");
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("LIstado de playeros");
			listarPlayeros();
			Console.WriteLine(" ");
			Console.WriteLine("Ingrese el numero del empleado que quiere dar de baja");
			int empleado_baja=IngreseNumeroInt(0);
			if((empleado_baja>0)&&(empleado_baja<=listaEmpleados.Count))
			{
				for (int i=0; i<=listaEmpleados.Count;i++)
				{
					if(empleado_baja==i)
					{
						try
						{
							listaEmpleados.RemoveAt(i-1);
						}
						catch
						{
							Console.Clear();
							Console.WriteLine("Ha ocurido un error intentelo nuevamente");
							BajaPlayero();
						}
						Console.WriteLine(" ");
						Console.WriteLine("El empleado fue retirado de la lista");
					}
				}
				Console.WriteLine(" ");
				Console.WriteLine("Listado de playeros actualizados");
				Console.WriteLine(" ");
				listarPlayerosActualizados();
				Console.WriteLine(" ");
				PresioneUnaTeclaParaContinuar();
			}
			else
			{
				Console.WriteLine("No existe ese empleado, vuelva a intentarlo por favor");
				PresioneUnaTeclaParaContinuar();
			}
		}
		public static void AsignarPlayeroAUnSurtidor()
		{
			Console.Clear();
			Console.WriteLine("Listado de Playeros");
			for (int i=0; i<listaEmpleados.Count;i++)
			{
				string datos=i+1+") "+((ClsEmpleado)listaEmpleados[i]).getNombreApellido();
				Console.WriteLine(datos);
			}
			Console.WriteLine(" ");
			Console.WriteLine("Ingrese el nro del playero");
			int playero_selecionado=IngreseNumeroInt(0);
			Console.WriteLine(" ");
			Console.WriteLine("Ingrese numero del surtidor a asignarlo");
			for (int i=0; i<listaSurtidores.Count;i++)
			{
				string datos=i+1+") "+((ClsSurtidor)listaSurtidores[i]).getNumeroSurtidor();
				Console.WriteLine(datos);
			}
			int surtidorSeleccionado=IngreseNumeroInt(0);
			try
			{
				((ClsSurtidor)listaSurtidores[surtidorSeleccionado-1]).setPlayeroAsignado(((ClsEmpleado)listaEmpleados[playero_selecionado-1]).getNombreApellido());
				
			}
			catch
			{
				Console.Clear();
				Console.WriteLine("Ha ocurido un error intentelo nuevamente");
				PresioneUnaTeclaParaContinuar();
				AsignarPlayeroAUnSurtidor();
			}
			Console.WriteLine(" ");
			string prueba="El surtidor "+((ClsSurtidor)listaSurtidores[surtidorSeleccionado-1]).getNumeroSurtidor()+" es atendido por "+((ClsEmpleado)listaEmpleados[playero_selecionado-1]).getNombreApellido();
			Console.WriteLine(prueba);
			Console.WriteLine(" ");
			PresioneUnaTeclaParaContinuar();
		}
		public static void listarPlayeros()
		{
			Console.WriteLine("Listado de playeros");
			Console.WriteLine(" ");
			for (int i=0; i<listaEmpleados.Count;i++)
			{
				string datos=i+1+") "+((ClsEmpleado)listaEmpleados[i]).getNombreApellido();
				Console.WriteLine(datos);
			}
			Console.WriteLine(" ");
		}
		public static void listarPlayerosActualizados()
		{
			for (int i=0; i<listaEmpleados.Count;i++)
			{
				string datos=((ClsEmpleado)listaEmpleados[i]).getNombreApellido();
				Console.WriteLine(datos);
			}
		}
		public static void MenuPromociones()
		{
			string opcion_promociones="";
			while(opcion_promociones!="4")
			{
				PantallaSubmenuPromociones();
				opcion_promociones=Console.ReadLine();
				switch (opcion_promociones)
				{
					case "1":
						AltaPromocion();
						break;
						
					case "2":
						BajaPromocion();
						break;
						
					case "3":
						SubMenuListadoPromociones();
						listarPromociones();
						PresioneUnaTeclaParaContinuar();
						break;
					case "4":
						break;
					default:
						Console.WriteLine("La opcion ingresada no es valida,intente nuevamente por favor");
						System.Threading.Thread.Sleep(1000);
						break;
				}
			}
		}
		public static void AltaPromocion()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO PROMOCIONES   					*****");
			Console.WriteLine("*****					 Dar de alta una promocion   				*****");
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("Ingrese el tipo de promocion <1-puntos> o <2-descuentos>");
			int tipoDePromocion=IngreseNumeroInt(0);
			switch(tipoDePromocion)
			{
				case 1:
					{
						Console.WriteLine("Ingrese la tarjeta de credito");
						string TarjetaDeCredito=Console.ReadLine();
						Console.WriteLine("Ingrese de que banco es la tarjeta");
						string BancoDeLaTarjeta=Console.ReadLine();
						Console.WriteLine("Ingrese cantidad de puntos a sumar por litro cargado");
						int PuntosPorLitroCargado=IngreseNumeroInt(0);
						double Descuento=0;
						listaPromociones.Add(new ClsPromociones(TarjetaDeCredito,BancoDeLaTarjeta,PuntosPorLitroCargado,Descuento));
						Console.WriteLine("La promocion fue dada de alta correctamente");
						PresioneUnaTeclaParaContinuar();
						break;
					}
				case 2:
					{
						Console.WriteLine("Ingrese la tarjeta de credito");
						string TarjetaDeCredito=Console.ReadLine();
						Console.WriteLine("Ingrese de que banco es la tarjeta");
						string BancoDeLaTarjeta=Console.ReadLine();
						Console.WriteLine("Ingrese cel descuento que se va a aplicar");
						double Descuento=IngreseNumeroDou(0);
						int PuntosPromocion=0;
						listaPromociones.Add(new ClsPromociones(TarjetaDeCredito,BancoDeLaTarjeta,PuntosPromocion,Descuento));
						Console.WriteLine("La promocion fue dada de alta correctamente");
						PresioneUnaTeclaParaContinuar();
						break;
					}
				default:
					{
						Console.WriteLine("Ese tipo de promocion no esta disponible, intente nuevamente");
						PresioneUnaTeclaParaContinuar();
						break;
					}
			}
		}
		public static void BajaPromocion()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO PROMOCIONES   					*****");
			Console.WriteLine("*****				 	Dar de BAJA una promocion   				*****");
			Console.WriteLine("*****************************************************************************************************");
			listarPromociones();
			Console.WriteLine(" ");
			Console.WriteLine("Ingrese el numero de promocion que quiere dar de baja");
			int promocion_baja=IngreseNumeroInt(0);
			if((promocion_baja>0)&&(promocion_baja<=listaPromociones.Count))
			{
				for (int i=0; i<=listaPromociones.Count;i++)
				{
					if(promocion_baja==i)
					{
						try
						{
							listaPromociones.RemoveAt(i-1);
							Console.WriteLine(" ");
							Console.WriteLine("Listado de promociones actualizada");
							listarPromociones();
						}
						catch
						{
							Console.Clear();
							Console.WriteLine("Ha ocurrido un error intentelo nuevamente");
							PresioneUnaTeclaParaContinuar();
						}
						Console.WriteLine("La promocion fue retirada de la lista");
					}
				}
			}
			else
			{
				Console.WriteLine("No existe esa promocion");
			}
			PresioneUnaTeclaParaContinuar();
		}
		public static void SubMenuListadoPromociones()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO PROMOCIONES   					*****");
			Console.WriteLine("*****			 	Listar todas las promociones 					*****");
			Console.WriteLine("*****************************************************************************************************");
		}
		public static void listarPromociones()
		{
			Console.WriteLine("Listado de promociones vigentes");
			Console.WriteLine(" ");
			for (int i=0; i<listaPromociones.Count;i++)
			{
				double descuentos=((ClsPromociones)listaPromociones[i]).getDescuentoPromocion();
				double Puntos=((ClsPromociones)listaPromociones[i]).getPuntosPromocion();
				string banco=((ClsPromociones)listaPromociones[i]).getBancoPromocion();
				string tarjeta=((ClsPromociones)listaPromociones[i]).getTarjetaPromocion();
				if(descuentos==0)
				{
					Console.WriteLine(i+1+") Suma "+Puntos+" puntos por cada litro cargado con "+tarjeta+" "+banco);
				}
				else
				{
					Console.WriteLine(i+1+") "+descuentos+"% de descuento con "+tarjeta+" "+banco);
				}
			}
		}
		public static void MenuAdministracion()
		{
			string opcion_administracion="";
			while(opcion_administracion!="6")
			{
				PantallaSubmenuAdminstracion();
				opcion_administracion=Console.ReadLine();
				switch (opcion_administracion)
				{
					case "1":
						RecaudacionFinalDeLaEstacion();
						PresioneUnaTeclaParaContinuar();
						break;
						
					case "2":
						RecaudacionDeUnSurtidor();
						PresioneUnaTeclaParaContinuar();
						break;
						
					case "3":
						RecaudacionDeUnPlayero();
						PresioneUnaTeclaParaContinuar();
						break;
					case "4":
						CantidaDeLitosVendidos();
						PresioneUnaTeclaParaContinuar();
						break;
					case "5":
						DescuentoConPromociones();
						PresioneUnaTeclaParaContinuar();
						break;
					case "6":
						break;
					default:
						Console.WriteLine("La opcion ingresada no es valida,intente nuevamente por favor");
						System.Threading.Thread.Sleep(1000);
						break;
				}
			}
		}
		public static void RecaudacionFinalDeLaEstacion()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO ADMINISTRACION   				*****");
			Console.WriteLine("*****				 	Recaudacion final de la estacion   			*****");
			Console.WriteLine("*****************************************************************************************************");
			
			double RecaudacionFinal=0;
			for (int n = 0; n < listaSurtidores.Count; n++)
			{
				double datos=((ClsSurtidor)listaSurtidores[n]).getDineroRecaudado();
				RecaudacionFinal=RecaudacionFinal+datos;
			}
			Console.WriteLine("----------------------------------------------------");
			Console.WriteLine("Recaudacion final de la estacion "+RecaudacionFinal+"$");
		}
		public static void RecaudacionDeUnSurtidor()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO ADMINISTRACION   				*****");
			Console.WriteLine("*****			 		Recaudacion de surtidores   				*****");
			Console.WriteLine("*****************************************************************************************************");
			
			for (int n = 0; n < listaSurtidores.Count; n++)
			{
				double datos=((ClsSurtidor)listaSurtidores[n]).getDineroRecaudado();
				Console.WriteLine("El surtidor "+(n+1)+" recaudo "+datos+"$");
			}
			
		}
		public static void RecaudacionDeUnPlayero()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO ADMINISTRACION    				*****");
			Console.WriteLine("*****			 		Recaudacion de los playeros 				*****");
			Console.WriteLine("*****************************************************************************************************");
			
			for (int n = 0; n < listaEmpleados.Count; n++)
			{
				double datos=((ClsEmpleado)listaEmpleados[n]).getRecaudacion();
				Console.WriteLine("El Playero "+(n+1)+" recaudo "+datos+"$");
			}
			
			
		}
		public static void CantidaDeLitosVendidos()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				MODULO ADMINISTRACION    					*****");
			Console.WriteLine("*****				Cantidad de litros vendidos					*****");
			Console.WriteLine("*****************************************************************************************************");
			
			double litrosVendidos=0;
			for (int n = 0; n < listaSurtidores.Count; n++)
			{
				double datos=((ClsSurtidor)listaSurtidores[n]).getLitrosVendidosSurtidor();
				litrosVendidos=litrosVendidos+datos;
			}
			Console.WriteLine("----------------------------------------------------");
			Console.WriteLine("Se vendieron "+litrosVendidos+" litros de combustible");
		}
		public static void DescuentoConPromociones()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO ADMINISTRACION    				*****");
			Console.WriteLine("*****		Monto total descontado correspondiente a ventas con promociones			*****");
			Console.WriteLine("*****************************************************************************************************");
			for (int n = 0; n < listaSurtidores.Count; n++)
			{
				double datos=((ClsSurtidor)listaSurtidores[n]).getDineroAhorradoPromocion();
				Console.WriteLine("El surtidor "+(n+1)+")"+" ahorro "+datos+"$ con promociones");
			}
			Console.WriteLine("----------------------------------------------------");
			Console.WriteLine("La gente se ahorro "+AhorroDePromociones+"$");
		}
		public static void PantallaMenuPrincipal()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****					ESTACION DE SERVICIO					*****");
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("Seleccione una opcion: ");
			Console.WriteLine();
			Console.WriteLine("1-Surtidores");
			Console.WriteLine("2-Playeros");
			Console.WriteLine("3-Promociones");
			Console.WriteLine("4-Administracion");
			Console.WriteLine("5-Salir");
		}
		public static void PantallaSubMenuSurtidores()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO SURTIDORES   					*****");
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("Seleccione una opcion: ");
			Console.WriteLine();
			Console.WriteLine("0-Agregar surtidor");
			Console.WriteLine("1-Habilitar surtidor");
			Console.WriteLine("2-Deshabilitar surtidor");
			Console.WriteLine("3-Ver la cantidad de litros vendidos");
			Console.WriteLine("4-Cargar combustible");
			Console.WriteLine("5-Listar todos los surtidores");
			Console.WriteLine("6-Volver");
		}
		public static void PantallaSubMenuListarSurtidores()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO SURTIDORES   					*****");
			Console.WriteLine("*****				Listar todos los surtidores		 			*****");
			Console.WriteLine("*****************************************************************************************************");
		}
		public static void PantallaSubmenuListarPlayeros()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO PLAYEROS   					*****");
			Console.WriteLine("*****			 	Listar todos los playeros 			*****");
			Console.WriteLine("*****************************************************************************************************");
		}
		public static void PantallaSubMenuPlayeros()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO PLAYEROS   					*****");
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("Seleccione una opcion: ");
			Console.WriteLine();
			Console.WriteLine("1-Dar de alta un playero");
			Console.WriteLine("2-Dar de baja un playero");
			Console.WriteLine("3-Asignar playero a un surtidor");
			Console.WriteLine("4-Listar todos los playeros");
			Console.WriteLine("5-volver");
		}
		public static void PantallaSubmenuPromociones()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO PROMOCIONES   					*****");
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("Seleccione una opcion: ");
			Console.WriteLine();
			Console.WriteLine("1-Dar de alta una promocion");
			Console.WriteLine("2-Dar de baja una promocion");
			Console.WriteLine("3-Listar todas las promociones");
			Console.WriteLine("4-Volver");
		}
		public static void PantallaSubmenuAdminstracion()
		{
			Console.Clear();
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("*****				   	MODULO ADMINISTRACION  					*****");
			Console.WriteLine("*****************************************************************************************************");
			Console.WriteLine("Seleccione una opcion: ");
			Console.WriteLine();
			Console.WriteLine("1-Recaudacion final de la estacion");
			Console.WriteLine("2-Recaudacion de un surtidor");
			Console.WriteLine("3-Recaudacion de una playero");
			Console.WriteLine("4-Ver la cantidad de litros vendidos");
			Console.WriteLine("5-Monto total descontado correspondiente a ventas con promociones");
			Console.WriteLine("6-Volver");
		}
		public static int IngreseNumeroInt(int numero)
		{
			int r=0;
			try
			{
				numero=int.Parse(Console.ReadLine());
			}
			catch(Exception)
			{
				Console.WriteLine("Ha ocurrido un error, intente ingresar el numero nuevamente");
				r=IngreseNumeroInt(numero);
				return r;
			}
			return numero;
		}
		public static double IngreseNumeroDou(double numero)
		{
			double r=0;
			try
			{
				string Ingresado=Console.ReadLine();
				numero=Convert.ToDouble(Ingresado);
				
			}
			catch(Exception)
			{
				Console.WriteLine("Ha ocurrido un error, intente ingresar el numero nuevamente");
				r=IngreseNumeroDou(numero);
			}
			return numero;
			
		}
		public static void PresioneUnaTeclaParaContinuar()
		{
			Console.WriteLine("Preione una tecla para continuar");
			Console.ReadKey();
		}
		public static void AgregandoElementosDePrueba()
		{
			listaEmpleados.Add(new ClsEmpleado("Claudio Flores",24880143,"06:00 a 14:00hs",0,0));
			listaEmpleados.Add(new ClsEmpleado("Horacio Blasi",12824119,"14:00 a 22:00hs",0,0));
			listaEmpleados.Add(new ClsEmpleado("Facundo Blasi",39748371,"22:00 a 06:00hs",0,0));
			listaEmpleados.Add(new ClsEmpleado("Alejandra Flores",34440982,"06:00 A 14:00hs",0,0));
			listaEmpleados.Add(new ClsEmpleado("Ezequiel Blasi",33982034,"14:00 a 22:00hs",0,0));
			listaSurtidores.Add(new ClsSurtidor("1","Infinia",400,49.50,false,"Claudio Flores",0,0,0));
			listaSurtidores.Add(new ClsSurtidor("2","Super",200,42.30,true,"Pablo",0,0,0));
			listaSurtidores.Add(new ClsSurtidor("3","Ultra Diesel",11,19.99,true,"Jorge",0,0,0));
			listaSurtidores.Add(new ClsSurtidor("4","Infinia Diesel",100,43.50, false,"Tomas Aquino",0,0,0));
			listaPromociones.Add(new ClsPromociones("Serviclub","YPF",150,0));
			listaPromociones.Add(new ClsPromociones("Visa","Banco Provincia",0,15.0));
			listaPromociones.Add(new ClsPromociones("Club","La Nacion",300,0));
			
		}
		public static void infoParaCargar()
		{
			for (int i = 0; i < listaSurtidores.Count; i++)
			{
				bool surtidorHabili_Desabili=((ClsSurtidor)listaSurtidores[i]).getHabilitar();
				string playeroAsignadoAlSurtidor=((ClsSurtidor)listaSurtidores[i]).getPlayeroAsignado();
				if(surtidorHabili_Desabili==false)
				{
					Console.WriteLine("El surtido "+(i+1)+" Esta desahabilitado y es atendido por "+playeroAsignadoAlSurtidor);
				}
				else
				{
					Console.WriteLine("El surtido "+(i+1)+" Esta habilitado y es atendido por "+playeroAsignadoAlSurtidor);
				}
			}
		}
	}
}