﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M5;
using DominioTangerine;

namespace PruebasUnitarias.M5
{
    [TestFixture]
    public class PruebaLogica
    {
        #region Atributos
        bool answer;
        public Contacto theContact;
        public Contacto theContact2;
        public List<Contacto> listContact;
        public List<Contacto> listContact2;
        public Proyecto theProyect;
        public LogicaM5 logicM5;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theProyect = new Proyecto();
            theProyect.Idproyecto = 1;
            theContact = new Contacto();
            theContact.IdContacto = 8;
            logicM5 = new LogicaM5();
            theContact.Nombre = "Istvan";
            theContact.Apellido = "Bokor";
            theContact.Departamento = "Ventas";
            theContact.Cargo = "Gerente";
            theContact.Correo = "asdqwe@asd.com";
            theContact.Telefono = "7654321";
            theContact.TipoCompañia = 1;
            theContact.IdCompañia = 1;
            answer = false;
        }

        [TearDown]
        public void clean()
        {
            answer = false;
            theContact = null;
            theContact2 = null;
            listContact = null;
            listContact2 = null;
            theProyect = null;
            logicM5 = null;
        }
        #endregion

        #region Pruebas Unitarias

        /// <summary>
        /// Prueba que permite verificar el insertar de un contacto en la base de datos
        /// </summary>
        [Test]
        public void TestAddContact()
        {
            //Agrego el contacto a probar
            Assert.IsTrue(logicM5.AddNewContact(theContact));
            //Consulto todos los contactos de la compania 1, donde inserte el contacto anterior
            listContact = logicM5.GetContacts(1, 1);
            //Valido el contacto insertado para ver si es igual al ultimo que inserte
            Assert.AreEqual(theContact.Correo, listContact[listContact.Count - 1].Correo);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            answer = logicM5.DeleteContact(listContact[listContact.Count - 1]);
        }

        /// <summary>
        /// Prueba que permite verificar el eliminar de un contacto en la base de datos
        /// </summary>
        [Test]
        public void TestDeleteContact()
        {
            //Agrego el contacto a eliminar
            answer = logicM5.AddNewContact(theContact);
            //Consulto todos los contactos de la compania 1
            listContact = logicM5.GetContacts(1,1);
            //Valido que el contacto a eliminar sea el mismo que inserte
            Assert.AreEqual(theContact.Correo, listContact[listContact.Count - 1].Correo);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            Assert.IsTrue(logicM5.DeleteContact(listContact[listContact.Count - 1]));
        }

        /// <summary>
        /// Prueba que permite verificar el modificar de un contacto en la base de datos
        /// </summary>
        [Test]
        public void TestChangeContact()
        {
            //Agrego el contacto a modificar, theContact.Nombre = Istvan
            answer = logicM5.AddNewContact(theContact);
            //Consulto todos los contactos de la compania 1 para traer el id del contacto insertado
            listContact = logicM5.GetContacts(1,1);
            //Cambio el campo del nombre y asigno el id de la bd
            theContact.IdContacto = listContact[listContact.Count - 1].IdContacto;
            theContact.Nombre = "Joaquin";
            //Invoco "ChangeContact(Contacto theContact)" y valido si regresa true
            Assert.IsTrue(logicM5.ChangeContact(theContact));
            //Vuelvo a traer la lista con el cambio del nombre del ultimo contacto
            listContact = logicM5.GetContacts(1, 1);
            //Valido el nombre del contacto con el string que le asugne
            Assert.AreEqual("Joaquin", listContact[listContact.Count - 1].Nombre);
            //Elimino ese contacto de la bd
            answer = logicM5.DeleteContact(listContact[listContact.Count - 1]);
        }

        /// <summary>
        /// Prueba que permite verificar el consultar lista de contactos de una empresa en bd
        /// </summary>
        [Test]
        public void TestContactCompany()
        {
            //Agrego un contacto para tener almenos uno en la lista
            answer = logicM5.AddNewContact(theContact);
            //Consulto todos los contactos de la compania 1
            listContact = logicM5.GetContacts(1, 1);
            //answer obtiene true si se elimina el contacto
            Assert.IsNotNull(listContact);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            answer = logicM5.DeleteContact(listContact[listContact.Count - 1]);

        }

