# TCI_BasicFileWriter
Basic File Writer:  Writing stuff to a file should be easy and simple. 
I got tired of having to setup and write my own boilerplate code to do this each time so here we are. And here you go. 
Use it but don't go stealing my work tho! I'm watching you. This was a pain in the ass to write.

Program flow:

Constructor + comments:
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
