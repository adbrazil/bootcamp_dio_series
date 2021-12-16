using DIO.Serie;

namespace DIO.Series.Classes
{
    public  class ProdutoCatalogo:EntidadeBase
    {

        protected  Genero Genero {get;set;}
        protected  string Titulo {get;set;}
        protected   string Descricao {get;set;}
        protected   int Ano {get;set;}
        protected   bool Excluido {get;set;}

        
    }
}