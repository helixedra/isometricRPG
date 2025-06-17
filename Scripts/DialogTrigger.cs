using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogueFileName = "dialogue_npc1"; 
    [SerializeField] private GameObject hint;

    private DialogueManager dialogueManager;

    void Start()
    {
        hint.SetActive(false);
        dialogueManager = Object.FindFirstObjectByType<DialogueManager>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.LoadDialogueFromFile(dialogueFileName);
        }
        if (dialogueManager.dialogueUI.activeSelf)
            hint.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        hint.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        hint.SetActive(false);
    }

}
