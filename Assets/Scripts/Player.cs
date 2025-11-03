using UnityEngine;

public class Player : MonoBehaviour
{
    public static Entity Instance;

    public static bool IsDead => !Instance;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = GetComponent<Entity>();
    }
}