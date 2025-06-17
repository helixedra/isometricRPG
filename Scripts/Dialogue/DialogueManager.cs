using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public GameObject dialogueUI;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;
    public Transform optionsContainer;
    public Button optionButtonPrefab;

    private DialogueData currentDialogue;
    private int currentLineIndex;

    void Start() {
        dialogueUI.SetActive(false);
    }

    public void LoadDialogueFromFile(string fileName) {
        TextAsset json = Resources.Load<TextAsset>($"Dialogues/{fileName}");
        if (json == null) {
            Debug.LogError($"File not found: {fileName}");
            return;
        }
        currentDialogue = JsonUtility.FromJson<DialogueData>(json.text);
        currentLineIndex = 0;
        dialogueUI.SetActive(true);
        ShowLine();
    }

    void ShowLine() {
        var line = currentDialogue.lines[currentLineIndex];
        speakerNameText.text = line.speakerName;
        dialogueText.text = line.text;

        // Remove old buttons
        foreach (Transform child in optionsContainer)
            Destroy(child.gameObject);

        if (line.options != null && line.options.Length > 0) {
            foreach (var option in line.options) {
                var btn = Instantiate(optionButtonPrefab, optionsContainer);
                btn.GetComponentInChildren<TextMeshProUGUI>().text = option.text;
                btn.onClick.AddListener(() => OnOptionSelected(option.nextLineIndex));
            }
        } else {
            OnOptionSelected(-1);
        }
    }

    void OnOptionSelected(int nextLineIndex) {
        if (nextLineIndex >= 0) {
            currentLineIndex = nextLineIndex;
            ShowLine();
        } else {
            dialogueUI.SetActive(false);
        }
    }
}
