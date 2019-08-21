using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Dominio.Entidades
{
    public class Airplane
    {
        public Airplane(string codigo, string modelo, int quantidadePassageiros, DateTime dataCadastro)
        {           
            setQuantidadePassageiros(quantidadePassageiros);
            setCodigo(codigo);
            setModelo(modelo);
            this.DataCadastro = DateTime.Now;
        }

        protected Airplane() { }

        public int Id { get; private set; }
        public string Codigo { get; private set; }        
        public string Modelo { get; private set; }
        public int QuantidadePassageiros { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public void setCodigo(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
                Codigo = codigo;
        }

        public void setModelo(string modelo)
        {
            if (!string.IsNullOrEmpty(modelo))
                Modelo = modelo;
        }

        public void setQuantidadePassageiros(int quantidadePassageiros)
        {
            if (quantidadePassageiros > 0)
                QuantidadePassageiros = quantidadePassageiros;
        }

        //public void setId(int id)
        //{
        //    if (id > 0)
        //        Id = id;
        //}
    }
}
