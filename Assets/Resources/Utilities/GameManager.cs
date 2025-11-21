using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager _instance;
    public static GameManager instance {  get { return _instance; } }

    private void Awake()
    {
        if (_instance) Destroy(gameObject);
        else _instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    public GameObject battlersBase;
    public BattlersStat[] fishStats = new BattlersStat[5];
}
