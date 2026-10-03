using UnityEngine;

public class FoxAI : MonoBehaviour
{
    public float speed = 3.5f;
    public float detectionRange = 15f;
    public float catchDistance = 1.5f;

    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
            isChasing = true;

        if (distance > detectionRange * 1.5f)
            isChasing = false;

        if (isChasing)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0;

            transform.position += direction * speed * Time.deltaTime;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
            }

            if (distance <= catchDistance)
            {
                if (GameManager.Instance != null)
                    GameManager.Instance.LoseLife();

                transform.position -= direction * 3f;
            }
        }
    }
}