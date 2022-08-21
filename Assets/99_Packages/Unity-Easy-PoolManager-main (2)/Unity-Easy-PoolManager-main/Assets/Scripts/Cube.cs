using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IPoolable
{
    public void OnPool()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0, 5, 0);
        StartCoroutine(Disable());
    }

    public IEnumerator Disable()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
}
