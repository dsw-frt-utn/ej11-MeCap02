using Dsw2026Ej11.Domain;
using System.Globalization;

namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */
public class CasoLinq
{
    public Libro? GetPrimero(IEnumerable<Libro>? libros) => libros?.FirstOrDefault();

    public Libro? GetUltimo(IEnumerable<Libro>? libros) => libros?.LastOrDefault();

    public decimal GetTotalPrecios(IEnumerable<Libro>? libros) => libros?.Sum(l => l.Precio) ?? 0m;

    public decimal GetPromedioPrecios(IEnumerable<Libro>? libros) => (libros != null && libros.Any()) ? libros.Average(l => l.Precio) : 0m;

    public List<Libro> GetListById(IEnumerable<Libro>? libros) => libros?.Where(l => l.Id > 15).ToList() ?? new List<Libro>();

    public List<string> GetLibros(IEnumerable<Libro>? libros, CultureInfo? culture = null)
    {
        if (libros == null) return new List<string>();
        var ci = culture ?? CultureInfo.CurrentCulture;
        return libros.Select(l => $"{l.Titulo} - {l.Precio.ToString("C", ci)}").ToList();
    }

    public Libro? GetMayorPrecio(IEnumerable<Libro>? libros) => libros?.OrderByDescending(l => l.Precio).FirstOrDefault();

    public Libro? GetMenorPrecio(IEnumerable<Libro>? libros) => libros?.OrderBy(l => l.Precio).FirstOrDefault();

    public List<Libro> GetMayorPromedio(IEnumerable<Libro>? libros)
    {
        if (libros == null) return new List<Libro>();
        var avg = GetPromedioPrecios(libros);
        return libros.Where(l => l.Precio > avg).ToList();
    }

    public List<Libro> GetOrdenadosPorTituloDesc(IEnumerable<Libro>? libros) => libros?.OrderByDescending(l => l.Titulo).ToList() ?? new List<Libro>();
}
