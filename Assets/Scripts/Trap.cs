using UnityEngine;

public class Trap : MonoBehaviour
{
    public float cooldown = 2f;
    private float lastTriggerTime = -10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.time - lastTriggerTime > cooldown)
        {
            GameManager.Instance.LoseLife();
            lastTriggerTime = Time.time;
        }
    }
}