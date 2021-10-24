using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Touch touch;
    //public SpriteRenderer crosshairSprite;
    public Transform weaponTransform;

    private void Update()
    {

        if(Input.touchCount > 0)
        {
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                //crosshairSprite.transform.position = Input.GetTouch(0).position;

                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.DrawLine(ray.origin, hit.point, Color.red, 5000);
                    weaponTransform.LookAt(Vector3.Lerp(weaponTransform.position, hit.point, Time.deltaTime * 500));

                    if (hit.collider != null)
                    {
                        StickmanBehavior sm = hit.collider.GetComponent<StickmanBehavior>();
                        if (sm != null)
                        {
                            if (sm.type == StickmanType.Red)
                            {
                                Destroy(sm.gameObject);
                            }
                        }
                    }
                }
            }
        }

        
    }
}
