using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Library.BoardUtils;
using Library.BotUtils;
using Library.Exceptions;
using Library.UserUtils;
namespace Library.Shot
{   
    /// <summary>
    /// Clase base que permite que si en algun momento se necesitan ejecutar cambios simplemente 
    /// se debe crear otra clase que herde de esta. Consiguiendo una clase que tenga alta cohesio 
    /// y bajo acomplamiento.
    /// Esto hace que se cumpla el patrón SRP ya que es una clasebase que contiene un método sumar 
    /// y si se desea hacer otra suma que no sean WaterShot y BoatShot se reescribe el método y se 
    /// escribe lo que se necesita. 
    /// </summary>
    public abstract class ShotCount
    {
        /// <summary>
        /// Método a sobre escribir que se utiliza en las clases heredadas.
        /// </summary>
        public virtual void Sumar()
        {

        }
    }
}