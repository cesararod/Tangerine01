﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace LogicaTangerine.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1

        #endregion

        #region Modulo 2

        /// <summary>
        /// Método utilizado para devolver una instancia de la clase ComandoAgregarUsuario
        /// </summary>
        /// <returns>Retorna una instancia a ComandoAgregarUsuario</returns>
        public static Comandos.M2.ComandoAgregarUsuario agregarUsuario()
        {
            return new Comandos.M2.ComandoAgregarUsuario();
        }

        /// <summary>
        /// Método utilizado para devolver una instancia del Comando Usuario Default
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public static Comandos.M2.CrearUsuarioDefault crearUsuario(String nombre, String apellido)
        {
            return new Comandos.M2.CrearUsuarioDefault(nombre, apellido);
        }

        #endregion

        #region Modulo 3

        #endregion

        #region Modulo 4

        #endregion

        #region Modulo 5

        #endregion

        #region Modulo 6

        #endregion

        #region Modulo 7

        #endregion

        #region Modulo 8

        #endregion

        #region Modulo 9

        public static Comandos.M9.ComandoCargarPago cargarPago()
        {
            return new Comandos.M9.ComandoCargarPago();
        }

        #endregion

        #region Modulo 10

        #endregion
    }
}
