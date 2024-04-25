using F.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F.DAL;
public class PersonaFDAL
{

    public async Task<int> Crear(PersonaF persona)
        {
        using(var dbContext = new FDBContext())
            {
            await dbContext.PersonasF.AddAsync(persona);
            return await dbContext.SaveChangesAsync();
            }   
        } 

    public async Task<int> Modificar (PersonaF persona)
    {
        using (var dbContext = new FDBContext())
        {
                dbContext.PersonasF.Update(persona);
            return await dbContext.SaveChangesAsync();
        }
    }

    public async Task<int> Eliminar (int Id)
    {
        using (var dbContext = new FDBContext())
        {
                var PersonaEliminar = dbContext.PersonasF.FirstOrDefault(p => p.Id == Id);
                if (PersonaEliminar != null)
                {
                    // Marcar la entidad como eliminada
                    dbContext.PersonasF.Remove(PersonaEliminar);

                    // Guardar los cambios en la base de datos
                    return await dbContext.SaveChangesAsync();
                }
                return 0;
        }
    }

    public async Task<PersonaF> ObtenerPorId (int Id)
    {
        using (var dbContext = new FDBContext())
        {
            var Persona = dbContext.PersonasF.FirstOrDefault(p => p.Id == Id);
            if (Persona != null)
            {

                return Persona;
            }
            return null;

        }
    } 

    public async Task<List<PersonaF>> ObtenerTodos()
    {
        using (var dbContext = new FDBContext())
        {
            return await dbContext.PersonasF.ToListAsync();
        }
        
    }


}
