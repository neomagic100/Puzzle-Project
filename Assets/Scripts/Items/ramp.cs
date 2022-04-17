using UnityEngine;

public class ramp : Item
{
    Rigidbody2D rb;

  
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
