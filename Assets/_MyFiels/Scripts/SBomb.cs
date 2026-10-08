using System.Collections;
using UnityEngine;

public class SBomb : MonoBehaviour
{
    private Vector3 originalOffset;
    public GameObject fruitSliced;
    private Camera mainCam;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;
    Rigidbody2D rb;
    public float startForce = 15f;

    private void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            Debug.Log("Bomb Hit!1");
            StartCoroutine(ShakeCamera());
            Vector3 direction = (collision.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedPumpkin = Instantiate(fruitSliced, transform.position, rotation);
            Destroy(slicedPumpkin, 5f);
            Destroy(gameObject);
        }
    }

    IEnumerator ShakeCamera()
    {
        originalOffset = mainCam.transform.localPosition;

        while (shakeDuration > 0)
        {
            shakeDuration -= Time.deltaTime;

            // Random offset in X and Y
            mainCam.transform.localPosition = originalOffset +
                new Vector3(
                    Random.Range(-shakeMagnitude, shakeMagnitude),
                    Random.Range(-shakeMagnitude, shakeMagnitude),
                    0
                );

            yield return null;
        }

        // Restore camera position
        mainCam.transform.localPosition = originalOffset;
    }
}
