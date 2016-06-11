﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExcepcionesTangerine;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoObtenerCaracteres : Comando<String>
    {
        String _cadena;
        int _cantidad;

        /// <summary>
        /// Constructor que recibe los parametros cadena y cantidad
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="cantidad"></param>
        public ComandoObtenerCaracteres(String cadena, int cantidad)
        {
            _cadena = cadena;
            _cantidad = cantidad;
        }

        /// <summary>
        /// Método que ejecuta la logica para obtener los caracteres de un string
        /// </summary>
        /// <returns>Retorna los caracteres</returns>
        public override String Ejecutar()
        {
            string caracteres = "";
            try
            {
                char[] cadenaSeparada = new char[_cadena.Length];

                using (StringReader reader = new StringReader(_cadena))
                {
                    reader.ReadAsync(cadenaSeparada, 0, _cadena.Length);
                }

                for (int i = 0; i < _cadena.Length; i++)
                {
                    caracteres = caracteres + cadenaSeparada[i];
                    if (i == (_cantidad - 1))
                    {
                        break;
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Parametro invalido", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " +
                                                                     "ObtenerCaracteres()", ex);
            }

            return caracteres;
        }
    }
}
