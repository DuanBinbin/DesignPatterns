/*==============================
* FileName:		ScriptInitializer
* Author:		DuanBin
* CreateTime:	8/6/2018 4:36:16 PM
* Description:		
* ==============================
*/
using System.IO;

public class ScriptInitializer : UnityEditor.AssetModificationProcessor {

    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (path.ToLower().EndsWith(".cs") || path.ToLower().EndsWith(".lua"))
        {
            string content = File.ReadAllText(path);

            content = content.Replace("#AUTHORNAME#", "DuanBin");
            content = content.Replace("#CREATETIME#", System.DateTime.Now.ToString());

            File.WriteAllText(path, content);
        }
    }    
}


