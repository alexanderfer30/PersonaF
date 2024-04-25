using F.DAL;
using F.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace F.BL
{
    public class PersonaBL 
    {
        private readonly PersonaFDAL personaDAL=new PersonaFDAL();

        public async Task<int> Crear(PersonaF persona)
        {
            return await personaDAL.Crear(persona);
        }

        public async Task<int> Modificar(PersonaF persona)
        {
            return await personaDAL.Modificar(persona);
        }

        public async Task<int> Eliminar(int Id)
        {
            return await personaDAL.Eliminar(Id);
        }

        public async Task<PersonaF> ObtenerPorId(int Id)
        {
            return await personaDAL.ObtenerPorId(Id);
        }

        public async Task<List<PersonaF>> ObtenerTodos()
        {
            return await personaDAL.ObtenerTodos();
        }
    }
}
