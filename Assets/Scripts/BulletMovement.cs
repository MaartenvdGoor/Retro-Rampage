using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public int lifetime;
    public float spread = 36;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
		
		transform.rotation = Quaternion.Euler(0, 0, rot + 90 + (Random.Range(-spread,spread) * 10));
		Destroy(gameObject, lifetime);
	}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * force * Time.deltaTime);
    }
}
