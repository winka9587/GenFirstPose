using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPos : MonoBehaviour
{
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = trans.position + new Vector3(0, 0, 0.01f);
        trans = this.transform;
    }
}
