using System.Text;

namespace FicherosAleatorios
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task tarea = GenerarFicheroAsync();

            while (!tarea.IsCompleted)
            {
                Console.WriteLine("Generación del fichero en proceso");
                await Task.Delay(200);
            }

            Console.WriteLine("Finalizada la generación del fichero");
        }

        static async Task GenerarFicheroAsync()
        {
            await using var writer = new StreamWriter("numeros.txt");

            var rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                int numero = rnd.Next(1,100);
                await writer.WriteLineAsync(numero.ToString());
                await writer.FlushAsync();
                await Task.Delay(50);
            }
        }
    }
}
