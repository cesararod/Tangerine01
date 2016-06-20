﻿using DominioTangerine;
using LogicaTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M7;

namespace Tangerine_Presentador.M7
{
    public class PresentadorModificarProyecto
    {
        IContratoModificarProyecto vista;

        public PresentadorModificarProyecto(IContratoModificarProyecto vista)
        {
            this.vista = vista;
        }

        public void CargarProyecto(int id)
        {
            Entidad parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
            ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id = id;

            Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarXIdproyecto(parametro);
            Entidad proyecto = comando.Ejecutar();

            Comando<List<Entidad>> comando1 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarContactosXIdProyecto(parametro);
            List<Entidad> contactos = comando1.Ejecutar();

            Comando<Entidad> comando2 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoContactNombrePropuestaId(parametro);
            Entidad propuesta = comando2.Ejecutar();

            Comando<List<Entidad>> comando3 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosGerentes();
            List<Entidad> gerentes = comando3.Ejecutar();

            Comando<List<Entidad>> comando4 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosProgramadores();
            List<Entidad> programadores = comando4.Ejecutar();

            Comando<Entidad> comando5 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarXIdProyectoContacto(parametro);
            Entidad contactoEmp = comando5.Ejecutar();

            try
            {
                llenarComboEstatus(proyecto);
                llenarInputEncargados(contactos, contactoEmp);
                llenarComboGerentes(gerentes, proyecto);
                llenarInputPersonal(programadores);

                vista.inputPropuesta.Text = ((DominioTangerine.Entidades.M7.Propuesta)propuesta).Nombre;
                vista.textInputCosto.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo.ToString();
                vista.textInputNombreProyecto.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre;
                vista.textInputCodigo.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo;
                vista.textInputFechaInicio.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio.ToString("dd/MM/yyyy");
                vista.textInputPorcentaje.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarComboEstatus(Entidad proyecto)
        {
            Dictionary<int, string> Estatus = new Dictionary<int, string>();
                Estatus.Add(0, "En desarrollo");
                Estatus.Add(1, "Completado");
                Estatus.Add(2, "Completado a destiempo");
                Estatus.Add(3, "Cancelado");

            vista.inputEstatus.DataSource = Estatus;
            vista.inputEstatus.DataTextField = RecursoPresentadorM7.Value;
            vista.inputEstatus.DataValueField = RecursoPresentadorM7.Key;

            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals("En desarrollo"))
            {
                vista.inputEstatus.SelectedIndex = 0;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.ToString().Equals("Completado"))
            {
                vista.inputEstatus.SelectedIndex = 1;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals("Completado a destiempo"))
            {
                vista.inputEstatus.SelectedIndex = 2;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals("Cancelado"))
            {
                vista.inputEstatus.SelectedIndex = 3;
            }

            vista.inputEstatus.DataBind();
        }

        private void llenarInputEncargados(List<Entidad> contactos, Entidad contactoEmp)
        {
            int index = 0;
            foreach (Entidad contacto in contactos)
            { 
                if (contacto.Id == contactoEmp.Id)
                {
                    vista.imputEncargado.Items.Add((((DominioTangerine.Entidades.M7.Contacto)contacto).Nombre) +
                                " " + ((DominioTangerine.Entidades.M7.Contacto)contacto).Apellido);
                    vista.imputEncargado.SelectedIndex = index;
                    index++;
                }
                else
                {
                    vista.imputEncargado.Items.Add((((DominioTangerine.Entidades.M7.Contacto)contacto).Nombre) +
                                    " " + ((DominioTangerine.Entidades.M7.Contacto)contacto).Apellido);
                    index++;
                }
            }
        }

        private void llenarComboGerentes(List<Entidad> gerentes, Entidad proyecto)
        {
            Dictionary<int, string> listaGerentes = new Dictionary<int, string>();
            foreach (Entidad gerente in gerentes)
            {
                listaGerentes.Add(((DominioTangerine.Entidades.M7.Empleado)gerente).Id, (((DominioTangerine.Entidades.M7.Empleado)gerente).emp_p_nombre) +
                    " " + (((DominioTangerine.Entidades.M7.Empleado)gerente).emp_p_apellido));
            }
            vista.inputGerente.DataSource = listaGerentes;
            vista.inputGerente.DataTextField = RecursoPresentadorM7.Value;
            vista.inputGerente.DataValueField = RecursoPresentadorM7.Key;
            vista.inputGerente.SelectedIndex = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente;
            vista.inputGerente.DataBind();
        }

        private void llenarInputPersonal(List<Entidad> programadores)
        {
            foreach (Entidad programador in programadores)
            {
                vista.inputPersonal.Items.Add(((DominioTangerine.Entidades.M7.Empleado)programador).emp_p_nombre + " " + ((DominioTangerine.Entidades.M7.Empleado)programador).emp_p_apellido);
            }
        }

        public bool EventoClick_Modificar()
        {
            try
            {
                
                int _idGerente = vista.inputGerente.SelectedIndex;

                string _encargadoNombre;

                foreach (ListItem item in vista.imputEncargado.Items)
                {
                    if (item.Selected)
                    {
                        _encargadoNombre = item.Text.ToString();
                    }
                }

                

            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }
    }
}
