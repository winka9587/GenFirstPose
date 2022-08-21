## EditPose2.0

1.0代码在换电脑时被亲手Shift+Delete了:)

在测试跟踪算法的时候，需要第一针物体的位姿作为初值。
这项任务通常是检测算法来做的， 但对自己拍摄的视频序列以及模型而单独去训练一个检测网络有点太费劲了。

于是就有了EditPose，手动对齐目标模型和图像上的目标，输出一个大概的位姿供跟踪算法使用。

EditPose输出的位姿+跟踪算法重复跟踪第一帧，之后输出的结果基本就能作为第一帧的初值使用了。

## 1.UnityPoseTransform

**Unity部分依赖OpenCVForUnity2.3.8，确保已经安装**

将unity中物体的位姿转换成opencv下的，适配RBOT的坐标系。
如果是其他坐标系需要确认是左手系还是右手系

修改输出的txt位置

### before run

每台机器要单独编译生成exe，因为要针对每台机器设置输出路径。

## 2.Unity

### Inspector中配置Unity Pose Transform Script
打开Unity项目，

1.根据内参的fx或fy计算FOV,

2.填入图像width和hegiht

3.将模型放入Asset，将UnityPoseTransform.exe填入Exe_path

<img src='https://raw.githubusercontent.com/winka9587/MD_imgs/main/Norproject/2022-08-18-j2vEEb.png' width="50%" >

4.调整模型Pos和Rotation

5.点击Run_exe即可导出Pose到UnityPoseTransform指定的txt中

C#中添加”[ExecuteInEditMode]”
能够允许脚本在Edit模式下使用

