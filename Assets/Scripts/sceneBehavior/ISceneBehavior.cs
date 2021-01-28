using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ISceneBehavior
{

    void EnterScene();//进入场景(每次执行)
    void LeaveScene();//离开
}

