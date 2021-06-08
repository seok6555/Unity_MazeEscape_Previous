using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //목표가 될 변수.
    public Transform target;
    public bool isChase;
    public bool isMove;
    public bool isStop;

    //네비게이션 기능 받아오는 변수.
    NavMeshAgent nav;
    Rigidbody rb;
    public Animator anim;

    public GameObject[] position;
    private RaycastHit hit;
    public float timer = 10.0f;
    private Vector3 checkposition;
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, .0f, this.transform.position.z);
        if (isChase && timer > 0)
        {
            timer -= Time.deltaTime;
            nav.SetDestination(target.position);
            nav.speed = 8.5f;
            anim.SetBool("isWalk", true);
        } else
        {
            isChase = false;
            nav.speed = 6f;
            timer = 10.0f;
        }

        if(Physics.Raycast(this.transform.position,this.transform.forward, out hit, 40))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                isChase = true;
                isMove = false;
                isStop = false;
            }
        }

        if(!isMove && !isStop)
        {
            MoveStart();
        }

        if(isMove)
        {
            Stop();
        }

        if(isStop)
        {
            if(Random.Range(0,10000) > 9950) {
                MoveStart();
            }
        }

        if (GameObject.Find("PauseMenu").GetComponent<PauseMenu>().isMenuOpen == true)
            audio.Pause();
        else if (GameObject.Find("EnumManager").GetComponent<EnumManager>().gameState == GameState.dead)
            audio.Pause();
        else
        {
            if(!audio.isPlaying)
                audio.Play();
        }
    }

    void FixedUpdate()
    {
        if (isChase)
        {
            FreezeVelocity();
        }
    }

    void MoveStart()
    {
        if(!isMove)
        {
            isMove = true;
            isStop = false;
            nav.isStopped = false;
            int num = Random.Range(0, 5);
            nav.SetDestination(position[num].transform.position);
            Check(num);
            checkposition = position[num].transform.position;
            anim.SetBool("isWalk", true);
        }

        void Check(int n)
        {
            if(checkposition == position[n].transform.position)
            {
                int num = Random.Range(0, 5);
                nav.SetDestination(position[num].transform.position);
                Check(num);
            }
        }
    }

    void Stop()
    {
        int num = Random.Range(0, 10000);
        if(num > 9997)
        {
            Debug.Log("stop");
            isMove = false;
            isStop = true;
            nav.Stop();
            anim.SetBool("isWalk", false);
        }
    }

    void FreezeVelocity()
    {
            //물리적인 속도, 회전력을 0으로 만들어줌.
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
    }

    public void DieStart()
    {
        isChase = false;
        nav.enabled = false;
        anim.SetTrigger("doDie");
        StartCoroutine(deadDelay());
    }

    IEnumerator deadDelay()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Spot")
        {
            isMove = false;
            isStop = true; 
            nav.Stop();
            anim.SetBool("isWalk", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "Player")
        {
            DieStart();
        }
    }
}
