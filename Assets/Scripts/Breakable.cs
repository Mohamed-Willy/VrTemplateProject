
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakblePieces;
  
    void Start()
    {
        foreach(var item in breakblePieces)
        {
            item.SetActive(false);



        }
    }
    public void Break()
    {

        foreach (var item in breakblePieces)
        {
            item.SetActive(true);
            item.transform.parent = null;


        }
        gameObject.SetActive(false);
    }

  
}
