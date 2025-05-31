public static class Globals
{
    public static Adlo Adlo;
    public static NPC Clara;

    public static TestInteraction testInt;
    public static TestInteraction testInt1;
    public static List<Interaction> testInts;

    public static List<Room> cr1;
    public static List<Room> cr2;
    public static Room testRoom;
    public static Room testRoom1;
    public static Room testRoom2;

    static Globals()
    {
        // characters
        Adlo = new Adlo(name: "Adlo", surname: "Eier", title: Title.Journeyman,
            origin: Origin.Odelerg, profession: Prof.None, attitude: 1, activism: 0, reputation: 0, charisma: 0);

        Clara = new NPC(name: "Clara", surname: "Aedana", title: Title.Mistress,
            origin: Origin.Odelerg, profession: Prof.Domestic, attitude: 5, activism: 0, reputation: 1,
            opinion: 2, attraction: 1);

        // interactions
        testInt = new TestInteraction(character: Clara);
        testInt1 = new TestInteraction(character: Clara);
        testInts = new List<Interaction> { testInt };

        // rooms — create placeholders first
        testRoom = new Room("Test Room", testInts, new List<Room>());
        testRoom1 = new Room("Second Test Room", testInts, new List<Room>());
        testRoom2 = new Room("Third Test Room", testInts, new List<Room>());

        // now wire up the connections
        cr1 = new List<Room> { testRoom1, testRoom2 };
        cr2 = new List<Room> { testRoom };

        testRoom.ConnectedRooms = cr1;
        testRoom1.ConnectedRooms = cr2;
        testRoom2.ConnectedRooms = cr2;
    }
}