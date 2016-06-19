﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using LogicaTangerine.M5;
using Tangerine_Presentador.M7;
using Tangerine_Contratos.M7;
using LogicaTangerine.M10;


namespace Tangerine.GUI.M7
{
    public partial class modificarProyecto : System.Web.UI.Page, IContratoModificarProyecto
    {

        PresentadorModificarProyecto presentador;

        public modificarProyecto()
        {
            this.presentador = new PresentadorModificarProyecto(this);
        }

        #region Contrato

        TextBox IContratoModificarProyecto.inputPropuesta
        {
            get
            {
                return inputPropuesta;
            }
            set
            {
                inputPropuesta = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputNombreProyecto
        {
            get
            {
                return textInputNombreProyecto;
            }
            set
            {
                textInputNombreProyecto = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputCodigo
        {
            get
            {
                return textInputCodigo;
            }
            set
            {
                textInputCodigo = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputFechaInicio
        {
            get
            {
                return textInputFechaInicio;
            }
            set
            {
                textInputFechaInicio = value;
            }
        }

        Calendar IContratoModificarProyecto.textInputFechaEstimada
        {
            get
            {
                return textInputFechaEstimada; ;
            }
            set
            {
                textInputFechaEstimada = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputCosto
        {
            get
            {
                return textInputCosto;
            }
            set
            {
                textInputCosto = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputPorcentaje
        {
            get
            {
                return textInputPorcentaje;
            }
            set
            {
                textInputPorcentaje = value;
            }
        }

        DropDownList IContratoModificarProyecto.inputGerente
        {
            get
            {
                return inputGerente;
            }
            set
            {
                inputGerente = value;
            }
        }

        DropDownList IContratoModificarProyecto.inputEstatus
        {
            get 
            {
                return inputEstatus;
            }
            set
            {
                inputEstatus = value;
            }
        }

        TextBox IContratoModificarProyecto.text10
        {
            get
            {
                return text10;
            }
            set
            {
                text10 = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int Proyectoid = int.Parse(Request.QueryString["idCont"]);

            if (!IsPostBack)
            {
                presentador.CargarProyecto(Proyectoid);
            }
        }
    }
}