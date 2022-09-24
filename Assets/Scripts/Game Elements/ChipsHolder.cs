using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AK
{
public class ChipsHolder : ScriptableObject
{   
    public bool isUsed;
    public GameObject chipObject; 
    public int chipsCount; 

    

    public SO.TransformVariable chipsGrid; 

    void Start()
    {
        chipsCount = 100;
        
    }

   
}
}