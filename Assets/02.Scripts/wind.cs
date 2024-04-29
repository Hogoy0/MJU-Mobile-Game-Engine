using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour
{
    public Vector2 windDirection = Vector2.left; // 바람의 방향 
    public float windStrength = 10f; // 바람의 세기 

    private void FixedUpdate()
    {
        ApplyWindForce();
    }

    private void ApplyWindForce()
    {
        // 바람의 힘을 적용하기 위해 오브젝트 주변에 있는 모든 Rigidbody 2D에 힘을 가함
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f); // 반경 2 안에 있는 모든 콜라이더 탐색탐색탐색
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 바람의 방향과 세기에 따라 힘을 가함
                rb.AddForce(windDirection * windStrength, ForceMode2D.Force);
            }
        }
    }
}
