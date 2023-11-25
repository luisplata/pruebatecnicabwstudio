using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectOptionsElementsStrings : SelectOptionsElements
{
    [SerializeField] private string[] options; 
    protected override List<string> AddOptionsCustom()
    {
        _options = options.ToList();
        return _options;
    }
}