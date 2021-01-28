using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoSingleton<GameMng>
{
    private void Start()
    {
        //开始游戏
        LogicMM.logicLoaderControl.StartGame();
    }

    private void OnApplicationQuit()
    {
        //游戏关闭
        SoundManager.StopAllSound();
    }

    private void FixedUpdate()
    {
        if (ModuleBase.ModuleList != null && ModuleBase.ModuleList.Count > 0)
        {
            foreach (var modlue in ModuleBase.ModuleList)
            {
                modlue.Update();
            }
        }
    }
}