        /// <summary>
        /// Prueba que permite verificar el consultar un contacto unico
        /// </summary>
        [Test]
        public void TestSingleContact()
        {
            //Agrego un contacto para tene algo en la lista
            answer = logicM5.AddNewContact(theContact);
            //Consulto todos los contactos de la compania 1
            listContact = logicM5.GetContacts(1, 1);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            theContact2 = logicM5.SearchContact(listContact[listContact.Count - 1]);
            //Valido si el contacto que inserte es igual al que trajo el metodo
            Assert.AreEqual(theContact2.Correo, theContact.Correo);
            //Borro el contacto de la bd
            answer = logicM5.DeleteContact(theContact2);
        }

        /// <summary>
        /// Prueba que permite verificar el agregar contacto a un proyecto en la base de datos
        /// </summary>
        [Test]
        public void TestAddContactProy()
        {
            //Agrego el contacto a asignar al proyecto 1
            answer = logicM5.AddNewContact(theContact);
            //Consulto todos los contactos de la compania 1 para tener el ultimo contacto que agregue
            listContact = logicM5.GetContacts(1, 1);
            //Inserto en Contacto_proyecto el id del contacto y el id del proyecto
            Assert.IsTrue(logicM5.AddProyectContact(listContact[listContact.Count - 1], theProyect));
            //Traigo una lista de contactos del proyecto 1 para validar
            listContact2 = logicM5.GetContactsProyect(theProyect);
            //Valido los correos del contacto insertado y del ultimo contacto del proyecto
            Assert.AreEqual(theContact.Correo, listContact2[listContact2.Count - 1].Correo);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            answer = logicM5.DeleteContact(listContact[listContact.Count - 1]);
        }

        /// <summary>
        /// Prueba que permite verificar el consultar contactos de un proyecto en la base de datos
        /// </summary>
        [Test]
        public void TestContactProyect()
        {
            //Agrego el contacto a asignar al proyecto 1
            answer = logicM5.AddNewContact(theContact);
            //Consulto todos los contactos de la compania 1 para tener el ultimo contacto que agregue
            listContact = logicM5.GetContacts(1, 1);
            //Inserto en Contacto_proyecto el id del contacto y el id del proyecto
            answer = logicM5.AddProyectContact(listContact[listContact.Count - 1], theProyect);
            //Traigo una lista de contactos del proyecto 1 para validar
            listContact2 = logicM5.GetContactsProyect(theProyect);
            //Valido la lista que regresa de ContactProyect
            Assert.IsNotNull(listContact2);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            answer = logicM5.DeleteContact(listContact[listContact.Count - 1]);
        }

        /// <summary>
        /// Prueba que permite verificar el eliminar contacto de un proyecto en la base de datos
        /// </summary>
        [Test]
        public void TestDeleteContactProyect()
        {
            //Agrego el contacto a asignar al proyecto 1
            answer = logicM5.AddNewContact(theContact);
            //Consulto todos los contactos de la compania 1 para tener el ultimo contacto que agregue
            listContact = logicM5.GetContacts(1, 1);
            //Inserto en Contacto_proyecto el id del contacto y el id del proyecto
            answer = logicM5.AddProyectContact(listContact[listContact.Count - 1], theProyect);
            //Traigo una lista de contactos del proyecto 1 para validar
            listContact2 = logicM5.GetContactsProyect(theProyect);
            //Mando a eliminar el ultimo contacto del proyecto (El contacto que inserte)
            Assert.IsTrue(logicM5.DeleteContactProyect(listContact2[listContact2.Count - 1], theProyect));
            //Mando a eliminar el ultimo contacto de la lista (El contacto que inserte)
            answer = logicM5.DeleteContact(listContact[listContact.Count - 1]);
        }

        /// <summary>
        /// Prueba que permite verificar el consultar contactos de un proyecto en la base de datos
        /// </summary>
        [Test]
        public void TestContactNoProyect()
        {
            //Agrego el contacto a asignar al proyecto 1
            answer = logicM5.AddNewContact(theContact);
            //Consulto todos los contactos de la compania 1 para tener el ultimo contacto que agregue
            listContact = logicM5.GetContacts(1, 1);
            //Traigo una lista de contactos del proyecto 1 para validar
            listContact2 = logicM5.GetContactsNoProyect(theProyect);
            //Valido el ultimo contacto en la lista de ContactCompany contra la lista de ContactNoProyect
            Assert.AreEqual(listContact[listContact.Count - 1].Correo, listContact2[listContact2.Count - 1].Correo);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            answer = logicM5.DeleteContact(listContact[listContact.Count - 1]);
        }

        #endregion
    }
}