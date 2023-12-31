using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonDiffer.Services;

public class ComparisonSpaceService
{
    public event Action<List<ComparisonSpace>> SpacesUpdated;

    private List<ComparisonSpace> _spaces = new List<ComparisonSpace>();
    
    public void Do()
    {
        _spaces = new List<ComparisonSpace>
        {
            new ComparisonSpace
            {
                Name = "One"
            },
            new ComparisonSpace
            {
                Name = "Two"
            },
            new ComparisonSpace
            {
                Name = "Three"
            }
        };
        SpacesUpdated.Invoke(_spaces);
        //JsonSerializer.Deserialize<HarJson>(jsonString);
    }
}

public class ComparisonSpace
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<HarJson> HarJsons { get; set; }= new List<HarJson>();
}