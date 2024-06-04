using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask grassLayer;

    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //remove movement diagonal
            if (input.x != 0) input.y = 0;

            if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;
                
                if(IsWalkable(targetPosition))
                    StartCoroutine(Move(targetPosition));
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();

    }

    //Verificar en realmente el lugar por donde caminar el personaje es transitable
    private bool IsWalkable(Vector3 targetPos)
    {
        //Verificar si hay un objeto solido en la posicion del objetivo - Posicion del player o del objetivo, el radio del circulo, y el layer con el que se debe verificar
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) !=null)
        {
            return false;
        }

        return true;
    }

    public void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            if(Random.Range(1,101) <= 10)
            {
                Debug.Log("Te Haz encontrado con un POKEMON!");
            }
        }
    }
}
