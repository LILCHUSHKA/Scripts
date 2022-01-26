[System.Serializable]
public class Message
{
    public string theme, whom, description;

    public int index;

    public void GetMessageData(string _theme, string _whom, string _description)
    {
        theme = _theme;
        whom = _whom;
        description = _description;
    }
}