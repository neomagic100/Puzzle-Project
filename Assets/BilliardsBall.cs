using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardsBall : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.name == "Goal")
            print("Success!");
    }
}
