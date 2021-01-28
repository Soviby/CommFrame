using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class SceneControl :SmartControl<SceneModel>
{
    Dictionary<int, ISceneBehavior> _behaviors = new Dictionary<int, ISceneBehavior>();
    List<GameObject> scene_dos = new List<GameObject>();//场景中所有的对象

    public ISceneBehavior curScene = null;//当前场景
    public int curScene_id = -1;
    private Transform tf_parent = null;
    public void RegisterBehavior(int scene_sort, ISceneBehavior behavior)
    {
        _behaviors.Add(scene_sort, behavior);
    }

    public ISceneBehavior GetBehavior(int sceneID)
    {
        if (_behaviors.ContainsKey(sceneID))
            return _behaviors[sceneID];
        return null;
    }

    public string GetScenePath(int sceneID)
    {
        if (!DB.SceneBaseMap.ContainsKey(sceneID))
            return "";
        return (DB.SceneBaseMap[sceneID].is_tset ?
                   @"scence/test/" : @"scence/")
                   + DB.SceneBaseMap[sceneID].res;
    }

    //服务端调用
    public void EnterScene(int sceneID)
    {
        MyTask.Run(_EnterScene(sceneID));
    }
    IEnumerator _EnterScene(int sceneID)
    {
        var newBehavior = GetBehavior(sceneID);
        if (newBehavior == null)
            yield break;
        if (curScene != null)
        {
            curScene.LeaveScene();
            //销毁上一个场景
            if (model.Cur_Data != null && tf_parent)
            {
                var last = tf_parent.gameObject.FindChild(model.Cur_Data.name);
                GameObject.Destroy(last);
            }
        }

        //加载新场景
        if (!DB.SceneBaseMap.ContainsKey(sceneID))
        {
            Log.Error($"sceneID:{sceneID} ,配置表中不存在");
            yield break;
        }

        yield return MyTask.Call(BuildScene(DB.SceneBaseMap[sceneID]));
        curScene_id = sceneID;
        curScene = newBehavior;
        curScene.EnterScene();
    }
    void InitScene(SceneBase sceneBase)
    {
        //创建主角
        //初始化主角
        //var behaviour = LogicMM.mainRole.AddMainRole();
        //behaviour.transform.position = sceneBase.player_pos;
    }
    IEnumerator BuildScene(SceneBase sceneBase)
    {
        //从res中获取预制体
        var _gameObject = GameObject.Instantiate(Resources.Load<GameObject>(GetScenePath(sceneBase.id)));
        if (!_gameObject) Debug.Log($"{sceneBase.res},Resources中找不到");
        //创建根节点
        if (!tf_parent)
        {
            tf_parent = new GameObject("map").transform;
        }
        _gameObject.transform.parent = tf_parent;
        _gameObject.name = sceneBase.name;

        yield return null;
    }
}



