using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public static class  ConnectionStringService
    {
        public static string ConnString { get; private set; } = @"Data Source=DESKTOP-78JPLM2\SQLEXPRESS;Database=DB_Projet_Centre_Entrainement;Integrated Security = True";
    }



}
