using System;
using UnityEngine;
using UnityEngine.Events;
using OVR;

public class OVRInputListenerMono : MonoBehaviour
{
  

    public UnityEvent<float> m_onJoystickLeftHorizontal;
    public UnityEvent<float> m_onJoystickLeftVertical;
    public UnityEvent<float> m_onJoystickRightHorizontal;
    public UnityEvent<float> m_onJoystickRightVertical;

    // Trigger Events
    public UnityEvent<float> m_onLeftTriggerChanged;
    public UnityEvent<float> m_onRightTriggerChanged;

    // Grip Events
    public UnityEvent<float> m_onLeftGripChanged;
    public UnityEvent<float> m_onRightGripChanged;

    // Joystick Press Events
    public UnityEvent m_onLeftJoystickChanged;
    public UnityEvent m_onRightJoystickChanged;

    // Button Events
    public UnityEvent m_onAButtonRightDownChanged;
    public UnityEvent m_onBButtonRightUpChanged;
    public UnityEvent m_onXButtonLeftDownChanged;
    public UnityEvent m_onYButtonLeftUpChanged;

    public float m_joystickLeftHorizontal;
    public float m_joystickLeftVertical;
    public float m_joystickRightHorizontal;
    public float m_joystickRightVertical;

    public float m_triggerLeft;
    public float m_triggerRight;
    public float m_gripLeft;
    public float m_gripRight;

    public bool m_buttonLeftFront;
    public bool m_buttonLeftBack;
    public bool m_buttonRightFront;
    public bool m_buttonRightBack;





    private void Update()
    {
        // Get joystick axis
        Vector2 leftJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 rightJoystick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        // Get trigger values (float between 0 and 1)
        float leftTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        float rightTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        // Get grip values (float between 0 and 1)
        float leftGrip = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        float rightGrip = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);


        bool buttonLeftFront = OVRInput.Get(OVRInput.Button.Four);
        bool buttonLeftBack = OVRInput.Get(OVRInput.Button.Three);
        bool buttonRightFront = OVRInput.Get(OVRInput.Button.Two);
        bool buttonRightBack = OVRInput.Get(OVRInput.Button.One);


        if (m_gripLeft != leftGrip)
        {
            m_gripLeft = leftGrip;
            m_onLeftGripChanged?.Invoke(leftGrip);
        }

        if (m_gripRight != rightGrip)
        {
            m_gripRight = rightGrip;
            m_onRightGripChanged?.Invoke(rightGrip);
        }

        if (m_triggerLeft != leftTrigger)
        {
            m_triggerLeft = leftTrigger;
            m_onLeftTriggerChanged?.Invoke(leftTrigger);
        }

        if (m_triggerRight != rightTrigger)
        {
            m_triggerRight = rightTrigger;
            m_onRightTriggerChanged?.Invoke(rightTrigger);
        }


        if (m_joystickLeftHorizontal != leftJoystick.x)
        {
            m_joystickLeftHorizontal = leftJoystick.x;
            m_onJoystickLeftHorizontal.Invoke(leftJoystick.x);
        }

        if (m_joystickLeftVertical != leftJoystick.y)
        {
            m_joystickLeftVertical = leftJoystick.y;
            m_onJoystickLeftVertical.Invoke(leftJoystick.y);

            
        }

        if (m_joystickRightHorizontal != rightJoystick.x)
        {
            m_joystickRightHorizontal = rightJoystick.x;
            m_onJoystickRightHorizontal.Invoke(rightJoystick.x);
        }

        if (m_joystickRightVertical != rightJoystick.y)
        {
            m_joystickRightVertical = rightJoystick.y;
            m_onJoystickRightVertical.Invoke(rightJoystick.y);
        }




        if (m_buttonLeftFront != buttonLeftFront)
        {
            m_buttonLeftFront = buttonLeftFront;
            if (buttonLeftFront)
            {
                m_onLeftTriggerChanged?.Invoke(1);
            }
        }

        if (m_buttonLeftBack != buttonLeftBack)
        {
            m_buttonLeftBack = buttonLeftBack;
            if (buttonLeftBack)
            {
                m_onLeftGripChanged?.Invoke(1);
            }
        }

        if (m_buttonRightFront != buttonRightFront)
        {
            m_buttonRightFront = buttonRightFront;
            if (buttonRightFront)
            {
                m_onRightTriggerChanged?.Invoke(1);
            }
        }

        if (m_buttonRightBack != buttonRightBack)
        {
            m_buttonRightBack = buttonRightBack;
            if (buttonRightBack)
            {
                m_onRightGripChanged?.Invoke(1);
            }
        }
    }
}
