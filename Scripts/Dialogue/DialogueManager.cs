using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class DialogueManager : MonoBehaviour {
    public GameObject dialogueUI;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;
    public Transform optionsContainer;
    public Button optionButtonPrefab;

    private DialogueData currentDialogue;
    private Dictionary<string, DialogueLine> dialogueMap;
    private DialogueLine currentLine;

    void Start() {
        dialogueUI.SetActive(false);
    }

    public void LoadDialogueFromFile(string fileName) {
        TextAsset json = Resources.Load<TextAsset>($"Dialogues/{fileName}");
        if (json == null) {
            Debug.LogError($"Файл диалога не найден: {fileName}");
            return;
        }

        currentDialogue = JsonUtility.FromJson<DialogueData>(json.text);
        dialogueMap = currentDialogue.lines.ToDictionary(line => line.id, line => line);

        if (!dialogueMap.TryGetValue("start", out var firstLine)) {
            Debug.LogError("В диалоге нет строки с id = 'start'");
            return;
        }

        dialogueUI.SetActive(true);
        ShowLine(firstLine);
    }

    void ShowLine(DialogueLine line) {
        currentLine = line;
        speakerNameText.text = line.speakerName;
        dialogueText.text = line.text;

        foreach (Transform child in optionsContainer)
            Destroy(child.gameObject);

        if (line.options != null && line.options.Length > 0) {
            foreach (var option in line.options) {
                var btn = Instantiate(optionButtonPrefab, optionsContainer);
                btn.GetComponentInChildren<TextMeshProUGUI>().text = option.text;
                string nextId = option.nextLineId;

                btn.onClick.AddListener(() => {
                    if (!string.IsNullOrEmpty(nextId) && dialogueMap.TryGetValue(nextId, out var nextLine)) {
                        ShowLine(nextLine);
                    } else {
                        EndDialogue();
                    }
                });
            }
        } else {
            EndDialogue();
        }
    }

    void EndDialogue() {
        dialogueUI.SetActive(false);
    }
}
