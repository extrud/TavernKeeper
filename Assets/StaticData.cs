using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public static class StaticData
 {
    static List<string> Tags = new List<string>() { "Friendly", "Evil", "Gready", "Popular","Stupid","Rude","Agressive","Crazy","Libiertine", "Fastidious", "Mockery", "Drunkard" };
    static List<string> Names = new List<string>() {
        "Yogan","August","Ragnar","Atelstan","Flok","Irius","Claus","Jesus","Robin","Raxar","Odrik","Hodoor","Tirion","Robert","Nead","Tomas","Jeson","Jofry","Elliot","Francisk"
    };
    static List<string> Lastnames = new List<string>() {
        "Barateon","Lodbrok","Lanister","Adenwoolf","Freid","Nores","Stark","Gray","White","Black","Color","Gold","Vesker"
    };
    public static string GetRandomName()
    {
        return Names[Random.Range(0,Names.Count)];
    }
    public static string GetRandomLastName()
    {
        return Lastnames[Random.Range(0, Lastnames.Count)];
    }
    public static CharClass GetRandomClass()
    {
        return Classes[Random.Range(0, Classes.Count)];
    }
    public static string GetRandomTag()
    {
        return Tags[Random.Range(0, Tags.Count)];
    }
    static List<CharClass> Classes = new List<CharClass>()
    {
        new CharClass("Priest",5,2,3,new Sprite[]  { Resources.Load<Sprite>("Portrets/Prest.png") }),
        new CharClass("Hunter",2,2,6,new Sprite[]  { Resources.Load<Sprite>("Portrets/Hunter.png")}),
        new CharClass("Guard",2,6,2,new Sprite[]  { Resources.Load<Sprite>("Portrets/Guard.png")}),
        new CharClass("Doctor",2,6,2,new Sprite[]  { Resources.Load<Sprite>("Portrets/Doctor.png")}),
        new CharClass("Turist",4,6,1,new Sprite[]  { Resources.Load<Sprite>("Portrets/Turist.png")}),
     };

    public static List<string> Tags1
    {
        get
        {
            return Tags;
        }

        set
        {
            Tags = value;
        }
    }

    public static List<string> Names1
    {
        get
        {
            return Names;
        }

        set
        {
            Names = value;
        }
    }

    public static List<string> Lastnames1
    {
        get
        {
            return Lastnames;
        }

        set
        {
            Lastnames = value;
        }
    }

    internal static List<CharClass> Classes1
    {
        get
        {
            return Classes;
        }

        set
        {
            Classes = value;
        }
    }
}
