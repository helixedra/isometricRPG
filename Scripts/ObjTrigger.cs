using UnityEngine;
using System.Collections.Generic;

public class ObjTrigger : MonoBehaviour
{
   private PlayerData playerData;
   private bool isTriggered = false;

    void Start()
    {
        playerData = Object.FindFirstObjectByType<PlayerData>();
    }

    private void OnTriggerEnter(Collider other)
    {
       Debug.Log("Triggered");
        
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
        }   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTriggered)
        {
            Debug.Log("E pressed");
            playerData.GetInventory().AddItem("Ключ", 1);
            Debug.Log("Ключ добавлен в инвентарь");
            Destroy(gameObject);
        }
    }
}
