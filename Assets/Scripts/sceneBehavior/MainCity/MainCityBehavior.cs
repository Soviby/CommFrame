using UnityEngine;
using UnityEditor;
using Entity;

public class MainCityBehavior : SceneBehavior<MainCityModel>
{
    public override void OnAppInit()
    {
        base.OnAppInit();
        LogicMM.sceneControl.RegisterBehavior(SceneID.SCENE_ID_MAINCITY, this);
    }

}