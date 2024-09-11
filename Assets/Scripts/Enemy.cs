using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float borderRight = 9.5f;
    private float borderLeft = -9.5f;
    private float borderTop = 5.2f;
    private float borderBottom = -5.4f;
    private float _speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        float rndX = Random.Range(borderLeft, borderRight);


        transform.position = new Vector3(rndX, borderTop, 0);

    }

    // Update is called once per frame
    void Update()
    {

        float rndX = Random.Range(borderLeft, borderRight);

        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < borderBottom)
        {
            transform.position = new Vector3(rndX, borderTop + 1, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player _player = other.transform.GetComponent<Player>();
            if (_player != null)
                _player.Damage();
            Destroy(this.gameObject);

        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
