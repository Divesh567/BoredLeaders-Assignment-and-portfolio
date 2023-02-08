using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;
    public static MenuManager Instance { get { return _instance; } }

    [SerializeField]
    private MainMenu _mainMenuPrefab;
    [SerializeField]
    private GameMenu _gameMenuPrefab;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            InitializeMenus();
            DontDestroyOnLoad(gameObject);
        }
    }

    private void InitializeMenus()
    {
        Menu[] menus = { _mainMenuPrefab, _gameMenuPrefab};

        foreach (Menu menu in menus)
        {
            if (menu != null)
            {
                Menu newMenu = Instantiate(menu);
                newMenu.GetComponent<RectTransform>().SetParent(transform) ;
            }
        }
    }

    public void OpenMenu(Menu newmenu)
    {
        newmenu.MenuOpen();
    }
    public void CloseMenu(Menu newmenu)
    {
        newmenu.MenuClose();
    }
}
