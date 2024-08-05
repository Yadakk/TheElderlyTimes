using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TMP_LinkedTextsVerticalOffset : TMP_LinkedTexts
{
    public float VerticalOffset;

    protected override void UpdateTextMesh(TextMeshProUGUI textMesh)
    {
        textMesh.text = "<voffset=" + VerticalOffset.ToString(CultureInfo.InvariantCulture) + "em>" + Text + "</voffset>";
    }
}
