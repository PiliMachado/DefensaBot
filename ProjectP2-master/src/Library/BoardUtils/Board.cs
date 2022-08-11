// -----------------------------------------------------------------------
// <copyright file="Board.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Library.BoatUtils;
using Library.ContainerUtils;
using Library.Exceptions;
using Library.Managers;

namespace Library.BoardUtils
{
    /// <summary>
    /// Clase destinada a contener los botes, su conocimiento parte del conocimiento de
    /// cada bote incluído en ella.
    /// </summary>
    public abstract class Board
    {
        private static readonly string[] Alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        /// <summary>
        /// Obtiene la lista de botes contenidos en esta tabla.
        /// </summary>
        public List<Boat> Boats { get; }

        /// <summary>
        /// Obtiene el tamaño final de la tabla.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Obtiene la lista que contiene las coordenadas donde el jugador tiró y no acertó.
        /// </summary>
        public List<Tuple<int, int>> FailedHits { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Board"/> con el tamaño dado.
        /// </summary>
        /// <param name="size">El tamaño final de la board.</param>
        protected Board(int size)
        {
            this.Size = size;
            this.Boats = new List<Boat>();
            this.FailedHits = new List<Tuple<int, int>>();
        }

        /// <summary>
        /// Añade el bote a la lista de botes.
        /// Responsabilidad asignada por Expert, ya que Board es experta en los conocimientos sobre los botes
        /// que se encuentran en ella.
        /// Además aquí se aplica polimorfismo ya que el método RemoveBoat es polimórfico.
        /// </summary>
        /// <param name="boatType">El tipo de bote a añadir.</param>
        /// <param name="coords">Las coordenadas que ocupa el bote a añadir.</param>
        /// <returns>El nuevo bote.</returns>
        public Boat AddBoat(string boatType, ICollection<Tuple<int, int>> coords) // Deberia crear el bote por creator
        {
            BoatsManager bm = Singleton<BoatsManager>.Instance;
            Boat boat = (Boat)Activator.CreateInstance(bm.GetTypeByTag(boatType), coords);
            if (boat.Positions.Any(bp => bp.X >= this.Size || bp.Y >= this.Size))
            {
                throw new InvalidBoatException("El bote a agregar no puede estar fuera de la tabla.");
            }

            this.Boats.Add(boat);
            return boat;
        }

        /// <summary>
        /// Remueve el bote dado de la lista de botes contenidos en esta board.
        /// Responsabilidad asignada por Expert, ya que Board es experta en los conocimientos sobre los botes
        /// que se encuentran en ella.
        /// Ademas aquí se aplica polimorfismo ya que el método RemoveBoat es polimórfico.
        /// </summary>
        /// <param name="boat">El bote a remover.</param>
        public void RemoveBoat(Boat boat)
        {
            this.Boats.Remove(boat);
        }

        /// <summary>
        /// Lanza un disparo sobre la coordenada dada, afectando a cualquier barco que se encuentre en ella.
        /// Responsabilidad asignada por Expert, ya que Board es experta en los conocimientos sobre sus posiciones
        /// y si se encuentra un barco en ellas o no.
        /// </summary>
        /// <param name="x">El carácter del alfabeto que represente a la coordenada X (Horizontal).</param>
        /// <param name="y">La coordenada Y (Vertical).</param>
        /// <exception cref="InvalidAttackException">Lanzada si el carácter pasada por argumento no se encuentra en el
        /// alfabeto.</exception>
        /// <returns>El efecto que tuvo el disparo sobre la tabla (<see cref="BoardHitStatus"/>).</returns>
        public BoardHitStatus Hit(string x, int y)
        {
            int xCoord;
            if (Alphabet.Contains(x.ToUpper()))
            {
                xCoord = Array.IndexOf(Alphabet, x.ToUpper());
            }
            else
            {
                throw new InvalidAttackException("La coordenada x debe ser una letra contenida en el alfabeto.");
            }

            return this.Hit(xCoord, y);
        }

        /// <summary>
        /// Lanza un disparo sobre la coordenada dada, afectando a cualquier barco que se encuentre en ella.
        /// Responsabilidad asignada por Expert, ya que Board es experta en los conocimientos sobre sus posiciones
        /// y si se encuentra un barco en ellas o no.
        /// </summary>
        /// <param name="x">La coordenada X (Horizontal).</param>
        /// <param name="y">La coordenada Y (Vertical).</param>
        /// <returns>El efecto que tuvo el disparo sobre la tabla (<see cref="BoardHitStatus"/>).</returns>
        public BoardHitStatus Hit(int x, int y)
        {
            if (x >= this.Size || y >= this.Size || x < 0 || y < 0)
            {
                return BoardHitStatus.OutOfBoard;
            }

            Boat boat = this.GetBoatAt(x, y);
            if (boat == null)
            {
                if (this.FailedHits.Contains(new Tuple<int, int>(x, y)))
                {
                    return BoardHitStatus.WaterAgain;
                }

                this.FailedHits.Add(new Tuple<int, int>(x, y));
                return BoardHitStatus.Water;
            }

            BoatPosition bp = boat.Positions.Find(position => position.Equals(x, y));

            Debug.Assert(bp != null, nameof(bp) + " != null");
            if (bp.WasHit)
            {
                return BoardHitStatus.BoatHitAgain;
            }

            bp.WasHit = true;
            return BoardHitStatus.BoatHit;
        }

        /// <summary>
        /// Construye una string que representa a la tabla, lista para imprimirse o enviarse en un mensaje, para
        /// darle esta responsabilidad tuvimos en cuenta el patrón Expert, Board conoce todas las posiciones en la board
        /// y sus estados por ello es experta en la información necesaria para ejecutar la responsabilidad.
        /// </summary>
        /// <param name="isOwner">Declara si el jugador al que pertenece esta Board es el dueño de la misma
        /// o lo es su rival.</param>
        /// <returns>Esta tabla, representada como una string.</returns>
        public string GetPrintableBoard(bool isOwner)
        {
            StringBuilder result = new StringBuilder("  .|");
            for (int i = 0; i < this.Size; i++)
            {
                result.Append(' ');
                result.Append(i);
                result.Append(i < this.Size ? " .|" : ".|");
            }

            for (int i = 0; i < this.Size; i++)
            {
                result.Append("\n  ");
                for (int j = 0; j < this.Size * 2; j++)
                {
                    result.Append("---");
                }

                result.Append('\n');

                result.Append(Alphabet[i]);
                result.Append(" .|");
                for (int j = 0; j < this.Size; j++)
                {
                    Boat boat = this.GetBoatAt(i, j);
                    if (boat == null)
                    {
                        result.Append(
                            this.FailedHits.Contains(new Tuple<int, int>(i, j)) ?
                                " O |" : ".   .|");
                    }
                    else
                    {
                        BoatPosition bp = boat.Positions.Find(position => position.Equals(i, j));
                        Debug.Assert(bp != null, nameof(bp) + " != null");
                        result.Append(bp.WasHit ? " X |" :
                            isOwner ? " B |" : ".   .|");
                    }
                }
            }

            result.Append("\n  ");

            for (int j = 0; j < this.Size * 2; j++)
            {
                result.Append("---");
            }

            return result.ToString();
        }

        /// <summary>
        /// Obtiene el bote en las coordenadas dadas, si existe uno en las mismas.
        /// </summary>
        /// <param name="x">La coordenada X donde se busca el barco.</param>
        /// <param name="y">La coordenada Y donde se busca el barco.</param>
        /// <returns>Una instancia de <see cref="Boat"/>, si existe un bote en las
        /// coordenadas dadas, null de otra manera.</returns>
        public Boat GetBoatAt(int x, int y)
        {
            return (from boat in this.Boats let boatPositions = boat.Positions where boatPositions.Any(bp => bp.Equals(x, y)) select boat).FirstOrDefault();
        }
    }
}