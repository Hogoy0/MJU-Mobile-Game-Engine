using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushbox : MonoBehaviour
{
    public float pushForce = 10f; // 미는 힘이요

    // 캐릭터와 충돌할 때
    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한게 박스인지 확인
        if (collision.gameObject.CompareTag("Box"))
        {
            Rigidbody boxRigidbody = collision.gameObject.GetComponent<Rigidbody>(); //충돌한 오브젝트에 리지드불러오기, 이제 밀 수 있어용
            if (boxRigidbody != null)//리지드인지 아닌지 확인 != 인지 아닌지 
            {
                // 박스를 밀기 위해 힘을 가함 (여기부터 GPT없으면 못함)
                Vector3 pushDirection = collision.contacts[0].normal; // 충돌면의 법선 벡터를 획득하여 밀기 방향으로 사용(이라네요 뭔 소리지)
                boxRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);//박스에 힘을 준다. 위 변수에 10만큼의 힘을 가함. (순간적인 힘을 가함?)
            }
        }
    }
}
