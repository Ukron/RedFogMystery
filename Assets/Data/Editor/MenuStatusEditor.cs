using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(MenuStatus))]
public class MenuStatusEditor : BaseExcelEditor<MenuStatus>
{	
    public override void OnEnable()
    {
        base.OnEnable();
        
        MenuStatus data = target as MenuStatus;
        
        databaseFields = ExposeProperties.GetProperties(data);
        
        foreach(MenuStatusData e in data.dataArray)
        {
            dataFields = ExposeProperties.GetProperties(e);
            pInfoList.Add(dataFields);
        }
    }
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        //DrawDefaultInspector();
        if (GUI.changed)
        {
            pInfoList.Clear();
            
            MenuStatus data = target as MenuStatus;
            foreach(MenuStatusData e in data.dataArray)
            {
                dataFields = ExposeProperties.GetProperties(e);
                pInfoList.Add(dataFields);
            }
            
            EditorUtility.SetDirty(target);
            Repaint();
        }
    }
    
    public override bool Load()
    {
        MenuStatus targetData = target as MenuStatus;

        string path = targetData.SheetName;
        if (!File.Exists(path))
            return false;

        string sheet = targetData.WorksheetName;

        ExcelQuery query = new ExcelQuery(path, sheet);
        if (query != null && query.IsValid())
        {
            targetData.dataArray = query.Deserialize<MenuStatusData>().ToArray();
            EditorUtility.SetDirty(targetData);
            AssetDatabase.SaveAssets();
            return true;
        }
        else
            return false;
    }
}
