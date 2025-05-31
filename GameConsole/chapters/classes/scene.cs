public class Scene
{
    public List<Room> Rooms { get; set; }

    public Scene(List<Room> rooms)
    {
        this.Rooms = rooms;
    }
    public void BeginScene()
    {
        Room room = Rooms[0];
        room.EnterRoom();
    }
}