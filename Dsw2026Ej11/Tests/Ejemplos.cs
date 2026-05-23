namespace Dsw2026Ej11.Tests;

using System;
using System.Collections.Generic;
using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        CasoList casoList = new CasoList();

        Alumno a1 = new Alumno(1, "Mateo", 8.5);
        Alumno a2 = new Alumno(2, "Pato", 7.2);
        Alumno a3 = new Alumno(3, "Rocio", 9.1);

        casoList.AddAlumni(a1);
        casoList.AddAlumni(a2);
        casoList.AddAlumni(a3);

        Console.WriteLine("--- Lista de Alumnos ---");
        foreach (var alumno in casoList.ReturnAlumni())
        {
            Console.WriteLine(alumno);
        }

        Console.WriteLine("\n--- Buscar alumno existente (Mateo) ---");
        Alumno? alumnoEncontrado = casoList.SearchAlumno("Mateo");
        Console.WriteLine(alumnoEncontrado != null ? alumnoEncontrado.ToString() : "No existe");

        Console.WriteLine("\n--- Buscar alumno inexistente (Carlos) ---");
        Alumno? alumnoNoEncontrado = casoList.SearchAlumno("Carlos");
        Console.WriteLine(alumnoNoEncontrado != null ? alumnoNoEncontrado.ToString() : "No existe");


        Console.WriteLine("\n--- Eliminar a Pato y listar ---");
        casoList.DeteleAlumniWithObject(a2);
        foreach (var alumno in casoList.ReturnAlumni())
        {
            Console.WriteLine(alumno);
        }

        Console.WriteLine("\n--- Eliminar el primer elemento y listar ---");
        casoList.DeleteAlumniWithIndex(0);
        foreach (var alumno in casoList.ReturnAlumni())
        {
            Console.WriteLine(alumno);
        }
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        CasoDictionary casoDict = new CasoDictionary();

        Alumno a1 = new Alumno(101, "Cris", 8.8);
        Alumno a2 = new Alumno(102, "Mijail", 7.5);
        Alumno a3 = new Alumno(103, "Mateo", 9.4);

        casoDict.AddAlumni(a1);
        casoDict.AddAlumni(a2);
        casoDict.AddAlumni(a3);

        Console.WriteLine("\n--- Diccionario de Alumnos ---");
        foreach (KeyValuePair<int, Alumno> kvp in casoDict.ReturnDictionary())
        {
            Console.WriteLine($"Legajo: {kvp.Key} -> Datos: {kvp.Value}");
        }

        Console.WriteLine("\n--- Buscar alumno existente (Clave 102) ---");
        Alumno? dictEncontrado = casoDict.SearchAlumni(102);
        Console.WriteLine(dictEncontrado != null ? dictEncontrado.ToString() : "No existe");

        Console.WriteLine("\n--- Buscar alumno inexistente (Clave 999) ---");
        Alumno? dictNoEncontrado = casoDict.SearchAlumni(999);
        Console.WriteLine(dictNoEncontrado != null ? dictNoEncontrado.ToString() : "No existe");

        Console.WriteLine("\n--- Eliminar clave 101 y listar ---");
        casoDict.DeleteAlumni(101);
        foreach (var kvp in casoDict.ReturnDictionary())
        {
            Console.WriteLine($"Legajo: {kvp.Key} -> Datos: {kvp.Value}");
        }
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        CasoLinq casoLinq = new CasoLinq();

        List<Libro> listaLibros = Libro.CrearLista();

        Console.WriteLine("\n====== PRUEBAS DE LINQ ======");

        Console.WriteLine("\n1. Primer libro:");
        Console.WriteLine(casoLinq.GetPrimero(listaLibros)?.Titulo ?? "N/A");

        Console.WriteLine("\n2. Último libro:");
        Console.WriteLine(casoLinq.GetUltimo(listaLibros)?.Titulo ?? "N/A");

        Console.WriteLine("\n3. Suma total de precios:");
        Console.WriteLine(casoLinq.GetTotalPrecios(listaLibros).ToString("C"));

        Console.WriteLine("\n4. Promedio de precios:");
        Console.WriteLine(casoLinq.GetPromedioPrecios(listaLibros).ToString("C"));

        Console.WriteLine("\n5. Libros con Id mayor a 15:");
        foreach (var libro in casoLinq.GetListById(listaLibros))
        {
            Console.WriteLine($"{libro.Id} - {libro.Titulo}");
        }

        Console.WriteLine("\n6. Lista de títulos y precios:");
        foreach (var formatoStr in casoLinq.GetLibros(listaLibros))
        {
            Console.WriteLine(formatoStr);
        }

        Console.WriteLine("\n7. Libro con el precio más alto:");
        Libro? mayorPrecio = casoLinq.GetMayorPrecio(listaLibros);
        Console.WriteLine(mayorPrecio != null ? $"{mayorPrecio.Titulo} ({mayorPrecio.Precio:C})" : "N/A");

        Console.WriteLine("\n8. Libro con el precio más bajo:");
        Libro? menorPrecio = casoLinq.GetMenorPrecio(listaLibros);
        Console.WriteLine(menorPrecio != null ? $"{menorPrecio.Titulo} ({menorPrecio.Precio:C})" : "N/A");

        Console.WriteLine("\n9. Libros con precio mayor al promedio:");
        foreach (var libro in casoLinq.GetMayorPromedio(listaLibros))
        {
            Console.WriteLine($"{libro.Titulo} - {libro.Precio:C}");
        }

        Console.WriteLine("\n10. Libros ordenados por título (Z-A):");
        foreach (var libro in casoLinq.GetOrdenadosPorTituloDesc(listaLibros))
        {
            Console.WriteLine(libro.Titulo);
        }
    }
}
