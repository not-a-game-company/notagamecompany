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
    private KeyCode _keyCode;
    private int _keyNumber;
    public event Action<int> OnButtonClicked;
    

    private void OnEnable() 
    {
        _hotBar = GetComponentInParent<Hotbar>();
        
        _keyNumber = transform.GetSiblingIndex() + 1;
        _keyCode = KeyCode.Alpha0 + _keyNumber;
        selectableAssest = _hotBar.listOfSeletcableAssests[transform.GetSiblingIndex()];//get rid of static list
        
        if (_text == null)
        {
            _text = GetComponentInChildren<TMP_Text>();
        }
        
        _text.SetText(_keyNumber.ToString());
        gameObject.name = "HotBar Button" + _keyNumber;
    }


    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(HandleClick);
        
    }

    private void Update()
    {
        if(Hotbar.ListOfSelectableAsset.Count == 0) {Destroy(gameObject);}
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
