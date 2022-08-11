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
    /// Clase que se encarga de contar los tiros que se hacen al agua. 
    /// </summary>
    public class WaterShot: ShotCount
    {
        private int contadorWaterShot = 0;
        public WaterShot (): base ()
        {
        }
        /// <summary>
        /// Método que esta sobreescrito e la clase padre que cumple con la función de 
        /// agregar uno al contador cada vez que se le pega al agua.
        /// </summary>
        public override void Sumar ()
        {
            this.contadorWaterShot += 1;

        }
        /// <summary>
        /// Método que retorna el contador de cuantos goplpes se le hicieron al agua.
        /// </summary>
        /// <value></value>
        public int ContadorWaterShot
        {
            get 
            {
                return this.contadorWaterShot;
            }
        }
    }

}