using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace Entity
{
    public class SceneBase
    {
        public int id;
        public string res;
        public string name;
        public Dictionary<string, Vector3> player_poss;//玩家序号->坐标
        public bool is_tset;//是否为测试地图
    }

    public static class ResPathDefs
    {
        public static string AOI_PETH = "prefabs/";
    }

    public static class SceneID
    {
        public static int SCENE_ID_MAINCITY = 0;
    }
}