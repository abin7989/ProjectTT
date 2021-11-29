using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGameMove : MonoBehaviour
{
    private float moveX, MoveUp;
    [Header("�̵��ӵ� ����")]
    [SerializeField]
    [Range(1f, 20f)]
    private float playerMoveSpeed = 2f;

    private Vector3 gridTransform;
    private float gridMoveSpeed = 5.0f; //�׸��� �̵��� �ӵ�
    private float gridMoveDistance = 1f;  //�׸��� �̵��Ÿ�
    private bool gridCanMove = true;    //�׸��� �̵��� �����Ѱ�?
    private bool gridMoveDelay = false; //�̵���ư�� ������ ������ �׸��� �̵��� ��� ���ߴ� ȿ���� �ֱ����� ����
    private float gridMoveDelayTime = 0.05f;    //�̵���ư�� ������ ������ �׸��� �̵��� ��� ����ȿ�� �ð�

    private float Score = 0;
    void Start()
    {
        gridTransform = transform.position;
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        PlayerMoveControl();
    }

    private void PlayerMoveControl()
    {

        if (gridTransform == transform.position)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            if (gridCanMove == true)
            {
                switch (moveX)
                {
                    case 1:
                        if ((gridTransform + (Vector3.right * gridMoveDistance)).x < 4f)
                        {
                            gridTransform += Vector3.right * gridMoveDistance;
                        }

                        break;
                    case -1:
                        if ((gridTransform + (Vector3.left * gridMoveDistance)).x > -4f)
                        {
                            gridTransform += Vector3.left * gridMoveDistance;
                        }

                        break;
                }

                gridCanMove = false;
            }
            else
            {
                if (gridMoveDelay == false)
                {
                    gridMoveDelay = true;
                    StartCoroutine("GridMoveDelay");
                }
            }
        }
        else
        {
            transform.position =
                Vector3.MoveTowards(transform.position, gridTransform, Time.deltaTime * gridMoveSpeed); // Move there
        }

    }


    IEnumerator GridMoveDelay()
    {
        yield return new WaitForSeconds(gridMoveDelayTime);
        gridCanMove = true;
        gridMoveDelay = false;

    }
}