using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class player : MonoBehaviour
{
    private float speed;
    private int jump_counter;
    public Rigidbody rb;

    void Start()
    {
        this.speed = 0.03f;
        this.jump_counter = 0;
        this.rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if(this.rb.transform.position.x >= 98.08 && this.rb.transform.position.y >= 9.8 && this.rb.transform.position.y <= 11.3)
        {
            SceneManager.LoadScene(3);
        }

        if(this.rb.transform.position.y <= 5)
        {
            SceneManager.LoadScene(2);
        }


        float horz = Input.GetAxisRaw("Horizontal")*speed;
        //float vert = Input.GetAxisRaw("Vertical");

        transform.Translate(horz, 0, 0);

        if (Input.GetButtonDown("Jump") && this.jump_counter < 2)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            this.jump_counter++;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        this.jump_counter = 0;
    } 



}
