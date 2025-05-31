public class Option
{
    public string Prompt { get; set; }
    public AttributeType SetAttribute { get; set; }
    public AttributeType GetAttribute { get; set; }
    public int Amount { get; set; }
    public int Threshhold { get; set; }
    public int Opinion { get; set; }
    public int OpRequired { get; set; }
    public Trait TraitRequired { get; set; }

    public Option(string prompt, AttributeType setAttribute = AttributeType.None,
    AttributeType getAttribute = AttributeType.None, int threshhold = 0, int amount = 0,
    int opinion = 0, int opRequired = 0, Trait traitRequired = Trait.None)
    {
        this.Prompt = prompt;
        this.SetAttribute = setAttribute;
        this.GetAttribute = getAttribute;
        this.Threshhold = threshhold;
        this.Amount = amount;
        this.Opinion = opinion;
        this.OpRequired = opRequired;
        this.TraitRequired = traitRequired;
    }
    public String SelfResult()
    {
        string result = "";
        if (this.SetAttribute != AttributeType.None && this.Amount != 0)
        {
            string dir = this.Amount > 0 ? "increased" : "decreased";
            result = $"Adlo's {SetAttribute} has {dir} by {Math.Abs(Amount)}...";
        }
        return result;
    }
    public String CharResult()
    {
        string result = "";
        if (this.Opinion != 0)
        {
            string dir = this.Amount > 0 ? "increased" : "decreased";
            result = $"opinion of Adlo has {dir} by {Math.Abs(Opinion)}...";
        }
        return result;
    }
}

public class Decision
{
    public Option[] Options { get; set; }
    public NPC Character { get; set; }

    public Decision(Option[] options, NPC character = null)
    {
        this.Options = options;
        this.Character = character;
    }
    public void MakeDecision()
    {
        Adlo adlo = Globals.Adlo;
        Option [] options = this.Options;
        NPC character = this.Character;

        var availableOptions = options
        .Where(o =>
            (o.GetAttribute == AttributeType.None || adlo.GetCharAttr(o.GetAttribute) >= o.Threshhold) &&
            (character == null || o.OpRequired == 0 || character.Opinion >= o.OpRequired) &&
            (o.TraitRequired == Trait.None || adlo.Traits.Contains(o.TraitRequired))
        ).ToList();
        bool awaitInput = true;
        while (awaitInput == true)
        {
            for (int i = 0; i < availableOptions.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {availableOptions[i].Prompt}");
            }
            if (int.TryParse(Console.ReadLine(), out int decision) && decision >= 1 && decision <= availableOptions.Count())
            {
                Option option = availableOptions[decision - 1];
                if (option.SetAttribute != AttributeType.None)
                {
                    adlo.SetCharAttr(option.SetAttribute, option.Amount);
                }
                Console.WriteLine($"{option.Prompt}");
                if (character != null && option.Opinion != 0)
                {
                    character.ChangeOpinion(option.Opinion);
                    Console.WriteLine($"{character.GetName()}'s {option.CharResult()} ({character.Opinion})");
                }
                if (option.SetAttribute != AttributeType.None && option.Amount != 0)
                {
                    Console.WriteLine($"{option.SelfResult()}");
                }
                awaitInput = false;
            }
            else
            {
                Console.WriteLine($"Enter a number between 1 and {availableOptions.Count()}");
            }
        }
    }
    /*
    public static void ColorDecision(string[] options)
    {
        bool awaitInput = true;
        while (awaitInput == true)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            if (int.TryParse(Console.ReadLine(), out int decision) &&
                decision >= 1 && decision <= options.Length)
            {
                Console.WriteLine($"{options[decision - 1]}");
            }
            else
            {
                Console.WriteLine($"Enter a number between 1 and {options.Length}");
            }
        }
    }
    */
}
