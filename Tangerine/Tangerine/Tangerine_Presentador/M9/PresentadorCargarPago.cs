﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M9;
using DominioTangerine;
using LogicaTangerine;

namespace Tangerine_Presentador.M9
{
   public class PresentadorCargarPago
    {
        IContratoCargarPago vista;

        public PresentadorCargarPago(IContratoCargarPago vista)
        {
            this.vista = vista;
        }
    
   public void LlenarPorId (int numeroFactura)
        {
            DominioTangerine.Entidades.M8.Facturacion fact =
                    (DominioTangerine.Entidades.M8.Facturacion)DominioTangerine.Fabrica.FabricaEntidades.ObtenerFacturacion();
            fact.Id = numeroFactura;

            Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarXIdFactura(fact);
            Entidad facturaPagar = comando.Ejecutar();

            DominioTangerine.Entidades.M4.CompaniaM4 compania =
                (DominioTangerine.Entidades.M4.CompaniaM4)DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaVacia();

            compania.Id = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).idCompaniaFactura;

            Comando<Entidad> comandoCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(compania);
            Entidad companiaPagar = comandoCompania.Ejecutar();

            try
            {
                vista.cliente = ((DominioTangerine.Entidades.M4.CompaniaM4)companiaPagar).NombreCompania;
                vista.proyecto = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).descripcionFactura;
                vista.monto = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).montoFactura.ToString();
                vista.moneda = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).tipoMoneda;
                vista.numero = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).Id.ToString();
            }
            catch
            {

            }


        }

       public void AgregarPago()
   {

       int _idFactura = int.Parse(vista.numero.ToString());
       int _monto = int.Parse(vista.monto);
       string _moneda = vista.moneda.ToString();
       string _forma = vista.formPago;
       int _codApro = int.Parse(vista.codAprob);
       DateTime _fecha = DateTime.Today;

       Entidad pago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(_moneda, _monto, _forma, _codApro,_fecha, _idFactura);

       LogicaTangerine.Comandos.M9.ComandoAgregarPago comando = LogicaTangerine.Fabrica.FabricaComandos.cargarPago(pago);

       comando.Ejecutar();

   }
   
   
   }
    
}
