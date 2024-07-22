using NoteBook2_name.NoteBook2.Core.Data;
using NoteBook2_name.NoteBook2.Core.Entity;
using NoteBook2_name.NoteBook2.Core.Service;
using System;

NoteService2 dataService = new NoteService2(new NoteDataSource2());

Console.WriteLine("Start");
Console.WriteLine(string.Join("\n", dataService.GetAll()));
dataService.Create(new Note("Интерстеллар"));
Console.WriteLine("Added Интерстеллар");
Console.WriteLine(string.Join("\n", dataService.GetAll()));

Note tmp = new Note("Вверх");
dataService.Create(tmp);
Console.WriteLine("Added Вверх");
Console.WriteLine(string.Join("\n", dataService.GetAll()));

Note tmp2 = new Note("Пираты");
dataService.Update(tmp2);
Console.WriteLine("Changed Интерстеллар to Пираты");
Console.WriteLine(string.Join("\n", dataService.GetAll()));

dataService.Delete(tmp.ItemId);
Console.WriteLine("Deleted Вверх");
Console.WriteLine(string.Join("\n", dataService.GetAll()));

dataService.Delete(tmp2.ItemId);
Console.WriteLine("Deleted Интерстеллар");
Console.WriteLine(string.Join("\n", dataService.GetAll()));