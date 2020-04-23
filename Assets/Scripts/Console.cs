using TMPro;
using UnityEngine;

public class Console : MonoBehaviour
{
    public Controller target;
    public TextMeshPro text;

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        target.Register();
        text.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        target.UnRegister();
        text.gameObject.SetActive(false);
    }
}