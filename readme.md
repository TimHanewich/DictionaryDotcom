# Dictionary.com Nuget Package
A light-weight .NET library for accessing word definitions from Dictionary.com.

## Installing
The package is available to install from nuget [here](https://www.nuget.org/packages/DictionaryDotcom). To install via the .NET command line interface:
```
dotnet add package DictionaryDotcom
```

## Retrieving a definition
```
DictionaryService service = new DictionaryService();
DefinitionSet ds = await service.DefineAsync("departmentalize");
foreach (Definition def in ds.Definitions)
{
    Console.WriteLine(def.Class.ToString() + " - " + def.Description);
    Console.WriteLine("\t" + "Example: " + def.Example);
    Console.WriteLine();
}
```
You can also set a `DictionaryBook` to be used as storage for all retrieved definitions. After doing this, next time you request the same word twice from the `DictionaryService` class, the definition will be pulled from a saved copy of response from the initial request.

Example:
```
DictionaryService service = new DictionaryService();
DictionaryBook db = new DictionaryBook();
service.SetStorage(db);
DefinitionSet ds = await service.DefineAsync("departmentalize");
foreach (Definition def in ds.Definitions)
{
    Console.WriteLine(def.Class.ToString() + " - " + def.Description);
    Console.WriteLine("\t" + "Example: " + def.Example);
    Console.WriteLine();
}
Console.WriteLine(JsonConvert.SerializeObject(ds));
```
