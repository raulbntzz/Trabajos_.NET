namespace TablaMultiplicarAsincrona
{
    internal class Program
    {
        // async marca un método cómo asíncrono
        static async Task Main(string[] args)
        {
            // Si usamos await EjemploAsync(); 
            // El método main espera a que termine la ejecución de EjemploAsync


            // EjemploAsync devuelve un Task que no quiero usar.
            // Por eso usamos _=
            _ = MetodoAsync();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main sigue trabajando...");
                await Task.Delay(1050);
            }

            await Task.Delay(1000);
        }


        static async Task MetodoAsync()
        {
            Console.WriteLine("==== Tabla Del 1 ====");
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine("1 x " + i + " = " + 1 * i);
                await Task.Delay(1000);
            }
            Console.WriteLine("Fin");
        }
    }
}
