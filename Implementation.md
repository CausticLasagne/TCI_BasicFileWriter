/* Program:     TCI Test script
 * Description: Test script to help users understand how to use the library
 * 
 *              
 * Author:      Max Fox, TCI
 * Date:        25/02/2025
 * Version:     0.1
 */

using System.Text;
using System.Windows;
using TCI.BasicFileWriter;

namespace TCI.Tests
{
	class MyTestClass1
	{
		void Test()
		{
			// Use special folder to save a file to a directory
			// We will save to C:\Users\MyName\Documents\MyTest\MyFile.txt
			BFW fileWriter1 = new BFW(false, true, Environment.SpecialFolder.MyDocuments, "MyTest", "MyFile.txt", Encoding.Unicode);

			// Use standard folder to save a file to a directory
			// Notice that we have set special folder to null: this is OK
			// We will save to C:\MyTest\MyFile.txt
			BFW fileWriter2 = new BFW(false, false, null, "C:\\MyTest", "MyFile.txt", Encoding.Unicode);

			// As above but we will write a new file with binary
			BFW binWriter3 = new BFW(false, false, null, "C:\\MyTest", "MyBinFile.txt", Encoding.Unicode);

			// Calling the Initialise() function will create the folder and the file and close the file
			fileWriter1.Initialise();
			fileWriter2.Initialise();
			binWriter3.Initialise();

			// Show file path for each file
			MessageBox.Show(fileWriter1.AbsoluteFilePath);
			MessageBox.Show(fileWriter2.AbsoluteFilePath);
			MessageBox.Show(binWriter3.AbsoluteFilePath);

			// This will write to the file and then close it
			fileWriter1.Write(BFW.WriteType.WriteAllText, null,
				"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
				"Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
				"Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
				"Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

			// Read the file into a variable
			var myText = fileWriter1.Read(BFW.ReadType.ReadAllText);

			// This will write to the file and then close it
			fileWriter2.Write(BFW.WriteType.WriteAllLines,
				[
				"Lorem ipsum dolor sit amet",
				"consectetur adipiscing elit",
				"sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
				"Ut enim ad minim veniam,"
				]
				);

			// Convert text to byte array
			var bin = Encoding.ASCII.GetBytes("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
				"Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
				"Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
				"Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

			// This will write to the file and then close it
			binWriter3.Write(BFW.WriteType.WriteAllBytes, null, null, bin
				);

			// Delete the file
			fileWriter1.Operation(BFW.OperationType.Delete);
		}
	}
}