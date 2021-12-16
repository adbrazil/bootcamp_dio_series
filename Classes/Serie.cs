using System;
using DIO.Series.Classes;

namespace DIO.Serie
{
    public class Serie : ProdutoCatalogo
    {

    
        public Serie(int id,Genero genero,string titulo,string descricao,int ano){

            this.Id=id;
            this.Genero=genero;
            this.Titulo= titulo;
            this.Descricao=descricao;
            this.Ano=ano;
            this.Excluido=false;

        }

        public override string ToString(){
            string retorno = "";

            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;

            return retorno;
        }
  
        public int retornaId(){
            return this.Id;
        }

        public string retornaTitulo(){
            return this.Titulo;
        }

        public void Excluir(){
            this.Excluido=true;
        }
        
    }
}