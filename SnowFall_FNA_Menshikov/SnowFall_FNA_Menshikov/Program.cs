﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFall_FNA_Menshikov
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Snowfall snowfall = new Snowfall())
            {
                snowfall.Run();
            }
        }
    }
}
