using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DevExtensions {
    public static bool ContainsLayer(this LayerMask mask, int layer) {
        return mask == (mask | (1 << layer));
    }

    public static GameObject GetClosest(this Vector3 position, ICollection<GameObject> collection) {
        float distance = float.MaxValue;
        GameObject closest = null;
        foreach (GameObject go in collection) {
            float newDist = Vector3.Distance(position, go.transform.position);
            if (newDist < distance) {
                closest = go;
                distance = newDist;
            }
        }

        return closest;
    }

    public static void SetLayerRecursively(this GameObject obj, int newLayer) {
        if (null == obj) {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform) {
            if (null == child) {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    public static bool HasComponent<T>(this Component gameObject, out T component) {
        component = gameObject.GetComponent<T>();
        return component != null;
    }

    public static bool HasComponentInParent<T>(this Component gameObject, out T component) {
        component = gameObject.GetComponentInParent<T>();
        return component != null;
    }

    public static bool HasComponentInChildren<T>(this Component gameObject, out T component) {
        component = gameObject.GetComponentInChildren<T>();
        return component != null;
    }

    public static bool HasComponent<T>(this GameObject gameObject, out T component) {
        component = gameObject.GetComponent<T>();
        return component != null;
    }

    public static bool HasComponentInParent<T>(this GameObject gameObject, out T component) {
        component = gameObject.GetComponentInParent<T>();
        return component != null;
    }

    public static bool HasComponentInChildren<T>(this GameObject gameObject, out T component) {
        component = gameObject.GetComponentInChildren<T>();
        return component != null;
    }
}

public static class Tools {
    public static float WrapAngle(float angle) {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }

    public static float UnwrapAngle(float angle) {
        if (angle >= 0)
            return angle;

        angle = -angle % 360;

        return 360 - angle;
    }
}