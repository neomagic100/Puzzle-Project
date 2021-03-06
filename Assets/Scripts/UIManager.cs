using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Item Prefabs")]
    public GameObject blowerPrefab;
    public GameObject treadmillPrefab;
    public GameObject pistonPrefab;
    public GameObject trampolinePrefab;
    public GameObject fanPrefab;
    public GameObject ropePrefab;
    public GameObject balloonPrefab;
    public GameObject billiardPrefab;
    public GameObject soccerPrefab;
    public GameObject seesawPrefab;
    public GameObject rampPrefab;

    [Header("Unity References")]
    public GameObject runButton;
    public GameObject stopButton;
    public GameObject inGameOptions;
    public GameObject victoryScreen;
    public ToolkitManager toolkit;
    public GameObject levelTwoSetup;

    public static bool isRunning = false;

    public float sceneIndex;

    private GameObject[] tempItemArr;

    // Same format as itemImages array so that they keep track of which items are which
    public static GameObject[] items;
    public static GameObject[] objectiveItems;
    void Start()
    {
        // Gets the Array of Actual Items
        items = new GameObject[] { blowerPrefab, treadmillPrefab, pistonPrefab, trampolinePrefab,
                                   fanPrefab, ropePrefab, balloonPrefab, billiardPrefab, soccerPrefab,
                                   seesawPrefab, rampPrefab };

        // Finds all Objective Items like Soccer Ball or Dart
        objectiveItems = GameObject.FindGameObjectsWithTag("ObjectiveItem");

        // Defaults these buttons
        runButton.SetActive(true);
        stopButton.SetActive(false);
        inGameOptions.SetActive(false);

        isRunning = false;

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 2)
            Instantiate(levelTwoSetup);
    }

    // =============================================
    //                  Buttons
    // =============================================
    public void OnRunButton()
    {
        // Audio
        ButtonClick();

        // Finds the ItemImages that were created by the player
        GameObject[] _items = GameObject.FindGameObjectsWithTag("ItemImage");

        // Stores items for Stop and Reset
        tempItemArr = _items;

        // No Items Yet
        if (_items.Length <= 0)
            return;

        
        // Runs the Toolkit Items
        for (int i = 0; i < _items.Length; i++)
        {
            for (int j = 0; j < items.Length; j++)
            {
                if (_items[i].GetComponent<ItemID>().prefab == items[j])
                {
                    Instantiate(items[j], _items[i].transform.position, _items[i].transform.rotation);
                    _items[i].SetActive(false);
                }
            }                        
        }

        for (int i = 0; i < objectiveItems.Length; i++)
        {
            Instantiate(objectiveItems[i].GetComponent<ItemID>().prefab, objectiveItems[i].transform.position, objectiveItems[i].transform.rotation);
            objectiveItems[i].SetActive(false);
        }

        // Toggles Buttons
        runButton.SetActive(false);
        stopButton.SetActive(true);

        isRunning = true;
    }

    public void OnStopButton()
    {
        // Audio
        ButtonClick();

        // Finds the current Items that have been instantiated
        GameObject[] curItems = GameObject.FindGameObjectsWithTag("Item");

        foreach (GameObject item in tempItemArr)
        {
            item.SetActive(true);
        }

        foreach (GameObject item in objectiveItems)
        {
            item.SetActive(true);
        }

        // Removes all Items
        foreach (GameObject item in curItems)
        {
            Destroy(item);
        }

        // Toggles Buttons
        runButton.SetActive(true);
        stopButton.SetActive(false);

        isRunning = false;

        if (sceneIndex == 2)
            ResetLevelTwo();
    }

    public void OnResetButton()
    {
        // Audio
        ButtonClick();

        // Finds the ItemImages that were created by the player
        GameObject[] _items = GameObject.FindGameObjectsWithTag("ItemImage");

        // Finds the current Items that have been instantiated
        GameObject[] curItems = GameObject.FindGameObjectsWithTag("Item");

        // Removes all Item Images
        foreach (GameObject item in _items)
        {
            Destroy(item);
        }

        foreach (GameObject item in objectiveItems)
        {
            item.SetActive(true);
        }

        if (tempItemArr != null)
        {
            // Cleans the Cache
            foreach (GameObject item in tempItemArr)
            {
                Destroy(item);
            }
        }
        
        if (curItems != null)
        {
            // Removes all Items
            foreach (GameObject item in curItems)
            {
                Destroy(item);
            }
        }
                       
        // Resets all status
        runButton.SetActive(true);
        stopButton.SetActive(false);
        toolkit.ResetItemUses();

        isRunning = false;

        if (sceneIndex == 2)
            ResetLevelTwo();
    }

    public void OnMainMenuButton()
    {
        // Audio
        ButtonClick();

        SceneManager.LoadScene(0);
    }

    public void OnNextLevelButton()
    {
        // Audio
        ButtonClick();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnBackButton()
    {
        // Audio
        ButtonClick();
    }

    public void OnSettingsButton()
    {
        // Audio
        ButtonClick();
    }

    public void OnVictory()
    {
        Instantiate(victoryScreen);
    }

    public void ButtonClick()
    {
        if (AudioManager.instance == null)
            return;

        AudioManager.instance.Click();
    }

    // Utility Function
    private void ResetLevelTwo()
    {
        GameObject level = GameObject.Find("Level2Setup(Clone)");

        Destroy(level);
        Instantiate(levelTwoSetup);
    }
}
