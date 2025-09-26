using UnityEngine;

public class DialogueFlags : MonoBehaviour
{
    public static DialogueFlags instance;

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
