using System;
using System.Windows.Forms;
using AlcLib;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODOS FUNCIONARAM
            //Database db = new Database();
            //var list = db.Find("pessoas", "nome,email", "[cgc]='' AND email<>''");

            //db.Update("pessoas", "[codigo do local]=1", "[codigo da pessoa]=1");
            //list = db.Find("pessoas", "nome,email,[codigo do local]", "[codigo da pessoa]=1");

            //db.Insert("atividades", "[Codigo da Atividade],[Descricao da Atividade],rdata,Rhora", "16,'minha atvidade',GETDATE(),GETDATE()");
            //list = db.Find("atividades", "*", "[Codigo da Atividade]=16");
            //------------------

            //TODOS FUNCIONARAM
            //LFile lfile = new LFile("logs.txt");
            //lfile.WriteFile("Meu arquivo de logs");
            //lfile.WriteFile("Novo texto");

            //string texto = lfile.ReadFile();
            //Console.WriteLine(texto);


            //string apiUrl = Config.GetConfigValue("apiHost");
            //Console.WriteLine(apiUrl);
            //-----------------

            //ProdutoModel produto = new ProdutoModel(1, "Joao", "15.50");
            //string json = produto.ToJson();
            //Console.WriteLine(json);


            //ProdutoModel model = ProdutoModel.FromJson(json);



        }
    }
}
