using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBox : MonoBehaviour
{
    public string pushableTag = "Player"; // �� �� �ִ� �±�
    private Rigidbody2D rb;
    private bool isBeingPushed;
    private Collider2D pushingCharacter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false; // �ʱ� ���¿��� �ڽ��� �߷��� ������ ����
    }

    void FixedUpdate()
    {
        if (isBeingPushed && pushingCharacter != null)
        {
            Vector2 pushDirection = GetPushDirection(pushingCharacter);
            if (pushDirection != Vector2.zero)
            {
                rb.velocity = pushDirection * 5f; // �ӵ� ���� ����
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // ���ڰ� �и��� ���� �� ���� �ӵ��� 0���� ����
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(pushableTag))
        {
            isBeingPushed = true;
            pushingCharacter = collision.collider;
            rb.isKinematic = false; // �и��� ���� �ڽ��� ���������� �̵� �����ϰ� ����
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider == pushingCharacter)
        {
            isBeingPushed = false;
            pushingCharacter = null;
            rb.velocity = Vector2.zero; // �и��� ������ �� �ӵ� �ʱ�ȭ
        }
    }

    Vector2 GetPushDirection(Collider2D character)
    {
        float horizontal = Input.GetAxis("Horizontal");
        return new Vector2(horizontal, 0).normalized; // ���� ���⸸ ��ȯ
    }

    void OnDrawGizmos()
    {
        // ���� ��忡�� OverlapBox ������ �ð������� Ȯ��
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}