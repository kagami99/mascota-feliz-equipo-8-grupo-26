using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioDueño : IRepositorioDueño
    {
        /// <summary>
        /// Referencia al contexto de Dueño
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioDueño(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Dueño AddDueño(Dueño dueño)
        {
            var dueñoAdicionado = _appContext.Dueños.Add(dueño);
            _appContext.SaveChanges();
            return dueñoAdicionado.Entity;
        }

        public void DeleteDueño(int idDueño)
        {
            var dueñoEncontrado = _appContext.Dueños.FirstOrDefault(d => d.Id == idDueño);
            if (dueñoEncontrado == null)
                return;
            _appContext.Dueños.Remove(dueñoEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Dueño> GetAllDueños()
        {
            return GetAllDueños_();
        }

        public IEnumerable<Dueño> GetDueñosPorFiltro(string filtro)
        {
            var dueños = GetAllDueños(); // Obtiene todos los saludos
            if (dueños != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    dueños = dueños.Where(s => s.Nombres.Contains(filtro));
                }
            }
            return dueños;
        }

        public IEnumerable<Dueño> GetAllDueños_()
        {
            return _appContext.Dueños;
        }

        public Dueño GetDueño(int idDueño)
        {
            return _appContext.Dueños.FirstOrDefault(d => d.Id == idDueño);
        }

        public Dueño UpdateDueño(Dueño dueño)
        {
            var dueñoEncontrado = _appContext.Dueños.FirstOrDefault(d => d.Id == dueño.Id);
            if (dueñoEncontrado != null)
            {
                dueñoEncontrado.Nombres = dueño.Nombres;
                dueñoEncontrado.Apellidos = dueño.Apellidos;
                dueñoEncontrado.Direccion = dueño.Direccion;
                dueñoEncontrado.Telefono = dueño.Telefono;
                dueñoEncontrado.Correo = dueño.Correo;
                _appContext.SaveChanges();
            }
            return dueñoEncontrado;
        }     
    }
}