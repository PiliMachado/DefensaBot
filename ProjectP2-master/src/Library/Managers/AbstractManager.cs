// -----------------------------------------------------------------------
// <copyright file="AbstractManager.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Library.Exceptions;
using Library.Managers.Manageables;

namespace Library.Managers
{
    /// <summary>
    /// Maneja tipos de clases y datos sensibles al momento de utilizar los mismos.
    /// </summary>
    /// <typeparam name="TManageable">El tipo de Manageable.</typeparam>
    /// <typeparam name="TManaged">El tipo de clase a manejar.</typeparam>
    public abstract class AbstractManager<TManageable, TManaged>
        where TManageable : Manageable<TManaged>
    {
        /// <summary>
        /// Diccionario que contiene cada "tag" de los tipos manejados en este Manager.
        /// </summary>
        protected readonly Dictionary<string, TManageable> AvailableTypes = new Dictionary<string, TManageable>();

        /// <summary>
        /// Obtiene una lista de tipos o tamaños de tablas disponibles a la hora de crear una nueva partida.
        /// Designada por Expert ya que GameContainer conoce la lista de boards disponibles.
        /// </summary>
        /// <returns>La lista de tamaños o tipos disponibles.</returns>
        public List<string> GetAvailableTags()
        {
            return this.AvailableTypes.Keys.ToList();
        }

        /// <summary>
        /// Obtiene el tag de una board según su tipo.
        /// </summary>
        /// <param name="type">El type de la board previamente registrada.</param>
        /// <returns>El tag del tipo de board.</returns>
        public string GetTagByType(Type type)
        {
            return this.AvailableTypes.FirstOrDefault(at => at.Value.Type == type).Key;
        }

        /// <summary>
        /// Obtiene el tipo de board según su tag.
        /// Designada por Expert ya que GameContainer conoce la lista de boards disponibles.
        /// </summary>
        /// <param name="tag">El tag de la board previamente registrada.</param>
        /// <returns>El tipo de board.</returns>
        public Type GetTypeByTag(string tag)
        {
            return this.AvailableTypes.ContainsKey(tag) ? this.AvailableTypes[tag].Type : null;
        }

        /// <summary>
        /// Obtiene los botes que necesita contener una tabla.
        /// </summary>
        /// <param name="tag">El tag de la board previamente registrada.</param>
        /// <returns>Los tipos de botes y sus respectivas cantidades.</returns>
        public TManageable GetManageableByTag(string tag)
        {
            return this.AvailableTypes[tag];
        }

        /// <summary>
        /// Agrega un nuevo tipo de board y su correspondiente clase al diccionario de tipos de boards.
        /// Designada por Expert ya que GameContainer conoce la lista de boards disponibles.
        /// </summary>
        /// <param name="tag">El tag o nombre por el que se le conoce a la al dato que queremos registrar.</param>
        /// <param name="data">La data necesaria para el funcionamiento del tipo manejado.</param>
        public void AddAvailableType(string tag, TManageable data)
        {
            if (data == null || data.Type == null)
            {
                throw new NullPointerException("La data de un tipo manejado o su tipo no pueden ser nulos.");
            }

            if (!data.Type.IsClass || !data.Type.IsSubclassOf(typeof(TManaged)))
            {
                throw new InvalidDataException($"{data.Type.Name} No es una clase válida o no extiende la clase {typeof(TManaged).Name}!");
            }

            this.AvailableTypes.Add(tag, data);
        }
    }
}