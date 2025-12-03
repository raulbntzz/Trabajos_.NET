using System.Text;

namespace SumarNumeros
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task tarea = GenerarFicheroAsync();

            while (!tarea.IsCompleted)
            {
                Console.WriteLine("Generación del fichero en proceso");
                await Task.Delay(500);
            }

            Console.WriteLine("Finalizada la generación del fichero");

            var progreso = new Progress<int>();

            int sumaTotal = await LeerYSumarNumerosAsync(progreso);

            Console.WriteLine($"Suma total: {sumaTotal}");

            await Task.Delay(3000);
        }

        static async Task GenerarFicheroAsync()
        {
            await using var writer = new StreamWriter("numeros.txt");

            var rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                int numero = rnd.Next(1, 100);
                await writer.WriteLineAsync(numero.ToString());
                await writer.FlushAsync();
                await Task.Delay(50);
            }
        }

        static async Task<int> LeerYSumarNumerosAsync(IProgress<int> progreso)
        {
            int suma = 0;
            int lineasProcesadas = 0;

            using var reader = new StreamReader("numeros.txt");

            string? linea;
            while ((linea = await reader.ReadLineAsync()) != null)
            {
                if (int.TryParse(linea, out int numero))
                {
                    suma += numero;
                }

                lineasProcesadas++;
                int porcentaje = lineasProcesadas;
                progreso?.Report(porcentaje);
            }

            return suma;
        }
    }
}
