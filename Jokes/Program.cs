using Jokes;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;


class Program
{

    HttpClient client = new HttpClient();
    static async Task Main()
    {
        Program program = new Program();

        Console.WriteLine("1. Deserialize a joke\n2. Serialize a joke");
        string input = "-1";
        while (input != "0")
        {
            
            input = Console.ReadLine();
            if (input == "1")
            {
                await program.Deserialize();
                Console.WriteLine("desiralization complete");

            }
            else if (input == "2")
            {
                program.serialization();
                Console.WriteLine("Serialization complete");
            }
            Console.WriteLine("1. Deserialize a joke\n2. Serialize a joke");
        }
      

    }
    //Deserialize from the 
    private async Task Deserialize()
    {
      
        string fileName = "joke.json";
        string jsonString = File.ReadAllText(fileName);
        Joke joke = JsonSerializer.Deserialize<Joke>(jsonString)!;
        Console.WriteLine(joke.joke);

        Console.WriteLine(joke.Setup);

        Console.WriteLine(joke.Delivery);

    }
    //Serialize data from the API
    private async Task serialization()
    {
       
        
        client = new()
        {
            BaseAddress = new Uri("https://v2.jokeapi.dev")
        };

        Joke? joke = await client.GetFromJsonAsync<Joke>("/joke/any");

      
        var options = new JsonSerializerOptions();
        options.WriteIndented = true;
        string jsonString = JsonSerializer.Serialize<Joke>(joke, options);
        File.WriteAllText("joke.json", jsonString);
    }
}

