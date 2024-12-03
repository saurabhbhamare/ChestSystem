using UnityEngine;

[CreateAssetMenu(fileName = "ChestSO", menuName = "ScriptableObject/ChestSO")]
public class ChestSO : ScriptableObject
{
    public ChestData[] chests;
}
