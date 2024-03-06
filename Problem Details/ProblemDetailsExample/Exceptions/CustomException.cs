namespace ProblemDetailsExample
{
    public class GreetingException : Exception
    {
        public string Greeting { set; get; }
        public GreetingException(string greeting)
        {
            Greeting = greeting;
        }
    }
}