using UnityEngine;

public class UIBoxFactory : MonoBehaviour
{
    [SerializeField] private GameObject IfBoxPrefab;
    [SerializeField] private GameObject PressButtonPrefab;
    [SerializeField] private GameObject MoveBoxPrefab;

    [SerializeField] private EditorPanel editor;

    public void CreateIfBox()
    {
        GameObject ifBox = Instantiate(IfBoxPrefab, transform.position, transform.rotation, transform);
        editor.RegisterWindow(ifBox.GetComponent<Box>());
    }

    public void CreatePressButtonBox()
    {
        GameObject pressButton = Instantiate(PressButtonPrefab, transform.position, transform.rotation, transform);
        editor.RegisterWindow(pressButton.GetComponent<Box>());
    }

    public void CreateMoveBox()
    {
        GameObject moveBox = Instantiate(MoveBoxPrefab, transform.position, transform.rotation, transform);
        editor.RegisterWindow(moveBox.GetComponent<Box>());
    }
}