public class Room
{
    public string Name { get; set; }
    public Interaction[] Interactions { get; set; }
    public Room[] ConnectedRooms { get; set; }
    public Room(string name, Interaction[] interactions, Room[] connectedRooms = null)
    {
        this.Name = name;
        this.Interactions = interactions;
        this.ConnectedRooms = connectedRooms;
    }

    public List<Interaction> UpdateRoom()
    {
        Adlo adlo = Globals.Adlo;
        var availableInteractions = this.Interactions
            .Where(interaction =>
                (interaction.Completed != true) &&
                (interaction.ReqAttribute == AttributeType.None || adlo.GetCharAttr(interaction.ReqAttribute) >= interaction.Threshold) &&
                (interaction.Character == null || interaction.Character.Opinion >= interaction.ReqOpinion) &&
                (interaction.ReqTrait == Trait.None || Globals.Adlo.Traits.Contains(interaction.ReqTrait))
            ).ToList();
        return availableInteractions;
    }
    public void GenericRoom()
    {
        bool inRoom = true;
        Console.WriteLine($"Standing in {this.Name}...");
        List<Interaction> availableInteractions = UpdateRoom();
        while (inRoom)
        {
            if (availableInteractions.Count == 0)
            {
                Console.WriteLine("Nothing to see here...");
                if (this.ConnectedRooms == null)
                {
                    break;
                }
                for (int i = 0; i < availableInteractions.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {ConnectedRooms[i].Name}");
                    }
                if (int.TryParse(Console.ReadLine(), out int decision) &&
                    decision >= 1 && decision <= availableInteractions.Count())
                {
                    Room nextRoom = ConnectedRooms[decision - 1];
                    nextRoom.GenericRoom();
                    break;
                }
            }
            else
            {
                for (int i = 0; i < availableInteractions.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {availableInteractions[i].Title}");
                }
                if (int.TryParse(Console.ReadLine(), out int decision) &&
                    decision >= 1 && decision <= availableInteractions.Count())
                {
                    Interaction interaction = availableInteractions[decision - 1];
                    Console.WriteLine($"{interaction.Title}");
                    interaction.Dialogue();
                    availableInteractions = UpdateRoom();
                }
                else
                {
                    Console.WriteLine($"Enter a number between 1 and {availableInteractions.Count}");
                }
            }
        }
    }
}