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
    /// Clase encarga de contar los tiros que realiza el bote. 
    /// </summary>
    public class BoatShot: ShotCount
    {
        private int contadorBoatShot = 0;
        public BoatShot (): base ()
        {

        }
        /// <summary>
        /// Metodo sobreescrito de la clase padre que cumple la función de agregar uno al contador cada 
        /// vez que se le pega al bote
        /// </summary>
        public override void Sumar()
        {
            this.contadorBoatShot +=1;
        }
        /// <summary>
        /// Mteodo que retorna el contador de la cantidad de tiros que se realizan en el bote. 
        /// </summary>
        /// <value></value>
        public int ContadorBoatShot 
        {
            get
            {
                return this.contadorBoatShot;
            }
        }
    }
}