using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioDueño
    {
        IEnumerable<Dueño> GetAllDueños();
        Dueño AddDueño(Dueño dueño);
        Dueño UpdateDueño(Dueño dueño);
        void DeleteDueño(int idDueño);
        Dueño GetDueño(int idDueño);
        IEnumerable<Dueño> GetDueñosPorFiltro(string filtro);
    }
}