using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.Windows;

public class JSONParser {
    public Root localization;
    // Start is called before the first frame update
    public JSONParser(TextAsset json) {
        localization = JsonConvert.DeserializeObject<Root>(json.text);
    }
}

public class Menu
{
    public string title_txt { get; set; }
    public string start_btn { get; set; }
    public string tutorial_btn { get; set; }
    public string controls_btn { get; set; }
    public string exit_btn { get; set; }
}

public class Root
{
    public Menu menu { get; set; }
    public TutorialIntroduction tutorial_introduction { get; set; }
    public TutorialPopups tutorial_popups { get; set; }
}

public class TutorialIntroduction
{
    public string step1 { get; set; }
    public string step2 { get; set; }
    public string step3 { get; set; }
}

public class TutorialPopups
{
    public string step1 { get; set; }
    public string step2 { get; set; }
    public string step3 { get; set; }
    public string step4 { get; set; }
    public string step5 { get; set; }
}