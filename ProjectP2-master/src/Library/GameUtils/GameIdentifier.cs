// -----------------------------------------------------------------------
// <copyright file="GameIdentifier.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Library.GameUtils
{
    /// <summary>
    /// GameIdentifier es una clase cuya mayor responsabilidad es crear identificadores
    /// para los games.
    /// </summary>
    public static class GameIdentifier
    {
        /// <summary>
        /// Random es una variable estática ya que no nos interesa crear nuevas instancias
        /// de ella cada vez que generemos un identificador. Su función es dar la capacidad de generar
        /// números random.
        /// </summary>
        /// <returns>Objeto Random.</returns>
        private static readonly Random Random = new Random();

        /// <summary>
        /// PossibleCharacters es una lista de strings, que contiene todos los posibles characters
        /// que pueda tener un identificador.
        /// </summary>
        /// <value>Lista de strings.</value>
        private static readonly string[] PossibleCharacters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        /// <summary>
        /// ExistingIdentifiers es una lista de strings, que contiene todos los identificadores
        /// que se han creado, asi evitamos que se repitan.
        /// </summary>
        /// <returns>Lista de strings.</returns>
        private static readonly List<string> ExistingIdentifiers = new List<string>();

        /// <summary>
        /// GenerateIdentifier es un método cuya función es generar un identificador
        /// para un game.
        /// Designado por Expert ya que conoce la lista de identificadores ya existentes.
        /// </summary>
        /// <returns>Un identificador único para un nuevo game.</returns>
        public static string GenerateIdentifier()
        {
            bool notFinished = true;
            string identifier = string.Empty;

            // Hasta que no se cree un identificador que no se haya creado previamente sigue el bucle.
            while (notFinished)
            {
                for (int i = 0; i < 10; i++)
                {
                    int randomNumber = Random.Next(0, 34);
                    identifier += PossibleCharacters[Convert.ToInt32(randomNumber)];
                }

                // Verificamos que no lo contenga antes de salir el bucle.
                if (!ExistingIdentifiers.Contains(identifier))
                {
                    ExistingIdentifiers.Add(identifier); // Agregamos el identificador a la lista.
                    notFinished = false; // Salimos del bucle.
                }
                else
                {
                    identifier = string.Empty; // Si ya existía un identifier como el creado, entonces generaremos nuevamente el identifier.
                }
            }

            return identifier;
        }
    }
}