﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;
using DatosTangerine.M9;
using ExcepcionesTangerine;
using LogicaTangerine.M4;


namespace LogicaTangerine.M9
{
    public class LogicaM9
    {
        public Pago elPago;

        public void init()
        {

        }

        public bool AgregarPago(Pago pago)
        {
            try
            {
                return BDPagos.CargarPago(pago);
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM9.Codigo,
                    LogicResourcesM9.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM9.Codigo,
                    LogicResourcesM9.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool CambiarStatusFactura(int factura, int status)
        {
            try
            {
                return BDPagos.CargarStatus(factura, status);
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM9.Codigo,
                    LogicResourcesM9.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM9.Codigo,
                    LogicResourcesM9.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
