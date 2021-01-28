using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class SceneBehavior<M> : SmartControl<M>, ISceneBehavior where M : Model, new()
{

    public virtual void EnterScene()
    {

    }

    public virtual void LeaveScene()
    {

    }
}

