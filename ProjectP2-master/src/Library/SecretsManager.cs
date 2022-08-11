// -----------------------------------------------------------------------
// <copyright file="SecretsManager.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public class SecretsManager
    {
        /// <summary>
        /// La única instancia de la clase <see cref="BattleShipSettings"/>.
        /// </summary>
        private static SecretsManager _instance;

        private SecretsManager()
        {
            // foreach (string line in File.ReadLines(Path.Combine("..", "..", "..", "secrets.txt")))
            foreach (string line in File.ReadLines(Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "..", "..", "..", "..", "..", "src", "Program", "secrets.txt")))
            {
                string[] args = line.Split("::");
                this.Secrets.Add(args[0], args[1]);
            }
        }

        /// <summary>
        /// Obtiene la única instancia de la clase <see cref="SecretsManager"/>.
        /// </summary>
        public static SecretsManager Instance
        {
            get { return _instance ??= new SecretsManager(); }
        }

        /// <summary>
        /// Contiene los secretos y las keys para objetos sensibles como bots.
        /// </summary>
        public Dictionary<string, string> Secrets { get; } = new Dictionary<string, string>();
    }
}