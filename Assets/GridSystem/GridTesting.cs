using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridTesting : MonoBehaviour
{
    private Grid<bool> grid;
    void Start()
    {
        grid = new Grid<bool>(10, 10, 2f, new Vector3(-5, -5));
    }

    // private void Update() 
    // {
    //     if(Input.GetMouseButtonDown(0)) 
    //     {
    //         grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
    //     }
    //     if(Input.GetMouseButtonDown(1)) 
    //     {
    //         Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
    //     }
    // }
}
