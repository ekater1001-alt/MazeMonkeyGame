using UnityEngine;

public class banana : MonoBehaviour
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