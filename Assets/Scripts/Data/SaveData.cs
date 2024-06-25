
using UnityEngine;
[CreateAssetMenu(fileName = "Save Data", menuName = "Save/Cell")]
public class SaveData : ScriptableObject
{
    public int scene;
    public int level;
    public int money;
    public float point;

    public int wordCounter;
    public int litterCounter;

}
