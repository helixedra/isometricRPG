using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogueFileName = "dialogue_npc1"; 

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Object.FindFirstObjectByType<DialogueManager>().LoadDialogueFromFile(dialogueFileName);
        }
    }
}
