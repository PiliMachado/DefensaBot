// -----------------------------------------------------------------------
// <copyright file="Singleton.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace Library.ContainerUtils
{
    /// <summary>
    /// Singleton es una clase estática cuya función es poder aplicar el patron Singleton.
    /// Con esta clase podemos tener una única instancia de una clase para asi los valores
    /// de ella no cambian de instancia en instancia.
    /// </summary>
    /// <typeparam name="T">El tipo de objeto para el cual se va a mantener una sola instancia.</typeparam>
    public static class Singleton<T>
        where T : new()
    {
        /// <summary>
        /// Variable estática privada instance, de tipo genérico T ya que depende del tipo del elemento en el cual se implemente la clase.
        /// </summary>
        private static T instance;

        /// <summary>
        /// Obtiene variable estática publica Instance, el valor de instance no cambiara y no podremos acceder a el directamente.
        /// Solo podemos acceder a partir de este Instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                // Verificamos si instance es nulo.
                if (instance == null)
                {
                    // En caso de que lo sea creamos uno vacio.
                    instance = new T();
                }

                return instance;
            }
        }
    }
}