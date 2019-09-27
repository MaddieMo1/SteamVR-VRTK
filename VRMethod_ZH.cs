using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRMethod_ZH : MonoBehaviour
{

    VRTK_ControllerEvents _Events;//VRTK组件

    SteamVR_Controller.Device _Device;
    SteamVR_TrackedObject TrackdeObjec;

    void Start()
    {
        //获取手柄上的这个组件  
        _Events = GetComponent<VRTK_ControllerEvents>();

        //获取手柄输入  
        _Device = SteamVR_Controller.Input((int)TrackdeObjec.index);


        _Events.TouchpadTouchStart += new ControllerInteractionEventHandler(OnTouchPadPressed);
        _Events.TriggerHairlineStart += new ControllerInteractionEventHandler(TriggerClick);
        _Events.ButtonTwoPressed += new ControllerInteractionEventHandler(MenuShow);
    }

    /// <summary>
    ///  菜单键
    /// </summary>

    #region //菜单键

    public void MenuOnclick()
    {
        if (_Events.buttonTwoPressed)
        {
            print("菜单键按下");
        }
    }

    //菜单按键
    void MenuShow(object sender, ControllerInteractionEventArgs e)
    {
        print("菜单键");
    }

    #endregion


    /// <summary>
    ///  扳机键
    /// </summary>

    #region //扳机键
    public void TriggerOnclick()
    {
        //如果扳机键被按下
        if (_Events.triggerPressed)
        {
            print("按下扳机键");
        }
        if (_Events.triggerAxisChanged)
        {
            print("扳机键或多或少受到挤压");
        }
        if (_Events.triggerClicked)
        {
            print("扳机键一直向下挤压");
        }
    }

    //扳机按键
    void TriggerClick(object sender, ControllerInteractionEventArgs e)
    {
        print("扳机键");
    }
    #endregion


    /// <summary>
    ///  握柄键
    /// </summary>

    #region //握柄键

    public void GripOnclick()
    {
        if (_Events.gripPressed)
        {
            print("握柄键被按下");
        }
        if (_Events.gripAxisChanged)
        {
            print("握柄键或多或少受到挤压");
        }
        if (_Events.gripClicked)
        {
            print("握柄键一直向下挤压");
        }
    }

    #endregion


    /// <summary>
    /// 触摸板
    /// </summary>

    #region //触摸板
    public void TouchedOnclick()
    {
        //如果触摸板被按下
        if (_Events.touchpadPressed)
        {
            print("触摸板被按下");
        }

        //如果触摸板被触摸
        if (_Events.touchpadTouched)
        {
            print("触摸板被触碰");
        }
    }

    //触摸板点击
    private void OnTouchPadPressed(object sender, ControllerInteractionEventArgs e)
    {
        if (e.touchpadAngle <= 45 || e.touchpadAngle >= 315)
        {
            print("按下上方向键");

        }

        else if (e.touchpadAngle > 135 && e.touchpadAngle <= 225)
        {
            print("按下下方向键");

        }

        else if (e.touchpadAngle > 225 && e.touchpadAngle < 315)
        {
            print("按下左方向键");

        }

        else if (e.touchpadAngle > 45 && e.touchpadAngle <= 135)
        {
            print("按下右方向键");
        }
    }

    #endregion


    //手柄震动
    public void ShakeOnclick()
    {
        _Device.TriggerHapticPulse(1000);
    }

}
