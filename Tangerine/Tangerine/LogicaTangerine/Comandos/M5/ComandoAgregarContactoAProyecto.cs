﻿using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M5
{
    public class ComandoAgregarContactoAProyecto : Comando<bool>
    {
        private Entidad _proyecto;

        public ComandoAgregarContactoAProyecto( Entidad contacto, Entidad proyecto ) 
        {
            _laEntidad = contacto;
            _proyecto = proyecto;
        }

        public override bool Ejecutar()
        {
            bool respuesta = false;

            try 
            {
                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                respuesta = daoContacto.AgregarContactoAProyecto( _laEntidad, _proyecto );
            }
            catch ( Exception ex )
            {
                return respuesta;
            }

            return respuesta;
        }
    }
}
