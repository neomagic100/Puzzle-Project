using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    public GameObject selectedItem;
    Vector2 selectPosition;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    [SerializeField]
    public void DestroySelection(GameObject obj)
    {
       
        selectPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pos2D = new Vector2((int)selectPosition.x, (int)selectPosition.y);

        RaycastHit2D hit = Physics2D.Raycast(pos2D, Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject);
        }
        
    }
}
