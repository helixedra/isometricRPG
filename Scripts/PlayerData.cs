using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private int _score;

    public void SetScore()
    {
        _score++;
    }

    public int GetScore()
    {
        return _score;
}

}