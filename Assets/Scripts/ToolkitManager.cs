using UnityEngine;
using UnityEngine.Events;

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
    public float[] tempUsePerItem;


    private Vector3 itemOffset;
    private Vector2 selectPosition;
    //private Rigidbody2D selectedItem;
    private GameObject selectedItem;
    private float mouseDownTimer;
    private float requiredHoldTime = 1f;
    public UnityEvent onLongClick;

    // An Array used to for the Run Button to identify which items are which
    public static GameObject[] itemImages;

    // Start is called before the first frame update
    void Start()
    {
        usePerItem = new float[11];
        tempUsePerItem = new float[11];
        Debug.Log(usePerItem.Length + " -- " + tempUsePerItem.Length);

        // Saving ImagePrefabs in Array
        GameObject[] itemImages = new GameObject[] { blowerImagePrefab, treadmillImagePrefab, pistonImagePrefab, trampolineImagePrefab,
                                        fanImagePrefab, ropeImagePrefab, balloonImagePrefab, billiardImagePrefab, soccerImagePrefab,
                                        seesawImagePrefab, rampImagePrefab };

        
        itemOffset = Camera.main.transform.position + new Vector3(0f, 0f, 10f);
        mouseDownTimer = 0f;

        for (int i = 0; i < usePerItem.Length; i++)
        {
            tempUsePerItem[i] = usePerItem[i];
        }
    }

    void Update()
    {
        bool isMouseDown;

        // Updates the Text on Screen 
        int index = 0;
        foreach (Transform child in transform)
        {
            child.GetComponent<ItemButtonUsage>().UItext.text = usePerItem[index].ToString();
            index++;
        }

        
        // Remove Item on Screen
        if (Input.GetMouseButtonDown(0))
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

    }


    
    private void OnMouseDown()
    {
        if (selectedItem != null)
        {
            mouseDownTimer += Time.deltaTime;
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

    // On Reset, resets the number of Items used
    public void ResetItemUses()
    {
        for (int i = 0; i < usePerItem.Length; i++)
        {
            usePerItem[i] = tempUsePerItem[i];
        }
    }

    // =================================================
    //                    Buttons
    // =================================================
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
