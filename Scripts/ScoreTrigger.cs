using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;


    private void OnTriggerEnter(Collider other)
    {

        // Debug.Log("Triggered");
        
        if (other.CompareTag("Player"))
        {
            playerData.SetScore();
            Debug.Log("Score: " + playerData.GetScore());
        }   
    }
}
