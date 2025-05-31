using System.Net.NetworkInformation;

public enum Trait
{
    None,
    Orator,
    Barbed,
    Cheerful
}
public class Adlo : Character
{
    public int Charisma { get; set; }
    public List<Trait> Traits { get; set; }
    public Adlo(
        string name, string surname, string title, string origin, string profession, int attitude,
        int activism, int reputation, int charisma
    ) : base(name, surname, title, origin, profession, attitude, activism, reputation)
    {
        this.Charisma = charisma;
        this.Traits = new List<Trait>();
    }
    public int GetAdloValue(AttributeType attribute)
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
    public void GetAdloTraits()
    {
        if (this.Traits.Count() == 0)
        {
            Console.WriteLine("Adlo has no traits...");
        }
        for (int i = 0; i < this.Traits.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {this.Traits[i]}");
        }
    }
}