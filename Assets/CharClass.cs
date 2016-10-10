using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharClass
    {
        string name;
        int vine;
        int beer;
        int whiskey;

        Sprite[] classSprites;

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

    public int Vine
    {
        get
        {
            return vine;
        }

        set
        {
            vine = value;
        }
    }

    public int Beer
    {
        get
        {
            return beer;
        }

        set
        {
            beer = value;
        }
    }

    public int Whiskey
    {
        get
        {
            return whiskey;
        }

        set
        {
            whiskey = value;
        }
    }

    public Sprite[] ClassSprites
    {
        get
        {
            return classSprites;
        }

        set
        {
            classSprites = value;
        }
    }

    public CharClass(string name, int vine, int beer, int whiskey, Sprite[] classSprites)
    {
        this.Name = name;
        this.Vine = vine;
        this.Beer = beer;
        this.Whiskey = whiskey;
        this.ClassSprites = classSprites;
    }
}

