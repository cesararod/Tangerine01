﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M6
{
    public interface IContratoModificarPropuesta
    {
        string ContenedorCompania
        {
            get;
            set;
        }
        string IdCompania
        {
            get;
        }
        string Descripcion
        {
            get;
        }
        DropDownList ComboDuracion
        {
            get;
            set;
        }
        string TextoDuracion
        {
            get;
        }
        string DatePickerUno
        {
            get;
        }
        string DatePickerDos
        {
            get;
        }
        DropDownList TipoCosto
        {
            get;
            set;
        }

        string TextoCosto
        {
            get;
        }
        DropDownList FormaPago
        {
            get;
            set;
        }
        DropDownList ComboCuota
        {
            get;
            set;
        }
        DropDownList ComboStatus
        {
            get;
            set;
        }


    }
}
