using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class SelectOptionsElements : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TextMeshProUGUI textBefore, textAfter;
    protected List<string> _options;
    public event Action<string> onValueChanged;

    protected abstract List<string> AddOptionsCustom();

    private void OnValueChanged(int arg0)
    {
        var indexBefore = arg0 <= 0 ? _options.Count - 1 : arg0 - 1;
        var indexAfter = arg0 >= _options.Count - 1 ? 0 : arg0 + 1;
        textBefore.text = _options[indexBefore];
        Debug.Log($"Option selected: {_options[arg0]}");
        textAfter.text = _options[indexAfter];
        onValueChanged?.Invoke(_options[arg0]);
    }

    public virtual void Config()
    {
        dropdown.ClearOptions();
        _options = AddOptionsCustom();
        dropdown.AddOptions(AddOptionsCustom());
        dropdown.onValueChanged.AddListener(OnValueChanged);
        OnValueChanged(0);
    }
}