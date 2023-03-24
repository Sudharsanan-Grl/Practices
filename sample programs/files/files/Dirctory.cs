
// directory class
public class DExample
{
	// directory method  and files
	public void directory()
	{
		// for creating a new directory
		Directory.CreateDirectory(@"E:\Data\C#");

		// for getting all the files with our specialization 
		// all the datas are returns in string array
	    var files=	Directory.GetFiles(@"E:\Data\C#","*.sln",SearchOption.AllDirectories);

		// for dispalying the string array
		foreach (var file in files)
		{
			// dispaly single item in array
			 Console.WriteLine(file);
		}
        // for getting all the directories with our specialization 
        var directories = Directory.GetDirectories(@"E:\Data\C#", "*.", SearchOption.AllDirectories);
        // for dispalying the string array

        foreach (var dirctory in directories)
		{
            // dispaly single item in array
            Console.WriteLine(dirctory);
		}

		// checks weather a directery is exists or not
		Directory.Exists("");
	}
	// directory info
	public void directoryInfo()
	{
		// creating a instance for directory info
		var directoryInfo = new DirectoryInfo("");

		// creating a directory info
		directoryInfo.Create();

        // deleting a directory info
        directoryInfo.Delete();

		//accessing the files using directory info
		directoryInfo.GetFiles();

        // the directory using directory info
        directoryInfo.GetDirectories();

	}
	//path method
	public void path ()
	{
		//getting directory name using path
		Path.GetDirectoryName("");

        //getting file name using path
        Path.GetFileName("");

        //getting extension using path
        Path.GetExtension("");

        //getting path
        Path.GetFullPath("");

        //getting the temporary folder
        Path.GetTempPath();

        //combines array of strings into a path and returns in combined path
        Path.Combine();


    }

}
