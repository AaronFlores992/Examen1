using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Modelos
{
    internal class Ruleta
    {
        private List<int> _rojos;
        private List<int> _negros;
        private List<int> _contadorPos;
        private int _giros;

        public Ruleta(List<int> rojos, List<int> negros, List<int> contadorPos, int giros) {
            this._rojos = new List<int>() {
            1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34 ,36};
            this._negros = new List<int>() {
            2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33 ,35};
            this._contadorPos = new List<int>();
            this._giros = giros;
        }

        public List<int> rojos
        {
            get { return _rojos; }
            set { _rojos = value; }
        }

        public List<int> negros
        {
            get { return _negros; }
            set { _negros = value; }
        }

        public List<int> contadorPos
        {
            get { return _contadorPos; }
            set { _contadorPos = value; }
        }

        public int giros
        {
            get { return _giros; }
            set { _giros = value; }
        }



    }
}
