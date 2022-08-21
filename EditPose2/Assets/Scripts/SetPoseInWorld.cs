using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class SetPoseInWorld : MonoBehaviour
{
    public ButtonController bc;
    public string filename;
    public List<float> objectPoseList;
    public int objectPoseListLength;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        objectPoseList = new List<float>();
        //ReadFile(Application.dataPath + filename);
        ReadFile(Application.dataPath + filename);
        myTransform = this.GetComponent<Transform>();
        //Debug.Log(objectPoseList.Count);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myTransform.localPosition = new Vector3(objectPoseList[bc.frameIndex_B * 6], objectPoseList[bc.frameIndex_B * 6 + 1], objectPoseList[bc.frameIndex_B * 6 + 2]);
        Vector3 objEluer = new Vector3(objectPoseList[bc.frameIndex_B * 6 + 3], objectPoseList[bc.frameIndex_B * 6 + 4], objectPoseList[bc.frameIndex_B * 6 + 5]);
        myTransform.localEulerAngles = objEluer;//Quaternion.Euler(objEluer);
        //Debug.Log(objEluer);
        //Debug.Log(myTransform.localEulerAngles);
    }

    private void ReadFile(string FileName)
    {
        string[] strs = File.ReadAllLines(FileName); //读取所有行信息
        int num = strs.Length;
        objectPoseListLength = num;
        string[] tmp;
        for (int i = 0; i < num; i++)
        {
            tmp = strs[i].Split(' ');
            int tmpNum = tmp.Length;
            //Debug.Log(tmpNum);
            for (int j = 0; j < tmpNum; j++)
            {
                objectPoseList.Add(Convert.ToSingle(tmp[j]));
                //Debug.Log(t);
            }
        }

    }
}
