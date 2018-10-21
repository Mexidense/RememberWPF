using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoWpfApplication.Model
{
    public class UsuarioModel
    {
        public string Nombre { get; set; }
        public string PalabraDePaso { get; set; }
    }

    public class UsuariosModel : ObservableCollection<UsuarioModel>
    {
        public UsuariosModel() : base()
        {
            Add(new UsuarioModel { Nombre = "Pablo", PalabraDePaso = "Picasso" });
            Add(new UsuarioModel { Nombre = "Pablito", PalabraDePaso = "Neruda" });
            Add(new UsuarioModel { Nombre = "Antonio", PalabraDePaso = "Banderas" });
            Add(new UsuarioModel { Nombre = "Toni", PalabraDePaso = "Ayala" });
            Add(new UsuarioModel { Nombre = "Ana", PalabraDePaso = "Torroja" });
        }
    }
}
