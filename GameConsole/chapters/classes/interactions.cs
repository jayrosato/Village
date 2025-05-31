using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;


public class Interaction
{
    public string Title { get; set; }
    public NPC Character { get; set; }
    public int ReqOpinion { get; set; }
    public AttributeType ReqAttribute { get; set; }
    public int Threshold { get; set; }
    public Trait ReqTrait { get; set; }
    public bool Completed { get; set; }

    public Interaction(string title = "", NPC character = null, int reqOpinion = 0,
    AttributeType reqAttribute = AttributeType.None, int threshhold = 0, Trait reqTrait = Trait.None)
    {
        this.Character = character;
        this.ReqOpinion = reqOpinion;
        this.ReqAttribute = reqAttribute;
        this.Threshold = threshhold;
        this.ReqTrait = reqTrait;
        this.Completed = false;
        if (title == "" && this.Character != null)
        {
            this.Title = this.Character.GetName();
        }
    }
    public virtual void Dialogue()
    {
        return;
    }
}
public class Line
{
    public string Dialogue { get; set; }
    public Decision Decision { get; set; }

    public Line(string dialogue, Decision decision = null)
    {
        this.Dialogue = dialogue;
        this.Decision = decision;
    }
    public void WriteLine()
    {
        Console.WriteLine($"{this.Dialogue}");
        if (this.Decision != null)
        {
            Decision.MakeDecision();
        }
        Console.ReadKey();
    }
}