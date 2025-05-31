public class TestInteraction : Interaction
{
    public TestInteraction(string title = "", NPC character = null, int reqOpinion = 0,
    AttributeType reqAttribute = 0, int threshhold = 0, Trait reqTrait = Trait.None)
    : base(title, character, reqOpinion, reqAttribute, threshhold, reqTrait)
    {
        this.Completed = false;
    }
    public override void Dialogue()
    {
        Console.WriteLine("HINT: When you see '...', hit any key to continue");
        Console.WriteLine("Odelerg...");
        Console.ReadKey();
        Console.WriteLine("Clara: Good Morning, Master Eier!");
        Console.ReadKey();
        Option option0 = new Option(
            prompt: "Good Morning Clara! So Amazing to see you!",
            setAttribute: AttributeType.Attitude,
            getAttribute: AttributeType.Attitude,
            amount: 1,
            threshhold: 1,
            opinion: 2,
            traitRequired: Trait.Cheerful
        );
        Option option1 = new Option(
            prompt: "Good morning Clara!",
            setAttribute: AttributeType.Attitude,
            amount: 1,
            opinion: 1
        );
        Option option2 = new Option(
            prompt: "Hi, Clara."
        );
        Option option3 = new Option(
            prompt: "[shrug]",
            setAttribute: AttributeType.Attitude,
            amount: -1,
            opinion: -1
        );
        Decision testDecision = new Decision(Globals.Adlo, [option0, option1, option2, option3], this.Character);
        testDecision.MakeDecision();
        bool pass = Check.OpinionCheck(Globals.Adlo, this.Character, 1);
        if (pass)
        {
            Console.WriteLine("How are you today, Adlo?");
            pass = Check.SelfCheck(Globals.Adlo, AttributeType.Attitude, 1);
            if (pass)
            {
                Console.WriteLine("I'm great!");
            }
            else
            {
                Console.WriteLine("Meh...");
            }
        }
        Console.WriteLine("\n ...");
        this.Completed = true;
    }
}