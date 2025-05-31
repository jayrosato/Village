public class Check
{
    public static bool SelfCheck(Adlo adlo, AttributeType checkAttribute, int threshhold = 0)
    {
        int value = 0;
        switch (checkAttribute)
        {
            case AttributeType.None:
                break;
            case AttributeType.Attitude:
                value = adlo.Attitude;
                break;
            case AttributeType.Activism:
                value = adlo.Activism;
                break;
            case AttributeType.Reputation:
                value = adlo.Reputation;
                break;
        }
        return value >= threshhold;
    }
    public static bool OpinionCheck(Adlo adlo, NPC character, int threshhold = 0)
    {
        return character.Opinion >= threshhold;
    }
}
