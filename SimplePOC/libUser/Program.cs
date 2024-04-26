using System.Reflection;

internal class SimplePOCUser
{
    private static void Main(string[] args)
    {
        try {
            // Retrieve new dll if needed
            string distantDllFilePath = @"../../../../lib/bin/Debug/net8.0/lib.dll";
            string currentDllFilePath = @"../../../usedDll/SimplePOCLib.dll";
            FileInfo distantDllFile = new(distantDllFilePath), currentDllFile = new(currentDllFilePath);
            if (!currentDllFile.Exists || currentDllFile.LastWriteTimeUtc < distantDllFile.LastWriteTimeUtc)
                File.Copy(distantDllFilePath, currentDllFilePath, true);

            // Load the DLL and test it
            Assembly dll = Assembly.LoadFile(currentDllFile.FullName);
            Type type = dll.GetType("SimplePOCLib.POC") ?? throw new Exception("Class missing");
            MethodInfo method = type?.GetMethod("Run") ?? throw new Exception("Method missing");
            object POC = Activator.CreateInstance(type) ?? throw new Exception("Instance creation failed");
            //----
            object[] parameters = [new string[] { @"Hello", @"world" }];
            object res = method.Invoke(POC, parameters) ?? throw new Exception("Method call failed");
            Console.WriteLine(res.ToString());
        }
        catch (Exception e) { Console.WriteLine(e.ToString()); }
    }
}
