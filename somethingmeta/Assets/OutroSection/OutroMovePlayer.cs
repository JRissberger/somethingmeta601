using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroMovePlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void MovePlayer(Transform newPosition)
    {
        player.transform.position = newPosition.position;
    }

    public void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);
        player.SetActive(false);
        StartCoroutine(RemoveCrashScreen(screen));
    }

    private IEnumerator RemoveCrashScreen(GameObject screen)
    {
        yield return new WaitForSeconds(1.5f);
        player.SetActive(true);
        screen.SetActive(false);
    }
}
