using System;
using System.Net.Http;
using System.Text.Json;
using viaCep;

class Program {
    static async Task Main(string[] args) {
        string sair;
        do {
            Console.WriteLine("---------------------------- Busca por CEP ----------------------------");

            Console.Write("Digite o CEP que deseja consultar: ");
            string cepConsulta = Console.ReadLine();

            string url = $"https://viacep.com.br/ws/{cepConsulta}/json/";

            HttpClient client = new HttpClient();

            try {
                HttpResponseMessage resposta = await client.GetAsync(url);   // Envia uma requisição GET para a URL especificada e espera a resposta

                if (resposta.IsSuccessStatusCode) {                             // Verifica se a resposta da requisição foi bem-sucedida
                    string json = await resposta.Content.ReadAsStringAsync();   //Lê o arquivo

                    Endereco endereco = JsonSerializer.Deserialize<Endereco>(json);     //deserialize server para converter o JSON em objeto para o C#

                    Console.WriteLine($"CEP: {endereco.cep}");
                    Console.WriteLine($"Rua: {endereco.logradouro}");
                    Console.WriteLine($"Bairro: {endereco.bairro}");
                    Console.WriteLine($"Cidade: {endereco.localidade}");
                    Console.WriteLine($"UF: {endereco.uf}");

                }
                else {
                    Console.WriteLine($"Erro na requisição: {resposta.StatusCode}");
                }
            }

            catch (Exception ex) {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            Console.WriteLine("Deseja realizar outra consulta? (Y/N)");
            sair = Console.ReadLine();

        } while (sair != "N" && sair != "n");
    }
}
       
    
   

            