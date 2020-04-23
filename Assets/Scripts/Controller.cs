using UnityEngine;

public class Controller : MonoBehaviour
{
    private float speed = 3;

    private void Start()
    {
    }

    public void Register()
    {
        if (!LevelManager.singleton.movable.Contains(this))
            LevelManager.singleton.movable.Add(this);
    }


    public void UnRegister()
    {
        if (LevelManager.singleton.movable.Contains(this))
            LevelManager.singleton.movable.Remove(this);
    }

    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}