import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import java.util.HashMap; 
import java.util.ArrayList; 
import java.io.File; 
import java.io.BufferedReader; 
import java.io.PrintWriter; 
import java.io.InputStream; 
import java.io.OutputStream; 
import java.io.IOException; 

public class Item_Name_Updater extends PApplet {

String[] test;

public void setup()
{
  updateAllFiles();
}

public void draw()
{
  
}

public void updateAllFiles()
{
  File[] files = listFiles("data");
  for (int i = 0; i < files.length; i++)
  {
    updateFile(files[i].toString());
  }
  exit();
}

public void updateFile(String fileName)
{
  String name = "";
  String toolTip = "";
  Boolean defaults = false;
  int shifting = 0;
  String[] data = loadStrings(fileName);
  String[] newData = new String[data.length + 7];
  for (int i = 0; i < data.length; i++)
  {
    newData[i + shifting] = data[i];
    if (data[i].contains("item.name"))
    {
      name = split(data[i],'"')[1];
      newData[i] = "";
    }
    if ((data[i].contains("item.toolTip") || data[i].contains("AddTooltip")) && (toolTip == ""))
    {
      toolTip = split(data[i],'"')[1];
      newData[i] = "";
    }
    if ((data[i].contains("item.toolTip2") || data[i].contains("AddTooltip2")) && (toolTip !=""))
    {
      toolTip = toolTip + "\\n" + split(data[i],'"')[1];
      newData[i] = "";
    }
    if (data[i].contains("SetDefaults()"))
    {
      defaults = true;
    }
    if (defaults && data[i].contains("}"))
    {
      newData[i+1] = "";
      newData[i+2] = "    public override void SetStaticDefaults()";
      newData[i+3] = "    {";
      newData[i+4] = "      DisplayName.SetDefault(\"" + name + "\");";
      newData[i+5] = "      Tooltip.SetDefault(\"" + toolTip + "\");";
      newData[i+6] = "    }";
      newData[i+7] = "";
      shifting = 7;
      defaults = false;
    }
  }
  saveStrings(fileName, newData);
}
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "Item_Name_Updater" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
