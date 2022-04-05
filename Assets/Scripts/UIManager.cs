using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static bool isRunning = false;

    // Same format as itemImages array so that they keep track of which items are which
    public static GameObject[] items;

    void Start()
    {
        // Gets the Array of Actual Items
        items = new GameObject[] { blowerPrefab, treadmillPrefab, pistonPrefab, trampolinePrefab,
                                   fanPrefab, ropePrefab, balloonPrefab, billiardPrefab, soccerPrefab,
                                   seesawPrefab, rampPrefab };

        // Defaults these buttons
        runButton.SetActive(true);
        stopButton.SetActive(false);
    }

    public void OnRunButton()
    {
        // Finds the ItemImages that were created by the player
        GameObject[] _items = GameObject.FindGameObjectsWithTag("ItemImage");

        // No Items Yet
        if (_items.Length <= 0)
            return;

        

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

        // Toggles Buttons
        runButton.SetActive(false);
        stopButton.SetActive(true);

        isRunning = true;
    }

    public void OnStopButton()
    {
        // Finds the ItemImages that were created by the player
        GameObject[] _items = GameObject.FindGameObjectsWithTag("ItemImage");

        // Finds the current Items that have been instantiated
        GameObject[] curItems = GameObject.FindGameObjectsWithTag("Item");

        foreach (GameObject item in curItems)
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
    }

    public void OnResetButton()
    {
        // Finds the ItemImages that were created by the player
        GameObject[] _items = GameObject.FindGameObjectsWithTag("ItemImage");

        // Finds the current Items that have been instantiated
        GameObject[] curItems = GameObject.FindGameObjectsWithTag("Item");

        // Removes all Item Images
        foreach (GameObject item in _items)
        {
            Destroy(item);
        }

        // Removes all Items
        foreach (GameObject item in curItems)
        {
            Destroy(item);
        }

        // Resets all status
        runButton.SetActive(true);
        stopButton.SetActive(false);

        isRunning = false;
    }
}
