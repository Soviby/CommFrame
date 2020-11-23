using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class LogicMM
{
    public static LogicLoaderControl logicLoaderControl = new LogicLoaderControl();
    public static SceneControl sceneControl = new SceneControl();
    public static CameraContol cameraContol = new CameraContol();
    public static MainCityBehavior mainCity = new MainCityBehavior();//主城
    /// <summary>
    /// 初始化
    /// </summary>
    public static void FireOnAppInit() {
        foreach (var modlue in ModuleBase.ModuleList) {
            modlue.OnAppInit();
            //处理属性绑定（网络协议）
        }
        //
        GameMng.instance.StartCoroutine(FrameUpdate());

    }

    static IEnumerator FrameUpdate() {
        while (true)
        {
            foreach (var modlue in ModuleBase.ModuleList)
            {
                modlue.OnFrameUpdate();
            }
            yield return new WaitForSeconds(0.02f);

        }
        
    }
}

