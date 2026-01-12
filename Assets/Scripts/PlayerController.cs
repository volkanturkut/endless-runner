using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool isGameStarted = false;
    [SerializeField] float speed = 10f;
    [SerializeField] private float clampValue = 4;
    [SerializeField] GameObject[] particles;


    Animator _animator;

    // Update is called once per frame
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isGameStarted) return;
        float horizontal = Input.GetAxis("Horizontal");


        _animator.SetBool("isRun", true);

        transform.position += transform.forward * speed * Time.deltaTime;
        Vector3 tempPos = transform.position;
        tempPos.x += horizontal * speed * Time.deltaTime;
        tempPos.x = Mathf.Clamp(tempPos.x, -clampValue, clampValue);
        transform.position = tempPos;
    }

    public void StartGame()
    {
        isGameStarted = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            isGameStarted = false;
            _animator.SetTrigger("dancing");
            foreach (GameObject particle in particles)
            {
                particle.SetActive(true);
            }
        }
    }
}
