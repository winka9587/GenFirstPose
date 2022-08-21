using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
[ExecuteInEditMode] //编辑模式下运行

//该脚本挂载到所有模型下
//点击run即可运行
//模型的名称不能有空格，否则会报错
//其实可以解决，找自己博客草稿箱。但是改了的话还得修改exe，懒得改了


public class UnityPoseTransform : MonoBehaviour
{
	//默认参数
    public bool run_exe = false;
    private string result = "none";
    //public string save_path = "C:/Users/dell/Desktop/"; 
	public string save_path = "E:/Image/"; 
    public string filename = "FirstPose.txt";  //save_path 路径下必须有一个 filename 文件
    public string exe_path = "D:/UnityHub/UnityWork/EditPose2/UnityPoseTransform.exe";  //调用exe所在的路径
    public GameObject Img;
    private RawImage rawImage;
    private Component component_Img;

    public Component[] cs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (run_exe)
        {
            rawImage = Img.GetComponent<RawImage>();
            UnityEngine.Debug.Log(rawImage.texture.name);
            //raw = component.FindChild("RawImage2");
            //component_Img = rawImage.GetComponent("RawImage");
            //cs = component_Img.GetComponent("RawImage");
            //UnityEngine.Debug.Log(rawImage.Color);
            //UnityEngine.Debug.Log(null); ;
            //运行函数
            run_exe = false;
            UnityEngine.Debug.Log("Function Run");
           
            Process foo = new Process();
            foo.StartInfo.FileName = exe_path;
            foo.StartInfo.Arguments =
                save_path+filename+","+
                //this.name + "," + 
                rawImage.texture.name + "," + 
                this.transform.localPosition.x + "," +
                this.transform.localPosition.y + "," +
                this.transform.localPosition.z + "," +
                this.transform.eulerAngles.x + "," + 
                this.transform.eulerAngles.y + "," + 
                this.transform.eulerAngles.z;
            foo.Start();
        }
    }

}
