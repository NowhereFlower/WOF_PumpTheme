using TMPro;
using UnityEngine;

public class SFruit : MonoBehaviour
{
    public GameObject fruitSliced;
    Rigidbody2D rb;
    public float startForce = 15f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {

            Vector3 direction = (collision.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            Debug.Log("Pumpkin SLice!1");
            GameObject slicedPumpkin = Instantiate(fruitSliced, transform.position, rotation);
            Destroy(slicedPumpkin, 5f);
            Destroy(gameObject);
        }
    }
}
