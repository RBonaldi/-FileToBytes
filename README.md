<p align="center">
    <a>
        <img alt="logo" src="Assets/logo.png">
    </a>
</p>
<br>

Convert file into byte array.<br>
Convert byte array into file.<br>
Get information file.

# Convert

```cs
using FileLibrary;

byte[] filebyte = FileByte.ConvertFilePathToByte(@"C:\files\bytes.png");  // byte[]
FileByte.SaveByteInPath(@"C:\files", "test.png", byte[]);                 // True
byte[] filebyte = FileByte.ConvertFormFileToBytes(IFormFile)			  // byte[]
```

# GET

```cs

using FileLibrary;

var type = FileByte.GetType(@"C:\files\bytes.png");			    // png
var name = FileByte.GetName(@"C:\files\bytes.png");  			// bytes
var nameType = FileByte.GetNameAndType(@"C:\files\bytes.png");	// bytes.png

```
