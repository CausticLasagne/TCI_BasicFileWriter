# TCI_BasicFileWriter
////////////////////////////////////////////////////////////////////////////////  
## What is it?
Basic File Writer:  Writing stuff to a file should be easy and simple. 
I got tired of having to setup and write my own boilerplate code to do this each time so here we are. And here you go. 
Use it but don't go stealing my work tho! I'm watching you. This was a pain in the ass to write.

## NOTE: Do not use in Production
⚠ This is version 0.5 of the writer. It is functional but expect code improvements, deprecations and further changes as I improve the performance
and code layout of the library. As a result, this is not recommended to use in a production environment just yet.

## Objective
The final goal of this project will be to allow any C# developer to write anything to file, even in Async, in only a few lines of code.

# Program flow:
## Constructor + comments:
```
/// <summary>
/// Set the parameters for the program.
/// </summary>
/// <param name="UseSharedSpecialAndDirectory">
/// If we want to use certain shared parameters across the project, 
/// they can be set once by setting this value to true. </param>
/// <param name="UseSpecialFolder">Enable special folder usage. Setting this to false will allow you to type a direct path in mainFolderName/file</param>
/// <param name="environmentFolderType">Specify which special folder will be used to store the directory/file</param>
/// <param name="mainFolderName">Main name of the folder which will contain our file</param>
/// <param name="mainFileName">Main name of the file we are writing to</param>
/// <param name="fileEncoding">Encoding to use for the saved file</param>
/// <remarks>REMARK: If UseSharedSpecialAndDirectory is set to true, you must manually set the static special folder, 
/// save directory and file encoding by calling their static values in this class prior to writing to file.</remarks>
/// <remarks>REMARK: When writing the main folder name, don't include slashes at the end of the folder string. They are included automatically</remarks>
/// <remarks>REMARK: If you leave environmentFolderType null, it will automatically be ignored and you can specify a non-special folder in mainFolderName</remarks>

public BFW(
    bool UseSharedSpecialAndDirectory,
    bool UseSpecialFolder,
    Environment.SpecialFolder? environmentFolderType,
    string? mainFolderName,
    string mainFileName,
    Encoding? fileEncoding
    )
```
## Sample Implementation
-> You can find more examples in the attached Implementation.md file in this project
```
// Use special folder to save a file to a directory
// We will save to C:\Users\MyName\Documents\MyTest\MyFile.txt
BFW fileWriter1 = new BFW(false, true, Environment.SpecialFolder.MyDocuments, "MyTest", "MyFile.txt", Encoding.Unicode);

// Calling the Initialise() function will create the folder and the file and close the file
fileWriter1.Initialise();

// This will write to the file and then close it
fileWriter1.Write(BFW.WriteType.WriteAllText, null,
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
    "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
    "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
    "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

// Read the file into a variable
var myText = fileWriter1.Read(BFW.ReadType.ReadAllText);

// Delete the file, we don't need it anymore
fileWriter1.Operation(BFW.OperationType.Delete);
```

