﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M10;

namespace Tangerine.GUI.M1
{
    public partial class EmpleadosAdmin : System.Web.UI.Page
    {
        string fecha;
        public string empleado
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }

        public string button
        {
            get
            {
                return this.nuevoempleado.Text;
            }
            set
            {
                this.nuevoempleado.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int typeComp = 2;
            int idComp = 3;
            LogicaM10 logicaM10 = new LogicaM10();
            //Aqui debe recibir typeComp y idComp de MOD3 y MOD4
            //int typeComp = int.Parse(Request.QueryString["typeComp"]);
            //int idComp = int.Parse(Request.QueryString["idComp"]);
            /*
            try
            {
                int idEmp = int.Parse(Request.QueryString["idCont"]);
                if (idEmp != null)
                {
                    logicaM10.DeleteEmpleado(idEmp);
                }
            }
            catch
            {

            }*/

            if (!IsPostBack)
            {
                //Aqui ejecuto el filltable de la clase creada en logica para probar la conexion a la bd
                //los parametros son tipo de empresa 1 (Compania), id de la empresa 1.
                //prueba.fillTable(1,1);
                List<Empleado> listEmpleado = logicaM10.GetEmpleados();

                try
                {
                    foreach (Empleado theEmpleado in listEmpleado)
                    {
                        //Nombres
                        empleado += ResourceGUIM10.AbrirTR;
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.emp_p_nombre.ToString() + 
                            ResourceGUIM10.Espacio +
                            theEmpleado.emp_s_nombre.ToString() + ResourceGUIM10.CerrarTD;
                        //Apellidos
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.emp_p_apellido.ToString() + 
                            ResourceGUIM10.Espacio +
                            theEmpleado.emp_s_apellido.ToString() + ResourceGUIM10.CerrarTD;
                        //Cedula
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.emp_cedula.ToString() +
                            ResourceGUIM10.CerrarTD;
                        //Cargo
                        empleado += ResourceGUIM10.AbrirTD + "AQUI VA CARGO" +
                            ResourceGUIM10.CerrarTD;
                        //Fecha de nacimiento??
                        empleado += ResourceGUIM10.AbrirTD + 
                             theEmpleado.emp_fecha_nac.ToString(ResourceGUIM10.FormatoFecha.ToString()) +
                             ResourceGUIM10.CerrarTD;
                        //Estatus
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.emp_activo +
                             ResourceGUIM10.CerrarTD;
                        //Acciones de cada empleado
                        empleado += ResourceGUIM10.AbrirTD;
                        //Ver
                        empleado += ResourceGUIM10.BotonVerEmpAbrir + theEmpleado.emp_num_ficha +
                            ResourceGUIM10.BotonVerEmpCerrar;
                        //Modificar
                        empleado += ResourceGUIM10.BotonModificarEmpAbrir + theEmpleado.emp_num_ficha +
                            ResourceGUIM10.BotonModificarEmpCerrar;
                        empleado += ResourceGUIM10.BotonStatusEmpAbrir + theEmpleado.emp_num_ficha +
                            ResourceGUIM10.BotonStatusEmpCerrar;

                        empleado += ResourceGUIM10.CerrarTD;
                        empleado += ResourceGUIM10.CerrarTR;
                    }
                    button += ResourceGUIM10.VentanaAgregarEmpleado;
                }
                catch (Exception ex)
                {

                }
            }

        }
    }
}