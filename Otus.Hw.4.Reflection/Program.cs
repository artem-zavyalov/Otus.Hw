// See https://aka.ms/new-console-template for more information

using Otus.Hw._4.Reflection;
using Otus.Hw._4.Reflection.Models;
using Otus.Hw._4.Reflection.Service;


Console.WriteLine("Hello, World!");

var classF = TestClass.Get();
var classF2 = TestClass2.Get();

//TimeTest
TimeTest.Serialization(classF, 10_000, true);
await TimeTest.Deserialization("TestJson.json", 10_000);

