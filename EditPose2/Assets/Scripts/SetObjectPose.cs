using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class SetObjectPose : MonoBehaviour
{
    public ButtonController bc;
    public string filename;
    public string filenameOpotimized;
    public List<string> previousPose;
    public List<float> objectPoseList = new List<float>();
    private Transform myTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        previousPose = new List<string>();
        ReadFile(Application.dataPath + filename);
        //ReadFile(Application.dataPath + filenameOpotimized);
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
        //print(num);
        string[] tmp;
        for (int i = 0; i < num; i++)
        {
            tmp = strs[i].Split(' ');
            int tmpNum = tmp.Length-1;
            //Debug.Log(tmpNum);
            for (int j = 0; j < tmpNum; j++)
            {
                objectPoseList.Add(Convert.ToSingle(tmp[j]));
            }
        }

    }

}
