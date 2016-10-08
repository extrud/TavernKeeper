using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

class Person
{
    CharClass chClass;
    string name;
    int solvency;
    int drunk;
    List<String> tags;
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
}

