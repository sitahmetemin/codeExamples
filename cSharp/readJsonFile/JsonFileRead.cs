public class JsonFileRead
{
    public void ReadFile()
    {
        using (StreamReader cityFile = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Cities.json")))
        {
            string jsonCity = cityFile.ReadToEnd();
            List<City> cities = JsonConvert.DeserializeObject<List<City>>(jsonCity);

            foreach (var city in cities)
            {
                List<Province> editedProvince = new List<Province>();
                using (StreamReader provinceFile = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Provinces.json")))
                {
                    string jsonProvince = provinceFile.ReadToEnd();
                    List<Province> Provinces = JsonConvert.DeserializeObject<List<Province>>(jsonProvince);

                    foreach (var provinceItem in Provinces)
                    {
                        if (city.LicensePlate == provinceItem.LicensePlate)
                        {
                            provinceItem.CityId = city.Id;
                            editedProvince.Add(provinceItem);
                        }
                    }
                }
            }
        }
    }
}

public class City
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int LicensePlate { get; set; }
}

public class Province
{
    public int Id { get; set; }
    public Guid CityId { get; set; }
    public int LicensePlate { get; set; }
    public string Name { get; set; }
}