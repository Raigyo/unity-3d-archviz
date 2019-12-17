using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableVars", order = 1)]
public class ScriptableVars : ScriptableObject
{
    public int gameSelected;
    //call with public ScriptableVars scriptableVars;//scriptable object ref
    //links data folder to scriptableVars
    //call with: scriptableVars.myVar;
}
