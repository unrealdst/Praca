namespace WebApplication1.Controllers
{
    public class HelloWorld : IHelloWorld
    {
        public string GetHelloWorld()
        {
            return "Hellow world";
        }
    }
}