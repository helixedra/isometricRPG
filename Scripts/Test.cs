using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {
    public string name;
    public string description;
    public int reward;
    public bool completed;
}

public class Test : MonoBehaviour
{
    public List<Quest> quests;

    void Start()
    {
        quests = new List<Quest>();
        quests.Add(new Quest { name = "Quest 1", description = "Description 1", reward = 10, completed = false });
        quests.Add(new Quest { name = "Quest 2", description = "Description 2", reward = 20, completed = false });

        foreach (Quest quest in quests)
        {
            Debug.Log(quest.name + " " + quest.completed);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            quests[0].completed = true;
            Debug.Log(quests[0].completed);
        }
    }
}
