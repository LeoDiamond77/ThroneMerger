using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public List<GameObject> ThingsToDrop;      

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var pos = transform.position;
            pos.x += MoveSpeed * Time.deltaTime; 
            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var pos = transform.position;
            pos.x -= MoveSpeed * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(0, ThingsToDrop.Count);

            Instantiate(ThingsToDrop[index], transform.position, Quaternion.identity);
        }
    }
}
