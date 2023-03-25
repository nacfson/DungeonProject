using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolSample : MonoBehaviour
{

    public Button poolBtn1;
    public Button poolBtn2;
    void Start()
    {
        PoolManager.CreatePool<Cube>("Cube1", gameObject.transform);
        poolBtn1.onClick.AddListener(OnClickPoolBtn1);

        PoolManager.CreatePool<Cube>("Cube2", gameObject.transform);
        poolBtn2.onClick.AddListener(OnClickPoolBtn2);
    }

    public void OnClickPoolBtn1()
    {
        PoolManager.GetItem<Cube>("Cube1");
    }

    public void OnClickPoolBtn2()
    {
        PoolManager.GetItem<Cube>("Cube2");
    }


}
