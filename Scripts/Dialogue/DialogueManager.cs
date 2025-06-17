using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;
    public Button nextButton;

    private DialogueData currentDialogue;
    private int currentLineIndex;

    void Start()
    {
        dialogueUI.SetActive(false);
        nextButton.onClick.AddListener(NextLine);
    }

    public void LoadDialogueFromFile(string filename)
    {
        TextAsset json = Resources.Load<TextAsset>($"Dialogues/{filename}");
        currentDialogue = JsonUtility.FromJson<DialogueData>(json.text);
        currentLineIndex = 0;
        dialogueUI.SetActive(true);
        ShowLine();
    }

    void ShowLine()
    {
        var line = currentDialogue.lines[currentLineIndex];
        speakerNameText.text = line.speakerName;
        dialogueText.text = line.text;
    }

    void NextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < currentDialogue.lines.Length)
        {
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueUI.SetActive(false);
    }
}
