using Doozy.Engine.UI;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public RectTransform Area;
    public GameObject Interact;

    private GameObject _player;
    private UIPopup _popup;

    protected void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _popup = UIPopup.GetPopup("Store");
    }

    public void Update()
    {
        if (Interact == null)
            return;

        Interact.SetActive(_player != null && Area.rect.Contains(_player.transform.position));

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Interact.activeSelf)
            {
                if (_popup.IsShowing) _popup.Hide();
                else _popup.Show();
            }
        }
    }
}
