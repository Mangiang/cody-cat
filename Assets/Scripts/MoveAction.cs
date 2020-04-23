using UnityEngine;

public class MoveAction : ScriptAction
{
    bool shouldMove = false;
    float speed = 1f;

    public Vector3 direction = Vector3.zero;

    private Vector3 originPos;
    public Vector3 targetPos;

    float posProgress = 0;

    public override void Init()
    {
        shouldMove = true;
        originPos = target.transform.position;
        targetPos = target.transform.position + 5 * Vector3.up;
    }

    public override void Update()
    {
        if (originPos == targetPos)
            isFinished = true;
        else
        {
            posProgress += speed * Time.deltaTime;
            float newPosX = Mathf.Lerp(originPos.x, targetPos.x, posProgress);
            float newPosY = Mathf.Lerp(originPos.y, targetPos.y, posProgress);
            float newPosZ = Mathf.Lerp(originPos.z, targetPos.z, posProgress);
            Vector3 newPos = new Vector3(newPosX, newPosY, newPosZ);
            target.transform.position = newPos;
        }
    }
}