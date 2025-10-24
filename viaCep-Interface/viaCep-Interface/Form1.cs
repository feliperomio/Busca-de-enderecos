using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace viaCep_Interface
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private async void btnBuscar_Click(object sender, EventArgs e) {        //para botão que faz um get na API, lembrar de botar async antes do void senao n funciona


            string url = $"https://viacep.com.br/ws/{textBoxCep.Text}/json/";


            HttpClient client = new HttpClient();

            HttpResponseMessage resposta = await client.GetAsync(url);
            string json = await resposta.Content.ReadAsStringAsync();
            Endereco endereco = JsonSerializer.Deserialize<Endereco>(json);
          
            dataGridView1.DataSource = new List<Endereco> { endereco }; 
            }

        private void textBoxCep_KeyPress(object sender, KeyPressEventArgs e) {      //chama o metodo que só aceita numeros que esta no program.cs
            Program.IntNumber(e);
        }
    }
}
