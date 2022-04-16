using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolkitManager : MonoBehaviour
{
    [Header("ItemImages Prefabs")]
    public GameObject blowerImagePrefab;        // 0
    public GameObject treadmillImagePrefab;     // 1 
    public GameObject pistonImagePrefab;        // 2
    public GameObject trampolineImagePrefab;    // 3
    public GameObject fanImagePrefab;           // 4
    public GameObject ropeImagePrefab;          // 5
    public GameObject balloonImagePrefab;       // 6
    public GameObject billiardImagePrefab;      // 7
    public GameObject soccerImagePrefab;        // 8
    public GameObject seesawImagePrefab;        // 9
    public GameObject rampImagePrefab;          // 10

    [Header("Number of Uses per Item")]
    [Header("Lines up with Order from Above")]
    public float[] usePerItem; // Indexes Lines up with Indexs Above ^

    private Vector3 itemOffset;

    // An Array used to for the Run Button to identify which items are which
    public static GameObject[] itemImages;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] itemImages = new GameObject[] { blowerImagePrefab, treadmillImagePrefab, pistonImagePrefab, trampolineImagePrefab,
                                        fanImagePrefab, ropeImagePrefab, balloonImagePrefab, billiardImagePrefab, soccerImagePrefab,
                                        seesawImagePrefab, rampImagePrefab };

        itemOffset = Camera.main.transform.position + new Vector3(0f, 0f, 10f);
    }

    void Update()
    {
        // Updates the Text on Screen 
        int index = 0;
        foreach (Transform child in transform)
        {
            child.GetComponent<ItemButtonUsage>().UItext.text = usePerItem[index].ToString();
            index++;
        }
    }

    public void OnBlowerButton()
    {
        if (usePerItem[0] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(blowerImagePrefab, itemOffset, transform.rotation);

        usePerItem[0]--;
    }

    public void OnTreadmillButton()
    {
        if (usePerItem[1] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(treadmillImagePrefab, itemOffset, transform.rotation);

        usePerItem[1]--;
    }

    public void OnPistonButton()
    {
        if (usePerItem[2] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(pistonImagePrefab, itemOffset, transform.rotation);

        usePerItem[2]--;
    }

    public void OnTrampolineButton()
    {
        if (usePerItem[3] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(trampolineImagePrefab, itemOffset, transform.rotation);

        usePerItem[3]--;
    }

    public void OnFanButton()
    {
        if (usePerItem[4] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(fanImagePrefab, itemOffset, transform.rotation);

        usePerItem[4]--;
    }

    public void OnRopeButton()
    {
        if (usePerItem[5] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(ropeImagePrefab, itemOffset, transform.rotation);

        usePerItem[5]--;
    }

    public void OnBalloonButton()
    {
        if (usePerItem[6] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(balloonImagePrefab, itemOffset, transform.rotation);

        usePerItem[6]--;
    }

    public void OnBilliardButton()
    {
        if (usePerItem[7] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(billiardImagePrefab, itemOffset, transform.rotation);

        usePerItem[7]--;
    }

    public void OnSoccerButton()
    {
        if (usePerItem[8] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(soccerImagePrefab, itemOffset, transform.rotation);

        usePerItem[8]--;
    }

    public void OnSeesawButton()
    {
        if (usePerItem[9] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(seesawImagePrefab, itemOffset, transform.rotation);

        usePerItem[9]--;
    }

    public void OnRampButton()
    {
        if (usePerItem[10] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        Instantiate(rampImagePrefab, itemOffset, transform.rotation);

        usePerItem[10]--;
    }

    public void ButtonClick()
    {
        if (AudioManager.instance == null)
            return;

        AudioManager.instance.Click();
    }
}
