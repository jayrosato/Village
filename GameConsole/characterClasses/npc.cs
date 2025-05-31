using System.Net.NetworkInformation;

public class NPC : Character
{
    public int Opinion { get; set; }
    int attraction { get; set; }
    public NPC(
        string name, string surname, string title, string origin, string profession, int attitude,
        int activism, int reputation, int opinion, int attraction
    ) : base(name, surname, title, origin, profession, attitude, activism, reputation)
    {
        this.Opinion = opinion;
        this.attraction = attraction;
    }

}