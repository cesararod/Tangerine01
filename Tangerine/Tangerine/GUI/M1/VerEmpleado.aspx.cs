﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M10;
using DominioTangerine;
using Tangerine_Contratos.M10;
using Tangerine_Presentador.M10;
using System.Globalization;

namespace Tangerine.GUI.M1
{
    public partial class VerEmpleado : System.Web.UI.Page, IContratoVerEmpleados
    {
        private PresentadorConsultaEmpleadoId presentador;

        public Literal FormViewEmployees
        {
            get
            {
                return FormViewEmployee;
            }
            set
            {
                FormViewEmployee = value;
            }
        }

         public VerEmpleado()
        {
            this.presentador = new PresentadorConsultaEmpleadoId(this); 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int Empleadoid = int.Parse(Request.QueryString["EmployeeId"]);

           

                if (!IsPostBack)
                {
                    presentador.cargarEmpleadosId(Empleadoid);


                }
            

            

  
            //int employeeCode;
            //LogicaM10 logicEmployee = new LogicaM10();
            //try
            //{
            //    employeeCode = int.Parse(Request.QueryString["EmployeeId"]);
            //}
            //catch
            //{
            //    employeeCode = 1;
            //}
            //Empleado employee = logicEmployee.GetEmployee(employeeCode);

            //dataEmployee = ViewFormEmployee(employee);// este es el llamado al presentador en el .cs

        }

        //private string EmployeeAge(string year)
        //{
        //    int age;

        //    age = Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(year);
            
        //    return age.ToString(); 
        //}

        //private String ViewFormEmployee(Empleado employee)
        //{
        //    dataEmployee += ResourceGUIM10.OpenDivRow;
           
        //    dataEmployee += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos personales</h4>" ;
        //    dataEmployee += ResourceGUIM10.OpenLabel + "Nombre" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Emp_cedula.ToString() + ResourceGUIM10.CloseInputTextDisabled +
        //                    ResourceGUIM10.CloseDiv + ResourceGUIM10.OpenFormGroup +
        //                    ResourceGUIM10.OpenInputText + employee.Emp_p_nombre.ToString() +
        //                    ResourceGUIM10.Espacio + employee.Emp_s_nombre.ToString() +
        //                    ResourceGUIM10.Espacio + employee.Emp_p_apellido.ToString() +
        //                    ResourceGUIM10.Espacio + employee.Emp_s_apellido.ToString() +
        //                    ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;
        //    dataEmployee += ResourceGUIM10.OpenLabel + "Genero" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Emp_genero.ToString() + ResourceGUIM10.CloseInputTextDisabled +
        //                    ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenLabel + "Fecha de nacimiento" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Emp_fecha_nac.ToString("dd/MM/yyyy") +
        //                    ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenLabel + "Edad" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    EmployeeAge(employee.Emp_fecha_nac.ToString("yyyy")).ToString() + ResourceGUIM10.CloseInputTextDisabled +
        //                    ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenLabel + "Direccion" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Adrress+ ResourceGUIM10.CloseInputTextDisabled +
        //                    ResourceGUIM10.CloseDiv;

        //    //cierre de col
        //    dataEmployee += ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos contrato</h4>";

        //    dataEmployee += ResourceGUIM10.OpenLabel + "Fecha contratacion" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    Convert.ToDateTime(employee.Job.FechaIni).ToString("dd/MM/yyyy") + 
        //                    ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Job.FechaFin + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenLabel + "Cargo" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Job.Nombre + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenLabel + "Sueldo Base" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Job.Sueldo.ToString() + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenLabel + "Estatus" + ResourceGUIM10.CloseLabel;
        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Emp_activo + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

        //    //cierre de col
        //    dataEmployee += ResourceGUIM10.CloseDiv;

        //    //cierre de row
        //    dataEmployee += ResourceGUIM10.CloseDiv;

        //    dataEmployee += ResourceGUIM10.OpenDivRow;

        //    dataEmployee += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos de contacto</h4>";

        //    dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
        //                    employee.Emp_email.ToString() + ResourceGUIM10.CloseInputTextDisabled +
        //                    ResourceGUIM10.CloseDiv;

        //    //cierre de row
        //    dataEmployee += ResourceGUIM10.CloseDiv;              
                            

        //    return dataEmployee;
 
        //}
    }
}
