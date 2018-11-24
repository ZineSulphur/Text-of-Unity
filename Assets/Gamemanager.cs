using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {

    public GameObject point;//鼠标点击时产生的点
    public GameObject mirror;

    public Vector2 screenPosition;
    public Vector2 mousePositionOnScreen;
    public Vector2 mousePositionInWorld;

    public bool isPoint1;

    private Vector2 point1Vector;
    private Vector2 point2Vector;
    private Vector2 mirrowVector;

    private GameObject point1;
    private GameObject point2;

    // Use this for initialization
    void Start()
    {
        isPoint1 = false;
        mirrowVector = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        //CreateMirror();
    }

    void CreateMirror()//根据两点坐标生成镜子
    {
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePositionOnScreen = Input.mousePosition;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        if (isPoint1 == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                point1 = Instantiate(point, mousePositionInWorld, Quaternion.identity) as GameObject;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isPoint1 = true;
                point1Vector = mousePositionInWorld;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                point2Vector = mousePositionInWorld;
                mirrowVector = (point1Vector + point2Vector) / 2;
                point2 = Instantiate(point, mousePositionInWorld, Quaternion.identity) as GameObject;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Instantiate(mirror, mirrowVector, Quaternion.identity);
                isPoint1 = false;
                Destroy(point1);
                Destroy(point2);
            }
        }
    }
}
