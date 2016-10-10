using UnityEngine;
using System.Collections.Generic;

public struct CityGenerateData
{
    public int peopleCount;
}
public class Town
{
   public List<Person> Persons = new List<Person>();
    List<string> Tags = new List<string>();

    public void GenerateTown( CityGenerateData gd)
    {
        Persons.Clear();
        for (int i = 0; i < gd.peopleCount; i++)
        {
            Persons.Add(Person.GetRandomPerson());            
        }
    }
    public void ListPersons()
    {
        foreach (var p in Persons)
            Debug.Log(p.ToString());
    }
}

