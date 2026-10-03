using UnityEngine;

public class Banana : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Collectbanana();
            Destroy(gameObject);
        }
    }
}