using ClassAdapter;

Console.Title = "Adapter";

ICityAdapter adapter = new CityAdapter();

City city = adapter.GetCity();

Console.WriteLine($"City : {city.Name}, inhabitants: {city.Inhabitants}");