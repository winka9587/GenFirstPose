using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(0,0,0);
        this.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        print(this.transform.localPosition);
        //print(trans.rotation);
    }
}
