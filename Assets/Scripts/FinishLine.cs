using TMPro;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TutoManager.singleton.NextStatus(StateEnum.FINISHED);
    }
}