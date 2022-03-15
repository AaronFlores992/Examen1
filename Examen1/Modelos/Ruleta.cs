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
            this._rojos = new List<int>();
            this._negros = new List<int>();
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
