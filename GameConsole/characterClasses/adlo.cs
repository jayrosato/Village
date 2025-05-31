using System.Net.NetworkInformation;
public class Adlo : Character
{
    private int charisma { get; set; }
    public int Charisma
    {
        get => charisma;
        private set
        {
            charisma = Math.Clamp(value, -100, 100);
        }
    }
    public List<Trait> Traits { get; set; }
    public Adlo(
        string name, string surname, Title title, Origin origin, Prof profession, int attitude,
        int activism, int reputation, int charisma
    ) : base(name, surname, title, origin, profession, attitude, activism, reputation)
    {
        this.Charisma = charisma;
        this.Traits = new List<Trait>();
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