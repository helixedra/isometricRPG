[System.Serializable]
public class DialogueData {
    public DialogueLine[] lines;
}

[System.Serializable]
public class DialogueLine {
    public string id;
    public string speakerName;
    public string text;
    public DialogueOption[] options;
}

[System.Serializable]
public class DialogueOption {
    public string text;
    public string nextLineId;
}
