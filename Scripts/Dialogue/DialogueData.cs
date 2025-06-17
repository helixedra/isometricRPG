[System.Serializable]
public class DialogueOption {
    public string text;
    public int nextLineIndex;
}

[System.Serializable]
public class DialogueLine {
    public string speakerName;
    public string text;
    public DialogueOption[] options;
}

[System.Serializable]
public class DialogueData {
    public DialogueLine[] lines;
}
