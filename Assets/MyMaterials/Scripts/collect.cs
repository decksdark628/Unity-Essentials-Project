using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    // Start is called before the first frame update
    public int rotationSpeed = 10;
    public int rotationSpeed2 = 6;
    public GameObject onCollectEffect;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed2, rotationSpeed, 0);

        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * 1) * 0.01f;
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Destroy the collectible
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);

            Instantiate(onCollectEffect, transform.position, transform.rotation);
            
        }
        Debug.Log("fdfsd");
    }
}
