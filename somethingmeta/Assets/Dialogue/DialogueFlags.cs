using UnityEngine;

public class DialogueSingletonScript : MonoBehaviour
{
    public static DialogueSingletonScript instance;

    [HideInInspector]
    public int score;

    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
