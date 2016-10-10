
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Person
{
    public static Person GetRandomPerson()
    {
        List<string> TagsL =  new List<string>() ;
        int TagsCount = Random.Range(0, 5);
        bool nomoretags = false;
        for (int j = 0; j < TagsCount; j++)
        {
            if (nomoretags)
                break;
            int tagid = Random.Range(0, StaticData.Tags1.Count);
           
            if (TagsL.Contains(StaticData.Tags1[tagid]))
            {
                Debug.Log("CONTAINS!!!!");
                int i = tagid;
                while (TagsL.Contains(StaticData.Tags1[i]))
                {
                    i++;
                    if (i >= StaticData.Tags1.Count)
                    {
                        i = 0;
                    }
                    if (tagid == i)
                    {
                        nomoretags = true;
                        break;
                    }
                }
                if (!nomoretags)
                {
                    TagsL.Add(StaticData.Tags1[i]);
                }
                  
            }
            else
            {
                TagsL.Add(StaticData.Tags1[tagid]);
            }
            }
        Person newPerson = new Person()
        {
            Name = StaticData.GetRandomName(),
            ChClass = StaticData.GetRandomClass(),
            Lastname = StaticData.GetRandomLastName(),
            Solvency = Random.Range(0, 6),
            Tags = TagsL,
            drunk = 0
        };
        return newPerson;
    }
    CharClass chClass;
    string name;
    string lastname;
    int solvency;
    int drunk;
    List<string> tags;
    public override string ToString()
    {
        string res = Name + ' ' + Lastname + ' ' + chClass.Name + " Tags:";
        foreach (var t in Tags)
        {
            res += t + ";";
        }
        return res;
    }
    bool IsHaveTag(string tag)
    {
        return tags.Contains(tag);
    }
    void RemoveTag(string tag)
    {
        tags.Remove(tag);
    }
    void AddTag(string tag)
    {
        tags.Add(tag);
    }
    internal CharClass ChClass
    {
        get
        {
            return chClass;
        }

        set
        {
            chClass = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int Solvency
    {
        get
        {
            return solvency;
        }

        set
        {
            solvency = value;
        }
    }

    public int Drunk
    {
        get
        {
            return drunk;
        }

        set
        {
            drunk = value;
        }
    }

    public List<string> Tags
    {
        get
        {
            return tags;
        }

        set
        {
            tags = value;
        }
    }

    public string Lastname
    {
        get
        {
            return lastname;
        }

        set
        {
            lastname = value;
        }
    }
}

