using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class BakingNavMesh : MonoBehaviour
{
    public NavMeshSurface[]navMeshSurfaces;
    private GameObject[] Floors; 
    // Start is called before the first frame update
    void Start()
    {
        foreach (NavMeshSurface floor in navMeshSurfaces) 
        {
            floor.GetComponent<NavMeshSurface>().BuildNavMesh();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
