using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public interface IPanel {
    void OnInit();
    void OnShow();
    void OnDestroy();
    void Display(bool b);
    bool IsVisible { get; }
}
public class PanelBase : IPanel
{
    protected GameObject _gameObject;

    public virtual bool IsVisible {
        get {
            return false;
        }
    }

    public GameObject gameObject { get => _gameObject;  }
    public Camera uiCamera { get => LogicMM.cameraContol.UiCamera;  }
    public MyTaskRunner myTaskRunner = new MyTaskRunner(5);

    public virtual void Display(bool b)
    {

    }
    public virtual void OnClick(MonoBehaviour behaviour) {

    }

    public virtual void OnDestroy()
    {

    }

    public virtual void OnInit()
    {

    }

    public virtual void OnShow()
    {

    }
    public virtual void OnDrag(MyDragData myDragData)
    {

    }

    public virtual void OnDragStart(MyDragData myDragData)
    {

    }

    public virtual void OnDragEnd(MyDragData myDragData)
    {

    }

    public virtual void OnUIRoomLoadComlete(My3DRoomImage my3DRoomImage)
    {

    }

    public virtual void Update()
    {

    }

    public void RunUITask(IEnumerator e)
    {
        myTaskRunner.Run(e);
    }
}