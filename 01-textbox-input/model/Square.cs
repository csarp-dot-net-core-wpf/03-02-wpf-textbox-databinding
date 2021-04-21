using System;
using System.Collections.Generic;
using System.Text;

namespace oop.model
{
    /// <summary>
    /// Négyzet osztály
    /// </summary>
    class Square
    {
        /// <summary>
        /// A négyzet oldala.
        /// </summary>
        private double side;

        /// <summary>
        /// Négyzetet oldalával létrehozó konstruktor.
        /// </summary>
        /// <param name="side">A négyzet oldala</param>
        public Square(double side)
        {
            // S2.02 Ha a négyzet oldala negatív vagy nulla kivételt dobunk.                   
            if (side <= 0)
                // S2.02 thwow -> kivétel dobás
                //       Kivétel dobódásakor az adott utasítássorozat végrehajtása megszakad,
                //       és a vezérlés átadódik a kivételkezelő blokkokhoz.
                // S2.03 SqueraSideCannotBeNagativOrZero saját kivétel.
                //       A saját kivétel nevét beszédesre választjuk.
                //       A paraméterbe a kivétel szövege kerül.
                // S2.04 A saját kivételt az IDE segítségével egy új fájlba legyártjuk.
                //       A saját kivételt a new utasítással példányosítjuk.
                //       Elékészül a SqueraSideCannotBeNagativOrZero.cs állomány.
                throw new SqueraSideCannotBeNagativOrZero(side + " oldalú négyzet nincs. A négyzetet nem jön létre.");
            this.side = side;
        }

        /// <summary>
        /// Side tulajdonság get és set metódussal..
        /// </summary>
        public double Side
        {
            get 
            { 
                return side; 
            }
            set
            {
                // S2.05 Módosításkor is megadhatunk negatív oldalt.
                //       Ha a négyzet oldala negatív vagy nulla kivételt dobunk.
                //       Használhatjuk a már megírt kivételt!
                if (value <= 0)
                    throw new SqueraSideCannotBeNagativOrZero(value + " méretre a négyzet oldalát nem lehet változtatni. A négyzet oldala maradt " + side + ".");
                side = value;
            }
        }

        /// <summary>
        /// A négyzet kerület tulajdonsága. Csak olvasható.
        /// </summary>
        public double District
        {
            get
            {
                double district = 4 * side;
                return district;
            }
        }

        /// <summary>
        /// A négyzet terület tulajdonsága. Csak olvasható.
        /// </summary>
        public double Area
        {
            get
            {
                double area = side * side;
                return area;
            }
        }

        /// <summary>
        /// A négyzet adatait ilyen alakban jelenítjük meg.
        /// </summary>
        /// <returns>A négyzet odlala és a hozzá tartozó szöveg.</returns>
        public override string ToString()
        {
            return side + " méter a négyzet oldala.";
        }
    }
}
