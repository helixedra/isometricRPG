[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    public string text;
}

[System.Serializable]
public class DialogueData
{
    public DialogueLine[] lines;
}
