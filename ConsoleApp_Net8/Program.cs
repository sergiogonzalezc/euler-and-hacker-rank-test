namespace ConsoleApp_Net8
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            RestAPI api = new RestAPI();
            var output = await api.GetRestData();
        }
    }
}
