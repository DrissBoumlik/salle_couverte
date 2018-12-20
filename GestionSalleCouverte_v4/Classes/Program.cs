using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App_Gestion_Reservation;
using GestionSalleCouverte._Finance2.Annuel_Dcpln;

namespace GestionSalleCouverte.Classes
{static class Program
    {
        /// <summary> Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Logine());
        }
    }
}