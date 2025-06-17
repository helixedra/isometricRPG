using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    public DialogueLine[] lines;
}
