namespace SimplePOCLib
{
    public class POC
    {
        public static string Run(string[] args)
        {
            return "[from DLL 5] " + String.Join(" ", args);
        }
    }
}
