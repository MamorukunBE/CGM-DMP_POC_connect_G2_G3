using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SimplePOCLib;

WebAssemblyHostBuilder.CreateDefault(args);

namespace SimplePocWasm
{
    public class WasmClass
    {
        [JSInvokable]
        public static Task<string> WasmMethod(string[] args)
        {
            return Task.FromResult(POC.Run(args));
        }
    }
}
