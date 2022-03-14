using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1.Modelos
{
    internal class Jugador
    {
        private String _nombre;
        private int _id;
        private int _dineroActual;
        private int _dineroPerdido;

        public Jugador(String nombre, int id, int dineroActual, int dineroPerdido) { 
            this._nombre = nombre;
            this._id = id;
            this._dineroActual = 300;
            this._dineroPerdido = 0;
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int dineroActual
        {
            get { return _dineroActual; }
            set { _dineroActual = value; }
        }

        public int dineroPerdido
        {
            get { return _dineroActual; }
            set { _dineroPerdido = value; }
        }

        public override string ToString()
        {
            return $"Jugador: {_nombre}";
        }
    }
}
