﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoAgregarPropuesta : Comando<bool>
    {

        public ComandoAgregarPropuesta(Entidad laPropuesta) {
             _laEntidad = laPropuesta;
        }

        public override bool Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                return daoPropuesta.Agregar(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}