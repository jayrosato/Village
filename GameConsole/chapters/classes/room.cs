public class Room
{
    public string Name { get; set; }
    public List<Interaction> Interactions { get; set; }
    public List<Room> ConnectedRooms { get; set; }
    public Room(string name, List<Interaction> interactions, List<Room> connectedRooms)
    {
        this.Name = name;
        Interactions = interactions ?? new List<Interaction>();
        ConnectedRooms = connectedRooms ?? new List<Room>();
    }

    public List<Interaction> UpdateRoom()
    {
        Adlo adlo = Globals.Adlo;
        var availableInteractions = this.Interactions
            .Where(interaction =>
                (interaction.Completed != true) &&
                (interaction.ReqAttribute == AttributeType.None || adlo.GetCharAttr(interaction.ReqAttribute) >= interaction.Threshold) &&
                (interaction.Character == null || interaction.Character.Opinion >= interaction.ReqOpinion) &&
                (interaction.ReqTrait == Trait.None || adlo.CheckAdloTrait(interaction.ReqTrait))
            ).ToList();
        return availableInteractions;
    }
    public void NextRoom(Room room)
    {
        room.EnterRoom();
    }
    public void EnterRoom()
    {
        bool inRoom = true;
        Room nextRoom = ConnectedRooms[0];
        Console.WriteLine($"Standing in {this.Name}...");
        List<Interaction> availableInteractions = UpdateRoom();
        while (inRoom)
        {
            if (availableInteractions.Count == 0)
            {
                Console.WriteLine("Nothing to see here...");
                if (ConnectedRooms == null)
                {
                    return;
                }
                for (int i = 0; i < ConnectedRooms.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ConnectedRooms[i].Name}");
                }
                if (int.TryParse(Console.ReadLine(), out int decision) &&
                    decision >= 1 && decision <= ConnectedRooms.Count)
                {
                    nextRoom = ConnectedRooms[decision - 1];
                    Console.WriteLine($"Entering {nextRoom.Name}");
                    inRoom = false;
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
        NextRoom(nextRoom);
    }
}