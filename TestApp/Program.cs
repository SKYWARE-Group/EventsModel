// See https://aka.ms/new-console-template for more information
using Skyware.Lis.EventsModel;
using System.Diagnostics;
using System.Reflection;

Console.WriteLine("Hello, World!");

var pr = Process.GetCurrentProcess().MainModule.FileName;
var fn = System.IO.Path.Combine(Path.GetDirectoryName(pr), "Skyware.Lis.EventsModel.dll");
Assembly assembly = Assembly.LoadFile(fn);
var allTypes = assembly.GetTypes();
var bm = allTypes.FirstOrDefault(x => x.Name == "BaseMessage");
foreach (Type x in assembly.GetTypes())
{
    //Console.WriteLine(x.FullName);
    if (x.GetType().IsSubclassOf(bm))
    {
        Console.WriteLine(x.Name);
    }
}
//Console.WriteLine("");

//string nspace = "Skyware.Lis.EventsModel.Instruments";

//var q = from t in assembly.GetTypes()
//        where t.IsClass && t.Namespace == nspace
//        select t;
//q.ToList().ForEach(t => Console.WriteLine(t.Name));