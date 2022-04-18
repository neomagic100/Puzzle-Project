using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

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
    private float[] tempUsePerItem = new float[11];

    private Vector3 itemOffset;
    private Vector2 selectPosition;
    private GameObject selectedItem;
    private float mouseDownTimer;
    private float requiredHoldTime = 1f;
    public UnityEvent onLongClick;

    // An Array used to for the Run Button to identify which items are which
    public static GameObject[] itemImages;

    // List to keep track of Instantiated items in the play area
    public List<GameObject> itemsInPlay = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] itemImages = new GameObject[] { blowerImagePrefab, treadmillImagePrefab, pistonImagePrefab, trampolineImagePrefab,
                                        fanImagePrefab, ropeImagePrefab, balloonImagePrefab, billiardImagePrefab, soccerImagePrefab,
                                        seesawImagePrefab, rampImagePrefab };

        itemOffset = Camera.main.transform.position + new Vector3(0f, 0f, 10f);


        mouseDownTimer = 0f;

        // Stores Data of Item Uses
        for (int i = 0; i < usePerItem.Length; i++)
        {
            tempUsePerItem[i] = usePerItem[i];
        }

        // Aligns the Buttons that are even usables
        int index = 0;
        foreach (Transform child in transform)
        {
            if (tempUsePerItem[index] == 0)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
            index++;
        }
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

    // Remove Item on Screen
    private void OnMouseDown()
    {
        Debug.Log("Mouse Down for " + mouseDownTimer);
        selectPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos2D = new Vector2((int)selectPosition.x, (int)selectPosition.y);
        RaycastHit2D hit = Physics2D.Raycast(pos2D, Vector2.zero);

        mouseDownTimer += Time.deltaTime;

        if (hit.collider != null && mouseDownTimer > requiredHoldTime)
        {
            Debug.Log("hit on " + hit.collider.gameObject.name);
            selectedItem = hit.collider.gameObject;
            removeItem(selectedItem);
        }
    }
        

    // Remove an item from the screen
    public void removeItem(GameObject obj)
    {
        Debug.Log("In remoteItem()");
        // Remove Item on Screen
       
        Destroy(obj);
   
        mouseDownTimer = 0;
    }

    // On Reset Button, restores the Item Uses
    public void ResetItemUses()
    {
        for (int i = 0; i < usePerItem.Length; i++)
        {
            usePerItem[i] = tempUsePerItem[i];
        }
    }


    // =============================================
    //                  Buttons
    // =============================================

    private GameObject temp; // Temporary variable to hold a GameObject when instantiated

    public void OnBlowerButton()
    {
        if (usePerItem[0] <= 0)
        {
            return;
        }

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(blowerImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[0]--;
    }

    public void OnTreadmillButton()
    {
        if (usePerItem[1] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(treadmillImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[1]--;
    }

    public void OnPistonButton()
    {
        if (usePerItem[2] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(pistonImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[2]--;
    }

    public void OnTrampolineButton()
    {
        if (usePerItem[3] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(trampolineImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[3]--;
    }

    public void OnFanButton()
    {
        if (usePerItem[4] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(fanImagePrefab, itemOffset, fanImagePrefab.transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[4]--;
    }

    public void OnRopeButton()
    {
        if (usePerItem[5] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(ropeImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[5]--;
    }

    public void OnBalloonButton()
    {
        if (usePerItem[6] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(balloonImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[6]--;
    }

    public void OnBilliardButton()
    {
        if (usePerItem[7] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(billiardImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[7]--;
    }

    public void OnSoccerButton()
    {
        if (usePerItem[8] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(soccerImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[8]--;
    }

    public void OnSeesawButton()
    {
        if (usePerItem[9] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(seesawImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[9]--;
    }

    public void OnRampButton()
    {
        if (usePerItem[10] <= 0)
            return;

        ButtonClick();

        if (UIManager.isRunning)
            return;
        temp = Instantiate(rampImagePrefab, itemOffset, transform.rotation);
        addToGameObjectsInPlay(temp);
        usePerItem[10]--;
    }

    public void ButtonClick()
    {
        if (AudioManager.instance == null)
            return;

        AudioManager.instance.Click();
    }

    // Add the instantiated item into the itemsInPlay list
    private void addToGameObjectsInPlay(GameObject obj)
    {
        itemsInPlay.Add(obj);
    }

}
