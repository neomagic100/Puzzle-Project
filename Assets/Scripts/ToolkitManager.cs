using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolkitManager : MonoBehaviour
{
    [Header("ItemImages Prefabs")]
    public GameObject blowerImagePrefab;
    public GameObject treadmillImagePrefab;
    public GameObject pistonImagePrefab;
    public GameObject trampolineImagePrefab;
    public GameObject fanImagePrefab;
    public GameObject ropeImagePrefab;
    public GameObject balloonImagePrefab;
    public GameObject billiardImagePrefab;
    public GameObject soccerImagePrefab;
    public GameObject seesawImagePrefab;
    public GameObject rampImagePrefab;

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

    public void OnBlowerButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(blowerImagePrefab, itemOffset, transform.rotation);        
    }

    public void OnTreadmillButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(treadmillImagePrefab, itemOffset, transform.rotation);
    }

    public void OnPistonButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(pistonImagePrefab, itemOffset, transform.rotation);
    }

    public void OnTrampolineButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(trampolineImagePrefab, itemOffset, transform.rotation);
    }

    public void OnFanButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(fanImagePrefab, itemOffset, transform.rotation);
    }

    public void OnRopeButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(ropeImagePrefab, itemOffset, transform.rotation);
    }

    public void OnBalloonButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(balloonImagePrefab, itemOffset, transform.rotation);
    }

    public void OnBilliardButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(billiardImagePrefab, itemOffset, transform.rotation);
    }

    public void OnSoccerButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(soccerImagePrefab, itemOffset, transform.rotation);
    }

    public void OnSeesawButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(seesawImagePrefab, itemOffset, transform.rotation);
    }

    public void OnRampButton()
    {
        if (UIManager.isRunning)
            return;
        Instantiate(rampImagePrefab, itemOffset, transform.rotation);
    }
}
