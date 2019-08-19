using Gol.Dominio.Entidades;
using Gol.InfraData.Contexto;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.InfraData.DadosIniciais
{
    public class Seed
    {
        public static void Initialize(EfDbContext contexto)
        {
            contexto.Database.EnsureCreated();

            // Look for any students.
            if (contexto.Airplanes.Any())
            {
                return;   // DB has been seeded
            }

            var airplanes = new Airplane[]
            {
            new Airplane("Codigo 1", "Modelo 1", 101, DateTime.Now),
            new Airplane("Codigo 2", "Modelo 2", 102, DateTime.Now),
            new Airplane("Codigo 3", "Modelo 3", 103, DateTime.Now),
            new Airplane("Codigo 4", "Modelo 4", 104, DateTime.Now),
            new Airplane("Codigo 5", "Modelo 5", 105, DateTime.Now),
            new Airplane("Codigo 6", "Modelo 6", 106, DateTime.Now),
            new Airplane("Codigo 7", "Modelo 7", 107, DateTime.Now),
            new Airplane("Codigo 8", "Modelo 8", 108, DateTime.Now),
            new Airplane("Codigo 9", "Modelo 9", 109, DateTime.Now),
            new Airplane("Codigo 10", "Modelo 10", 110, DateTime.Now),
            };
            foreach (Airplane a in airplanes)
            {
                contexto.Airplanes.Add(a);
            }
            contexto.SaveChanges();
        }
    }
}