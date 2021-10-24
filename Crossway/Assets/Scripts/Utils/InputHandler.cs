using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHandler {

    public static bool PointerDown(out PointerEventArgs eventArgs) {
        eventArgs = null;

        if (SystemInfo.deviceType == DeviceType.Handheld) {
            if (Input.touchCount > 0) {
                eventArgs = new PointerEventArgs(Input.GetTouch(0).position);
                return Input.GetTouch(0).phase == TouchPhase.Began;
            }
            else
                return false;
        }
        else {
            eventArgs = new PointerEventArgs(Input.mousePosition);
            return Input.GetMouseButtonDown(0);
        }
    }

    public static bool PointerUp(out PointerEventArgs eventArgs) {
        eventArgs = null;

        if (SystemInfo.deviceType == DeviceType.Handheld) {
            if (Input.touchCount > 0) {
                eventArgs = new PointerEventArgs(Input.GetTouch(0).position);
                return Input.GetTouch(0).phase == TouchPhase.Ended;
            }
            else
                return false;
        }
        else {
            eventArgs = new PointerEventArgs(Input.mousePosition);
            return Input.GetMouseButtonUp(0);
        }
    }

    public static bool PointerHold(out PointerEventArgs eventArgs) {
        eventArgs = null;

        if (SystemInfo.deviceType == DeviceType.Handheld) {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) {
                    eventArgs = new PointerEventArgs(touch.position);
                    return true;
                }
            }
        }
        else {
            if (Input.GetMouseButton(0)) {
                eventArgs = new PointerEventArgs(Input.mousePosition);
                return true;
            }
        }
        return false;
    }
}

public class PointerEventArgs {
    public Vector2 position;

    public PointerEventArgs(Vector2 _position) {
        position = _position;
    }
}
