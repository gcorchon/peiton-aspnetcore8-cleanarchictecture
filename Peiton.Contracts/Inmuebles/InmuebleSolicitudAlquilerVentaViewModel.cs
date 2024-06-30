using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peiton.Contracts.Inmuebles
{
    public class InmuebleSolicitudAlquilerVentaViewModel
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Persona de contacto
        /// </summary>
        public string? Nombre { get; set; }
        
        /// <summary>
        /// Teléfono de contacto
        /// </summary>
        public string? Contacto { get; set; }
        public string? Comentarios { get; set; }
        public string? ObservacionesDepartamentoInmuebles { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = null!;
        public string? Observaciones { get; set; }
        
        public InmuebleSolicitudAlquilerVentaInfo Inmueble { get; set; } = null!;
        public string? Ocupacion { get; set; }
        public string Trabajador { get; set; } = null!;
    }


    public class InmuebleSolicitudAlquilerVentaInfo
    {
        public int Id { get; set; }
        public string DireccionCompleta { get; set; } = null!;        
        public TuteladoSolicitudAlquilerVenta Tutelado { get; set; } = null!;
    }

    public class TuteladoSolicitudAlquilerVenta { 
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;

        public string DNI { get; set; } = null!;
    }
}
