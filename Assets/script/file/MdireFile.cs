using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MdireFile  {

	public void mkdirFile(string path,string name)
    {
        string assertpath = Application.streamingAssetsPath+"/"+path;

        try
        {
            // Determine whether the directory exists.
            if (!Directory.Exists(assertpath))
            {
                // Create the directory it does not exist.
                Directory.CreateDirectory(assertpath);
            }
            /*
            if (Directory.Exists(assertpath))
            {
                // Delete the target to ensure it is not there.
                Directory.Delete(assertpath, true);
            }
            */
            // Move the directory.
            //Directory.Move(path, assertpath);
            if(File.Exists(assertpath + @"\myfile.txt"))
            {
                File.Delete(assertpath + @"\myfile.txt");
            }
            // Create a file in the directory.
            File.CreateText(assertpath + @"\myfile.txt");

            // Count the files in the target directory.
            Debug.Log("The number of files in "+ Directory.GetFiles(assertpath).Length);
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        finally { }
    }
}
