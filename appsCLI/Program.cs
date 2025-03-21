using appsCLI;

List<Apps> lista = Apps.LoadFromCsv(@"..\..\..\src\apps.csv");

var i = 1;
Console.WriteLine("6.Feladat - Kiírás");
foreach (var item in lista)
{
    Console.WriteLine($"{i} {item.ToString()}");
    i++;
}

Console.WriteLine("7.Feladat - Válogatás");

var lastUpdateY = lista
    .OrderByDescending(x => x.UpdateYear)
    .First();
var lastUpdateM = lista
    .Where(x => x.UpdateYear == lastUpdateY.UpdateYear)
    .OrderByDescending(y => y.UpdateMonth)
    .First();

var mindenkinek = lista
    .Where(x => x.ContentRating.ContentRatingName == "Everyone" && x.Category.CategoryName == "PHOTOGRAPHY" && x.UpdateYear == lastUpdateY.UpdateYear && x.UpdateMonth == lastUpdateM.UpdateMonth).ToList();

Console.WriteLine($"Frissítve: {lastUpdateY.UpdateYear}.{lastUpdateM.UpdateMonth}");
foreach (var item in mindenkinek)
{
    Console.WriteLine($"{item.ToString()}");
}

var sw = new StreamWriter(@"..\..\..\src\bests.txt");

var sorrend = lista.OrderByDescending(x => x.Rating).ToList();

foreach (var item in sorrend)
{
    if (item.Rating == -1)
    {
        Console.WriteLine($"NO RESULT \t {item.AppName}");
    }
    else Console.WriteLine($"{item.Rating} \t {item.AppName}");
}

sw.Close();