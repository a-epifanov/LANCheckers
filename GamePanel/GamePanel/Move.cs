using System;
using System.Collections.Generic;

namespace BoardGame
{

    public class Move
    {

        private Square origin;
        private List<Square> destinations;


        public Move(Square origin, List<Square> destinations)
        {
            this.origin = origin;
            this.destinations = destinations;
        }


        public Square Origin
        {
            get { return origin; }
        }

        public List<Square> Destinations
        {
            get { return destinations; }
        }

        public bool IsCapturing
        {
            get 
            { 
                return Math.Abs(origin.Row - destinations[0].Row) == 2; 
            }
        }

    }
}
