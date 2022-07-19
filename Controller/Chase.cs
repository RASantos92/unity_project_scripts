using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform player;
    public float speed = 10f;
    public float gravity = -9.81f;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            Vector3 direction = player.position - this.transform.position;

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);

            if(direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 5f * Time.deltaTime);
            }
            velocity.y += gravity * Time.deltaTime;

        }
    }
}
