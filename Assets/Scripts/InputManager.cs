using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
public class InputManager : MonoBehaviour
{
    public static Action<Vector3> onClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray;
            RaycastHit raycstHit;
            Vector3 pos = new Vector3(0, 0, 0);

            PointerEventData pointerData = new PointerEventData(EventSystem.current);

            pointerData.position = Input.mousePosition; // use the position from controller as start of raycast instead of mousePosition.

            List<RaycastResult> results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerData, results);
            if (results.Count == 0)
            {  
                Debug.Log("Ko");
                ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycstHit, float.MaxValue))
                {
                    pos = raycstHit.point;
                    onClick.Invoke(pos);
                }
            }
        }
    }

}
