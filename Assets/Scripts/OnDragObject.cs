using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDragObject : MonoBehaviour
{      
    public void OnMouseDrag()
    {
        Vector3 inWorldPosition = Input.mousePosition;
        inWorldPosition.z = 10f;        
        transform.position = Camera.main.ScreenToWorldPoint(inWorldPosition);        
    }
}
