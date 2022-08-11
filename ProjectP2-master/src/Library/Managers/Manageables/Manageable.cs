// -----------------------------------------------------------------------
// <copyright file="Manageable.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using Library.Exceptions;

namespace Library.Managers.Manageables
{
    /// <summary>
    /// Guarda información sensible sobre un tipo de objeto pasado por parámetro.
    /// </summary>
    /// <typeparam name="TManaged">El tipo de objeto del cual se guardará la información sensible.</typeparam>
    public abstract class Manageable<TManaged>
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Manageable{TManaged}"/>,
        /// estableciendo el tipo de objeto incluído en este Manageable.
        /// Este tipo debe ser una subclase de el tipo manejado TManaged.
        /// </summary>
        /// <param name="type">El tipo de objeto del cual se guardará información sensible.</param>
        /// <exception cref="InvalidDataException">Lanzada en caso de que el tipo pasado en este constructor
        /// no sea una subclase de el tipo manejado.</exception>
        protected Manageable(Type type)
        {
            if (type == null)
            {
                throw new NullPointerException("El tipo manejado no puede ser null.");
            }

            if (!type.IsClass || !type.IsSubclassOf(typeof(TManaged)))
            {
                throw new InvalidDataException($"{type.Name} No es una clase válida o no extiende la clase {typeof(TManaged).Name}!");
            }

            this.Type = type;
        }

        /// <summary>
        /// Obtiene o establece el tipo a ser manejado.
        /// </summary>
        public Type Type { get; }
    }
}