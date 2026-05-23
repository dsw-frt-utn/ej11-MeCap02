using Dsw2026Ej11.Domain;
using System.Runtime.Intrinsics.X86;

namespace Dsw2026Ej11.Collections;

//Crear un campo que represente una lista de alumnos (List<>)
//Incluir un método para agregar alumnos a la lista
//Incluir un método para retornar la lista
//Incluir un método para buscar un alumno por nombre
//Incluir un método para eliminar un alumno (debe recibir un alumno)
//Incluir un método para eliminar un alumno en una determinada posición de la lista
public class CasoList
{
    private List<Alumno> alumniList = new List<Alumno>();

    public void AddAlumni(Alumno alumno) => alumniList.Add(alumno);

    public List<Alumno> ReturnAlumni() => alumniList;

    public Alumno? SearchAlumno(string aux)
    {
        foreach (Alumno a in alumniList)
        {
            if(a.Nombre == aux) return a;
        }
        return null;
    }

    public void DeteleAlumniWithObject(Alumno alumno)
    {
        foreach (Alumno a in alumniList)
        {
            if (a.Equals(alumno)) alumniList.Remove(a);
        }
    }

    public void DeleteAlumniWithIndex(int aux)
    {
        alumniList.RemoveAt(aux);
    }
}
