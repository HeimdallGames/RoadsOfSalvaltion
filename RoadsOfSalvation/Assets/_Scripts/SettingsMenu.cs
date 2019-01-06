using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO;
using System.Xml;
using System.Text;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

	public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    /*
    public TextAsset dictionary;
    public string nameLanguage;
    public int currentLanguage;

    string button1;
    string button2;

    List<Dictionary<string, string>> languages = new List<Dictionary<string, string>>();
    Dictionary<string, string> obj;

    private void Awake()
    {
        Reader();
    }

    private void Update()
    {
        languages[currentLanguage].TryGetValue("Name", out nameLanguage);
        languages[currentLanguage].TryGetValue("button1", out nameLanguage);
        languages[currentLanguage].TryGetValue("button2", out nameLanguage);
    }

    private void OnGUI()
    {
        GUILayout.Button(button1);
        GUILayout.Button(button2);
    }

    void Reader()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(dictionary.text);
        XmlNodeList languagesList = xmlDoc.GetElementsByTagName("language");

        foreach(XmlNode languageValue in languagesList)
        {
            XmlNodeList languageContent = languageValue.ChildNodes;
            obj = new Dictionary<string, string>();

            foreach(XmlNode value in languageContent)
            {
                if(value.Name == "Name")
                {
                    obj.Add(value.Name, value.InnerText);
                }
                if (value.Name == "button1")
                {
                    obj.Add(value.Name, value.InnerText);
                }
                if (value.Name == "button2")
                {
                    obj.Add(value.Name, value.InnerText);
                }
            }
            languages.Add(obj);
        }
    }*/
}
