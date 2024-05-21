using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public int landLimit = 5; // 부서지기 전에 필요한 착지 횟수
    private int landCount = 0; // 플레이어의 착지 횟수

    public void PlayerLanded()
    {
        // 플레이어가 착지할 때 호출되는 함수
        landCount++;
        if (landCount >= landLimit)
        {
            BreakPlatform();
        }
    }

    private void BreakPlatform()
    {
        // 발판을 부수는 함수 (애니메이션 재생 또는 부서진 그래픽 처리)
        // 이후 발판을 비활성화하거나 제거하는 등의 추가 작업을 수행할 수 있습니다.
        gameObject.SetActive(false); // 발판 비활성화
    }
}
