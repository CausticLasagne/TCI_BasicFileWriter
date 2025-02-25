using System.Text;

/* Program:     TCI Basic File Writer
 * Description: A boilerplate wrapper library that makes it easier to write stuff to file. 
 * I made it for myself to use because I got sick of having to setup a new file and directory each time
 * 
 * Twisted Coffee Interactive Basic File Writer © 2025 by Max Fox is licensed under Creative Commons Attribution-NoDerivatives 4.0 International
 * Commercial usage is permitted without modification and with attribution
 * Author:      Max Fox
 * Date:        25/02/2025
 * Version:     0.5
 */

/*
    DISCLAIMER OF WARRANTY AND LICENSE NOTICE

    This software is provided "AS IS," without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, 
    fitness for a particular purpose, and non-infringement. In no event shall the authors, developers, or copyright holders be liable for any claim, damages, 
    or other liability, whether in an action of contract, tort, or otherwise, arising from, out of, or in connection with the software or the use or other dealings in the software.

    By using this software, you acknowledge and agree that you assume all risks associated with its use, including but not limited to potential data loss, 
    security vulnerabilities, and unexpected behavior. The authors do not warrant that the software will be error-free or that defects will be corrected.

    LICENSE NOTICE

    This notice, along with the full license text, must be included with all copies or substantial portions of the software. 
    Removal or modification of this notice is strictly prohibited.
*/

namespace TCI.BasicFileWriter
{
    /// <summary>
    /// Basic File Writer:
    /// Writing stuff to a file should be easy and simple. I got tired of having to setup and write my own boilerplate code to do this each time
    /// so here we are. And here you go. Use it but don't go stealing my work tho! I'm watching you. This was a pain in the ass to write.
    /// </summary>
    public class BFW
    {
        // Sharable

        /// <summary>
        /// If you want to use the static variables, set this to TRUE
        /// </summary>
        bool UseSharedSpecialAndDirectory = false;

        /// <summary>
        /// If you want to use a non-special folder, set this to FALSE
        /// </summary>
        bool UseSpecialFolder = true;

        /// <summary>
        /// Type of encoding used for the file, also takes into account if it is statically shared or not
        /// </summary>
        Encoding EncodingType => UseSharedSpecialAndDirectory ? StaticFileEncoding ?? Encoding.Default : fileEncoding ?? Encoding.Default;

