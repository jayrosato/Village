using System.Net.NetworkInformation;
using System.Windows;

class Program
{
    public static void Main(string[] args)
    {
        TestInteraction testInt = new TestInteraction(character: Globals.Clara);
        Interaction[] testInts = [testInt];
        Room testRoom = new Room("Test Room", testInts);
        Room[] testRooms = [testRoom];
        Scene testScene = new Scene(rooms: testRooms);
        testScene.BeginScene();
    }
}
