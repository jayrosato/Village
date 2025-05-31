using System.Net.NetworkInformation;

public class Character
{
    private string name;
    private string surname;
    private Title title;
    private Origin origin;
    private Prof profession;
    private int attitude;
    public int Attitude
    {
        get => attitude;
        private set
        {
            attitude = Math.Clamp(value, -100, 100);
        }
    }
    private int activism;
    public int Activism
    {
        get => activism;
        private set
        {
            activism = Math.Clamp(value, -100, 100);
        }
    }
    private int reputation;
    public int Reputation
    {
        get => reputation;
        private set
        {
            reputation = Math.Clamp(value, -100, 100);
        }
    }
    public Character(
        string name, string surname, Title title, Origin origin, Prof profession, int attitude,
        int activism, int reputation
    )
    {
        this.name = name;
        this.surname = surname;
        this.title = title;
        this.origin = origin;
        this.profession = profession;
        this.Attitude = attitude;
        this.Activism = activism;
        this.Reputation = reputation;
    }
    public String GetName()
    {
        return $"{name} {surname}";
    }
    public String GetNameTitle()
    {
        return $"{title} {name} {surname}";
    }
    public String GetEverything()
    {
        return $"{title} {name} {surname}, {profession} of {origin}.";
    }
    public int GetCharAttr(AttributeType attribute)
    {
        switch (attribute)
        {
            case AttributeType.Attitude:
                return this.Attitude;
            case AttributeType.Activism:
                return this.Activism;
            case AttributeType.Reputation:
                return this.Reputation;
        }
        return 0;
    }
    public void SetCharAttr(AttributeType attribute, int delta)
    {
        switch (attribute)
        {
            case AttributeType.Attitude:
                ChangeAttitude(delta);
                break;
            case AttributeType.Activism:
                ChangeActivism(delta);
                break;
            case AttributeType.Reputation:
                ChangeReputation(delta);
                break;
        }
    }
    public void ChangeAttitude(int delta)
    {
        Attitude += delta;
    }
    public void ChangeActivism(int delta)
    {
        Activism += delta;
    }
    public void ChangeReputation(int delta)
    {
        Reputation += delta;
    }
    public void SetTitle(Title title)
    {
        this.title = title;
    }
    public void SetProfession(Prof profession)
    {
        this.profession = profession;
    }
}