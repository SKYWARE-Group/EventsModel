// See https://aka.ms/new-console-template for more information
using Skyware.Lis.EventsModel;
using System.Diagnostics;
using System.Reflection;


string curLoc = System.Reflection.Assembly.GetExecutingAssembly().Location;
var libFileName = System.IO.Path.Combine(Path.GetDirectoryName(curLoc), "Skyware.Lis.EventsModel.dll");
Assembly libAssembly = Assembly.LoadFile(libFileName);
var allAssemblyTypes = libAssembly.GetTypes();
var baseMessageType = allAssemblyTypes.FirstOrDefault(x => x.Name == nameof(Skyware.Lis.EventsModel.BaseMessage));
foreach (Type curType in libAssembly.GetTypes())
{
    //Console.WriteLine(x.FullName);
    if (curType.IsSubclassOf(baseMessageType))
    {
        var obj = Activator.CreateInstance(curType);
        var objVal = baseMessageType.InvokeMember(nameof(Skyware.Lis.EventsModel.BaseMessage.DefaultAddress), BindingFlags.GetProperty, null, obj, null);
        Console.WriteLine($"{objVal}: {curType.Name}");
    }
}
