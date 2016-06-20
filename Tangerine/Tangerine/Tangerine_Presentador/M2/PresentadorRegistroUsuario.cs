﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M2;
using DominioTangerine;
using LogicaTangerine.M2;

namespace Tangerine_Presentador.M2
{
    public class PresentadorRegistroUsuario
    {
        private IContratoRegistroUsuario _vista;

        /// <summary>
        /// Constructor del presentador de la vista Registrar Usuario
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorRegistroUsuario(IContratoRegistroUsuario vista)
        {
            _vista = vista;
        }

        /// <summary>
        /// Método que inicia la vista de la página registrar usuario
        /// </summary>
        public void inicioVista()
        {
            LogicaTangerine.Comando<List<Entidad>> theComando = LogicaTangerine.Fabrica.FabricaComandos.ConsultarEmpleados();
            LogicaTangerine.Comandos.M10.ComandoConsultarEmpleado comando = (LogicaTangerine.Comandos.M10.ComandoConsultarEmpleado)theComando;
            List<Entidad> listaDeEmpleados = comando.Ejecutar();
            bool usuarioExistente;
            foreach (Entidad theEmpleado in listaDeEmpleados)
            {
                DominioTangerine.Entidades.M10.EmpleadoM10 empleado = (DominioTangerine.Entidades.M10.EmpleadoM10)theEmpleado;
                LogicaTangerine.Comando<Boolean> theComandoVerificar = LogicaTangerine.Fabrica.FabricaComandos.verificarUsuario(empleado.emp_id);
                LogicaTangerine.Comandos.M2.ComandoVerificarUsuario comandoVerificar = (LogicaTangerine.Comandos.M2.ComandoVerificarUsuario)theComandoVerificar;
                usuarioExistente = comandoVerificar.Ejecutar();
                _vista.tablaEmpleado += ResourceGUIM2.OpenTR;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.emp_id.ToString() + ResourceGUIM2.CloseTD;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_nombre + ResourceGUIM2.CloseTD;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_apellido + ResourceGUIM2.CloseTD;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_cedula + ResourceGUIM2.CloseTD;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.jobs.Nombre + ResourceGUIM2.CloseTD;

                if (usuarioExistente == false)
                {
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegNuevaVentana + empleado.emp_id + ResourceGUIM2.NombreEmpleado
                                            + empleado.emp_p_nombre + ResourceGUIM2.ApellidoEmpleado + empleado.emp_p_apellido
                                            + ResourceGUIM2.CloseBotonParametro + ResourceGUIM2.CloseTD;
                }
                else
                {
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegBlock + ResourceGUIM2.CloseBotonParametroDesactivado + ResourceGUIM2.CloseTD;
                }

                _vista.tablaEmpleado += ResourceGUIM2.CloseTR;
            }
        }
    }
}