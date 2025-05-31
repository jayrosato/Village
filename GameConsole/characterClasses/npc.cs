using System.Net.NetworkInformation;

public class NPC : Character
{
    private int opinion;
    public int Opinion
    {
        get => opinion;
        private set
        {
            opinion = Math.Clamp(value, -100, 100);
        }
    }
    private int attraction;
    public int Attraction
    {
        get => attraction;
        private set
        {
            attraction = Math.Clamp(value, -100, 100);
        }
    }
    public NPC(
        string name, string surname, Title title, Origin origin, Prof profession, int attitude,
        int activism, int reputation, int opinion, int attraction
    ) : base(name, surname, title, origin, profession, attitude, activism, reputation)
    {
        this.Opinion = opinion;
        this.Attraction = attraction;
    }
    public void ChangeOpinion(int delta)
    {
        Opinion += delta;
    }

}