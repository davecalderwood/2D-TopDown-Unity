using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    public static ArrowPool instance;

    [SerializeField] private GameObject pooledArrow;
    private bool notEnoughArrows = true;
    private List<GameObject> arrows;
    private void Awake() 
    {
        instance = this;
    }

    private void Start() 
    {
        arrows = new List<GameObject>();
    }

    public GameObject GetArrow()
    {
        if(arrows.Count > 0)
        {
            for(int i =0; i < arrows.Count; i++)
            {
                if(!arrows[i].activeInHierarchy)
                {
                    return arrows[i];
                }
            }
        }

        if(notEnoughArrows)
        {
            GameObject arrow = Instantiate(pooledArrow);
            arrow.SetActive(false);
            arrows.Add(arrow);
            return arrow;
        }
        
        return null;
    }
}
