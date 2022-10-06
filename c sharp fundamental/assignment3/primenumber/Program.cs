namespace PrimeNumberAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a list of prime numbers: ");

            var run = Task.WhenAll(GetPrimeNumber(10, 100), GetPrimeNumber(200, 300));

            Task.WaitAll(run);

            Console.WriteLine("\nThe Task is all done.");

            Console.ReadKey();
        }
        
        static async Task GetPrimeNumber(int startNumber, int endNumber)
        {
            await Task.Run(() =>
            {
                for (int number = startNumber; number <= endNumber; number++)
                {
                    int temporaryNumber = 0;

                    for (int rangeNumber = 2; rangeNumber <= number / 2; rangeNumber++)
                    {
                        if (number % rangeNumber == 0)
                        {
                            temporaryNumber++;
                            break;
                        }
                    }

                    if (temporaryNumber == 0 && number != 1)
                    {
                        Thread.Sleep(500);
                        Console.Write("{0} ", number);
                    }
                }
            });
        }
    }
}
