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


}
