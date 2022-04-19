using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("Unity References")]
    public GameObject victoryScreen;

    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.name == "SoccerBall(Clone)")
        {
            // Creates the Victory Screen to traverse to the next level
            Instantiate(victoryScreen);

            // Saves the Game
            float volume = AudioManager.instance.volume;
            float unlocks = SceneManager.GetActiveScene().buildIndex;

            SaveData.SaveGame(unlocks, volume);
            Debug.Log("Success!");
        }
    }
}
