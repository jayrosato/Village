using System.Net.NetworkInformation;

public class Character
{
    private string name { get; set; }
    private string surname { get; set; }
    private string title { get; set; }
    private string origin { get; set; }
    private string profession { get; set; }
    public int Attitude { get; set; }
    public int Activism { get; set; }
    public int Reputation { get; set; }

    string outlook
    {
        get
        {
            if (Attitude >= -5 && Attitude <= 5) { return "Aloof"; }
            if (Attitude < -5) { return "Cynical"; }
            if (Attitude > 5) { return "Optimist"; }
            else { return "Error"; }
        }
    }
    string ideology
    {
        get
        {
            if (Activism >= -5 && Activism <= 5) { return "Neutral"; }
            if (Activism < -5) { return "Reactionary"; }
            if (Activism > 5) { return "Radical"; }
            else { return "Error"; }
        }
    }
    string renown
    {
        get
        {
            if (Reputation >= -5 && Reputation <= 5) { return "Unkown"; }
            if (Reputation < -5) { return "Infamous"; }
            if (Reputation > 5) { return "Famous"; }
            else { return "Error"; }
        }
    }
    public Character(
        string name, string surname, string title, string origin, string profession, int attitude,
        int activism, int reputation
    )
    {
        this.name = name;
        this.surname = surname;
        this.title = title;
        this.origin = origin;
        this.origin = origin;
        this.profession = profession;
        this.Attitude = attitude;
        this.Activism = activism;
        this.Reputation = reputation;
    }
    public String GetName()
    {
        return $"\n{name} {surname}";
    }
    public String GetNameTitle()
    {
        return $"\n{title} {name} {surname}";
    }
    public String GetEverything()
    {
        return $"\n{title} {name} {surname}, {profession}";
    }
}