using System.Net.NetworkInformation;
public class Adlo : Character
{
    private int charisma;
    public int Charisma
    {
        get => charisma;
        private set
        {
            charisma = Math.Clamp(value, -100, 100);
        }
    }
    private List<Trait> traits;
    public Adlo(
        string name, string surname, Title title, Origin origin, Prof profession, int attitude,
        int activism, int reputation, int charisma
    ) : base(name, surname, title, origin, profession, attitude, activism, reputation)
    {
        this.Charisma = charisma;
        this.traits = new List<Trait>();
    }
    public void AttitudeTraits()
    {
        if (Attitude < -10)
        {
            traits.Remove(Trait.Cheerful);
            traits.Remove(Trait.LevelHeaded);
            AddAdloTrait(Trait.Melancholic);
        }
        if (Attitude > 10)
        {
            traits.Remove(Trait.Melancholic);
            traits.Remove(Trait.LevelHeaded);
            AddAdloTrait(Trait.Cheerful);
        }
        if (Attitude >= -10 && Attitude <= 10)
        {
            traits.Remove(Trait.Melancholic);
            traits.Remove(Trait.Cheerful);
            AddAdloTrait(Trait.LevelHeaded);
        }
    }
    public void ActivismTraits()
    {
        if (Activism < -10)
        {
            traits.Remove(Trait.FreedomFighter);
            traits.Remove(Trait.Pragmatic);
            AddAdloTrait(Trait.Reactionary);
        }
        if (Activism > 10)
        {
            traits.Remove(Trait.Reactionary);
            traits.Remove(Trait.Pragmatic);
            AddAdloTrait(Trait.FreedomFighter);
        }
        if (Activism >= -10 && Activism <= 10)
        {
            traits.Remove(Trait.Reactionary);
            traits.Remove(Trait.FreedomFighter);
            AddAdloTrait(Trait.Pragmatic);
        }
    }
    public bool CheckAdloTrait(Trait trait)
    {
        return traits.Contains(trait);
    }
    public void AddAdloTrait(Trait trait)
    {
        if (!traits.Contains(trait))
            traits.Add(trait);
        Console.Write($"Adlo has gained the trait {trait}!");
    }
    public String GetAdloTraits()
    {
        if (this.traits.Count == 0)
        {
            return "Adlo has no traits...";
        }
        string traits = "";
        for (int i = 0; i < this.traits.Count(); i++)
        {
            traits += $"\n{i + 1}. {this.traits[i]}";
        }
        return traits;
    }
}