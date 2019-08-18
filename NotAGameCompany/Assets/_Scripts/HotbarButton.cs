using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HotbarButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] GameObject selectableAssest;
    private Sprite sprite;
    private Image m_Image;
    private Texture2D tex;
    
    public Hotbar _hotBar;
    [SerializeField]private KeyCode _keyCode;
    private int _keyNumber;
    public event Action<int> OnButtonClicked;

    private static int x = 0;

    private void LateUpdate()
    {
        
    }

    private void HotBarButtonInfo()
    {
        selectableAssest = _hotBar.listOfSeletcableAssests[x];
            
            if (_text == null)
            {
                _text = GetComponentInChildren<TMP_Text>();
            }
            
            x += 1;
            _keyCode = KeyCode.Alpha0 + x;
            _text.SetText(x.ToString());
    }

    private void Awake()
    {
        _hotBar = FindObjectOfType<Hotbar>();
        GetComponent<Button>().onClick.AddListener(HandleClick);
    }

    private void OnEnable()
    {
      HotBarButtonInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_keyCode))
        {
            HandleClick();
            AssetsPlacer.selectedAssest = selectableAssest;              
        }
    }

    private void HandleClick()
    {
        OnButtonClicked?.Invoke(_keyNumber);
    }

}
