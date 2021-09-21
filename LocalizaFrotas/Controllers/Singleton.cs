namespace Localiza.Frotas.Controllers
{
    internal class Singleton
    {
        public Singleton()
        {
        }

        public static object Instance { get; internal set; }
    }
}