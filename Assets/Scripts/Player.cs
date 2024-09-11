using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    private Vector3 _laserOffset = new Vector3(0, 1.05f, 0);
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private BorderDimensionsSO _borderDimensionsSO;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

    }

    void CalculateMovement()
    {
        float borderRight = _borderDimensionsSO.borderRightProperty;
        float borderLeft = _borderDimensionsSO.borderLeftProperty;
        float borderTop = _borderDimensionsSO.borderTopProperty;
        float borderBottom = _borderDimensionsSO.borderBottomProperty;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        /* Wrap effect */
        if (transform.position.x > borderRight)
            transform.position = new Vector3(borderLeft, transform.position.y, 0);
        else if (transform.position.x < borderLeft)
            transform.position = new Vector3(borderRight, transform.position.y, 0);

        /* Y axis restrictions could be optimized with Math.Clmap(min,max)*/
        if (transform.position.y > borderTop)
            transform.position = new Vector3(transform.position.x, borderTop, 0);
        else if (transform.position.y < borderBottom)
            transform.position = new Vector3(transform.position.x, borderBottom, 0);

    }

    void FireLaser()
    {

        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + _laserOffset, Quaternion.identity);

    }

    public void Damage()
    {
        this._lives -= 1;

        if (_lives <= 0)
        {

            if (_spawnManager != null)
                _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);

        }

    }
}
