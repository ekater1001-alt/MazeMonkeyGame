using UnityEngine;

public class ExitZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null &&
                GameManager.Instance.bananasCollected >= GameManager.Instance.totalbananas)
            {
                GameManager.Instance.WinGame();
            }
            else
            {
                Debug.Log("Нужно собрать все яйца!");
            }
        }
    }
}