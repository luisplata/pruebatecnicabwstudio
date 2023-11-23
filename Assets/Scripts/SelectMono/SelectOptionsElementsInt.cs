using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectOptionsElementsInt : SelectOptionsElements
{
    [SerializeField] protected int[] options;
    protected override List<string> AddOptionsCustom()
    {
        _options = options.Select(x => x.ToString()).ToList();
        return _options;
    }
    
}