using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScriptableObjects : MonoBehaviour
{

    public ScriptableVars scriptableVars;//scriptable object ref
    // Start is called before the first frame update
    void Start()
    {
        scriptableVars.gameSelected = 0;
    }
}
