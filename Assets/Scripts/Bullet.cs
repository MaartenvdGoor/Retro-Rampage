using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public bool isPlayerBullet;
	private Vector3 mousePos;
	private Camera mainCam;
	public int lifetime;
    public float spread;

	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 rotation = new Vector3(0, 0, 0);
        if (!isPlayerBullet)
        {
			player = GameObject.FindGameObjectWithTag("Player");
            rotation = transform.position - player.transform.position;
			//rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
			
		}
        else
        {
			mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
			mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
			rotation = transform.position - mousePos;
			

		}
		float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, rot + 90 + (Random.Range(-spread, spread) * 10));
		Destroy(gameObject, lifetime);
	}

    void Update()
    {
		transform.Translate(Vector2.up * force * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Kevin Test Scene");
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}