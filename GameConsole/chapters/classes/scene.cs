public class Scene
{
    public Room[] Rooms { get; set; }
    public Room Start { get; set; }

    public Scene(Room[] rooms, Room start = null)
    {
        this.Rooms = rooms;
        if (start == null)
        {
            this.Start = rooms[0];
        }
        else
        {
            this.Start = start;
        }
    }
    public void BeginScene()
    {
        this.Start.GenericRoom();
    }
}