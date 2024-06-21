using AlcLibrary;

namespace TestForm
{
    internal class ProdutoModel : ModelBase<ProdutoModel>
    {      
        public string Name { get; set; }
        public string Preco { get; set; }

        public ProdutoModel() { }
        public ProdutoModel(int id, string name, string preco)
        {
            this.Id = id;
            this.Name = name;
            this.Preco = preco;
        }

        //public override string ToString()
        //{
        //    return $"Id: {Id}, Name: {Name}, Preco: {Preco}";
        //}

    }

}
