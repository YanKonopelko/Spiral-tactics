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

        PointerEventData pointerData = new PointerEventData(EventSystem.current);

        //Считывает косание или нажатие левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            pointerData.position = Input.mousePosition;
            OnClick(pointerData);
        }
        else if (Input.touchCount > 0)
        {
            pointerData.position = Input.GetTouch(Input.touchCount - 1).position;
            OnClick(pointerData);
        }

        
    }

    private void OnClick(PointerEventData pointerData)
    {
        Ray ray;
        RaycastHit raycstHit;
        Vector3 pos = new Vector3(0, 0, 0);

        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointerData, results);

        //Проверяет наличие элемента интерфейса в точке касания
        if (results.Count ==0)
        {
            //Преобразует координаты в общемировые
            ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(pointerData.position);
            if (Physics.Raycast(ray, out raycstHit, float.MaxValue))
            {
                onClick.Invoke(raycstHit.point);
            }
        }
    }
}
