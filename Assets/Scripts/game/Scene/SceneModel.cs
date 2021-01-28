using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SceneModel :SmartModel<SceneControl>
{
    public SceneBase Cur_Data
    {
        get
        {
            if (!DB.SceneBaseMap.ContainsKey(control.curScene_id))
                return null;
            return DB.SceneBaseMap[control.curScene_id];
        }
    }
}

