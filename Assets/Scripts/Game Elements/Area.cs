using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK.GameElements
{
public class Area : MonoBehaviour
{   
    public AreaLogic logic;


    public void OnDrop()
    {
        logic.Execute();
    }
}
}