        /// <summary>
        /// Special folder type to save the file/folder under
        /// </summary>
        public string EnvironmentString =>
            UseSharedSpecialAndDirectory ?
            Environment.GetFolderPath(StaticEnvironmentFolderType ?? Environment.SpecialFolder.MyDocuments) :
            Environment.GetFolderPath(EnvironmentFolderType ?? Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Name of the directory which the file will be saved, I.E '\\FolderName'
        /// </summary>
        public string GetMainFolderName => UseSharedSpecialAndDirectory ? StaticMainFolderName :
            mainFolderName;

        /// <summary>
        /// Name of the directory which the file will be saved, I.E '\\FolderName'
        /// </summary>
        public static string StaticMainFolderName = "";

        ///////////////////////////////////////////////////////////////
        // If we are using the shared special folder or directory
        // Set that up here. We can try to use less resources by not needing to re-declare
        // the same special folders/directory paths and instead just use the one
        public static Environment.SpecialFolder? StaticEnvironmentFolderType = null;

        /// <summary>
        /// Set the type of encoding for the file. If you have special characters like smiley faces and whatnot
        /// use Unicode.
        /// </summary>
        public static Encoding? StaticFileEncoding = null;



        // Sharable
        ///////////////////////////////////////////////////////////////
        /// <summary>
        /// Enumeration for the special folder in case we need to find out which folder is being used
        /// </summary>
        public Environment.SpecialFolder? EnvironmentFolderType => environmentFolderType;
        Environment.SpecialFolder? environmentFolderType = null;

        /// <summary>
        /// Set the type of encoding for the file. If you have special characters like smiley faces and whatnot
        /// use Unicode.
        /// </summary>
        Encoding? fileEncoding = null;
        public Encoding? FileEncoding => fileEncoding;

        /// <summary>
        /// Name of the directory which the file will be saved, I.E '\\FolderName'
        /// </summary>
        public string MainFolderName => mainFolderName;
        string mainFolderName = "\\MyDirectory";
        // End Sharable
        ///////////////////////////////////////////////////////////////

        



        /// <summary>
        /// Name of the file that will be saved, I.E '\\DataFile.txt'
        /// </summary>
        public string MainFileName => mainFileName;
        string mainFileName = "\\DataFile.txt";

        /// <summary>
        /// Returns the absolute file path to the saved file which is made up of the special folder,
        /// named directory and named file and extension, I.E 'C:\Users\Documents\MyFolder\MyFile.txt'
        /// </summary>
        public string AbsoluteFilePath => absoluteFilePath;
        string absoluteFilePath = string.Empty;

        /// <summary>
        /// Returns the absolute file path to the saved file which is made up of the special folder,
        /// named directory and named file and extension, I.E 'C:\Users\Documents\MyFolder\MyFile.txt'
        /// </summary>
        public string AbsoluteFolderPath => absoluteFolderPath;
        string absoluteFolderPath = string.Empty;

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
        {
            this.UseSharedSpecialAndDirectory = UseSharedSpecialAndDirectory;
            this.UseSpecialFolder = UseSpecialFolder;
            
            this.environmentFolderType = UseSharedSpecialAndDirectory ? StaticEnvironmentFolderType : environmentFolderType ?? Environment.SpecialFolder.MyDocuments;
            this.mainFolderName = UseSharedSpecialAndDirectory ? StaticMainFolderName : mainFolderName ?? string.Empty;
            this.mainFileName = mainFileName;
            
            this.fileEncoding = UseSharedSpecialAndDirectory ? StaticFileEncoding : fileEncoding ?? Encoding.Default;


            // Create the absolute file path now
            // We will use the environment special folder, but if it is null 
            // Slashes are included automatically

            // Determine if we want to use a special folder.
            var folder = UseSpecialFolder ? EnvironmentString + "\\" : string.Empty;

            absoluteFolderPath = $"{folder}{GetMainFolderName}";

            // Create the absolute file path now
            // We will use the environment special folder, but if it is null 
            // Slashes are included automatically
            absoluteFilePath = $"{absoluteFolderPath}\\{MainFileName}";
        }

        

        /// <summary>
        /// Create the directory and file
        /// </summary>
        public void Initialise()
        {
            // Create the directory if it does not exist
            if (!Directory.Exists(absoluteFolderPath))
            {
                Directory.CreateDirectory(absoluteFolderPath);
            }

            // Create the file if it does not exist
            if (!File.Exists(absoluteFilePath))
            {
                File.Create(absoluteFilePath).Close();
            }
        }

        public bool Operation(OperationType opType)
        {
            switch (opType)
            {
                case OperationType.Delete:
                    {
                        File.Delete(AbsoluteFilePath);
                        return true;
                    }
                case OperationType.Exists:
                    {
                        return File.Exists(AbsoluteFilePath);
                    }
                default:
                    {
                        throw new InvalidOperationException("Could not find case that was not part of operation type");
                    }
            }
        }

        public enum OperationType
        {
            Delete,
            Exists
        }

        public void Write(WriteType writeType, string[]? array = null, string? textBlock = null, byte[]? bytes = null)
        {
            switch (writeType)
            {
                case WriteType.AppendAllBytes:
                    {
                        File.AppendAllBytes(AbsoluteFilePath, bytes);
                        break;
                    }
                case WriteType.AppendAllLines:
                    {
                        File.AppendAllLines(AbsoluteFilePath, array);
                        break;
                    }
                case WriteType.AppendAllText:
                    {
                        File.AppendAllText(AbsoluteFilePath, textBlock);
                        break;
                    }
                case WriteType.WriteAllBytes:
                    {
                        File.WriteAllBytes(AbsoluteFilePath, bytes);
                        break;
                    }
                case WriteType.WriteAllLines:
                    {
                        File.WriteAllLines(AbsoluteFilePath, array);
                        break;
                    }
                case WriteType.WriteAllText:
                    {
                        File.WriteAllText(AbsoluteFilePath, textBlock);
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException("Could not find case that was not part of operation type");
                    }
            }
        }

        public object Read(ReadType readType)
        {
            switch (readType)
            {
                case ReadType.ReadAllBytes:
                    {
                        return File.ReadAllBytes(AbsoluteFilePath);
                    }
                case ReadType.ReadAllLines:
                    {
                        return File.ReadAllLines(AbsoluteFilePath);
                    }
                case ReadType.ReadAllText:
                    {
                        return File.ReadAllText(AbsoluteFilePath);
                    }
                default:
                    {
                        throw new InvalidOperationException("Could not find case that was not part of operation type");
                    }
            }
        }

        public enum WriteType
        {
            AppendAllBytes,
            AppendAllLines,
            AppendAllText,
            WriteAllBytes,
            WriteAllLines,
            WriteAllText
        }

        public enum ReadType
        {
            ReadAllBytes,
            ReadAllLines,
            ReadAllText
        }

        public DateTime GetDate(DateType dateType, bool useUTCFormat)
        {
            switch (dateType)
            {
                case DateType.Creation:
                    return useUTCFormat ? File.GetCreationTimeUtc(AbsoluteFilePath) : File.GetCreationTime(AbsoluteFilePath);
                case DateType.LastAccess:
                    return useUTCFormat ? File.GetLastAccessTimeUtc(AbsoluteFilePath) : File.GetLastAccessTime(AbsoluteFilePath);
                case DateType.LastWrite:
                    return useUTCFormat ? File.GetLastWriteTimeUtc(AbsoluteFilePath) : File.GetLastWriteTime(AbsoluteFilePath);
                default:
                    throw new InvalidOperationException("Could not find case that was not part of date type");
            }
        }

        public FileAttributes GetAttributes()
        {
            return File.GetAttributes(AbsoluteFilePath);
        }

        public UnixFileMode GetUnix()
        {
            return File.GetUnixFileMode(AbsoluteFilePath);
        }

        public void SetDate(DateType dateType, DateTime date, bool useUTCFormat)
        {
            switch (dateType)
            {
                case DateType.Creation:
                    if (useUTCFormat) File.SetCreationTimeUtc(AbsoluteFilePath, date); else File.SetCreationTime(AbsoluteFilePath, date);
                    break;
                case DateType.LastAccess:
                    if (useUTCFormat) File.SetLastAccessTimeUtc(AbsoluteFilePath, date); else File.SetLastAccessTime(AbsoluteFilePath, date);
                    break;
                case DateType.LastWrite:
                    if (useUTCFormat) File.SetCreationTimeUtc(AbsoluteFilePath, date); else File.SetCreationTimeUtc(AbsoluteFilePath, date);
                    break;
                default:
                    throw new InvalidOperationException("Could not find case that was not part of date type");
            }
        }

        public void SetAttributes(FileAttributes attributes)
        {
            File.SetAttributes(AbsoluteFilePath, attributes);
        }

        public void SetUnix(UnixFileMode unix)
        {
            File.SetUnixFileMode(AbsoluteFilePath, unix);
        }

        public enum DateType
        {
            Creation,
            LastAccess,
            LastWrite
        }
    }
}
